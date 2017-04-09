using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class UserModel : DbContext
    {
        public UserModel()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
    }

    public static class SeedData
    {
        public static List<UserProfile> UserProfilesSeed()
        {
            var userProfiles = new List<UserProfile>
            {
                new UserProfile { Name = "Саша", City = "Київ", Age = 18 },
                new UserProfile { Name = "Аня", City = "Львів", Age = 25 },
                new UserProfile { Name = "Віка", City = "Харків", Age = 22 },
                new UserProfile { Name = "Ігор", City = "Київ", Age = 40 },
                new UserProfile { Name = "Ваня", City = "Львів", Age = 16 }
            };

            return userProfiles;
        }
    }
}