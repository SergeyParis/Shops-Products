using System;
using System.Collections.Generic;

namespace ShopsProducts.Data.Model.Wrap
{
    public sealed class DetailsSingleItemWrapped : SDK.IDetailsSingleItem
    {
        public long Id { get; set; }
        public IEnumerable<string> ImagesUrl { get; set; }


    }
}
