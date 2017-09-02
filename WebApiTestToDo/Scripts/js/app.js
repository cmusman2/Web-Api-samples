'use strict';

var App = angular.module('myApp',['ngRoute', 'ui.bootstrap','ngStorage'/*,'ngAnimate'*/]);
/*
$scope.myInterval = 3000;
$scope.noWrapSlides = false;
$scope.active = 0;*/

App.config(['$routeProvider', function($routeProvider) {
	$routeProvider
		.when('/items/hotels', {
			templateUrl: 'items/hotels',
			controller : "ItemListController as itemListCtrl",
			resolve: {
                async: ['ItemService', function(ItemService) {
                    return ItemService.fetchAllHotels('hotels');
               	}]
            }
		})
		.when('/items/hotels/:id', {
			templateUrl: 'items/hotelDetails.html',
			controller: "ItemDetailsController as itemDetailsCtrl",
			resolve: {
                async: ['ItemService','$route', function(ItemService , $route)  {                	
                    return ItemService.fetchSpecificHotels('hotels',$route.current.params.id);
               	}]
            }
		})
		.when('/items/hotels/:id/:sdate/:nights', {
			templateUrl: 'Views/hotels.html',
			controller : "ItemListController as itemListCtrl",
			resolve: {				
                async: ['ItemService','$route', function(ItemService , $route)  {
                	//$route.current.params.id = $('#CityAjaxH').val();
                	//$route.current.params.sdate = $('#from').val();                	                	               	                	
					return ItemService.fetchSpecificHotels($route.current.params.id + "/" + $route.current.params.sdate + "/" + $route.current.params.nights, $route.current.params.id);
               	}]
            }
		})

		
		.when('/items/hotels/details/:id', {
			templateUrl: 'items/hotelDetails.html',
			controller: "ItemDetailsController as itemDetailsCtrl",
			resolve: {
                async: ['ItemService','$route', function(ItemService , $route) {
                    return ItemService.fetchSpecificHotel('hotels/details',$route.current.params.id);
               	}]
            }
		})
		
		.when('/items/booking/:id', {
			templateUrl: 'items/booking',
			controller : "BookingController as bkController",
			resolve: { 
                async: ['ItemService','$route', function(ItemService , $route) {
                    return ItemService.fetchBooking('booking',$route.current.params.id);
               	}]
            }
		})
		
		.when('/items/booking/ext/:id', {
			templateUrl: 'items/booking',
			controller : "BookingController as bkController",
			resolve: { 
                async: ['ItemService','$route', function(ItemService , $route) {
                    return ItemService.submitExternalBooking('booking',$route.current.params.id);
               	}]
            }
		})		
		
		.when('/test', {
			templateUrl: 'items/index2',
			controller : "testController as testCtrl",
			resolve:{
				async: ['ItemService','$route', function(ItemService , $route) {
                    return ItemService.fetchTemplate('index2',$route.current.params.id);
               	}]
				
			}

            
		})
		.otherwise({redirectTo:'/items/'});		
}]);

App.filter('trusted', ['$sce', function($sce) {
    var div = document.createElement('div');
    return function(text) {
        div.innerHTML = text;
        return $sce.trustAsHtml(div.textContent);
    };
}]);

App.filter('range', function() {
	  return function(input, start, end) {    
	    start = parseInt(start);
	    end = parseInt(end);
	    var direction = (start <= end) ? 1 : -1;
	    while (start != end) {
	        input.push(start);
	        start += direction;
	    }
	    return input;
	  };
	});

App.filter("asDate", function () {
    return function (input) {
        return new Date(input);
    }
});


