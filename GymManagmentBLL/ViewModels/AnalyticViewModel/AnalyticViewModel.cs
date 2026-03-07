using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.AnalyticViewModel
{
    public class AnalyticViewModel
    {
        public int TotalMembers { get; set; }
        public int ActiveMember { get; set; }
        public int TotalTrainers { get; set; }
        public int ActiveSession { get; set; }
        public int UpcomingSession { get; set; }
        public int OngoingSession { get; set; }
        public int CompeletedSession { get; set; }

    }
}
