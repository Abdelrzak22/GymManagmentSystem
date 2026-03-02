using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.PlanViewModel
{
    internal class PlanToUpdate
    {
       
        public string PlanName { get; set; } = null!;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Description must be between 2 and 200 char")]
        public string   Description { get; set; } = null!;

        [Required(ErrorMessage = "Price is required")]
        [Range(0.1,100,ErrorMessage ="price is must be less than 10000")]

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Duration days  is required")]
        [Range(1, 365, ErrorMessage = "dauration days  are  between 1 and  365")]

        public int DurationDays { get; set; }


    }
}
