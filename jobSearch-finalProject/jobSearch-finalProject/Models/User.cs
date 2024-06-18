using jobSearch_finalProject.Models;

namespace API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string profession { get; set; }
    }
}