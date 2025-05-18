using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTSolution.BL.ViewModels
{
  public   class UpdateMarketVM
    {
        public string Name { get; set; }
        public string Count { get; set; }
        public string Category { get; set; }
        public IFormFile? ImgFile { get; set; }
    }
}
