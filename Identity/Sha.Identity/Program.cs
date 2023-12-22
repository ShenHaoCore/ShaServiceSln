using Sha.Identity;

var builder = WebApplication.CreateBuilder(args);
var identity = builder.Services.AddIdentityServer();
identity.AddInMemoryIdentityResources(Config.IdentityResources);
identity.AddInMemoryApiScopes(Config.ApiScopes);
identity.AddInMemoryApiResources(Config.ApiResources);
identity.AddInMemoryClients(Config.Clients);
identity.AddDeveloperSigningCredential();

var app = builder.Build();
app.UseIdentityServer();
app.UseAuthorization();

app.Run();
