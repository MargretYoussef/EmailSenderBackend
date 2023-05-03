using Email_Sender.Models;
using Email_Sender.services;
using Email_Sender.Settings;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MessageContext>(options =>

     options.UseSqlServer(builder.Configuration.GetConnectionString("EmailDbContext")
     ));

builder.Services.AddCors((CorsOptions) =>
{
    CorsOptions.AddPolicy("MyPolicy", (policyOptions) =>
    {
        policyOptions.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});



builder.Services.AddTransient<IMailingService, MailingService>();

builder.Services.Configure<MailSettings>(
builder.Configuration.GetSection("MailSettings"));




var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
