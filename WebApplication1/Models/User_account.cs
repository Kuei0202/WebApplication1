using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class User_account
    {
        [Key]
        public int ID { get; set; }
        public string? Account { get; set; }
        public string? Password { get; set; }
    }
    public class Temp_User_Data
    {
        public string? Account { get; set; }
        public string? Password { get; set; }
        public string? Password2 { get; set; }
    }
}
