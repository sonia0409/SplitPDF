var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(); //to set razor page as homepage
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//app.MapGet("/default", () => "SplitPDF!!");


app.UseDefaultFiles();
app.UseStaticFiles(); //wwwroot folder holds the static files like html js

app.MapRazorPages(); //to set razor page as homepage
app.Run();
