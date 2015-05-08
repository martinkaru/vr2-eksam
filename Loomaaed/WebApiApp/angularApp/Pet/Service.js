/// <reference path="../../angular/angular.js" />
/// <reference path="../app.js" />
app.service("petService", function($http) {
    console.log("petService");
    this.getAll = function() {
        console.log("petService - getAll");
        return $http.get("/api/pet/get");
    };
    this.getAllByOwnerID = function(ownerId) {
        console.log("petService - getAllByOwnerId " + ownerId);
        return $http.get("/api/pet/getAllByOwnerID?ownerId=" + ownerId);
    };
    this.getOne = function(id) {
        console.log("petService - getOne ", id);
        return $http.get("/api/pet/get?petId=" + id);
    };
    this.create = function(values) {
        console.log("petService - createNew ", values);
        return $http.post("/api/pet/post", values)
            .success(function(data) {
                console.log(data);
            });
    };
    this.update = function(id, values) {
        console.log("petService - update ", values);
        return $http.put("/api/pet/put?petId=" + id, values)
            .success(function(data) {
                console.log(data);
            });
    };
    this.delete = function(id) {
        console.log("petService - delete", id);
        return $http.delete("/api/pet/delete?petId=" + id)
            .success(function(data) {
                console.log(data);
            });
    };
    this.GetEmptyDto = function () {
        console.log("petService - GetEmptyDto");
        return $http.get("/api/pet/getEmptyDto")
            .success(function (data) {
                console.log(data);
            });
    };
});