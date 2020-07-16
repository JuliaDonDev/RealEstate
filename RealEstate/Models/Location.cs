using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models
{
    public class Location
    {
        [RegularExpression(@"^[A-Z]+[a-zA-Z ]*$", ErrorMessage = "You used forbidden symbols. Please, reenter the city.")]
        [StringLength(20, ErrorMessage = "Name of the city is too long")]
        [Required(ErrorMessage = "Please, enter the city")]
        public string City { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z ]*$", ErrorMessage = "You used forbidden symbols. Please, reenter the state.")]
        [StringLength(20, ErrorMessage = "Name of the state is too long")]
        [Required(ErrorMessage = "Please. enter the state")]
        public string State { get; set; }
    }
}
