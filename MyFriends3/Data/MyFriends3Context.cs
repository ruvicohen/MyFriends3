using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFriends3.Models;

namespace MyFriends3.Data
{
    public class MyFriends3Context : DbContext
    {
        public MyFriends3Context (DbContextOptions<MyFriends3Context> options)
            : base(options)
        {
        }

        public DbSet<MyFriends3.Models.Picture> Picture { get; set; } = default!;
        public DbSet<MyFriends3.Models.User> User { get; set; } = default!;
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<User>()
        //        .HasMany(u => u.UserPicture)
        //        .WithOne(p => p.User)
        //        .HasForeignKey(p => p.UserId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<User>()
        //        .HasOne(u => u.Avatar)
        //        .WithMany()
        //        .HasForeignKey(u => u.ProfilePictureId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // Optional: Add further configurations here
        //}
    }

}
