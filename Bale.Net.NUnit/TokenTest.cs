using Microsoft.Extensions.Configuration;
using NUnit.Framework.Internal;

namespace Bale.Net.NUnit;

public class TokenTest
{
    private readonly string _token;
    private BaleClient? _client;
    public TokenTest()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("secrets.json")
            .Build();
        
        _token = configuration.GetRequiredSection("Token").Value!;
    }

    [Test]
    public void TestToken_IsNotNull()
    {
        Assert.That(_token, Is.Not.Null);
    }
    [Test]
    public void ClientToken_IsNotNull()
    {
        _client = new (_token);
        Assert.That(_client.Token,Is.Not.Null);
    }
}