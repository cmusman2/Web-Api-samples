'use strict';
App.controller('ItemListController', ['async', function (async, ItemService) {
	
	var self = this; 
          self.items=async;
        
		  self.values = { name: 'misko', gender: 'male' };
          
}]);



App.controller('SubmissionController', function($scope, $localStorage, $sessionStorage,   $window, $location,  $http,  ItemService) {
	 
	  var dt = new Date();
	  dt = dt.setDate(dt.getDate() + 2);
	  $scope.from= dt;
	  $scope.hotelid='';
	  
	  $scope.submitForm = function (isValid){
		 
		  $scope.searchForm.$setSubmitted();
		  if($scope.searchForm.$invalid){
		         return;
		    }
		 
		   
		  	  
		  //var path= '/items/hotels/London/20-10-2017/1';
		  sessionStorage.city = $('#CityAjaxH').val();
		  sessionStorage.checkindate = $('#from').val();
		  sessionStorage.nights = $('#nights').val();
		  
		  if ((sessionStorage.nights!=null) && (sessionStorage.nights.indexOf("number:")>-1))
			{
			  sessionStorage.nights = sessionStorage.nights.substring(7);
			}
		  
		  var path= '/items/hotels/'+ sessionStorage.city +'/'+  sessionStorage.checkindate + '/' + sessionStorage.nights;
		 
		  $location.path(path);	    
	  }
	  
	  $scope.submitForDetails=function ()
	  {
		   
		  $sessionStorage.hotelid = hotelid;
		  
		  var path='/items/hotels/details/'+$sessionStorage.hotelid;
		  $location.path(path);	
	  }
	  
	  $scope.doSubmitForDetails=function ($index)
	  {
		  
	   
		  sessionStorage.hotelid = JSON.parse(sessionStorage.htlData)[$index].hotelid;
	
		  sessionStorage.ratecurrencycode = JSON.parse(sessionStorage.htlData)[$index].ratecurrencycode;
		  
		  var path='/items/hotels/details/'+sessionStorage.hotelid;
		  $location.path(path);	
	  }
	  
	  $scope.doSubmitForBooking=function ($index)
	  {
		  
	  
		  sessionStorage.ratecode = JSON.parse(sessionStorage.roomData)[$index].ratecode;
		  sessionStorage.roomtypecode = JSON.parse(sessionStorage.roomData)[$index].roomtypecode;
	
		  
		  var path='/items/booking/'+sessionStorage.hotelid;
		  $location.path(path);	
	  }
	  
	  
	  $scope.doSubmitForBookingExternal=function ($index)
	  {
		  
		  
		  sessionStorage.ratecode = JSON.parse(sessionStorage.roomData)[$index].ratecode;
		  sessionStorage.roomtypecode = JSON.parse(sessionStorage.roomData)[$index].roomtypecode;
		 
		  
		  var arrivalDate = sessionStorage.checkindate;
		  var departureDate = arrivalDate;
		 
		  if(sessionStorage.checkindate!="")
		  { //30-05-2017
			  
			 
			  
			var sd = sessionStorage.checkindate; 
			var sday= sd.substring(0,2); 
			var smon= sd.substring(3,5);
			var syea= sd.substring(6,10);
			 
			var nights = sessionStorage.nights;
			if (nights.indexOf("number:")>-1)
			{
				nights = nights.substring(7);
			}
			
			var numNights=0;
			numNights= nights;
			if (numNights=="") numNights=1;
			
			//number:1
			
			
			arrivalDate = smon+"/"+sday+"/"+syea;
			
			var dt =new Date(arrivalDate);
		 
			
		 
			 
			
			dt.setDate(dt.getDate() + parseInt(numNights));
			
		 
            departureDate = (dt.getMonth() + 1) +"/" + dt.getDate() + "/" + dt.getFullYear();

            arrivalDate = encodeURIComponent(arrivalDate);
            departureDate = encodeURIComponent(departureDate);           
			 
		  }
		  
		  
		  var form = document.createElement("form");
		  //form.setAttribute("target", "_blank");
		  
		  form.setAttribute("target", "formresult");
		  
		  form.setAttribute("method", "post");
		  form.setAttribute("action", "https://secure.lowestroomrates.com/Booking.php");

		  var hiddenField = document.createElement("input");              
		  hiddenField.setAttribute("name", "hotelId");
		  hiddenField.setAttribute("value", sessionStorage.hotelid);
		  form.appendChild(hiddenField);
		  
		  hiddenField = document.createElement("input");              
		  hiddenField.setAttribute("name", "arrivalDate");
		  hiddenField.setAttribute("value", arrivalDate);
		  form.appendChild(hiddenField);		  
		  
		  hiddenField = document.createElement("input");              
		  hiddenField.setAttribute("name", "departureDate");
		  hiddenField.setAttribute("value", departureDate);
		  form.appendChild(hiddenField);		  

		  hiddenField = document.createElement("input");              
		  hiddenField.setAttribute("name", "roomTypeCode");
		  hiddenField.setAttribute("value", sessionStorage.roomtypecode);
		  form.appendChild(hiddenField);		  

		  hiddenField = document.createElement("input");              
		  hiddenField.setAttribute("name", "rateCode");
		  hiddenField.setAttribute("value", sessionStorage.ratecode);
		  form.appendChild(hiddenField);		  

		  hiddenField = document.createElement("input");              
		  hiddenField.setAttribute("name", "currency");
		  hiddenField.setAttribute("value", sessionStorage.ratecurrencycode);
		  form.appendChild(hiddenField);		  
		  
		  hiddenField = document.createElement("input");              
		  hiddenField.setAttribute("name", "roomsCount");
		  hiddenField.setAttribute("value", "1");
		  form.appendChild(hiddenField);		  
		  
		  hiddenField = document.createElement("input");              
		  hiddenField.setAttribute("name", "roomsdata");
		  hiddenField.setAttribute("value", "rooms[0].adultsCount=1|rooms[0].childrenCount=0");
		  form.appendChild(hiddenField);		  
		 
		  document.body.appendChild(form);
		  
		  // creating the 'formresult' window with custom features prior to submitting the form
		  //window.open('bookResult.html', 'formresult', 'scrollbars=no,menubar=no,height=600,width=800,resizable=yes,toolbar=no,status=no');

		  form.submit();  
		  document.body.removeChild(form);
		  
		  return;
		  /*
		  $http({
		       url:'https://secure.lowestroomrates.com/Booking.php',
		       method:"POST",
		       headers: {
		              //    'Authorization': 'Basic dGVzdDp0ZXN0',
		                  'Content-Type': 'application/x-www-form-urlencoded'
		       },
		       data:$.param({
		              'hotelId': sessionStorage.hotelid,
		              'arrivalDate':arrivalDate,
		              'departureDate':departureDate,
		              'roomTypeCode':sessionStorage.roomtypecode,
		              'rateCode':sessionStorage.ratecode,
		              'currency':'',
		              'roomsCount':'1',
		              'roomsdata':'rooms[0].adultsCount=1|rooms[0].childrenCount=0',
		              'roomQ':'',
		              'room1':''
		    	   
		            })
		  }).success(function (data) {
              Console.write(data);
          });*/
		  
		  return;
		  /*var path='/items/booking/ext/'+sessionStorage.hotelid;
		  $location.path(path);	
		  */
	  }
	  
	  
	  $scope.showPopover = function(v,c) {
		  $scope.popoverIsVisible = true;
		  $scope.popContent=v;
		  $scope.caption=c;
		};

		$scope.hidePopover = function () {
		  $scope.popoverIsVisible = false;
		};
	});

