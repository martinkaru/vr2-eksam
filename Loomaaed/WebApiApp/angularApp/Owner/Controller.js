/// <reference path="../../angular/angular.js" />
/// <reference path="../app.js" />

app.controller("userListCtrl", function($scope, ownerService) {
    loadRecords();

    function loadRecords() {
        console.log("userListCtrl - loadRecords");

        var promiseGet = ownerService.getAll();
        promiseGet.then(
            function(pl) {
                console.log("userListCtrl - promiseGet - ok");

                $scope.Users = pl.data;
            },
            function(errorPl) {
                console.log("userListCtrl - promiseGet - failure");

                $log.error("failure loading Users", errorPl);
            });
    }
});

app.controller("userDetailCtrl", function($scope, $routeParams, ownerService) {
    ownerService
        .getOne($routeParams.id)
        .then(
            function(pl) {
                $scope.User = pl.data;
            },
            function(errorPl) {
                $log.error("failure loading Car", errorPl);
            });
});