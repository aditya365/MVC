using MVCMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hello! welcome to our application.";

            return View();
        }

        public JsonResult QuickSearch(string term) {
            var musicStoreDB = new MusicStoreDB();
            var albums = musicStoreDB.Albums.Where(a => a.Title.Contains(term)).
                ToList().
                Select(a => new { value = a.Title });
            return Json(albums,JsonRequestBehavior.AllowGet);
        }

        public ActionResult AlbumSearch(string album) {
            var musicStoreDB = new MusicStoreDB();
            var albums = musicStoreDB.Albums.Where(a => a.Title.Contains(album)).ToList();
            return PartialView("_AlbumSearch",albums);
        }


        public ActionResult BestSellingArtist() {
            var musicStoreDB = new MusicStoreDB();
            var artist = musicStoreDB.Artists.OrderBy(a=>a.Name).First();
            return PartialView("_BestSellingArtist",artist); 
        }


        public ActionResult DailyDeal() {
            var album = GetDailyDeal();
            return PartialView("_DailyDeal",album);
        }

        private Album GetDailyDeal() {
            var musicStoreDb = new MusicStoreDB();
            var album = musicStoreDb.Albums.OrderBy(a => a.Price).First();
            album.Price *= 0.5m;
            return album;
        }


        public ActionResult Search(string q) {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Edit() {
            return View();
        }
    }
}