using System.Collections.Generic;

namespace ShopsProducts.SDK
{
    public interface IDetailsSingleItem
    {
        long Id { get; set; }
        IEnumerable<string> ImagesUrl { get; set; }
    }
}
