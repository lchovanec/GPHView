using Serilog;

var builder = WebApplication.CreateBuilder(args);

var log = new LoggerConfiguration().WriteTo.File("GPHView.log").CreateLogger();

builder.Services.AddRazorPages();
builder.Services.AddSerilog(log);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
