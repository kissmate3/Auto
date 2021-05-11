using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Common.Models
{
    public class MClient
    {
        public long Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string CarType { get; set; }
        public string LicensePN { get; set; }
        public string Description { get; set; }
        public DateTime StartingDate { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} : {CarType} , {LicensePN} , {Description} , {StartingDate.Year + ". " + StartingDate.Month + ". " + StartingDate.Day + ".   " + StartingDate.Hour + ":" + StartingDate.Minute + ":" + StartingDate.Second} , {Status}";
            //return $"{FirstName} {LastName} : {CarType} , {LicensePN} , {Description} , {StartingDate.Date}, {Status}" ;
        }
    }
}
