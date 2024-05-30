using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using R2EShop.App.Services.ArtworkService;
using R2EShop.App.Services.DeviceService;
using R2EShop.App.ViewModel;

namespace R2EShop.App.Pages
{
    public class IndexModel : BasePageModel
    {

        public IndexModel(IDeviceService deviceService) : base(deviceService)
        {
        }

        public void OnGet()
        {
        }
    }
}