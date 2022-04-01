using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace KutseeApp_Grigorjev.Models
{
    public class GuestContext : DbContext
    {
        public DbSet<Guest> Guest { get; set; }
    }
}