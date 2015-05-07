/// <reference path="../../angular/angular.js" />
/// <reference path="../app.js" />
app.service("petService", function($http) {
    console.log("petService");
    this.getAll = function() {
        console.log("petService - getAll");
        return $http.get("/api/pet");
    };
    this.getOne = function(id) {
        console.log("petService - getOne ", id);
        return $http.get("/api/pet/" + id);
    };
    this.create = function(values) {
        console.log("petService - createNew ", values);
        $http.post("/api/pet/", values)
            .success(function(data) {
                alert("ok");
                console.log(data);
            });
    };
    this.update = function(id, values) {
        console.log("petService - update ", values);
        $http.put("/api/pet/" + id, values) // $scope.Pet
            .success(function(data) {
                alert("ok");
                console.log(data);
            });
    };
    this.delete = function(id) {
        console.log("petService - delete", id);
        $http.delete("/api/pet/" + id)
            .success(function(data) {
                alert("ok");
                console.log(data);
            });
    };
    this.GetEmptyDto = function (id) {
        console.log("petService - GetEmptyDto", values);
        $http.get("/api/pet/getEmptyDto")
            .success(function (data) {
                alert("ok");
                console.log(data);
            });
    };
});