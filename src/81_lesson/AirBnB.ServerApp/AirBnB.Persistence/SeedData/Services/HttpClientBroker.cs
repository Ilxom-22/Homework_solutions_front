namespace AirBnB.Persistence.SeedData.Services;

public static class HttpClientBroker
{
    public static async ValueTask DownloadAsync(string url, string fileSavingPath)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(fileSavingPath) ?? throw new ArgumentNullException(nameof(fileSavingPath), "The given file path cannot be null."));

        using var client = new HttpClient();
        try
        {
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var fileBytes = await response.Content.ReadAsByteArrayAsync();

                File.WriteAllBytes(fileSavingPath, fileBytes);
            }
            else
            {
                await Console.Out.WriteLineAsync("The given URL is either invalid or not responding.");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Unexpected error occured while downloading the file.");
        }
    }
}