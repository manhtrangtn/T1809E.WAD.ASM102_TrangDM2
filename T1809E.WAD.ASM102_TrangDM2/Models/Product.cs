using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace T1809E.WAD.ASM102_TrangDM2.Models
{
    public class Product
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public string Thumbnail { get; set; }
      public double Price { get; set; }
      [ForeignKey("Category")]
      public int CategoryId { get; set; }
      public virtual Category Category { get; set; }
    }
}