App.controller('UtilityController', function ($scope){
   
	this.doSearchTerm=function(v){$scope.searchTerm=$('#CityAjaxH').val();}
	this.toggleShowHide=function(sh){$scope.checked= !sh;}
     
})
.filter('trusted', ['$sce', function($sce){
    return function(text) {
        return $sce.trustAsHtml(text);
    };
}])
;



	App.controller('sliderCtrl', function ($scope, $timeout){	
    $scope.timeInMs = 0;
    
    var countUp = function() {
        $scope.timeInMs+= 500;
        $timeout(countUp, 500);
    }
    
    $timeout(countUp, 500);
});
	
	App.controller('CarouselCtrl', function ($scope,ItemService) {
		  $scope.myInterval = 3000;
		  $scope.noWrapSlides = false;
		  $scope.active = 0;
		  var slides = $scope.slides = [];
		  var currIndex = 0;

		  $scope.addSlide = function(img) {
		    var newWidth = 600 + slides.length + 1;
		    slides.push({
		      image: img.url,
		      text: img.caption,
		      id: currIndex++
		    });
		  };

		  $scope.message="hasimg";

		  for (var i = 0; i < ItemService.liveDataImgaes.images.length; i++) {
		    $scope.addSlide( ItemService.liveDataImgaes.images[i]);
		  }
		  
		
		  $scope.dataSlides=function(ds)
		  {
			  $scope.slides = ds;
		  }

		  $scope.hasImgaes=function(setIndex)
		  {$scope.message="hasimg3";
			  for(var i=0;i< $scope.slides.length; i++)
				  if ($scope.slides[i].id == setIndex){
					  break;
					  }
			   
			  
			 // if (ItemService.liveDataImgaes.images == null) {alert('no')} else {alert('yes' + ItemService.liveDataImgaes.images.length);}
		  }
		  
		  $scope.findId=function(slide)
		  {			 
			  return slide.id;
		  }
		 
		  
		  $scope.setImages=function(img)
		  {			 
			  $scope.cimg = img;
			 
		  }
		  
		});	
	
	
	
	

