using CrudApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Controllers
{
    public class RecordsController : Controller
    {
        private readonly AppDbContext _context;

        public RecordsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var records = _context.Records.ToList();
            return View(records);
        }

        [HttpPost]
        public IActionResult Create(Record record)
        {
            if (ModelState.IsValid)
            {
                _context.Records.Add(record);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(record);
        }

        [HttpPost]
        public IActionResult Edit(Record record)
        {
            if (ModelState.IsValid)
            {
                _context.Records.Update(record);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(record);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var record = _context.Records.Find(id);
            if (record != null)
            {
                _context.Records.Remove(record);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
