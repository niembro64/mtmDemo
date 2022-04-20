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
      ViewBag.AllActors = _context.Actors.OrderBy(a => a.Name).ToList();
      ViewBag.AllMovies = _context.Movies.OrderBy(a => a.Title).ToList();

      return View();
    }

    [HttpGet("actor/{actId}")]
    public IActionResult OneActor(int actId)
    {
      ViewBag.OneActor = _context.Actors.FirstOrDefault(a => a.ActorId == actId);
      ViewBag.AllActors = _context.Actors.OrderBy(a => a.Name).ToList();
      ViewBag.AllMovies = _context.Movies.OrderBy(a => a.Title).ToList();

      return View();
    }

    public IActionResult Movies()
    {
      ViewBag.AllActors = _context.Actors.OrderBy(a => a.Name).ToList();
      ViewBag.AllMovies = _context.Movies.OrderBy(a => a.Title).ToList();
      return View();
    }
    [HttpGet("movie/{movId}")]
    public IActionResult OneMovie(int movId)
    {
      ViewBag.OneMovie = _context.Movies.FirstOrDefault(a => a.MovieId == movId);
      ViewBag.AllActors = _context.Actors.OrderBy(a => a.Name).ToList();
      ViewBag.AllMovies = _context.Movies.OrderBy(a => a.Title).ToList();

      return View();
    }
    //////////////////////////

    [HttpPost("cast/add")]
    public IActionResult AddCast(Cast newCast)
    {

      _context.Casts.Add(newCast);
      _context.SaveChanges();

      ViewBag.AllActors = _context.Actors.OrderBy(a => a.Name).ToList();
      ViewBag.AllMovies = _context.Movies.OrderBy(a => a.Title).ToList();
      return RedirectToAction("Index");

    }
    [HttpPost("actor/add")]
    public IActionResult AddActor(Actor newActor)
    {
      if (ModelState.IsValid)
      {
        _context.Actors.Add(newActor);
        _context.SaveChanges();

        ViewBag.AllActors = _context.Actors.OrderBy(a => a.Name).ToList();
        ViewBag.AllMovies = _context.Movies.OrderBy(a => a.Title).ToList();
        return RedirectToAction("Index");
      }
      else
      {
        ViewBag.AllActors = _context.Actors.OrderBy(a => a.Name).ToList();
        ViewBag.AllMovies = _context.Movies.OrderBy(a => a.Title).ToList();
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

        ViewBag.AllActors = _context.Actors.OrderBy(a => a.Name).ToList();
        ViewBag.AllMovies = _context.Movies.OrderBy(a => a.Title).ToList();
        return RedirectToAction("Movies");
      }
      else
      {

        ViewBag.AllActors = _context.Actors.OrderBy(a => a.Name).ToList();
        ViewBag.AllMovies = _context.Movies.OrderBy(a => a.Title).ToList();
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
