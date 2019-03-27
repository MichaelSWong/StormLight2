using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StormLight2.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using StormLight2.Models;

namespace StormLight2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            BookDAL dal = new BookDAL();
            return View(dal.GetAllBooks());
        }

        public IActionResult BookDetail(int id)
        {
            BookDAL dal = new BookDAL();
            BookModel character = dal.GetBook(id);

            return View(character);
        }

        public IActionResult CharacterView()
        {
            CharacterSqlDAL dal = new CharacterSqlDAL();
            return View(dal.GetAllCharacters());
        }

        public IActionResult CharacterDetail(int id)
        {
            CharacterSqlDAL dal = new CharacterSqlDAL();
            CharacterModel character = dal.GetCharacter(id);

            return View(character);
        }
        
        [HttpGet]
        public IActionResult NewSurvey()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewSurvey(SurveyResultModel model)
        {
            SurveyDAL myDal = new SurveyDAL();
            myDal.SaveSurvey(model);

            return RedirectToAction("favorites");
        }
        private List<SelectListItem> characterselect = new List<SelectListItem>()
        {
            new SelectListItem(){Text="Kaladin"},
            new SelectListItem(){Text="Shallan"},
            new SelectListItem(){Text="Dalinar"},
            new SelectListItem(){Text="Jansah"},
            new SelectListItem(){Text="Lift"},
        };

        private List<SelectListItem> states = new List<SelectListItem>()
        {
            new SelectListItem() {Text ="Alabama" },
            new SelectListItem() {Text ="Alaska"},
            new SelectListItem() {Text ="Arizona"},
            new SelectListItem() {Text ="Arkansas"},
            new SelectListItem() {Text ="California"},
            new SelectListItem() {Text ="Colorado" },
            new SelectListItem() {Text ="Connecticut"},
            new SelectListItem() {Text ="Delaware"},
            new SelectListItem() {Text ="District Of Columbia"},
            new SelectListItem() {Text ="Florida" },
            new SelectListItem() {Text ="Georgia"},
            new SelectListItem() {Text ="Hawaii"},
            new SelectListItem() {Text ="Idaho"},
            new SelectListItem() {Text ="Illinois"},
            new SelectListItem() {Text ="Indiana"},
            new SelectListItem() {Text ="Iowa"},
            new SelectListItem() {Text ="Kansas"},
            new SelectListItem() {Text ="Kentucky"},
            new SelectListItem() {Text ="Louisiana"},
            new SelectListItem() {Text ="Maine"},
            new SelectListItem() {Text ="Maryland"},
            new SelectListItem() {Text ="Massachusetts" },
            new SelectListItem() {Text ="Michigan"},
            new SelectListItem() {Text ="Minnesota"},
            new SelectListItem() {Text ="Mississippi"},
            new SelectListItem() {Text ="Missouri"},
            new SelectListItem() {Text ="Montana"},
            new SelectListItem() {Text ="Nebraska"},
            new SelectListItem() {Text ="Nevada"},
            new SelectListItem() {Text ="New Hampshire"},
            new SelectListItem() {Text ="New Jersey" },
            new SelectListItem() {Text ="New Mexico"},
            new SelectListItem() {Text ="New York"},
            new SelectListItem() {Text ="North Carolina"},
            new SelectListItem() {Text ="North Dakota"},
            new SelectListItem() {Text ="Ohio" },
            new SelectListItem() {Text ="Oklahoma"},
            new SelectListItem() {Text ="Oregon"},
            new SelectListItem() {Text ="Pennsylvania"},
            new SelectListItem() {Text ="Rhode Island"},
            new SelectListItem() {Text ="South Carolina"},
            new SelectListItem() {Text ="South Dakota"},
            new SelectListItem() {Text ="Tennessee"},
            new SelectListItem() {Text ="Texas"},
            new SelectListItem() {Text ="Utah"},
            new SelectListItem() {Text ="Vermont" },
            new SelectListItem() {Text ="Virginia" },
            new SelectListItem() {Text ="Washington"},
            new SelectListItem() {Text ="West Virginia" },
            new SelectListItem() {Text ="Wisconsin"},
            new SelectListItem() {Text ="Wyoming" }
        };

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
