using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    [Route("[controller]/[action]")]
    public class AboutController :Controller
    {
        public string Phone()
        {
            return "+ 5555 666 7777";
        }

        public string Address()
        {
            return "Cairo, Egypt";
        }
    }
}
