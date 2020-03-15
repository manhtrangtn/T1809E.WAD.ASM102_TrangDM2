using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace T1809E.WAD.ASM102_TrangDM2.Data
{
    public class ASM102Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ASM102Context() : base("name=ASM102Context")
        {
        }

        public System.Data.Entity.DbSet<T1809E.WAD.ASM102_TrangDM2.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<T1809E.WAD.ASM102_TrangDM2.Models.Product> Products { get; set; }
    }
}
