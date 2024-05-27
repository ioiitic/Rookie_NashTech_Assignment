namespace R2EShop.App.ViewModel
{
    public record DeviceModel(
        Guid Id,
        string DeviceName,
        bool IsNew,
        IList<DeviceModel>? ChildDevices);
}
