var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddPostgres("db").WithPgAdmin();
var cache = builder.AddRedis("cache");
var products = builder.AddProject<Projects.Products>("products")
    .WithReference(db);

builder.AddProject<Projects.Store>("store")
    .WithReference(products)
    .WithReference(cache);

builder.Build().Run();
