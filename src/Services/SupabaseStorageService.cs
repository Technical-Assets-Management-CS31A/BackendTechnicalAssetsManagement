namespace BackendTechnicalAssetsManagement.src.Services
{
    public interface ISupabaseStorageService
    {
        Task<string> UploadImageAsync(IFormFile file, string folder);
        Task DeleteImageAsync(string imageUrl);
    }

    public class SupabaseStorageService : ISupabaseStorageService
    {
        private readonly Supabase.Client _client;
        private readonly string _bucket;

        public SupabaseStorageService(IConfiguration config)
        {
            var url = config["Supabase:Url"] ?? config["Supabase__Url"] ?? throw new InvalidOperationException("Supabase__Url is not configured.");
            var key = config["Supabase:ServiceRoleKey"] ?? config["Supabase__ServiceRoleKey"] ?? throw new InvalidOperationException("Supabase__ServiceRoleKey is not configured.");
            _bucket = config["Supabase:BucketName"] ?? config["Supabase__BucketName"] ?? throw new InvalidOperationException("Supabase__BucketName is not configured.");

            _client = new Supabase.Client(url, key, new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = false
            });
        }

        public async Task<string> UploadImageAsync(IFormFile file, string folder)
        {
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            var fileName = $"{folder}/{Guid.NewGuid()}{ext}";

            using var stream = file.OpenReadStream();
            var bytes = new byte[file.Length];
            await stream.ReadAsync(bytes);

            await _client.Storage
                .From(_bucket)
                .Upload(bytes, fileName, new Supabase.Storage.FileOptions { ContentType = file.ContentType, Upsert = true });

            return _client.Storage.From(_bucket).GetPublicUrl(fileName);
        }

        public async Task DeleteImageAsync(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl)) return;

            // Extract path from URL: .../storage/v1/object/public/{bucket}/{path}
            var uri = new Uri(imageUrl);
            var segments = uri.AbsolutePath.Split($"/object/public/{_bucket}/");
            if (segments.Length < 2) return;

            await _client.Storage.From(_bucket).Remove(new List<string> { segments[1] });
        }
    }
}
