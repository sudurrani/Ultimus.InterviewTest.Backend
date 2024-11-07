using Serilog;
using Ultimus.API;



var builder = WebApplication.CreateBuilder(args);


var app = builder
       .ConfigureServices()
       .ConfigurePipeline();


// drop & create fresh database
//await app.ResetDatabaseAsync();

app.Run();

public partial class Program { }