using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace StringCounterDemo.Models
{
    public class Strings
    {
        public int Id { get; set; }
        public string InputString { get; set; } = string.Empty;
        public string OutputString { get; set; } = string.Empty;

   }
}
