using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StringCounterDemo.Data;

namespace StringCounterDemo.Controllers
{
    public class StringsController : Controller
    {
        private readonly DataContext _context;

        public StringsController(DataContext context)
        {
            _context = context;
        }

        // GET: Strings
        public async Task<IActionResult> Index()
        {

              return _context.strings != null ? 
                          View(await _context.strings.ToListAsync()) :
                          Problem("Entity set 'DataContext.strings'  is null.");
        }

        // GET: Strings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.strings == null)
            {
                return NotFound();
            }

            var strings = await _context.strings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (strings == null)
            {
                return NotFound();
            }

            return View(strings);
        }

        // GET: Strings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Strings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InputString,OutputString")] Strings strings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(strings);
                await _context.SaveChangesAsync();
                return GetViewStrings();
            }
            return View(strings);
        }

        // GET: Strings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.strings == null)
            {
                return NotFound();
            }

            var strings = await _context.strings.FindAsync(id);
            if (strings == null)
            {
                return NotFound();
            }
            return View(strings);
        }

        // POST: Strings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InputString,OutputString")] Strings strings)
        {
            if (id != strings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(strings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StringsExists(strings.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
				return GetViewStrings();
			}
            return View(strings);
        }

        // GET: Strings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.strings == null)
            {
                return NotFound();
            }

            var strings = await _context.strings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (strings == null)
            {
                return NotFound();
            }

            return View(strings);
        }

        // POST: Strings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.strings == null)
            {
                return Problem("Entity set 'DataContext.strings'  is null.");
            }
            var strings = await _context.strings.FindAsync(id);
            if (strings != null)
            {
                _context.strings.Remove(strings);
            }
            
            await _context.SaveChangesAsync();
			return GetViewStrings();
		}

        private bool StringsExists(int id)
        {
          return (_context.strings?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public ActionResult GetViewStrings()
        {
            return ViewComponent("Strings", new { Typeof = "viewstrings" });
        }

        public ActionResult GetViewStringInfo(string id)
        {
            return ViewComponent("Strings", new { Typeof = "viewstringinfo", filter1 = id });
        }

		public void UpdateString(string input, string output)
		{
			string sql = "";

			try
			{
				sql = "INSERT INTO Strings (InputString, OutputString) VALUES ('" + input + "','" + output + "')";

				using (SqliteConnection con = new SqliteConnection("Data Source=sqlite.db"))
				{
					using (SqliteCommand cmd = new SqliteCommand(sql, con))
					{
						con.Open();
						SqliteDataReader reader = cmd.ExecuteReader();
					}
				}
			}
			catch (Exception e)
			{
				string error = e.Message;
			}
		}
    }
}
