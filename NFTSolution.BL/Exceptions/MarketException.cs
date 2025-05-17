using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTSolution.BL.Exceptions
{
    class MarketException:Exception
    {
        public MarketException():base("Default message")
        {
                
        }
        public MarketException(string errormessage):base(errormessage)
        {
            
        }
    }
}
