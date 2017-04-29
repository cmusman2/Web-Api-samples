var GuitarApp = angular.module('GuitarApp', [
  'ngRoute',
  'GuitarControllers'
]);

GuitarApp.config(['$routeProvider', function($routeProvider) {
  $routeProvider.
  when('/list', { 
    templateUrl: 'partials/list.html',
    controller: 'ListController'
  }).
        when('/details/:guitarID/:hotelName', { 
            templateUrl: 'partials/details.html',
            controller: 'DetailsController'
        }).
  otherwise({
    redirectTo: '/list'
  });
}]);