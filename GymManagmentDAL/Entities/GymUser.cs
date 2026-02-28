using GymManagmentDAL.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Entities
{
    public abstract class GymUser:BaseEntity

    {

        public string Name { get; set; } = null!;
        public string Email { get; set; }=null!;
        public string Phone { get; set; } = null!;
        public DateOnly Dateofbirth { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }= null!;
    }

    [Owned]
    public class Address
    {
        public string Street { get; set; } = null!;
        public int BuldingNumber { get; set; }
        public string City { get; set; } = null!;
    }
}
