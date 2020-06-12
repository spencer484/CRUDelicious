using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;
namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }


        [HttpGet("")]
        public ViewResult Index()
        {
            List<Dish> AllDishes = dbContext.Dishes.ToList();
            return View("Index", AllDishes);
        }


        [HttpGet("NewDish")]
        public ViewResult NewDish()
        {
            return View("NewDish");
        }


        [HttpPost("dishes/create")]
        public IActionResult CreateDish(Dish FromForm)
        {
            if (ModelState.IsValid)
            {
                dbContext.Dishes.Add(FromForm);
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View("NewDish", FromForm);
            }
        }

        [HttpGet("dishes/info/{DishId}")]
        public ViewResult DishInfo(int DishId)
        {
            // get Dish from database with the id passed in from url (DishId)

            Dish ToShow = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == DishId);
            // render the view, using the Dish object from previous step
            return View("DishInfoPage", ToShow);
        }

        [HttpGet("dishes/edit/{DishId}")]
        public ViewResult EditDish(int DishId)
        {
            Dish ToEdit = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == DishId);
            return View("EditDishPage", ToEdit);
        }

        [HttpPost("dishes/update/{DishId}")]
        public IActionResult UpdateDish(int DishId, Dish FromForm)
        {
            if (ModelState.IsValid)
            {
                FromForm.DishId = DishId;
                dbContext.Update(FromForm);
                dbContext.Entry(FromForm).Property("CreatedAt").IsModified = false;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditDish", DishId);
            }
        }

        [HttpGet("dishes/delete/{DishId}")]
        public RedirectToActionResult DeleteDish(int DishId)
        {
            Dish ToDelete = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == DishId);
            dbContext.Remove(ToDelete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


















        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
