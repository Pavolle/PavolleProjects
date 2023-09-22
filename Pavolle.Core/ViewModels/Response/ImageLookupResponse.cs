using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.Core.ViewModels.Response
{
    public class ImageLookupResponse : ResponseBase
    {
        public List<ImageLookupViewData> DataList { get; set; }
    }
}
