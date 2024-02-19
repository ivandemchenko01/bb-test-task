namespace BB.TaskManager.Tests;

[TestFixture]
public class MyEndpointTests
{
    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    [Test]
    public async Task Get_EndpointReturnsSuccessAndCorrectContentType()
    {
        var response = await _client.PostAsJsonAsync("User/create-user/", new CreateUserModel
        {
            Username = "username",
            Email = "username@gmail.com",
            Password = "asdas12312!213"
        });

        // Assert
        response.EnsureSuccessStatusCode();
    }
}