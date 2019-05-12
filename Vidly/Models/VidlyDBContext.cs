using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Vidly.Models
{
    public class VidlyDBContext: DbContext
    {
        public VidlyDBContext() : base("VidlyDB") { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }

        public DbSet<Genre> Genres { get; set; }

    }
}