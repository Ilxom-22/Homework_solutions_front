namespace AirBnB.Domain.Common.Extensions;

public static class FileExtensions
{
    public static string ToUrl(this string filePath, string? prefix) => $"{prefix ?? string.Empty}/{filePath.Replace(@"wwwroot\", "").Replace(@"\", "/")}";
}