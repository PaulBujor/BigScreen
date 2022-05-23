using BigScreen.Backend.Models;
using BigScreen.Backend.Security;
using BigScreen.SDK.DataAccess.Extensions;
using BigScreen.SDK.WebAPI.Extensions;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

var keyVaultClient = new KeyVaultClient();

//todo move to KeyVault once we have production Cosmos DB
var cosmosEndPoint = keyVaultClient.GetEndPoint();

var accessKey = keyVaultClient.GetAccessKey();

const string databaseName = "BigScreen";

// Add services to the container.
builder.Services.AddCosmosDb(cosmosEndPoint, accessKey, databaseName)
    .AddDbSet<TestDbEntry>()
    .AddDbSet<CommentDbEntry>()
    .AddDbSet<RatingDbEntry>()
    .AddDbSet<TopListDbEntry>()
    .AddDbSet<UserDbEntry>();
builder.Services.AddDataAccess().Add<TestDto, TestDbEntry>().Build();
builder.Services.AddControllers().AddOData(opt =>
    opt.Select().Filter().OrderBy().Count()
        .AddRouteComponents("api/movies", GetEdmModel()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

// if (app.Environment.IsDevelopment())
app.UseSwagger();
app.UseSwaggerUI();

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