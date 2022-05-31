using BigScreen.Backend.Models;
using BigScreen.Backend.Security;
using BigScreen.Core.Models.BigScreen;
using BigScreen.SDK.DataAccess.Extensions;
using BigScreen.SDK.Utilities;
using BigScreen.SDK.WebAPI.Core.Attributes;
using BigScreen.SDK.WebAPI.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.Identity.Web;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

var keyVaultClient = new KeyVaultClient();

var cosmosEndPoint = keyVaultClient.GetEndPoint();

var accessKey = keyVaultClient.GetAccessKey();

const string databaseName = "BigScreen";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));

builder.Services.AddCosmosDb(cosmosEndPoint, accessKey, databaseName)
    .AddDbSet<CommentDbEntry>()
    .AddDbSet<RatingDbEntry>()
    .AddDbSet<TopListDbEntry>()
    .AddDbSet<UserDbEntry>();

builder.Services.AddDataAccess().Add<CommentDto, CommentDbEntry>()
    .Add<RatingDto, RatingDbEntry>()
    .Add<TopListDto, TopListDbEntry>()
    .Add<UserDto, UserDbEntry>()
    .Build();

builder.Services.AddControllers().AddOData(opt =>
    opt.Select().Filter().Count().Expand()
        .AddRouteComponents("api", GetEdmModel(), new DefaultODataBatchHandler()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opts =>
    opts.AddPolicy("Development", policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddCors(opts =>
    opts.AddPolicy("Production",
        policyBuilder => policyBuilder.WithOrigins("https://bigscreen.azurewebsites.net").AllowAnyHeader()
            .AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Development");
}
else
{
    app.UseCors("Production");
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<CommentDto>(typeof(CommentDto).GetAttribute<EdmCollectionAttribute>().CollectionName);
    builder.EntitySet<RatingDto>(typeof(RatingDto).GetAttribute<EdmCollectionAttribute>().CollectionName);
    builder.EntitySet<UserDto>(typeof(UserDto).GetAttribute<EdmCollectionAttribute>().CollectionName);
    builder.EntitySet<TopListDto>(typeof(TopListDto).GetAttribute<EdmCollectionAttribute>().CollectionName);
    return builder.GetEdmModel();
}