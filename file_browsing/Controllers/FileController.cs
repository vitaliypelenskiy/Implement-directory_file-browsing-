using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using file_browsing.Models;
namespace file_browsing.Controllers
{
    
  
    public class FileController : ApiController
    {
       BrFile obj = new BrFile();
       
        public IEnumerable<string> Get()
        {

            return obj.FunctionDir().AsEnumerable();
        }


        [System.Web.Http.HttpPost]
        public IEnumerable<string> Post(BrFile mas)
        {

            obj.put = mas.put;
            obj.FunctionNumber();
            return obj.directories.AsEnumerable(); ;
        }

    }
}
