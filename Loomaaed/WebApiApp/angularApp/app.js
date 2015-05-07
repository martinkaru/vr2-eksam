/// <reference path="../../angular/angular.js" />

var app;
(function() {
    app = angular.module("martinModule", ["ngRoute"]);
    console.log("martinModule");
})();

app.config(function($routeProvider, $locationProvider) {

    // User routes
    $routeProvider
        .when("/users", {
            templateUrl: "/angularApp/user/views/list.html",
            controller: "userListCtrl"
        })
        .when("/user/:id", {
            templateUrl: "/angularApp/user/views/detail.html",
            controller: "userDetailCtrl"
        })
        .when("/users/new", {
            templateUrl: "/angularApp/user/views/edit.html",
            controller: "userDetailCtrl"
        })
        .when("/users/edit/:id", {
            templateUrl: "/angularApp/user/views/edit.html",
            controller: "userDetailCtrl"
        });

    // Car routes
    $routeProvider
        .when("/cars", {
            templateUrl: "/angularApp/car/views/list.html",
            controller: "carListCtrl"
        })
        .when("/car/:id", {
            templateUrl: "/angularApp/car/views/detail.html",
            controller: "carDetailCtrl"
        })
        .when("/cars/new", {
            templateUrl: "/angularApp/car/views/edit.html",
            controller: "carDetailCtrl"
        })
        .when("/cars/edit/:id", {
            templateUrl: "/angularApp/car/views/edit.html",
            controller: "carDetailCtrl"
        });

});