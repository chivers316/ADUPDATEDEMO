using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using ADASSESSMENT.Models;
using Microsoft.Data.Sqlite;
using System.Globalization;

namespace ADASSESSMENT.ViewComponents
{
    public class TimeSlotViewComponent : ViewComponent
    {
        public IConfiguration _con;

        public TimeSlotViewComponent(IConfiguration Configuration)
        {
            _con = Configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(
         string Typeof, string filter1, string filter2, string filter3, string filter4, Int16 filter5)
        {
            try
            {
                switch (Typeof)
                {
                    case "viewtimeslotbooking":
                        var viewtimeslotbooking = await GetViewTimeSlotBooking();
                        return View(Typeof, viewtimeslotbooking);
                    default:
                        return new HtmlContentViewComponentResult(new HtmlString("<strong>No detail available<strong>"));
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;

            }
        }

        private async Task<TimeSlot> GetViewTimeSlotBooking()
        {          
            TimeSlot TimeSlots = new TimeSlot();

            string sql = "";
                
            try
            {
                sql = "SELECT * FROM TimeSlots";

                using (SqliteConnection con = new SqliteConnection("Data Source=sqlite.db"))
                {
                    using (SqliteCommand cmd = new SqliteCommand(sql, con))
                    {
                        con.Open();
                        SqliteDataReader reader = await cmd.ExecuteReaderAsync();

                        while (reader.Read())
                        {
                            
                            TimeSlots.Id = Convert.ToInt32(reader["Id"]);
                            
                            //NewTimeSlot.BookedDate = Convert.ToDateTime(reader["BookedDate"]);

                            //DateTime.ParseExact(NewTimeSlot.BookedDate.ToShortDateString(), "M/d/yyyy", CultureInfo.InvariantCulture);

                            TimeSlots.monSlot1 = Convert.ToBoolean(reader["monSlot1"]);

                            TimeSlots.monSlot1String = Convert.ToString(reader["monSlot1String"]);

                            TimeSlots.monSlot2 = Convert.ToBoolean(reader["monSlot2"]);

                            TimeSlots.monSlot2String = Convert.ToString(reader["monSlot2String"]);

                            TimeSlots.monSlot3 = Convert.ToBoolean(reader["monSlot3"]);

                            TimeSlots.monSlot3String = Convert.ToString(reader["monSlot3String"]);

                            TimeSlots.tueSlot1 = Convert.ToBoolean(reader["tueSlot1"]);

                            TimeSlots.tueSlot1String = Convert.ToString(reader["tueSlot1String"]);

                            TimeSlots.tueSlot2 = Convert.ToBoolean(reader["tueSlot2"]);

                            TimeSlots.tueSlot2String = Convert.ToString(reader["tueSlot2String"]);

                            TimeSlots.tueSlot3 = Convert.ToBoolean(reader["tueSlot3"]);

                            TimeSlots.tueSlot3String = Convert.ToString(reader["tueSlot3String"]);

                            TimeSlots.wedSlot1 = Convert.ToBoolean(reader["wedSlot1"]);

                            TimeSlots.wedSlot1String = Convert.ToString(reader["wedSlot1String"]);
                            
                            TimeSlots.wedSlot2 = Convert.ToBoolean(reader["wedSlot2"]);
                            
                            TimeSlots.wedSlot2String = Convert.ToString(reader["wedSlot2String"]);
                            
                            TimeSlots.wedSlot3 = Convert.ToBoolean(reader["wedSlot3"]);
                            
                            TimeSlots.wedSlot3String = Convert.ToString(reader["wedSlot3String"]);
                           
                            TimeSlots.thuSlot1 = Convert.ToBoolean(reader["thuSlot1"]);
                            
                            TimeSlots.thuSlot1String = Convert.ToString(reader["thuSlot1String"]);
                            
                            TimeSlots.thuSlot2 = Convert.ToBoolean(reader["thuSlot2"]);
                            
                            TimeSlots.thuSlot2String = Convert.ToString(reader["thuSlot2String"]);
                            
                            TimeSlots.thuSlot3 = Convert.ToBoolean(reader["thuSlot3"]);
                            
                            TimeSlots.thuSlot3String = Convert.ToString(reader["thuSlot3String"]);
                            
                            TimeSlots.friSlot1 = Convert.ToBoolean(reader["friSlot1"]);
                            
                            TimeSlots.friSlot1String = Convert.ToString(reader["friSlot1String"]);
                            
                            TimeSlots.friSlot2 = Convert.ToBoolean(reader["friSlot2"]);
                            
                            TimeSlots.friSlot2String = Convert.ToString(reader["friSlot2String"]);
                            
                            TimeSlots.friSlot3 = Convert.ToBoolean(reader["friSlot3"]);
                            
                            TimeSlots.friSlot3String = Convert.ToString(reader["friSlot3String"]);
                            
                            TimeSlots.satSlot1 = Convert.ToBoolean(reader["satSlot1"]);
                            
                            TimeSlots.satSlot1String = Convert.ToString(reader["satSlot1String"]);
                            
                            TimeSlots.satSlot2 = Convert.ToBoolean(reader["satSlot2"]);
                            
                            TimeSlots.satSlot2String = Convert.ToString(reader["satSlot2String"]);
                            
                            TimeSlots.satSlot3 = Convert.ToBoolean(reader["satSlot3"]);
                            
                            TimeSlots.satSlot3String = Convert.ToString(reader["satSlot3String"]);
                           
                            TimeSlots.sunSlot1 = Convert.ToBoolean(reader["sunSlot1"]);
                            
                            TimeSlots.sunSlot1String = Convert.ToString(reader["sunSlot1String"]);
                            
                            TimeSlots.sunSlot2 = Convert.ToBoolean(reader["sunSlot2"]);
                            
                            TimeSlots.sunSlot2String = Convert.ToString(reader["sunSlot2String"]);
                           
                            TimeSlots.sunSlot3 = Convert.ToBoolean(reader["sunSlot3"]);
                            
                            TimeSlots.sunSlot3String = Convert.ToString(reader["sunSlot3String"]);
                            
                            TimeSlots.SlotBooked = Convert.ToString(reader["SlotBooked"]);
                        }
                    }
                }
                return TimeSlots;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }


    }
}
