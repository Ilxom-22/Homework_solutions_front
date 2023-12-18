namespace AirBnB.Domain.Common.Extensions;

public static class FileExtensions
{
    public static string ToUrl(this string filePath, string prefix = "") => 
        $"{prefix}/{filePath
            .Replace(@"wwwroot\", "")
            .Replace(@"\", "/")}";
}