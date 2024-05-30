namespace R2EShop.App.ViewModel
{
    public record ArtworkModel(
        Guid Id,
        Guid PhoneCaseId,
        double PhoneCasePrice,
        string DeviceName,
        string CaseTypeName,
        int NumberOfColors);
}
