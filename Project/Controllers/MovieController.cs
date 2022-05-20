using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class MovieController : Controller
    {
        private readonly Context _con;
        public MovieController(Context con)
        {
            _con = con;
        }
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult movieTable()
        {
          

           
            //var movies = _con.Movies.ToList();
            var movies = _con.Movies
    .FromSqlRaw("Select *from dbo.Movies")
    .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult movieAdd()
        {
            return View();
        }
        public IActionResult movieNew(Movies m)
        {
         
            var addMovie = _con.Movies
  .FromSqlRaw("EXECUTE dbo.movieList @mName='Movie Name',@mGenre='Movie Genre'")
  .ToList();//doğru ama daha doğru yol olan alt kısım


            SqlCommand DBCommand2 = new SqlCommand("movieList", _con);//SQL connectionu buraya vereceğiz ama projende nerede -> eklenecek
            DBCommand2.CommandType = CommandType.StoredProcedure;
            DBCommand2.Parameters.AddWithValue("@mName", "Test 1");//bu yapıyı da anlamaya çalış anlayamazsan anlatırım ben
            DBCommand2.Parameters.AddWithValue("@mGenre", "Test 2");
            DBCommand2.ExecuteReader();
            //İlk yaptığın şekilde de doğru ancak ADO.NET ile yapman daha doğru oluyor. Buraya sql connectionu verip çalıştırdığında çalışacak. ADO.NET ile işlemi yapmaya bakabilirmiin?Kodu hazır yukarıdaki olacak sadece araştırmanı ve tamamlamanı rica ediyorum. Sql connectionun eksik ve ADO.NET ile nasıl yapılır aslında ona bakmanı istiyorum. 



            return View(addMovie);
        }
 

    }
}
