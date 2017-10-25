using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Hosting;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using CVE.Models;

namespace CVE.Controllers
{
    public class ValuesController : ApiController
    {
        public const int PAGE_SIZE = 25;
        public ValuesController() : base()
        {
            physicalPath = HostingEnvironment.MapPath("~/Content/nvdcve-1.0-2017.json");
        }

        public ValuesController(string path) : base()
        {
            physicalPath = path;
        }

        public string physicalPath { get; set; }
        // GET api/values
        public CVEWrapper Get()
        {
            CVE.Models.Schema cveObject = CVE.Models.Schema.FromJson(File.ReadAllText(physicalPath));
            List<Def_cve_item> sourceList = cveObject.CVE_Items.Take(PAGE_SIZE).ToList();
            CVEWrapper myWrapper = new CVEWrapper();
            myWrapper.count = cveObject.CVE_Items.Count;
            myWrapper.items = new List<CVEItem>();
            foreach(Def_cve_item myItem in sourceList)
            {
                CVEItem addItem = new CVEItem(myItem);
                myWrapper.items.Add(addItem);
            }
            return myWrapper;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
