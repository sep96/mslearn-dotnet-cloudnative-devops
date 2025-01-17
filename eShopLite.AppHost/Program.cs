var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
var products = builder.AddProject<Projects.Products>("products");

builder.AddProject<Projects.Store>("store")
    .WithReference(products)
    .WithReference(cache);

builder.Build().Run();
