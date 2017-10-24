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
        // GET api/values
        public List<Def_cve_item> Get()
        {
            string physicalPath = HostingEnvironment.MapPath("~/Content/nvdcve-1.0-2017.json");
            CVE.Models.Schema cveObject = CVE.Models.Schema.FromJson(File.ReadAllText(physicalPath));
            return cveObject.CVE_Items.Take(25).ToList();
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
