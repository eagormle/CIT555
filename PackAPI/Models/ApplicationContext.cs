using System;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PackAPI.Models;

namespace PackAPIAPI.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    { }
    public DbSet<User> User { get; set; } = null!;
    public DbSet<List> Lists { get; set; } = null!;
    public DbSet<ListBody> ListBodies { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    //public DbSet<Reply> Replies { get; set; } = null!;
    public DbSet<CommentLike> CommentLikes { get; set; } = null!;
    //public DbSet<CommentDislike> CommentDislikes { get; set; } = null!;
    //public DbSet<ReplyLike> ReplyLikes { get; set; } = null!;
    //public DbSet<ReplyDislike> ReplyDislikes { get; set; } = null!;
}