
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
                                select new AlbumArtist
                                {
                                    ArtistName = ar.Name,
                                    Title = al.Title
                                });

            //var API_Object = queryResults.AsEnumerable().Select(xx => new AlbumArtist {
            //    ArtistName = xx.ArtistName,
            //    Title = xx.Title
            //});

            var API_Object = queryResults.ToList();

            return API_Object;
        }

        public string echo(string s)
        {
            return "Echo: " + s;
        }

        public IEnumerable<Artist> searchArtist(string s)
        {
            var queryResults = (from ar in dbContext.Artists
                                orderby ar.Name
                                where ar.Name.Contains(s)
                                select new Artist
                                {
                                    Name = ar.Name,
                                    ArtistId = ar.ArtistId
                                });

            return queryResults;
        }

        public IEnumerable<AlbumArtist> artistAlbums(string a)
        {
            var queryResults = (from al in dbContext.Albums
                                join ar in dbContext.Artists on al.ArtistId equals ar.ArtistId
                                orderby al.Title
                                where ar.Name.Contains(a)
                                select new AlbumArtist
                                {
                                    ArtistName = ar.Name,
                                    Title = al.Title
                                });

            return queryResults.ToList();
        }
    }
}