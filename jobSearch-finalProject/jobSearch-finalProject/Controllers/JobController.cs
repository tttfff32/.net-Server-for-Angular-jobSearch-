using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication1.Models;
using System.Linq;
using System.Text.Json;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        
        public string JsonUrl = "E:/תשפד/Angular/angular-finalProject/New folder/.net-Server-for-Angular-jobSearch-/jobSearch-finalProject/jobSearch-finalProject/data/Jobs.json";

        public string JsonUrlCV = "E:/תשפד/Angular/angular-finalProject/New folder/.net-Server-for-Angular-jobSearch-/jobSearch-finalProject/jobSearch-finalProject/data/myListOfJobs.json";
        public string JsonData { get; set; }
        public List<Job> JobList { get; set; }
        public string JsonDataCV { get; set; }
        public List<Job> JobListCV { get; set; }
        public JobController()
        {

            JsonData = System.IO.File.ReadAllText(JsonUrl);
            JobList = JsonSerializer.Deserialize<List<Job>>(JsonData);
            JsonDataCV = System.IO.File.ReadAllText(JsonUrlCV);
            JobListCV = JsonSerializer.Deserialize<List<Job>>(JsonDataCV);
        }
        [HttpGet("GetAllJobs")]
        public ActionResult GetAllJobs()
        {

            return Ok(JobList);
        }
        [HttpGet("GetAllJobsCV")]
        public ActionResult GetAllJobsCV()
        {

            return Ok(JobListCV);
        }
        [HttpGet("FilterJobs")]
        public ActionResult FilterJobs([FromQuery] string profession)
        {
            if (profession == null)
            {
                return BadRequest("User is null");
            }
            return Ok(JobList.Where(j => j.profession==profession).ToArray<Job>());
        }

        [HttpGet("Filter")]
        public ActionResult Filter([FromQuery] string profession,string area)
        {
            if (profession == null || area ==null)
            {
                return BadRequest("job is null");
            }
            return Ok(JobList.Where(j => j.profession == profession && j.area.Contains(area)).ToArray<Job>());
        }

        [HttpPost("AddJob")]
        public ActionResult AddJob([FromBody] Job newJob)
        {
            JobListCV.Add(newJob);
            string updatedJsonData = JsonSerializer.Serialize(JobListCV);
            System.IO.File.WriteAllText(JsonUrlCV, updatedJsonData);
            return Ok();
        }


        [HttpGet("GetById/{id}")]
        public Job GetById(int id)
        {
            return JobList.FirstOrDefault(c => c.id == id);
        }

        [HttpGet("resetFavoriteJobs")]
        public async Task<IActionResult> ResetFavoriteJobs()
        {
                try
                {
                    await System.IO.File.WriteAllTextAsync(JsonUrlCV, "[]");
                    JsonDataCV = System.IO.File.ReadAllText(JsonUrlCV);
                    JobListCV = JsonSerializer.Deserialize<List<Job>>(JsonDataCV);
                    return Ok("json deleted succesfull");

                 }

                catch (Exception ex)
                 {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
    
    }
}
