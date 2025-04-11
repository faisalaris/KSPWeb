using client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage(); // Tambahkan ini untuk mengaktifkan LocalStorage
builder.Services.AddScoped(sp =>
{
    //var client = new HttpClient { BaseAddress = new Uri("http://103.130.164.28:1242/api/main/") }; Server Permanent
    var client = new HttpClient { BaseAddress = new Uri("https://rikapi.duckdns.org/api/main/") }; // Server Sementara
    client.DefaultRequestHeaders.Add("TokenId", "240782");
    client.DefaultRequestHeaders.Add("SenderId", "WKSP");
    client.DefaultRequestHeaders.Add("TransmitUniqueId", "12345");
    client.DefaultRequestHeaders.Add("UserId", "KSP");
    client.DefaultRequestHeaders.Add("RequestType", "Q");
    return client;
});

builder.Services.AddScoped<CustomerService>();

await builder.Build().RunAsync();
