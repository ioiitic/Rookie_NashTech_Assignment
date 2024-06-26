﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using R2EShop.App.Services.DeviceService;
using R2EShop.App.ViewModel;

namespace R2EShop.App.Pages
{
    public class BasePageModel : PageModel
    {
        protected readonly IDeviceService _deviceService;
        public IList<DeviceModel> Devices { get; set; }

        public BasePageModel(IDeviceService deviceService)
        {
            _deviceService = deviceService;
            Devices = new List<DeviceModel>();
        }

        public override async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            Devices = await _deviceService.GetDevicesAsync();
            await next.Invoke();
        }
    }
}
