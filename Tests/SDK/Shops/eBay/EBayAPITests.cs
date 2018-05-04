using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopsProducts.SDK;
using ShopsProducts.SDK.eBay;
using System.Linq;
using System.Reflection;

namespace ShopsProducts.Tests.SDK.Shops.eBay
{
    [TestClass]
    public class EBayAPITests
    {
        private static PrivateType eBayAPIWrapped;

        private static XmlReader items;
        private static XmlReader itemsDetails;
        private static XmlReader empty;
        private static XmlReader invalid;

        [ClassInitialize]
        public static void InitTests(TestContext testContext)
        {
            EBayAPI.AppID = "SergeyPa-oil-PRD-be04e9d4e-5f87abbe";

            items = CreateReaderItems();
            itemsDetails = CreateReaderItemsDetails();
            empty = CreateReaderEmpty();
            invalid = CreateReaderInvalid();

            eBayAPIWrapped = new PrivateType(typeof(EBayAPI));
        }

        #region EbayAPI.ReadItemsByKeywords() [private]
        [TestMethod]
        public void ReadItemsByKeywords_inputValidXml_outputValidCollection()
        {
            IEnumerable<EBaySingleItem> result = (IEnumerable<EBaySingleItem>)eBayAPIWrapped.InvokeStatic("ReadItemsByKeywords", items);

            EBaySingleItem[] expected = new EBaySingleItem[]
            {
                new EBaySingleItem(222946434826, @"Black Diamond Camalot Size #4 C4", @"http://thumbs3.ebaystatic.com/m/momFUog42CqrN67GFqT4s1g/140.jpg",
                                   @"http://rover.ebay.com/rover/1/711-53200-19255-0/1?ff3=2&toolid=10041&campid=1234567890&customid=k-man&lgeo=1&vectorid=229466&item=222946434826",
                                   "US", 46.0m),
                new EBaySingleItem(132606445555, @"BLACK DIAMOND Rock Climbing #3 Camalot CAM", @"http://thumbs4.ebaystatic.com/m/mBhD2PJu3m4eQ48_Xg16JBg/140.jpg",
                                   @"http://rover.ebay.com/rover/1/711-53200-19255-0/1?ff3=2&toolid=10041&campid=1234567890&customid=k-man&lgeo=1&vectorid=229466&item=132606445555",
                                   "US", 20.0m)
            };

            CollectionAssert.AreEqual(expected, result.ToArray());
        }
        [TestMethod]
        public void ReadItemsByKeywords_inputNull_outputNull()
        {
            XmlReader reader = null;
            IEnumerable<EBaySingleItem> result = (IEnumerable<EBaySingleItem>)eBayAPIWrapped.InvokeStatic("ReadItemsByKeywords", reader);

            Assert.IsNull(result);
        }
        #endregion

        #region EbayAPI.ReadItemsByIds() [private]
        [TestMethod]
        public void ReadItemsByIds_inputValidXml_outputValidCollection()
        {
            IEnumerable<EBayDetailsSingleItem> result = (IEnumerable<EBayDetailsSingleItem>)eBayAPIWrapped.InvokeStatic("ReadItemsByIds", itemsDetails);

            EBayDetailsSingleItem[] expected = new EBayDetailsSingleItem[]
            {
                new EBayDetailsSingleItem(new [] {
                    @"https://i.ebayimg.com/$_12.JPG?set_id=880000500F",
                    @"https://i.ebayimg.com/$_12.JPG?set_id=880000500F",
                    @"https://i.ebayimg.com/$_12.JPG?set_id=880000500F" }),
                new EBayDetailsSingleItem(new [] {
                    @"https://i.ebayimg.com/$_12.JPG?set_id=880000500F",
                    @"https://i.ebayimg.com/$_12.JPG?set_id=880000500F"
                })
            };

            CollectionAssert.AreEqual(expected, result.ToArray());
        }
        [TestMethod]
        public void ReadItemsByIds_inputNull_outputNull()
        {
            XmlReader reader = null;
            IEnumerable<EBayDetailsSingleItem> result = (IEnumerable<EBayDetailsSingleItem>)eBayAPIWrapped.InvokeStatic("ReadItemsByKeywords", reader);

            Assert.IsNull(result);
        }
        #endregion

        #region EbayAPI.GetProducts()
        [TestMethod]
        public void GetProducts_invalidResponseFromServer_outputXmlException()
        {
            XmlReaderFactory.Reader = invalid;

            try
            {
                var test = EBayAPI.GetProducts("test").Result;

            }
            catch (AggregateException e)
            {
                if (!(e.InnerException is XmlException))
                    Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void GetProducts_emptyResponseFromServer_outputXmlException()
        {
            XmlReaderFactory.Reader = empty;

            try
            {
                var test = EBayAPI.GetProducts("test").Result;

            }
            catch (AggregateException e)
            {
                if (!(e.InnerException is XmlException))
                    Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
        }
        #endregion

        private static XmlReader CreateReaderItems() => XmlReader.Create("../../SDK/Shops/eBay/eBayXmlTestItems.xml");
        private static XmlReader CreateReaderItemsDetails() => XmlReader.Create("../../SDK/Shops/eBay/eBayXmlTestItemsDetails.xml");
        private static XmlReader CreateReaderEmpty() => XmlReader.Create("../../SDK/Shops/XmlEmpty.xml");
        private static XmlReader CreateReaderInvalid() => XmlReader.Create("../../SDK/Shops/XmlInvalid.xml");
    }
}
