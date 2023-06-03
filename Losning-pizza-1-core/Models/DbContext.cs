using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Losning_pizza_1_core.Models
{
    public class Kunde      
    {                       
        [Key]
        public int KId { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public string Telefonnr { get; set; }

        public virtual List<Bestilling> Bestillinger { get; set; }
    }
    public class Bestilling
    {                     
        [Key]
        public int BId { get; set; }
        public string PizzaType { get; set; }
        public string Tykkelse { get; set; }
        public int Antall { get; set; }
    }

    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet <Kunde> Kunder { get; set; }
        public DbSet<Bestilling> Bestillinger { get; set; }

    }
}
