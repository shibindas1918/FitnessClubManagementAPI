using FitnessClubManagementAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FitnessClubManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly DatabaseHelper _dbHelper;

        public MemberController(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [HttpGet("ALL")]
        public IActionResult GetAllMembers()
        {
            var query = "SELECT * FROM Members";
            var result = _dbHelper.ExecuteQuery(query);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddMember(Member member)
        {
            var query = "INSERT INTO Members (Name, Email, Phone, JoinDate, SubscriptionEndDate) VALUES (@Name, @Email, @Phone, @JoinDate, @SubscriptionEndDate)";
            var parameters = new[]
            {
                new SqlParameter("@Name", member.Name),
                new SqlParameter("@Email", member.Email),
                new SqlParameter("@Phone", member.Phone),
                new SqlParameter("@JoinDate", member.JoinDate),
                new SqlParameter("@SubscriptionEndDate", member.SubscriptionEndDate)
            };
            _dbHelper.ExecuteNonQuery(query, parameters);
            return Ok("Member added successfully.");
        }
    }
}
