using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace KutseeApp_Grigorjev.Models
{
    public class GuestDBInitializater:CreateDatabaseIfNotExists<GuestContext>
    {
        protected override void Seed(GuestContext db)
        {
            base.Seed(db);
        }
    }
}