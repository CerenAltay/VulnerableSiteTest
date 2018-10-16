using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SecureWebsitePractices2.Models
{
    public class UserContext : DbContext
    {
        public UserContext()
          : base("DefaultConnection")
        {
        }

        public DbSet<ProfileModel> Profiles { get; set; }

        public DbSet<AuditModel> Audits { get; set; }
    }


    [Table("Profile")]
    public class ProfileModel
    {
        private string _nINumber;

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public string NINumber { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }


    [Table("Audit")]
    public class AuditModel
    {
        public int Auditid { get; set; }
        public string User { get; set; }
        public string Message { get; set; }
        public string Severity { get; set; }

    }
}