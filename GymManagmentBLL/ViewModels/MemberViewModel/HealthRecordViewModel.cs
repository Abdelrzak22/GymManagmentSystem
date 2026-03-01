using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.MemberViewModel
{
    internal class HealthRecordViewModel
    {

        [Required(ErrorMessage = "Height is required")]
        [Range(0.1, 300, ErrorMessage = "Height  is greater than 0 and less than 300")]
        public decimal Height   { get; set; }


        [Required(ErrorMessage = "Weight is required")]
        [Range(0.1, 500, ErrorMessage = "Weight  is greater than 0 and less than 500")]
        public decimal  Weight { get; set; }


        [Required(ErrorMessage = "Height is required")]
        [StringLength(3,ErrorMessage ="Blood type must be 3 character of less")]
        public string BloodType { get; set; } = null!;

        public string ? Note { get; set; }
    }
}
