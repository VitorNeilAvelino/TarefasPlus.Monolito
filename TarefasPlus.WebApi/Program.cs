using Microsoft.EntityFrameworkCore;
using TarefasPlus.Aplicacao;
using TarefasPlus.Repositorios.SqlServer;
using TarefasPlus.WebApi.Middlewares;

namespace TarefasPlus.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var tarefasPlusConnectionString = builder.Configuration.GetConnectionString("TarefasPlusConnection") ??
                throw new InvalidOperationException("Connection string 'TarefasPlusConnection' not found.");

            builder.Services.AddDbContext<TaferasPlusDbContext>(options => options
                .UseSqlServer(tarefasPlusConnectionString));

            builder.Services.AddScoped<ITarefaAplicacao, TarefaAplicacao>();

            builder.Services.AddControllers();            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(s => s.DescribeAllParametersInCamelCase());

            var app = builder.Build();
            
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

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