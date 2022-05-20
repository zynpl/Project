using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Movies
    {
        
        [Key]
        public int Id  { get; set; }

        public string Movie_Name { get; set; }
        public string Movie_Genre { get; set; }

        //internal void Entity<T>(Action<object> p)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
