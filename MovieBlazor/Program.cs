using Fluxor;
using MovieBlazor.Components;
using MovieBlazor.Components.Classes;
using MovieBlazor.Components.Interfaces;
using MovieBlazor.Store.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddFluxor(options => options.ScanAssemblies(typeof(Program).Assembly));

// Регистрация реактивного селектора для AuthState
builder.Services.AddScoped<ISelector<AuthState>>(provider =>
{
    var authState = provider.GetRequiredService<IState<AuthState>>();
    return new Selector<AuthState>(() => authState.Value);
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5105") });

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
