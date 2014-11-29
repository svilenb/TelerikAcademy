'use strict';

app.factory('ticTacToeData', function ($http, $q) {
    var url = 'http://localhost:33257/api';

    var createGame = function createGame(header) {
        var deferred = $q.defer();
        header["Content-Type"] = "application/json";

        $http({
            method: 'POST',
            url: url + '/Games/Create',
            headers: header
        })
        .success(function (data) {
            deferred.resolve(data);
        })
        .error(function (data) {
            deferred.reject(data);
        });

        return deferred.promise;
    };

    var getAvailableGames = function (header, page) {
        var deferred = $q.defer();
        header["Content-Type"] = "application/json";

        $http({
            method: 'GET',
            url: url + '/Games/AllAvailable?page=' + page,
            headers: header
        })
       .success(function (data) {
           deferred.resolve(data);
       })
       .error(function (data) {
           deferred.reject(data);
       });

        return deferred.promise;
    };

    var getMyGames = function (header, page) {
        var deferred = $q.defer();
        header["Content-Type"] = "application/json";

        $http({
            method: 'GET',
            url: url + '/Games/MyGames?page=' + page,
            headers: header
        })
       .success(function (data) {
           deferred.resolve(data);
       })
       .error(function (data) {
           deferred.reject(data);
       });

        return deferred.promise;
    };

    var getLeaderboard = function (header) {
        var deferred = $q.defer();

        $http({
            method: 'GET',
            url: url + '/Leaderboards/TopTen',
            headers: {
                "Authorization": header["Authorization"],
                "Content-Type": 'application/json',
            },
        })
       .success(function (data) {
           deferred.resolve(data);
       })
       .error(function (data) {
           deferred.reject(data);
       });

        return deferred.promise;
    };

    var joinGame = function (header, gameId) {
        var deferred = $q.defer();

        $http({
            method: 'POST',
            url: url + '/Games/Joinbyid',
            headers: {
                "Authorization": header["Authorization"],
                "Content-Type": 'application/json',
            },
            data: {
                "GameId": gameId
            }
        })
        .success(function (data) {
            deferred.resolve(data);
        })
        .error(function (data) {
            deferred.reject(data);
        });

        return deferred.promise;
    };

    var getGameStatus = function (header, gameId) {
        var deferred = $q.defer();

        $http({
            method: 'GET',
            url: url + '/Games/Status?gameid=' + gameId,
            headers: {
                "Authorization": header["Authorization"],
            }
        })
        .success(function (data) {
            deferred.resolve(data);
        })
        .error(function (data) {
            deferred.reject(data);
        });

        return deferred.promise;
    }

    var joinRandomGame = function (header) {
        var deferred = $q.defer();

        $http({
            method: 'POST',
            url: url + '/Games/Join',
            headers: {
                "Authorization": header["Authorization"],
                "Content-Type": 'application/json',
            }
        })
        .success(function (data) {
            deferred.resolve(data);
        })
        .error(function (data) {
            deferred.reject(data);
        });

        return deferred.promise;
    };

    var playGame = function (header, game) {
        var deferred = $q.defer();

        $http({
            method: 'POST',
            url: url + '/Games/Play',
            headers: {
                "Authorization": header["Authorization"],
                "Content-Type": 'application/json',
            },
            data: game
        })
        .success(function (data) {
            deferred.resolve(data);
        })
        .error(function (data) {
            deferred.reject(data);
        });

        return deferred.promise;
    };

    return {
        createGame: createGame,
        getAvailableGames: getAvailableGames,
        joinGame: joinGame,
        joinRandomGame: joinRandomGame,
        playGame: playGame,
        getLeaderboard: getLeaderboard,
        getGameStatus: getGameStatus,
        getMyGames: getMyGames
    }
});