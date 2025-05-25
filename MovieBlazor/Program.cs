using Fluxor;
using MovieBlazor.Components;
using MovieBlazor.Components.Classes;
using MovieBlazor.Store.Auth;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddFluxor(options => options.ScanAssemblies(typeof(Program).Assembly));
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5105") });
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddHttpClient<IMovieApiService, MovieApiService>((sp, client) =>
{
    client.BaseAddress = new Uri("http://localhost:5105");
});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
