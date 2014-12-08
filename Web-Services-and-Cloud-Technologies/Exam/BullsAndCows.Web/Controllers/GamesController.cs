namespace BullsAndCows.Web.Controllers
{
    using BullsAndCows.Data;
    using BullsAndCows.GameLogic;
    using BullsAndCows.Models;
    using BullsAndCows.Web.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using BullsAndCows.Web.Models;

    public class GamesController : BaseApiController
    {
        private const int defaultPageSize = 10;
        private IGameResultValidator resultValidator;
        private IUserIdProvider userIdProvider;
        private static Random random = new Random();

        public GamesController()
            : this(new BullsAndCowsData(), new AspNetUserIdProvider(), new GameResultValidator())
        {
        }

        public GamesController(IBullsAndCowsData data, IUserIdProvider userIdProvider, IGameResultValidator resultValidator)
            : base(data)
        {
            this.resultValidator = resultValidator;
            this.userIdProvider = userIdProvider;
        }

        [HttpGet]
        public IHttpActionResult AllPulbic(int page = 0)
        {
            var currentUserId = this.userIdProvider.GetUserId();

            if (currentUserId == null)
            {
                var gamesPublic = this.data.Games.All()
                    .Where(g => g.GameState == GameState.WaitingForOpponent)
                    .Select(GameViewModel.FromGame)
                    .AsQueryable()
                    .OrderBy(g => g.GameState)
                    .ThenBy(g => g.Name)
                    .ThenBy(g => g.DateCreated)
                    .ThenBy(g => g.Red)
                    .Skip(page * defaultPageSize)
                    .Take(defaultPageSize);

                return Ok(gamesPublic);
            }
            else
            {
                var gamesAuthorized = this.data.Games.All()
               .Where(g => g.GameState == GameState.WaitingForOpponent || g.RedPlayerId == currentUserId || g.BluePlayerId == currentUserId)
               .AsQueryable()
               .Select(GameViewModel.FromGame)
               .OrderBy(g => g.GameState)
               .ThenBy(g => g.Name)
               .ThenBy(g => g.DateCreated)
               .ThenBy(g => g.Red)
               .Skip(page * defaultPageSize)
               .Take(defaultPageSize);

                return Ok(gamesAuthorized);
            }
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var currentUserId = this.userIdProvider.GetUserId();
            var player = this.data.Users.Find(currentUserId);

            var game = this.data.Games.Find(id);
            if (game == null)
            {
                return this.BadRequest("Invalid game id");
            }

            if (game.RedPlayerId != currentUserId && game.BluePlayerId != currentUserId)
            {
                return this.BadRequest("This is not your game!");
            }

            var result = new GameFullViewModel(game, player.Id, player.UserName);
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Create(GameCreateDataModel model)
        {
            var currentUserId = this.userIdProvider.GetUserId();

            var redPlayer = this.data.Users.Find(currentUserId);

            var number = model.Number;
            if (!IsValudNumber(number))
            {
                return BadRequest("Invalid number");
            }

            Game newGame = new Game
            {
                RedPlayerId = currentUserId,
                RedPlayer = redPlayer,
                Name = model.Name,
                RedPlayerNumber = number,
                GameState = BullsAndCows.Models.GameState.WaitingForOpponent,
                DateCreated = DateTime.Now
            };

            this.data.Games.Add(newGame);
            this.data.SaveChanges();

            GameViewModel result = new GameViewModel(newGame);

            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult Join(string id, PlayerRequestDataModel model)
        {
            var currentUserId = this.userIdProvider.GetUserId();
            var bluePlayer = this.data.Users.Find(currentUserId);

            var game = this.data.Games
                .All()
                .Where(g => g.GameState == GameState.WaitingForOpponent && g.RedPlayerId != currentUserId)
                .FirstOrDefault();

            if (game == null)
            {
                return NotFound();
            }

            var number = model.Number;
            if (!IsValudNumber(number))
            {
                return BadRequest("Invalid number");
            }

            game.BluePlayerId = currentUserId;
            game.BluePlayer = bluePlayer;
            game.BluePlayerNumber = number;
            game.GameState = (GameState)random.Next(1, 3);

            var notification = new Notification
            {
                Message = game.BluePlayer.UserName + " joined your game \"" + game.Name + "\"",
                DateCreated = DateTime.Now,
                Type = NotificationType.GameJoined,
                State = NotificationState.Unread,
                GameId = game.Id,
                ApplicationUserId = game.RedPlayer.Id,                
            };

            game.RedPlayer.Notifications.Add(notification);
            this.data.SaveChanges();

            var result = new JoinResponseDataModel(game.Name);

            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Guess(int id, PlayerRequestDataModel request)
        {
            var currentUserId = this.userIdProvider.GetUserId();
            var player = this.data.Users.Find(currentUserId);

            if (request == null || !ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var game = this.data.Games.Find(id);
            if (game == null)
            {
                return this.BadRequest("Invalid game id");
            }

            if (game.RedPlayerId != currentUserId && game.BluePlayerId != currentUserId)
            {
                return this.BadRequest("This is not your game!");
            }

            if (game.GameState != GameState.BlueInTurn && game.GameState != GameState.RedInTurn)
            {
                return this.BadRequest("Invalid game state!");
            }

            if ((game.GameState == GameState.RedInTurn && game.RedPlayerId != currentUserId)
                || (game.GameState == GameState.BlueInTurn && game.BluePlayerId != currentUserId))
            {
                return this.BadRequest("It's not your turn!");
            }

            var number = request.Number;
            if (!IsValudNumber(number))
            {
                return BadRequest("Invalid number");
            }

            var opponentNumber = game.RedPlayerId == currentUserId ? game.BluePlayerNumber : game.RedPlayerNumber;
            var guessResult = this.resultValidator.GetResult(request.Number, opponentNumber);

            if (game.RedPlayerId == currentUserId)
            {
                if (guessResult.BullsCount == 4)
                {
                    game.GameState = GameState.WonByRed;
                    game.BluePlayer.UserRank += 15;
                    game.RedPlayer.UserRank += 100;
                }
                else
                {
                    game.GameState = GameState.BlueInTurn;
                }
            }
            else if (game.BluePlayerId == currentUserId)
            {
                if (guessResult.BullsCount == 4)
                {
                    game.GameState = GameState.WonByBlue;
                    game.BluePlayer.UserRank += 100;
                    game.RedPlayer.UserRank += 15;
                }
                else
                {
                    game.GameState = GameState.RedInTurn;
                }
            }

            var guess = new Guess
            {
                BullsCount = guessResult.BullsCount,
                CowsCount = guessResult.CowsCount,
                DateMade = DateTime.Now,
                GameId = game.Id,
                Game = game,
                Number = number,
                UserId = currentUserId,
                UserName = player.UserName,
            };

            game.Guesses.Add(guess);


            if (game.GameState == GameState.WonByBlue)
            {
                var notificationBlue = new Notification
                {
                    Message = "You beat " + game.RedPlayer.UserName + "in game \"" + game.Name + "\"",
                    Type = NotificationType.GameWon,
                    DateCreated = DateTime.Now,
                    ApplicationUserId = game.BluePlayer.Id,
                    State = NotificationState.Unread,
                    GameId = game.Id
                };

                var notificationRed = new Notification
                {
                    Message = game.BluePlayer.UserName + " beat you in game \"" + game.Name + "\"",
                    Type = NotificationType.GameLost,
                    DateCreated = DateTime.Now,
                    ApplicationUserId = game.RedPlayer.Id,
                    State = NotificationState.Unread,
                    GameId = game.Id
                };

                game.RedPlayer.Notifications.Add(notificationRed);
                game.BluePlayer.Notifications.Add(notificationBlue);
            }
            else if (game.GameState == GameState.WonByRed)
            {
                var notificationBlue = new Notification
                {
                    Message = game.BluePlayer.UserName + " beat you in game \"" + game.Name + "\"",
                    Type = NotificationType.GameLost,
                    DateCreated = DateTime.Now,
                    ApplicationUserId = game.BluePlayer.Id,
                    State = NotificationState.Unread,
                    GameId = game.Id
                };

                var notificationRed = new Notification
                {
                    Message = "You beat " + game.BluePlayer.UserName + "in game \"" + game.Name + "\"",
                    Type = NotificationType.GameWon,
                    DateCreated = DateTime.Now,
                    ApplicationUserId = game.RedPlayer.Id,
                    State = NotificationState.Unread,
                    GameId = game.Id
                };

                game.RedPlayer.Notifications.Add(notificationRed);
                game.BluePlayer.Notifications.Add(notificationBlue);
            }
            else if (game.GameState == GameState.RedInTurn)
            {
                var notification = new Notification
                {
                    Message = "Is your turn in game \"" + game.Name + "\"",
                    Type = NotificationType.YourTurn,
                    DateCreated = DateTime.Now,
                    ApplicationUserId = game.RedPlayer.Id,
                    State = NotificationState.Unread,
                    GameId = game.Id
                };

                game.RedPlayer.Notifications.Add(notification);
            }
            else if (game.GameState == GameState.BlueInTurn)
            {

                var notification = new Notification
                {
                    Message = "Is your turn in game \"" + game.Name + "\"",
                    Type = NotificationType.YourTurn,
                    DateCreated = DateTime.Now,
                    ApplicationUserId = game.BluePlayer.Id,
                    State = NotificationState.Unread,
                    GameId = game.Id
                };

                game.BluePlayer.Notifications.Add(notification);
            }

            this.data.SaveChanges();
            var result = new PlayerGuessResponseDataModel(guess);
            return Ok(result);
        }

        private bool IsValudNumber(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    return false;
                }
            }

            for (int i = 0; i < number.Length; i++)
            {
                if (number.Substring(i + 1).IndexOf(number[i]) != -1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
