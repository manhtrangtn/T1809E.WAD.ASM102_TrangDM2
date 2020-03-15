using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace T1809E.WAD.ASM102_TrangDM2.Models
{
    public class Category
    {
      [Key]
      public int Id { get; set; }
      public string Name { get; set; }
      public virtual ICollection<Product> Products { get; set; }
    }
}