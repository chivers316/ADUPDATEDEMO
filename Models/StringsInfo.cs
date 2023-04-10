using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace StringCounterDemo.Models
{
    public class StringsInfo
    {
        public int Id { get; set; }
        public string InputStringResult { get; set; } = string.Empty;
        public string OutputStringResult { get; set; } = string.Empty;

   }
}
