using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mtmDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace mtmDemo.Controllers
{
  public class HomeController : Controller
  {
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
      _logger = logger;
      _context = context;
    }


    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Movies()
    {
      return View();
    }

    //////////////////////////

    [HttpPost("actor/add")]
    public IActionResult AddActor(Actor newActor)
    {
      if (ModelState.IsValid)
      {
        _context.Actors.Add(newActor);
        _context.SaveChanges();
        return RedirectToAction("Index");
      }
      else
      {
        return View("Index");
      }
    }
    [HttpPost("movie/add")]
    public IActionResult AddMovie(Movie newMovie)
    {
      if (ModelState.IsValid)
      {
        _context.Movies.Add(newMovie);
        _context.SaveChanges();
        return RedirectToAction("Movies");
      }
      else
      {
        return View("Movies");
      }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
