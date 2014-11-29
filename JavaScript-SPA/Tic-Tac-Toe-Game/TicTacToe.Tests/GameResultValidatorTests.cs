namespace TicTacToe.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TicTacToe.GameLogic;

    [TestClass]
    public class GameResultValidatorTests
    {
        [TestMethod]
        public void GetResult_WhenGameNotFinished_ShouldReturnNotFinished()
        {
            string board = "--XO-----";

            var validator = new GameResultValidator();
            var result = validator.GetResult(board);
            Assert.AreEqual(GameResult.NotFinished, result);
        }

        [TestMethod]
        public void GetResult_WhenGameWonByXOnHorizonals_ShouldReturnwonByX()
        {
            string board = "OO-XXX---";

            var validator = new GameResultValidator();
            var result = validator.GetResult(board);
            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void GetResult_WhenGameWonByOOnHorizonals_ShouldReturnwonByO()
        {
            string board = "X-XX--OOO";

            var validator = new GameResultValidator();
            var result = validator.GetResult(board);
            Assert.AreEqual(GameResult.WonByO, result);
        }

        [TestMethod]
        public void GetResult_WhenGameWonByXOnVerticals_ShouldReturnwonByX()
        {
            string board = "X-OX--X-O";

            var validator = new GameResultValidator();
            var result = validator.GetResult(board);
            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void GetResult_WhenGameWonByOOnVerticals_ShouldReturnwonByO()
        {
            string board = "X-OX-O-XO";

            var validator = new GameResultValidator();
            var result = validator.GetResult(board);
            Assert.AreEqual(GameResult.WonByO, result);
        }


        [TestMethod]
        public void GetResult_WhenGameWonByXOnFirstDiagonal_ShouldReturnwonByX()
        {
            string board = "X-O-XO-OX";

            var validator = new GameResultValidator();
            var result = validator.GetResult(board);
            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void GetResult_WhenGameWonByOOnSecondDiagonal_ShouldReturnwonByO()
        {
            string board = "XXO-OXO--";

            var validator = new GameResultValidator();
            var result = validator.GetResult(board);
            Assert.AreEqual(GameResult.WonByO, result);
        }
    }
}
