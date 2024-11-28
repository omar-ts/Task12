using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class DetailController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var persons = _context.Persons.ToList();
            return View(model: persons);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {
            _context.Persons.Add(new()
            {
                Title = person.Title,
                Description = person.Description,
                DeadLine = person.DeadLine
            });
            _context.SaveChanges();
            TempData["Success"] = person.Title;
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var person = _context.Persons.Find(id);
            return View(model: person);
        }
        [HttpPost]
        public IActionResult Edit(Person persone)
        {
            _context.Persons.Update(new()
            {
                Id = persone.Id,
                Title = persone.Title,
                Description = persone.Description,
                DeadLine = persone.DeadLine
            });
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var personns = _context.Persons.Find(id);
            _context.Persons.Remove(personns);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
