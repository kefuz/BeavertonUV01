using Microsoft.EntityFrameworkCore;
using BeavertonUV.Data;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<BeavertonUVContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BeavertonUVContext") ?? throw new InvalidOperationException("Connection string 'BeavertonUVContext' not found.")));

// This function is in Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration["BUConnectToAZ:blob"], preferMsi: true);
    clientBuilder.AddQueueServiceClient(builder.Configuration["BUConnectToAZ:queue"], preferMsi: true);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

// Creating database if not exist.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<BeavertonUVContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
