using CareerCloud.gRPC.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<ApplicantEducationService>();
app.MapGrpcService<ApplicantJobApplicationService>();
app.MapGrpcService<ApplicantProfileService>();
app.MapGrpcService<CompanyDescriptionService>();
app.MapGrpcService<CompanyJobEducationService>();
app.MapGrpcService<CompanyJobService>();
app.MapGrpcService<SecurityLoginService>();
app.MapGrpcService<SecurityLoginsLogService>();
app.MapGrpcService<SystemLanguageCodeService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
