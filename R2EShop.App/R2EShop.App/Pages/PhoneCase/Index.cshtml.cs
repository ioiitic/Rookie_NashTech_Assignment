using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using R2EShop.App.Services.Device;

namespace R2EShop.App.Pages.PhoneCase
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
