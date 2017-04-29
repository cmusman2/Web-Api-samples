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
  otherwise({
    redirectTo: '/list'
  });
}]);