/// <reference path="../../angular/angular.js" />
/// <reference path="../app.js" />
app.service("ownerService", function($http) {
    console.log("ownerService");
    this.getAll = function() {
        console.log("ownerService - getAll");
        return $http.get("/api/owner/get");
    };
    this.getAllActive = function() {
        console.log("ownerService - getAllActive");
        return $http.get("/api/owner/getAllActive");
    };
    this.getOne = function(id) {
        console.log("ownerService - getOne ", id);
        return $http.get("/api/owner/get?ownerId=" + id);
    };
    this.create = function(values) {
        console.log("ownerService - create ", values);
        return $http.post("/api/owner/post", values)
            .success(function(data) {
                console.log(data);
            });
    };
    this.update = function(id, values) {
        console.log("ownerService - update", values);
        return $http.put("/api/owner/put?ownerId=" + id, values)
            .success(function(data) {
                console.log(data);
            });
    };
    this.delete = function(id) {
        console.log("ownerService - delete physically", id);
        return $http.delete("/api/owner/deleteOwner?ownerId=" + id)
            .success(function(data) {
                console.log(data);
            });
    };
    this.deleteLogically = function(id) {
        console.log("ownerService - delete logically", id);
        return $http.delete("/api/owner/deleteLogically?ownerId=" + id)
            .success(function(data) {
                console.log(data);
            });
    };
    this.putLogically = function(id) {
        console.log("ownerService - update", id);
        return $http.put("/api/owner/putLogically?ownerId=" + id)
            .success(function(data) {
                console.log(data);
            });
    };
    this.GetEmptyDto = function () {
        console.log("ownerService - GetEmptyDto");
        return $http.get("/api/owner/getEmptyDto")
            .success(function(data) {
                console.log(data);
            });
    };
});