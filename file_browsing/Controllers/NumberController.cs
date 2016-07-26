using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using file_browsing.Models;
namespace file_browsing.Controllers
{
    public class NumberController : ApiController
    {
        List<int> number = new List<int>();
         BrFile obj = new BrFile();
       
       
        public IEnumerable<int> Post(BrFile temp)
        {

            obj.put = temp.put;
            obj.FunctionNumber();
            number.Add(obj.less);
            number.Add(obj.norm);
            number.Add(obj.lot);
           
            return number.AsEnumerable();
        }

       
       

    }
}
