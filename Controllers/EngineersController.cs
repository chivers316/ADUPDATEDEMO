using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ADASSESSMENT.Data;
using ADASSESSMENT.Models;
using Microsoft.Data.SqlClient;
using System.Drawing;
using Microsoft.Data.Sqlite;
using System.Data;

namespace ADASSESSMENT.Controllers
{
    public class EngineersController : Controller
    {
        private readonly DataContext _context;

        public IConfiguration _con;

        public EngineersController(DataContext context)
        {
            _context = context;
        }

        // GET: Engineers
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Engineers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Engineers == null)
            {
                return NotFound();
            }

            var engineer = await _context.Engineers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (engineer == null)
            {
                return NotFound();
            }

            return View(engineer);
        }

        // GET: Engineers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Engineers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,EmailAddress,ContactNumber,Date,VRN,Comments,EngineerId,AddressId,TimeSlotId,JobCategoryId")] Engineer engineer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(engineer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(engineer);
        }

        // GET: Engineers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Engineers == null)
            {
                return NotFound();
            }

            var engineer = await _context.Engineers.FindAsync(id);
            if (engineer == null)
            {
                return NotFound();
            }
            return View(engineer);
        }

        // POST: Engineers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,EmailAddress,ContactNumber,Date,VRN,Comments,EngineerId,AddressId,TimeSlotId,JobCategoryId")] Engineer engineer)
        {
            if (id != engineer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(engineer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EngineerExists(engineer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(engineer);
        }

        // GET: Engineers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Engineers == null)
            {
                return NotFound();
            }

            var engineer = await _context.Engineers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (engineer == null)
            {
                return NotFound();
            }

            return View(engineer);
        }

        // POST: Engineers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Engineers == null)
            {
                return Problem("Entity set 'DataContext.Engineers'  is null.");
            }
            var engineer = await _context.Engineers.FindAsync(id);
            if (engineer != null)
            {
                _context.Engineers.Remove(engineer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EngineerExists(int id)
        {
            return _context.Engineers.Any(e => e.Id == id);
        }


        public List<Address> GetAddresses()
        {
            List<Address> Addresses = new List<Address>();
            string sql = "";
            try
            {
                sql = "SELECT Id, FirstLine, SecondLine, ThirdLine, City, PostCode From Addresses";

                using (SqliteConnection con = new SqliteConnection("Data Source=sqlite.db"))
                {
                    using (SqliteCommand cmd = new SqliteCommand(sql, con))
                    {
                        con.Open();
                        SqliteDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Address NewAddress = new Address();
                            NewAddress.Id = Convert.ToInt32(reader["Id"]);
                            NewAddress.FirstLine = Convert.ToString(reader["FirstLine"]);
                            NewAddress.SecondLine = Convert.ToString(reader["SecondLine"]);
                            NewAddress.ThirdLine = Convert.ToString(reader["ThirdLine"]);
                            NewAddress.City = Convert.ToString(reader["City"]);
                            NewAddress.PostCode = Convert.ToString(reader["PostCode"]);

                            Addresses.Add(NewAddress);
                        }
                    }
                }
                return Addresses;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }

        public ActionResult GetViewEnginner(string id)
        {
            return ViewComponent("Engineer", new { Typeof = "viewengineer", filter1 = id });
        }

        public ActionResult GetViewEngineerDetails(string id)
        {
            return ViewComponent("Engineer", new { Typeof = "viewengineerdetails", filter1 = id });
        }
    }
}