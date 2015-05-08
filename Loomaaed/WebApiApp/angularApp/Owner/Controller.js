/// <reference path="../../angular/angular.js" />
/// <reference path="../app.js" />
app
    .controller("ownerListCtrl", function($scope, $log, ownerService) {
        ownerService
            .getAll()
            .then(
                function(pl) {
                    $scope.Owners = pl.data;
                },
                function(errorPl) {
                    $log.error("failure loading Owners", errorPl);
                    $scope.errors = errorPl.message;
                });
    })
    .controller("ownerDetailCtrl", function($scope, $routeParams, $log, $location, ownerService, petService) {
        $scope.$routeParams = $routeParams;

        // action buttons
        $scope.ownerUpdate = function() {
            console.log("something has changed?", $scope.Owner);
            if ($scope.Owner.OwnerID) {
                ownerService.update($scope.Owner.OwnerID, $scope.Owner).success(function(data) {
                    $location.path("/owners");
                });
            } else {
                ownerService.create($scope.Owner).success(function(data) {
                    $location.path("/owners");
                });
            }
        };

        // deleting buttons
        $scope.ownerDelete = function (id) {
            ownerService.delete(id).success(function (data) {
                $location.path("/owners");
            });
        };
        $scope.ownerDeleteLogically = function (id) {
            ownerService.deleteLogically(id).success(function (pl) {
                $scope.Owner = pl.data;
                $location.path("/owners");
            });
        };
        $scope.ownerPutLogically = function (id) {
            ownerService.putLogically(id).success(function (pl) {
                $scope.Owner = pl.data;
                $location.path("/owners");
            });
        };

        // get active data
        var promise;
        if ($routeParams.id) {
            promise = ownerService.getOne($routeParams.id);
        } else {
            promise = ownerService.GetEmptyDto();
        }
        promise
            .then(
                function(pl) {
                    $scope.Owner = pl.data;
                    $scope.Owner.DateOfBirth = new Date($scope.Owner.DateOfBirth);

                    if ($routeParams.id) {
                        // get pets
                        petService
                            .getAllByOwnerID($scope.Owner.OwnerID)
                            .then(
                                function(pl) {
                                    $scope.Owner.Pets = pl.data;
                                },
                                function(errorPl) {
                                    $log.error("failure loading Owner's pets", errorPl);
                                });
                    }
                },
                function(errorPl) {
                    $log.error("failure loading Owner", errorPl);
                });
    });