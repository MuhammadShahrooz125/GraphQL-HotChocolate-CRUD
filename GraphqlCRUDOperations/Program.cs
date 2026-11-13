
using GraphqlCRUDOperations.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphqlCRUDOperations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
           
            builder.Services.AddSwaggerGen();

            builder.Services
               .AddGraphQLServer()
               .AddQueryType<Query>()
               .AddMutationType<Mutation>()
               .AddFiltering()
               .AddSorting();

            builder.Services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

            var app = builder.Build();           

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.MapGraphQL();

            app.Run();
        }
    }
}
