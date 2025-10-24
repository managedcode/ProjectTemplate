var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.ProjectTemplate_Api>("api");

builder.Build().Run();
