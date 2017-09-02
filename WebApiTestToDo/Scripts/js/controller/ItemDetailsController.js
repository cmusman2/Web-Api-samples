'use strict';

App.controller('ItemDetailsController', function(async,  $scope,ItemService) {
          var self = this;
          self.item=async;       
          
		  alert('submit3');
		  $scope.myInterval = 3000;
		  $scope.noWrapSlides = false;
		  $scope.active = 0;
		  var slides = $scope.slides = [];
		  var currIndex = 0;
		 
		  ItemService.liveDataImgaes.images = async.data.hotelImages.Images;
		  /*
		  $scope.addSlide = function(url,caption) {
			    
			    slides.push({
			      image: url,
			      text: caption,
			      id: currIndex++
			    });
			  };

			
			  
			  for (var i = 0; i < async.data.hotelImages.Images.length; i++) 
			  {				  
			    $scope.addSlide(async.data.hotelImages.Images[i].url,async.data.hotelImages.Images[i].caption);
			  }*/
          
});


App.controller('BookingController', function(async,  $scope,ItemService) {
    var self = this;
    self.item=async;       
    self.checkindate=sessionStorage.checkindate;
    $scope.checkindate= sessionStorage.checkindate;
    
  
    /** remove not valid **/
      for(var i=self.item.data.roomrates.length - 1; i>= 0; i--)
      {
    	   
    	  if (self.item.data.roomrates[i].roomtypecode ==sessionStorage.roomtypecode && self.item.data.roomrates[i].ratecode==sessionStorage.ratecode)
    	  {
    		     
    		    //alert('shwoing....'+ i +' ' + self.item.data.roomrates[i].ratedescription);
    		  self.item.data.roomrates = self.item.data.roomrates.splice(i,1);
    	  }  else
    		  {
    		    
    		    //alert('removing....'+ i +' ' + self.item.data.roomrates[i].ratedescription);
    		    //self.item.data.roomrates = self.item.data.roomrates.splice(i,1);
    		  }
      }
      
      
      
      $scope.cdate="apapap";
	  $scope.myInterval = 3000;
	  $scope.noWrapSlides = false;
	  $scope.active = 0;
	  var slides = $scope.slides = [];
	  var currIndex = 0;
	 
	  ItemService.liveDataImgaes.images = async.data.hotelImages.Images;
	  
	  $scope.getDate=function(dt)
	  {
		  $scope.checkindate = dt;
		  return $scope.checkindate;
	  }
	 
    
});



App.controller('UtilityController', function ($scope){
	   
	this.doFormatDate=function(searchTerm){$scope.message=$('#CityAjaxH').val();}
	this.toggleShowHide=function(sh){$scope.checked= !sh;}
     
})
.filter('trusted', ['$sce', function($sce){
    return function(text) {
        return $sce.trustAsHtml(decodeURI(text));
    };
}])
;

