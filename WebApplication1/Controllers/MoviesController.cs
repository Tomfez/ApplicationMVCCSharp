using DataModel.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = new List<Movie>()
            {
                new Movie() {Title = "titre 1", Description = "description du premier film" },
                new Movie() {Title = "titre 2", Description = "description du deuxième film" },
            };

            return View(movies);
        }
    }
}