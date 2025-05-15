using Fluxor;
using MovieBlazor.Components;
using MovieBlazor.Components.Classes;
using MovieBlazor.Store.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddFluxor(options => options.ScanAssemblies(typeof(Program).Assembly));
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddTransient<AuthAwareHttpClientHandler>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5105") });
builder.Services.AddHttpClient<IMovieApiService, MovieApiService>((sp, client) =>
{
    client.BaseAddress = new Uri("http://localhost:5105"); // замени на свой адрес
})
.AddHttpMessageHandler<AuthAwareHttpClientHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
