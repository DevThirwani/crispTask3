using RestSharp;
using Xunit;

public class ApiTests
{
    private readonly RestClient _client;

    public ApiTests()
    {
        _client = new RestClient(AppConfig.BaseUrl);
    }

    [Fact]
    public void GetPatientById_ValidId_Returns200()
    {
        var request = new RestRequest($"?Id={TestData.ValidId}", Method.Get);
        var response = _client.Execute(request);
        Assert.Equal(200, (int)response.StatusCode);
    }

    [Fact]
    public void GetPatientByName_ValidName_Returns200()
    {
        var request = new RestRequest($"?Name={TestData.ValidName}", Method.Get);
        var response = _client.Execute(request);
        Assert.Equal(200, (int)response.StatusCode);
    }

    [Fact]
    public void GetPatientByDateOfBirth_ValidDateOfBirth_Returns200()
    {
        var request = new RestRequest($"?DateOfBirth={TestData.ValidDateOfBirth}", Method.Get);
        var response = _client.Execute(request);
        Assert.Equal(200, (int)response.StatusCode);
    }

    [Fact]
    public void GetPatientById_InvalidId_Returns404()
    {
        var request = new RestRequest($"?Id={TestData.InvalidId}", Method.Get);
        var response = _client.Execute(request);
        Assert.Equal(404, (int)response.StatusCode);
    }

    [Fact]
    public void GetPatientByName_InvalidName_Returns404()
    {
        var request = new RestRequest($"?Name={TestData.InvalidName}", Method.Get);
        var response = _client.Execute(request);
        Assert.Equal(404, (int)response.StatusCode);
    }

    [Fact]
    public void GetPatientByDateOfBirth_InvalidDateOfBirth_Returns400()
    {
        var request = new RestRequest($"?DateOfBirth={TestData.InvalidDateOfBirth}", Method.Get);
        var response = _client.Execute(request);
        Assert.Equal(400, (int)response.StatusCode);
    }
}
