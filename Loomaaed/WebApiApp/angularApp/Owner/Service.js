/// <reference path="../../angular/angular.js" />
/// <reference path="../app.js" />
app.service("ownerService", function($http) {
    console.log("ownerService");
    this.getAll = function() {
        console.log("ownerService - getAll");
        return $http.get("/api/owner/get");
    };
    this.getOne = function(id) {
        console.log("ownerService - getOne ", id);
        return $http.get("/api/owner/get?ownerId=" + id);
    };
    this.create = function(values) {
        console.log("ownerService - create ", values);
        return $http.post("/api/owner/post", values)
            .success(function(data) {
                alert("ok");
                console.log(data);
            });
    };
    this.update = function(id, values) {
        console.log("ownerService - update", values);
        return $http.put("/api/owner/put" + id, values) // $scope.Pet
            .success(function(data) {
                alert("ok");
                console.log(data);
            });
    };
    this.deletePhysically = function(id) {
        console.log("ownerService - delete physically", id);
        return $http.delete("/api/owner/delete" + id)
            .success(function(data) {
                alert("ok");
                console.log(data);
            });
    };
    this.deleteLogically = function(id) {
        console.log("ownerService - delete logically", id);
        return $http.delete("/api/owner/deleteLogically" + id)
            .success(function(data) {
                alert("ok");
                console.log(data);
            });
    };
    this.putLogically = function(id) {
        console.log("ownerService - update", id);
        return $http.put("/api/owner/putLogically?id=" + id)
            .success(function(data) {
                alert("ok");
                console.log(data);
            });
    };
    this.GetEmptyDto = function () {
        console.log("ownerService - GetEmptyDto");
        return $http.get("/api/owner/getEmptyDto")
            .success(function(data) {
                alert("ok");
                console.log(data);
            });
    };
});