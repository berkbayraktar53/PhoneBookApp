using Autofac;
using Newtonsoft.Json;
using Autofac.Extensions.DependencyInjection;
using PhoneBookApp.Business.DependencyResolvers.Autofac;
//////////////////////////////////////////////////////////////////////////////////////////////////
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option =>
{
    option.AddPolicy("PhoneBookApi", options =>
    {
        options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
#region Autofac implementation
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new BusinessModule()));
#endregion
//////////////////////////////////////////////////////////////////////////////////////////////////
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("PhoneBookApi");
app.UseAuthorization();
app.MapControllers();
app.Run();