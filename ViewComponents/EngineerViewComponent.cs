using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using ADASSESSMENT.Models;
using Microsoft.Data.Sqlite;

namespace ADASSESSMENT.ViewComponents
{
    public class EngineerViewComponent : ViewComponent
    {
        public IConfiguration _con;

        public EngineerViewComponent(IConfiguration Configuration)
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
                    case "viewengineer":
                        var viewengineer = await GetViewEngineer();
                        return View(Typeof, viewengineer);
                    case "viewengineerdetails":
                        var viewengineerdetails = GetViewEngineerDetails(filter1);
                        return View(Typeof, viewengineerdetails);
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

        private async Task<List<Engineer>> GetViewEngineer()
        {          
            List<Engineer> EngineerList = new List<Engineer>();

            EngineerInfo engrInfo = new EngineerInfo();

            string sql = "";
                
            try
            {
                sql = "SELECT Id, FirstName, LastName, EmailAddress, ContactNumber, Date, VRN, Comments FROM Engineers";

                using (SqliteConnection con = new SqliteConnection("Data Source=sqlite.db"))
                {
                    using (SqliteCommand cmd = new SqliteCommand(sql, con))
                    {
                        con.Open();
                        SqliteDataReader reader = await cmd.ExecuteReaderAsync();

                        while (reader.Read())
                        {
                            Engineer NewEngineer = new Engineer();
                            NewEngineer.Id = Convert.ToInt32(reader["Id"]);
                            NewEngineer.FirstName = Convert.ToString(reader["FirstName"]);
                            NewEngineer.LastName = Convert.ToString(reader["LastName"]);
                            NewEngineer.EmailAddress = Convert.ToString(reader["EmailAddress"]);
                            NewEngineer.ContactNumber = Convert.ToInt32(reader["ContactNumber"]);
                            NewEngineer.Date = Convert.ToString(reader["Date"]);
                            NewEngineer.VRN = Convert.ToString(reader["VRN"]);
                            NewEngineer.Comments = Convert.ToString(reader["Comments"]);

                            EngineerList.Add(NewEngineer);
                        }
                    }
                }
                return EngineerList;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }



        public EngineerInfo GetViewEngineerDetails(string id)
        {
            //string orderNo = OrderNo.ToString().PadLeft(10, '0');
            List<string> engrAddress = new List<string>();
            List<string> bookedTime = new List<string>();
            List<string> selJobCat = new List<string>();
            string completeEngrAddress = string.Empty;
            string completeBookedTime = string.Empty;
            string completeSelJobCat = string.Empty;

            EngineerInfo EngrInformation = new EngineerInfo();
            
            try
            {
                string sql = "SELECT Addr.Id AS Address_Id, FirstLine AS FirstLine, SecondLine AS SecondLine, ThirdLine AS ThirdLine, " +
                             "City AS City, PostCode AS PostCode, TS.SlotBooked AS SlotBooked, JC.CategorySelected AS CategorySelected " +
                             "FROM Addresses Addr LEFT JOIN TimeSlots TS ON TS.Id = Addr.Id LEFT JOIN JobCategories JC ON JC.Id = Addr.Id " +
                             "WHERE Addr.Id = " + id;

                using (SqliteConnection con = new SqliteConnection("Data Source=sqlite.db"))
                {
                    using (SqliteCommand cmd = new SqliteCommand(sql, con))
                    {
                        con.Open();
                        SqliteDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            engrAddress.Add(reader["FirstLine"] as string);
                            engrAddress.Add(reader["SecondLine"] as string);
                            engrAddress.Add(reader["ThirdLine"] as string);
                            engrAddress.Add(reader["City"] as string);
                            engrAddress.Add(reader["PostCode"] as string);

                            bookedTime.Add(reader["SlotBooked"] as string);

                            selJobCat.Add(reader["CategorySelected"] as string);
                        }
                        foreach (var item in engrAddress)
                        {
                            completeEngrAddress = completeEngrAddress + item + "\r\n";
                        }
                        foreach (var item in bookedTime)
                        {
                            completeBookedTime = completeBookedTime + item + "\r\n";
                        }
                        foreach (var item in selJobCat)
                        {
                            completeSelJobCat = completeSelJobCat + item + "\r\n";
                        }
                    }
                }

                EngrInformation.EngineerAddress = completeEngrAddress;
                EngrInformation.BookedSlot = completeBookedTime;
                EngrInformation.SelectedJob = completeSelJobCat;

                return EngrInformation;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            EngrInformation.EngineerAddress = "";
            EngrInformation.BookedSlot = "";
            EngrInformation.SelectedJob = "";

            return EngrInformation;
        }






    }
}
