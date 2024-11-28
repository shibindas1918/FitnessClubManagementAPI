
using FitnessClubManagementAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FitnessClubManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly DatabaseHelper _dbHelper;

        public TrainerController(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            var query = "SELECT * FROM Trainers";
            var result = _dbHelper.ExecuteQuery(query);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddMember(Trainer member)
        {
            var query = "INSERT INTO Trainers (Name, Specialization) VALUES (@Name, @Specialization)";
            var parameters = new[]
            {
                new SqlParameter("@Name", member.Name),
                new SqlParameter("@Email", member.Specialization),
         
            };
            _dbHelper.ExecuteNonQuery(query, parameters);

            return Ok("Trainer added successfully.");
        }
    }
}
