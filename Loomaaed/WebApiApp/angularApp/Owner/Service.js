/// <reference path="../../angular/angular.js" />
/// <reference path="../app.js" />
app.service("ownerService", function($http) {
    console.log("ownerService");
    this.getAll = function() {
        console.log("ownerService - getAll");
        return $http.get("/api/owner");
    };
    this.getOne = function(id) {
        console.log("ownerService - getOne ", id);
        return $http.get("/api/owner/" + id);
    };
    this.create = function(values) {
        console.log("ownerService - create ", values);
        $http.post("/api/owner/", values)
            .success(function(data) {
                alert("ok");
                console.log(data);
            });
    };
    this.update = function(id, values) {
        console.log("ownerService - update", values);
        $http.put("/api/owner/" + id, values) // $scope.Pet
            .success(function(data) {
                alert("ok");
                console.log(data);
            });
    };
    this.deletePhysically = function(id) {
        console.log("ownerService - delete physically", id);
        $http.delete("/api/owner/" + id)
            .success(function(data) {
                alert("ok");
                console.log(data);
            });
    };
    this.deleteLogically = function(id) {
        console.log("ownerService - delete logically", id);
        $http.delete("/api/owner/deleteLogically" + id)
            .success(function(data) {
                alert("ok");
                console.log(data);
            });
    };
    this.putLogically = function(id) {
        console.log("ownerService - update", id);
        $http.put("/api/owner/putLogically?id=" + id)
            .success(function(data) {
                alert("ok");
                console.log(data);
            });
    };
    this.GetEmptyDto = function (id) {
        console.log("ownerService - GetEmptyDto", values);
        $http.get("/api/owner/getEmptyDto")
            .success(function(data) {
                alert("ok");
                console.log(data);
            });
    };
});