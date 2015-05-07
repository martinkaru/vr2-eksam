/// <reference path="../../angular/angular.js" />

var app;
(function() {
    app = angular.module("animalModule", ["ngRoute"]);
    console.log("martinModule");
})();

app.config(function($routeProvider, $locationProvider) {

    // Owner routes
    $routeProvider
        .when("/owners", {
            templateUrl: "/angularApp/owner/views/list.html",
            controller: "userListCtrl"
        })
        .when("/owners/:id", {
            templateUrl: "/angularApp/owner/views/detail.html",
            controller: "ownerDetailCtrl"
        })
        .when("/owners/edit/{id:int}", {
            templateUrl: "/angularApp/owner/views/edit.html",
            controller: "ownerDetailCtrl"
        })
        .when("/owners/new", {
            templateUrl: "/angularApp/owner/views/edit.html",
            controller: "ownerDetailCtrl"
        });

    // Pet routes
    $routeProvider
        .when("/pets", {
            templateUrl: "/angularApp/pet/views/list.html",
            controller: "petListCtrl"
        })
        .when("/pets/{id:int}", {
            templateUrl: "/angularApp/pet/views/detail.html",
            controller: "petDetailCtrl"
        })
        .when("/pets/edit/:id", {
            templateUrl: "/angularApp/pet/views/edit.html",
            controller: "petDetailCtrl"
        })
        .when("/pets/new", {
            templateUrl: "/angularApp/pet/views/edit.html",
            controller: "petDetailCtrl"
        });

});