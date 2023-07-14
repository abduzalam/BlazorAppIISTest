using System.ComponentModel.DataAnnotations;

namespace BlazorAppIISTest.Model
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }
        public string? Person_ID { get; set; }
        public string? WindowsLogin { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }
        public bool Active { get; set; }
    }
}
