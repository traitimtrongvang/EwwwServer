namespace Auth0.Settings;

public class Auth0Setting
{
    public required string DomainUrl { get; init; }
    public required string PublicKeyUri { get; init; }
    public required string Issuer { get; init; }
    public required List<string> Audiences { get; init; }
    public string IssuerSigningKeysStr { get; set; } = null!;
    
    private readonly HttpClient _httpClient;

    public Auth0Setting()
    {
        _httpClient = new HttpClient();
    }
    
    public async Task FetchIssuerSigningKeysStrAsync()
    {
        IssuerSigningKeysStr = await _httpClient.GetStringAsync($"{DomainUrl}/{PublicKeyUri}");
    }
}