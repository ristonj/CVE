using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CVE;
using CVE.Controllers;
using CVE.Models;


namespace CVE.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void testJsonLoad()
        {
            ValuesController vc = new ValuesController("nvdcve-1.0-2017.json");
            CVEWrapper cveItems = vc.Get();
            Assert.AreEqual(25, cveItems.items.Count);
            Assert.AreEqual(8083, cveItems.count);
        }
    }
}
