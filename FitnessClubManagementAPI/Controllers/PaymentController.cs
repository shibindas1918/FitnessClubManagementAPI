
using FitnessClubManagementAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FitnessClubManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly DatabaseHelper _dbHelper;

        public PaymentController(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            var query = "SELECT * FROM Payments";
            var result = _dbHelper.ExecuteQuery(query);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddMember(Payment member)
        {
            var query = "INSERT INTO Payments (MemberId, Amount,PaymentDate) VALUES (@MemberId, @Amount,@PaymentDate)";
            var parameters = new[]
            {
                new SqlParameter("@MemberId", member.MemberId),
                new SqlParameter("@Amount", member.Amount),
                new SqlParameter("@PaymentDate",member.PaymentDate)

            };
            _dbHelper.ExecuteNonQuery(query, parameters);

            return Ok("Payments added successfully.");
        }
    }
}
