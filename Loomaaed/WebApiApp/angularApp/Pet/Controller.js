/// <reference path="../../angular/angular.js" />
/// <reference path="../app.js" />
app
    .controller("carListCtrl", function ($scope, $log, petService) {
        $scope.$routeParams = $routeParams;

        petService
            .getAll()
            .then(
            function(pl) {
                $scope.Users = pl.data;
            },
            function(errorPl) {
                $log.error("failure loading Cars", errorPl);
                $scope.errors = errorPl.message;
            });
    })
    .controller("carDetailCtrl", function ($scope, $routeParams, $log, petService) {
        $scope.$routeParams = $routeParams;

        if ($routeParams.id) {
            petService
                .getOne($routeParams.id)
                .then(
                    function(pl) {
                        $scope.Car = pl.data;
                    },
                    function(errorPl) {
                        $log.error("failure loading Car", errorPl);
                        console.log($log.error.get);
                        $scope.errors = "Error loading Car " + $routeParams.id + " - " + errorPl.statusText;
                    });
        } else {
            $scope.Car = null;
        }

        $scope.submitData = function() {
            //            $scope.buttonDisabled = true;
            petService.createNew($('form#carForm').serialize());
        };
    });