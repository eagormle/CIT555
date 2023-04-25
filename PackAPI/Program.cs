using PackAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using PackAPI.Settings;
using Microsoft.Extensions.Configuration;
using PackAPIAPI.Models;

namespace PackAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "_corsapp",
                                  policy =>
                                  {
                                      policy.WithOrigins("*")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod()
                                            .AllowAnyOrigin();
                                  });
            });

            builder.Services.AddControllers();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Register and bind DatabaseSettings
            builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
            builder.Services.AddSingleton(x => x.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IListRepository>(provider =>
                new ListRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddTransient<IListBodyRepository, ListBodyRepository>();
            //builder.Services.AddTransient<ICommentRepository, CommentRepository>();
            //builder.Services.AddTransient<IReplyRepository, ReplyRepository>();
            //builder.Services.AddTransient<ICommentLikeRepository, CommentLikeRepository>();
            //builder.Services.AddTransient<ICommentDislikeRepository, CommentDislikeRepository>();
            //builder.Services.AddTransient<IReplyLikeRepository, ReplyLikeRepository>();
            //builder.Services.AddTransient<IReplyDislikeRepository, ReplyDislikeRepository>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("_corsapp");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
