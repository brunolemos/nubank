using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Newtonsoft.Json;
using Nubank.API.Responses;
using Nubank.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace UnitTestUAP
{
    [TestClass]
    public class BillsResponseUnitTest
    {
        private static List<Bill> bills;

        [TestInitialize]
        public async Task Init()
        {
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///bills.json"));
            string json = await FileIO.ReadTextAsync(file);
            bills = JsonConvert.DeserializeObject<BillsResponse>(json).Bills;
        }

        [TestMethod]
        public void TestBillsCount()
        {
            int expectedItemsCount = 4;
            Assert.AreEqual(expectedItemsCount, bills.Count);
        }

        [TestMethod]
        public void TestBillsIDs()
        {
            List<string> expectedValues = new List<string>() {
                "55256cd0-10f7-4fd3-a3be-213bfe01857d",
                "554cc619-5998-4687-8fd3-743fd88ef704",
                null,
                null
            };

            Assert.AreEqual(expectedValues[0], bills[0].ID);
            Assert.AreEqual(expectedValues[1], bills[1].ID);
            Assert.AreEqual(expectedValues[2], bills[2].ID);
            Assert.AreEqual(expectedValues[3], bills[3].ID);
        }

        [TestMethod]
        public void TestBillsBarcodes()
        {
            List<string> expectedValues = new List<string>() {
                "03394643200000389339646532300000001745800102",
                "03397643400001743269646532300000001745800102",
                "03395646500000396279646532300000001745800102",
                null
            };

            Assert.AreEqual(expectedValues[0], bills[0].Barcode);
            Assert.AreEqual(expectedValues[1], bills[1].Barcode);
            Assert.AreEqual(expectedValues[2], bills[2].Barcode);
            Assert.AreEqual(expectedValues[3], bills[3].Barcode);
        }
    }
}
