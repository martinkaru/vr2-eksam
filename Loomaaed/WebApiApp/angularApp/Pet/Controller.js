/// <reference path="../../angular/angular.js" />
/// <reference path="../app.js" />
app
    .controller("petListCtrl", function($scope, $log, petService) {
        petService
            .getAll()
            .then(
                function(pl) {
                    $scope.Pets = pl.data;
                },
                function(errorPl) {
                    $log.error("failure loading Pets", errorPl);
                    $scope.errors = errorPl.message;
                });
    })
    .controller("petDetailCtrl", function($scope, $routeParams, $log, $location, petService, ownerService) {
        $scope.$routeParams = $routeParams;

        // action buttons
        $scope.petUpdate = function() {
            if ($scope.Pet.PetID) {
                petService.update($scope.Pet.PetID, $scope.Pet).success(function (data) {
                    $location.path("/pets");
                });
            } else {
                petService.create($scope.Pet).success(function(data) {
                    $location.path("/pets");
                });
            }
        };
        $scope.petDelete = function(id) {
            petService.petDelete(id).success(function() {
                $location.path("/pets");
            });
        };


        // get active data
        var promise;
        if ($routeParams.id) {
            promise = petService.getOne($routeParams.id);
        } else {
            promise = petService.GetEmptyDto();
        }
        promise
            .then(
                function(pl) {
                    $scope.Pet = pl.data;
                },
                function(errorPl) {
                    $log.error("failure loading Pet", errorPl);
                });

        ownerService.getAll()
            .then(
                function (pl) {
                    $scope.Owners = pl.data;
                },
                function (errorPl) {
                    $log.error("failure loading Owners", errorPl);
                });

    });