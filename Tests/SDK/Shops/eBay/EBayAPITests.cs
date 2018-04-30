using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopsProducts.SDK.eBay;

namespace ShopsProducts.Tests.SDK.Shops.eBay
{
    [TestClass]
    public class EBayAPITests
    {
        [ClassInitialize]
        public void Init()
        {
            EBayAPI.AppID = "SergeyPa-oil-PRD-be04e9d4e-5f87abbe";
        }

        [TestMethod]
        public void GetProducts_()
        {
            
        }
    }
}
