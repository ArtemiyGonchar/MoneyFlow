
using MoneyFlow.Application.DI;
using MoneyFlow.Infrastructure.Context;
using MoneyFlow.Infrastructure.DI;
using MoneyFlow.Infrastructure.Initializer;

namespace MoneyFlow.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Registering Infrustructure Layer and Application Layer
            builder.Services.RegisterInfrastructure(builder.Configuration);
            builder.Services.RegisterApplication(builder.Configuration);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //Initializing db with migrations
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<MoneyFlowDbContext>();

                    var initializer = serviceProvider.GetRequiredService<DbInitializer>();
                    await initializer.InitializeDb(context);
                }
                catch (Exception)
                {
                    throw;
                }
            }

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
        }
    }
}
