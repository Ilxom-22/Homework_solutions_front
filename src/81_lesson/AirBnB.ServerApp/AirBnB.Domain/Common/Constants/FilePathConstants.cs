namespace AirBnB.Domain.Common.Constants;

public static class FilePathConstants
{
    public const string FileNameToken = "{{FileName}}";

    public const string LocationCategoryPath = @$"wwwroot\LocationCategories\{FileNameToken}";
    public const string LocationCategorySeedDataPath = @"SeedData\LocationCategories\locationCategories.json";

    public const string LocationPath = $@"wwwroot\Locations\{FileNameToken}";
    public const string LocationSeedDataPath = @"SeedData\Locations\locations.json";
}