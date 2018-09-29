using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SecureWebsitePractices.Models
{

    public class UserContext : DbContext
    {
        public UserContext()
          : base("DefaultConnection")
        {
        }

        public DbSet<ProfileModel> Profiles { get; set; }
    }


    [Table("Profile")]
    public class ProfileModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public Int64 NINumber { get; set; }
        public string Address { get; set; }
    }
}