using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Test.Models;

namespace Test.Controllers
{
    public class UserController : Controller
    {
        public ActionResult List()
        {
            var db = new UserModel();

            var users = db.UserProfiles.ToList();

            if (!users.Any())
            {
                db.UserProfiles.AddRange(SeedData.UserProfilesSeed());
                db.SaveChanges();
            }

            return View(users);
        }


        [Route("Api/Users")]
        public JsonResult GetFilterUsers(string city, string ageSort)
        {
            var db = new UserModel();
            IQueryable<UserProfile> userProfiles = db.UserProfiles;

            if (!city.IsNullOrWhiteSpace())
            {
                userProfiles = userProfiles.Where(profile => profile.City == city);
            }

            if (ageSort?.ToLower() == "asc")
            {
                userProfiles = userProfiles.OrderBy(profile => profile.Age);
            }
            else if (ageSort?.ToLower() == "desc")
            {
                userProfiles = userProfiles.OrderByDescending(profile => profile.Age);
            }

            return Json(userProfiles.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
