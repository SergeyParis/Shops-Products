using System.Collections.Generic;

namespace ShopsProducts.SDK
{
    public interface IDetailsSingleItem
    {
        ISingleItem SingleItem { get; set; }
        
        IEnumerable<string> ImagesUrl { get; set; }
    }
}
