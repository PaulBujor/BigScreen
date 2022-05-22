using BigScreen.Backend.Core.Models;
using BigScreen.SDK.DataAccess.Extensions;
using BigScreen.SDK.WebAPI.Extensions;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;

var builder = WebApplication.CreateBuilder(args);

const string httpsLocalhost = "https://localhost:8081";

const string accessKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

const string databaseName = "BigScreenTest";

// Add services to the container.
builder.Services.AddCosmosDb(httpsLocalhost, accessKey, databaseName).AddDbSet<TestDbEntry>();
builder.Services.AddDataAccess().Add<TestDto, TestDbEntry>().Build();
builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("odata", GetEdmModel()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<TestDto>("Test");
    return builder.GetEdmModel();
}