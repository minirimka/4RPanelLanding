using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PromoSite;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Контакты из wwwroot/appsettings.json (читаем по ключам — безопасно к trimming).
var config = builder.Configuration;
builder.Services.AddSingleton(new ContactsSettings
{
    Sales = new ContactLink
    {
        Label = config["Contacts:Sales:Label"] ?? "Отдел продаж",
        Telegram = config["Contacts:Sales:Telegram"] ?? "",
    },
    News = new ContactLink
    {
        Label = config["Contacts:News:Label"] ?? "Новости и обновления",
        Telegram = config["Contacts:News:Telegram"] ?? "",
    },
});

await builder.Build().RunAsync();
