using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ADASSESSMENT.Data;
using ADASSESSMENT.Models;

namespace ADASSESSMENT.Controllers
{
    public class TimeSlotsController : Controller
    {
        private readonly DataContext _context;

        public TimeSlotsController(DataContext context)
        {
            _context = context;
        }

        public ActionResult GetViewTimeSlots()
        {
            return ViewComponent("TimeSlot", new { Typeof = "viewtimeslotbooking" });
        }
    }
}
