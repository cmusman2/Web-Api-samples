'use strict';

App.factory('ItemService', ['$http', '$q', function($http, $q){
	
	var city;
	var hotelid;
	var checkindate;
	var nights;
	var ratecode;
	var roomtypecode;
	var htlData;
	var roomData;
	
	
	return {
		 
			fetchAllItems: function(category) {
					return $http.get('../LowestRoomRatesHS/item/'+category)
							.then(
									function(response){
										return response.data;
									}, 
									function(errResponse){
										console.error('Error while fetching Items');
										return $q.reject(errResponse);
									}
							); 
			},
			
			fetchAllHotels: function(category) {  
				 
				return $http.get('../LowestRoomRatesHS/item/'+category,{headers :{"content-type" : "application/json"}})
				  .success(function(data){alert('succ'+data);itemListCtrl.items =data; return data.hotels;}) 
				  .success(function(data){}) 
				  ;
		   },
		    
			fetchSpecificHotels: function(category,city) {	
				
				//return $http.get('hotels/'+category)
				
				return $http.get('hotels/' + city)
					.success(function (data) { sessionStorage.htlData = JSON.stringify(data); return data;})
				  .error(function(data){itemListCtrl.items =data; return data;})

				  ;
			
			
			
		   },

			fetchSpecificHotel: function(category,id) { 
				var url='../LowestRoomRatesHS/item/'+category+'/'+id+'/'+sessionStorage.checkindate;				
				url+='/'+sessionStorage.nights;
				
				 
				return $http.get(url,{headers :{"content-type" : "application/json"}})
				  .success(function(data){sessionStorage.roomData = JSON.stringify(data.roomrates);})
				  .error(function(data){itemListCtrl.items =data;})
				  
				  ;
		   },
		   
		   fetchBooking: function(category,id) {
				var url='../LowestRoomRatesHS/item/'+category+'/'+id+'?nights='+sessionStorage.nights;				
				url+='&checkindate='+sessionStorage.checkindate+'&ratecode='+sessionStorage.ratecode;
				url+='&roomtypecode=' + sessionStorage.roomtypecode;
				
				return $http.get(url,{headers :{"content-type" : "application/json"}})
				  .success(
						  function(data)
						  {							  
							  return data;
						  }
					)
				  .error(function(data){/*alert('error:'+data);*/bkController.items =data; return data;})
				  
				  ;
		   },
		   
		   submitExternalBooking: function(category,id) {
				var url='../LowestRoomRatesHS/item/'+category+'/'+id+'?nights='+sessionStorage.nights;				
				url+='&checkindate='+sessionStorage.checkindate+'&ratecode='+sessionStorage.ratecode;
				url+='&roomtypecode=' + sessionStorage.roomtypecode;
				
				return $http.get(url,{headers :{"content-type" : "application/json"}})
				  .success(
						  function(data)
						  {							  
							  return data;
						  }
					)
				  .error(function(data){/*alert('error:'+data);*/bkController.items =data; return data;})
				  
				  ;
		   },		   
		   
		   fetchTemplate: function(category,id) {
				return $http.get('../LowestRoomRatesHS/item/'+category)
				  .success(function(data){itemListCtrl.items =data; return data;})
				  .error(function(data){alert(id+'error:'+data);testController.items =data; return data;})
				  
				  ;
		   },

		   fetchSpecificItem: function(category,id) {  
				return $http.get('../LowestRoomRatesHS/item/'+category+'/'+id)
						.then(
								function(response){
									return response.data;
								}, 
								function(errResponse){
									console.error('Error while fetching specific Item');
									return $q.reject(errResponse);
								}
						);
			},
		   
		   liveDataImgaes:{
			   images:null
			   
		   },
			
			   dataImgaes:{
				   images:[]
				   
			   },
		   
		   searchCriteria:{
			   seacrhCity:city,
			   checkindate:checkindate,
			   nights:nights			   
		   },
		   selectedHotel:{
			   hotelid:hotelid			   
		   },
		   selectedRoom:{
			   rarecode:ratecode,
			   roomtypecode:roomtypecode,
			   nights:nights			   
		   }
		   
		   
		   
		   
	};
	
	 

}]);
