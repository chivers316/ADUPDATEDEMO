using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using StringCounterDemo.Models;
using Microsoft.Data.Sqlite;

namespace StringCounterDemo.ViewComponents
{
    public class StringsViewComponent : ViewComponent
    {
        public IConfiguration _con;

        public StringsViewComponent(IConfiguration Configuration)
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
                    case "viewstrings":
                        var viewstrings = await GetViewStrings();
                        return View(Typeof, viewstrings);
					case "viewstringinfo":
						var viewstringinfo = await GetViewStringDetails();
						return View(Typeof, viewstringinfo);
					case "backtolist":
						var backtolist = await GetViewStrings();
						return View(Typeof, backtolist);
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

        private async Task<List<Strings>> GetViewStrings()
        {          
            List<Strings> stringList = new List<Strings>();

            string sql = "";
                
            try
            {
                sql = "SELECT Id, InputString, OutputString FROM Strings";

                using (SqliteConnection con = new SqliteConnection("Data Source=sqlite.db"))
                {
                    using (SqliteCommand cmd = new SqliteCommand(sql, con))
                    {
                        con.Open();
                        SqliteDataReader reader = await cmd.ExecuteReaderAsync();

                        while (reader.Read())
                        {
                            Strings NewString = new Strings();
                            NewString.Id = Convert.ToInt32(reader["Id"]);
                            NewString.InputString = Convert.ToString(reader["InputString"]);
                            NewString.OutputString = Convert.ToString(reader["OutputString"]);

                            stringList.Add(NewString);
                        }
                    }
                }
                return stringList;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }

        private async Task<List<StringsInfo>> GetViewStringDetails()
        {
            List<StringsInfo> stringInfoList = new List<StringsInfo>();

            string sql = "";

            try
            {
                sql = "SELECT Id, InputStringResult, OutputStringResult FROM StringsInfo";

                using (SqliteConnection con = new SqliteConnection("Data Source=sqlite.db"))
                {
                    using (SqliteCommand cmd = new SqliteCommand(sql, con))
                    {
                        con.Open();
                        SqliteDataReader reader = await cmd.ExecuteReaderAsync();

                        while (reader.Read())
                        {
                            StringsInfo NewStringInfo = new StringsInfo();
                            NewStringInfo.Id = Convert.ToInt32(reader["Id"]);
                            NewStringInfo.InputStringResult = Convert.ToString(reader["InputStringResult"]);
                            NewStringInfo.OutputStringResult = Convert.ToString(reader["OutputStringResult"]);

                            stringInfoList.Add(NewStringInfo);
                        }
                    }
                }
                return stringInfoList;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }
	}
}
