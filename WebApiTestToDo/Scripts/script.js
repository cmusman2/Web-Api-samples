﻿// script.js

// create the module and name it scotchApp
// also include ngRoute for all our routing needs
var scotchApp = angular.module('scotchApp', ['ngRoute']);

// configure our routes
scotchApp.config(function ($routeProvider) {
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'Views/home.html',
            controller: 'mainController'
        })

        // route for the about page
        .when('/about', {
            templateUrl: 'Views/about.html',
            controller: 'aboutController'
        })
                // route for the about page
        .when('/hotels', {
            templateUrl: 'Views/xhotels.html',
            controller: 'xhotelsController'
        })
        // route for the contact page
        .when('/contact', {
            templateUrl: 'Views/contact.html',
            controller: 'contactController'
        });


});

// create the controller and inject Angular's $scope
scotchApp.controller('mainController', function ($scope) {
    // create a message to display in our view
    $scope.message = 'Everyone come and see how good I look!';
});

scotchApp.controller('aboutController', function ($scope) {
    $scope.message = 'Look! I am an about page.';
});

scotchApp.controller('contactController', function ($scope) {
    $scope.message = 'Contact us! JK. This is just a demo.';
});

scotchApp.controller('xhotelsController', function ($scope) { 
    $scope.message = 'Hotel us! JK. This is just a demo.';
});