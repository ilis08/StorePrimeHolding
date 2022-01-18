using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Appliance
    {
        public string Model { get; set; }

        public DateOnly ProductionDate { get; set; }

        public int Weight { get; set; }
    }
}
