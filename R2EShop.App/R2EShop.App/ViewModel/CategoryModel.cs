namespace R2EShop.App.ViewModel
{
    public record CategoryModel(
        Guid Id,
        string CategoryName,
        string CaseTypeName,
        IList<CategoryModel> ChildCategories);
}
