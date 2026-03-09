using GymManagmentDAL.Entities.Enum;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.TrainerViewModel
{
    public class TrainerViewModel
    {

        public int TrainerId { get; set; }

        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string Phone { get; set; }= null!;

        public string Specialties { get; set; }=null!;

        public string? DateOfBirth { get; set; }
        public string ? Address { get; set; } = null!;


    }
}
