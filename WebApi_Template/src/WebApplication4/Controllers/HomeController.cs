
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Mvc;
using WebApi_Template.Models;
using System.Collections.Generic;

namespace WebApi_Template.Controllers
{
  
    public class HomeController : Controller
    {

        private ApplicationDbContext dbContext { get; set; }

        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public IEnumerable<AlbumArtist> GetAll()
        {
            var queryResults = (from ar in dbContext.Artists
                                join al in dbContext.Albums
                                on ar.ArtistId equals al.ArtistId
                                orderby ar.Name
                                select new {
                                    ArtistName = ar.Name,
                                    Title = al.Title
                                });

            var API_Object = queryResults.AsEnumerable().Select(xx => new AlbumArtist {
                ArtistName = xx.ArtistName,
                Title = xx.Title
            });

            return API_Object;
        }

        public string mofo(string abc)
        {
            return "I farted " + abc;
        }

        public IEnumerable<Artist> search(string searchString)
        {
            var queryResults = (from ar in dbContext.Artists
                                orderby ar.Name
                                where ar.Name.Contains(searchString)
                                select new Artist
                                {
                                    Name = ar.Name,
                                    ArtistId = ar.ArtistId
                                });

            return queryResults;
        }
    }
}