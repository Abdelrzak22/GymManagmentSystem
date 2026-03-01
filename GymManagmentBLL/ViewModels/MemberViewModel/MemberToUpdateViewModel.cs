using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.MemberViewModel
{
    internal class MemberToUpdateViewModel
    {
        public string Name { get; set; } = null!;

        public string? Photo {  get; set; }

        [Required(ErrorMessage = "phone is required")]
        [Phone(ErrorMessage = "Invalid Phone format")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(010|011|012|015)\d{8}", ErrorMessage = "Phone Number must be valid Egyption phone number")]

        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "BuildingNumber is required")]
        [Range(1, 9000, ErrorMessage = "Building Number can be between 1 to 9000")]
        public int BuildingNumber { get; set; }


        [Required(ErrorMessage = "Street is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Street must be between 2 and 30")]

        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "Street is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Street must be between 2 and 30")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Street can only be letter and space")]

        public string City { get; set; } = null!;


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "invalid Email format")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Email must be between 5 and 50")]

        public string Email { get; set; } = null!;
    }
}
