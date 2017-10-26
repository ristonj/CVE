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

        [TestMethod]
        public void pageTwo()
        {
            ValuesController vc = new ValuesController("nvdcve-1.0-2017.json");
            CVEWrapper cveItems = vc.Get(2);
            Assert.AreEqual(25, cveItems.items.Count);
            Assert.AreEqual(8083, cveItems.count);
            Assert.AreEqual("CVE-2017-0027", cveItems.items[0].ID);
        }

        [TestMethod]
        public void pageZero()
        {
            ValuesController vc = new ValuesController("nvdcve-1.0-2017.json");
            CVEWrapper cveItems = vc.Get(0);
            Assert.AreEqual(25, cveItems.items.Count);
            Assert.AreEqual(8083, cveItems.count);
            Assert.AreEqual("CVE-2017-0001", cveItems.items[0].ID);
        }

        [TestMethod]
        public void page324()
        {
            ValuesController vc = new ValuesController("nvdcve-1.0-2017.json");
            CVEWrapper cveItems = vc.Get(324);
            Assert.AreEqual(8, cveItems.items.Count);
            Assert.AreEqual(8083, cveItems.count);
        }

        [TestMethod]
        public void page325()
        {
            ValuesController vc = new ValuesController("nvdcve-1.0-2017.json");
            CVEWrapper cveItems = vc.Get(325);
            Assert.AreEqual(8, cveItems.items.Count);
            Assert.AreEqual(8083, cveItems.count);
        }

        [TestMethod]
        public void testSeverity()
        {
            ValuesController vc = new ValuesController("nvdcve-1.0-2017.json");
            CVEWrapper cveItems = vc.Get(1, "HIGH");
            Assert.AreEqual(25, cveItems.items.Count);
            Assert.IsFalse(cveItems.items.Any(x => x.severity != "HIGH"));
        }
    }
}
