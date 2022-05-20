using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Movies> Movies { get; set; }

        public IQueryable<Movies> movies(string movie)
        {
            SqlParameter pContactName = new SqlParameter("@ContactName", movie);
            return this.movies.FromSql("EXECUTE Customers_SearchCustomers @ContactName", pContactName);
        }

    }
    }
