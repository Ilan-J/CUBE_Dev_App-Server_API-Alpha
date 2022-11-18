using MySql.Data.MySqlClient;
using APIServer.DBConnection;

namespace APIServer
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            if (!DBUtils.TryDBConnection(conn))
            {
                Console.Read();
                return;
            }

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
    }
}


