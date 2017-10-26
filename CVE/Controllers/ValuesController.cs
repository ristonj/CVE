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
        public CVEWrapper Get(int page = 1, string sev = "")
        {
            CVE.Models.Schema cveObject = CVE.Models.Schema.FromJson(File.ReadAllText(physicalPath));
            if (page < 1)
            {
                page = 1;
            }
            List<Def_cve_item> wholeList = null;
            if(string.IsNullOrWhiteSpace(sev))
            {
                wholeList = cveObject.CVE_Items.ToList();
            }
            else
            {
                wholeList = cveObject.CVE_Items.Where(x => x.Impact.BaseMetricV3.CvssV3.BaseSeverity.ToString() == sev).ToList();
            }

            if(((page + 1) * PAGE_SIZE) > wholeList.Count)
            {
                page = (wholeList.Count / PAGE_SIZE) + 1;
            }

            int numToSkip = (page - 1) * PAGE_SIZE;
            
            List<Def_cve_item> sourceList = wholeList.Skip(numToSkip).Take(PAGE_SIZE).ToList();
            CVEWrapper myWrapper = new CVEWrapper();
            myWrapper.count = wholeList.Count;
            myWrapper.items = new List<CVEItem>();
            foreach(Def_cve_item myItem in sourceList)
            {
                CVEItem addItem = new CVEItem(myItem);
                myWrapper.items.Add(addItem);
            }
            return myWrapper;
        }

       
    }
}
