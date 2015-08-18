using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcIoC.Models
{
   public class ProtienTrackingService
   {
       public int Total { get; set; }
       public int Goal { get; set; }
        public void AddProtien ( int amount )
        {
            Total+=amount;
        }
    }
}
