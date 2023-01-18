using Microsoft.Extensions.Options;
using TG.Code.ConfiguratonAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<OptionsConfig>(
    builder.Configuration.GetSection("SectionOptions")
);

builder.Services.AddOptions<OptionsConfigWithValidation>()
    .Bind(builder.Configuration.GetSection("SectionOptions"))
    .ValidateDataAnnotations();

builder.Services.AddSingleton<IValidateOptions<OptionsConfigWithValidation>, ConfigValidateOptions>();

// Register Feature Options
builder.Services.Configure<FeatureOptions>(
    "Feature1",
    builder.Configuration.GetSection("Features:Feature1"));
builder.Services.Configure<FeatureOptions>(
    "Feature2",
    builder.Configuration.GetSection("Features:Feature2"));

builder.Services.PostConfigure<FeatureOptions>("Feature1", options =>
{
    options.FeatureName = "Post-Configure Value";
});

builder.Services.PostConfigureAll<OptionsConfig>(options =>
{
    options.PostValue = "Post-Configure Value";
});

builder.Services.AddTransient<IClassicConfig, ClassicConfig>();

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