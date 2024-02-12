using CRUD_BlazorSample.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<CRUD_BlazorSample.Model.EmployeeService>();

builder.Services.AddHttpClient("employee", client =>
{
    client.BaseAddress = new Uri("https://localhost:7269/api/Employee/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

//app.MapRazorPages();
//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");


app.Run();
