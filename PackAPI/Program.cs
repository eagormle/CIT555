using PackAPI.Interfaces;
using PackAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var corsapp = "_corsapp";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsapp,
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

//builder.Services.AddDbContext<ApplicationContext>(options =>
//options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddTransient<IUserRepository, UserRepository>();
//builder.Services.AddTransient<IListRepository, ListRepository>();
//builder.Services.AddTransient<IListBodyRepository, ListBodyRepository>();
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

app.UseCors(corsapp);

app.UseAuthorization();

app.MapControllers();

app.Run();
