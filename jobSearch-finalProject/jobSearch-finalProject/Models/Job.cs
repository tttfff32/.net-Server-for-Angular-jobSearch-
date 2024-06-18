using jobSearch_finalProject.Models;

namespace WebApplication1.Models
{
    public class Job
    {
        public int id { get; set; }
        public int hours { get; set; }
        public string jobName { get; set; }
        public string profession { get; set; }
        public string area { get; set; }
        public string requirements { get; set; }
        public bool fromHome{ get; set; }



    }

}
