// script.js

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
            templateUrl: 'Views/hotels.html',
            controller: 'xhotelsController'
        })
        // route for the contact page
        .when('/contact', {
            templateUrl: 'Views/contact.html',
            controller: 'contactController'
        })
    .when('/hotels2', {
        templateUrl: 'Views/hotelDetails.html',
        controller: 'hotels2Controller'
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
    $scope.data = [1, 2, 3, 4];
});


scotchApp.controller("hotels2Controller", function ($scope, $http) {
    var url = "data.txt"; alert('hello');
    url = "http://localhost:50795";
    $scope.search = function (city) {
        $http({
            method: "GET",
            url: url+"/hotels/" + city,
            params: { page: 1, limit: 100, sort: 'name', direction: 'desc' }
            , headers: { 'Accept': 'application/json; charset=utf-8' }
            //headers : {'Accept' : 'application/json', 'Authorization': 'Basic QWxhZGRpbjpvcGVuIHNlc2FtZQ=='}
        }).then(function (response) {
            var data = response.data,
                status = response.status,
                header = response.header,
                config = response.config;
            $scope.hotels = response.data;
            // success handler
        }, function (response) {
            var data = response.data,
                status = response.status,
                header = response.header,
                config = response.config;
            // error handler
        }

    );
    }

    $scope.hotelDetails = function (hotelId) {

        $http({
            method: "GET",
            url: url+"/hoteldetails/" + hotelId,
            params: { page: 1, limit: 100, sort: 'name', direction: 'desc' }
            , headers: { 'Accept': 'application/json; charset=utf-8' }
            //headers : {'Accept' : 'application/json', 'Authorization': 'Basic QWxhZGRpbjpvcGVuIHNlc2FtZQ=='}
        }).then(function (response) {
            var data = response.data,
                status = response.status,
                header = response.header,
                config = response.config;
            $scope.hotelDetailsData = response.data;
            // success handler
        }, function (response) {
            var data = response.data,
                status = response.status,
                header = response.header,
                config = response.config;
            // error handler
        }

    );
    }
});


