namespace AirBnB.Domain.Common.Constants;

public static class FilePathConstants
{
    public const string FileNameToken = "{{FileName}}";

    public const string LocationCategoryPath = @$"wwwroot\LocationCategories\{FileNameToken}";
    public const string LocationCategorySeedDataPath = @"SeedData\LocationCategories\locationCategories.json";
}