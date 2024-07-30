var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "SyncStream API",
        Description = "An API for managing video sync streams",
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "SyncStream API V1");
        options.DocumentTitle = "SyncStream API Documentation";
    });
}

// Global exception handler
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        var errorResponse = new ErrorResponse(500, "An unexpected error occurred.");
        await context.Response.WriteAsJsonAsync(errorResponse);
    });
});

// Host Management
app.MapPost("/api/hosts", (HostRequest request) =>
{
    if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Image) || string.IsNullOrEmpty(request.Password))
    {
        return Results.BadRequest(new ErrorResponse(400, "Invalid request body."));
    }

    // Logic to create and confirm host
    var response = new HostResponse("uniqueHostId", request.Name, "confirmed");
    return Results.Ok(response);
});

// Client Management
app.MapPost("/api/parties/{id}/join", (string id, ClientRequest request) =>
{
    if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Image) || string.IsNullOrEmpty(request.Password))
    {
        return Results.BadRequest(new ErrorResponse(400, "Invalid request body."));
    }

    // Logic to create client and join party
    var response = new ClientResponse("uniqueClientId", request.Name, id, "joined");
    return Results.Ok(response);
});

// Video Player Controls
app.MapPut("/api/parties/{id}/play", (string id) =>
{
    // Logic to play video
    var response = new VideoStatusResponse("playing");
    return Results.Ok(response);
});

app.MapPut("/api/parties/{id}/pause", (string id) =>
{
    // Logic to pause video
    var response = new VideoStatusResponse("paused");
    return Results.Ok(response);
});

app.MapPut("/api/parties/{id}/stop", (string id) =>
{
    // Logic to stop video
    var response = new VideoStatusResponse("stopped");
    return Results.Ok(response);
});

app.MapPut("/api/parties/{id}/seek", (string id, SeekRequest request) =>
{
    if (string.IsNullOrEmpty(request.Time))
    {
        return Results.BadRequest(new ErrorResponse(400, "Invalid request body."));
    }

    // Logic to seek video
    var response = new SeekResponse("seeked", request.Time);
    return Results.Ok(response);
});

app.Run();

// Models
public record HostRequest(string Name, string Image, string Password);
public record HostResponse(string Id, string Name, string Status);
public record ClientRequest(string Name, string Image, string Password);
public record ClientResponse(string ClientId, string Name, string PartyId, string Status);
public record VideoStatusResponse(string Status);
public record SeekRequest(string Time);
public record SeekResponse(string Status, string Time);
public record ErrorResponse(int Code, string Message);