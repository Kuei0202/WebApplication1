using Microsoft.Data.SqlClient;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Calendar_Table
    {
        [Key]
        public int ID { get; set; }
        public DateTime Item_Date { get; set; } 
        public string? Item_Content { get; set; }
        public DateTime Create_Date { get; set; }
        public string? Create_User { get; set; }
    }
    
}
