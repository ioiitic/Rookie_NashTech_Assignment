using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using R2EShop.App.Services.Device;
using R2EShop.App.ViewModel;

namespace R2EShop.App.Pages
{
    public class IndexModel : BasePageModel
    {
        private readonly IDeviceService _deviceService;
        public IndexModel(IDeviceService deviceService) : base(deviceService)
        {
        }

        public void OnGet()
        {

        }
    }
}