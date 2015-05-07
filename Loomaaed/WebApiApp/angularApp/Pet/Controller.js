/// <reference path="../../angular/angular.js" />
/// <reference path="../app.js" />
app
    .controller("petListCtrl", function($scope, $log, petService) {
        $scope.$routeParams = $routeParams;

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
    .controller("petDetailCtrl", function($scope, $routeParams, $log, petService) {
        $scope.$routeParams = $routeParams;
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

                    $scope.submitData = function () {
                        petService.createNew($("form#petForm").serialize());
                    };

                    $scope.$watch(attrs['Pet'], function() {
                        alert('muutus');
                    });
                },
                function(errorPl) {
                    $log.error("failure loading Pet", errorPl);
                    console.log($log.error.get);
                    $scope.errors = "Error loading Pet " + $routeParams.id + " - " + errorPl.statusText;
                });

    });