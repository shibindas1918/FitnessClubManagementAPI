
using FitnessClubManagementAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FitnessClubManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly DatabaseHelper _dbHelper;

        public SessionsController(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            var query = "SELECT * FROM Sessions";
            var result = _dbHelper.ExecuteQuery(query);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddMember(Session member)
        {
            var query = "INSERT INTO Sessions (SessionName, TrainerId,Schedule) VALUES (@SessionName, @TrainerId,@Schedule)";
            var parameters = new[]
            {
                new SqlParameter("@SessionName", member.SessionName),
                new SqlParameter("@TrainerId", member.TrainerId),
                new SqlParameter("@Schedule",member.Schedule)

            };
            _dbHelper.ExecuteNonQuery(query, parameters);

            return Ok("Sessions added successfully.");
        }
    }
}
