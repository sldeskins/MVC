using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeNewsAndWeatherWithAsync 
{
   public class HomePageViewModel
    {
        internal void AddMessage ( string p )
        {
            throw new NotImplementedException();
        }

        public object Headline
        {
            get;
            set;
        }

        public object Temperature
        {
            get;
            set;
        }
    }
}
