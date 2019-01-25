using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class TeamModel
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        //per lygybe parasoma kaip construktorius nuo c# 6.0
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();
    }
}
