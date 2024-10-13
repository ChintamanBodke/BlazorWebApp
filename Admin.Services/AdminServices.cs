using System.Text.Json;

public class AdminServices : IAdminServices
{
    public async  Task<List<UserApiResult>> GetAdminUserList()
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/users");
        var request = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/users");
        HttpResponseMessage responseMessage = await httpClient.SendAsync(request);
        var result = await responseMessage.Content.ReadAsStringAsync();
        var adminList = result != null ? JsonSerializer.Deserialize<List<UserApiResult>>(result) : new List<UserApiResult>();
    
        return adminList;
    }
}