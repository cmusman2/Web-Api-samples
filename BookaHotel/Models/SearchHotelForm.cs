using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookaHotel.Models
{
    public class SearchHotelForm
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Destination")]
        [StringLength(100, ErrorMessage = "Please enter destination or hotel name")]
        public string CityAJaxH { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Check in date")]
        [StringLength(100, ErrorMessage = "Please enter the check-in date")]
        public DateTime Checkin { get; set; }

        [Required]
       // [Range(1,12 ,ErrorMessage ="1 to 12")]
        [Display(Name = "Nights to stay")]
        [StringLength(100, ErrorMessage = "Please enter the number of nights to stay")]
        public int nights { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Guests staying")]
        [StringLength(100, ErrorMessage = "Please enter the number of guest")]
        public int guests { get; set; } 

    }
}