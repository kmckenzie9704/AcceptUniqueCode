using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AcceptUniqueCode.Models
{
    public class UniqueCode
    {
        public string uniCode { get; set; }
        public string uniEmail { get; set; }
        public DateTime? uniAssignDate { get; set; }
        public DateTime? uniAcceptDate { get; set; }
        public bool uniAccepted { get; set; }


        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UniqueCode>(entity =>
            {
                entity.HasKey(e => e.uniCode);
            });
       }

    }
}
