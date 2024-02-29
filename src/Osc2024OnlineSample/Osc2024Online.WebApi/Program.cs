using Osc2024Online.Domain;
using Sekiban.Core.Dependency;
using Sekiban.Infrastructure.Cosmos;
using Sekiban.Infrastructure.Postgres;
using Sekiban.Web.Dependency;
using Sekiban.Web.OpenApi.Extensions;
var builder = WebApplication.CreateBuilder(args);

builder.AddSekibanWithDependency<OscDependencyDefinition>();
var useCosmos = true;
if (useCosmos)
{
    builder.AddSekibanCosmosDB();
}
else
{
    builder.AddSekibanPostgresDbWithAzureBlobStorage();
}
builder.AddSekibanWebFromDomainDependency<OscDependencyDefinition>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt => opt.ConfigureForSekibanWeb());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
