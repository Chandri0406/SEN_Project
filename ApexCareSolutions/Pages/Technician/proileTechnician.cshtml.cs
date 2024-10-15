using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;

namespace ApexCareSolutions.Pages.Technician
{
    public class proileTechnicianModel : PageModel
    {
        public List<Feedback> feedbacks =new List<Feedback>();
        public double averageRating = 0;
        private readonly string? _connectionString;

        //Ask David about this shit
        public int contractCount = GetTotalContracts();
        public int serviceAgentCount = GetTotalServiceAgents();
        public int technicianCount = 0;

        public void OnGet()
        {
            DBConnection dbt = new DBConnection();
            var totalTechnicians = dbt.GetTotalTechnicians();   

            DBConnection dbs = new DBConnection();
            var totalServiceAgents = dbs.GetTotalServiceAgents();

            DBConnection dbc = new DBConnection();
            var totalContracts = dbc.GetTotalContracts();

            DBConnection db = new DBConnection();
            var feedbacks = db.GetFeedbacks();

            int sumOfRatings = 0;
            int totalFeedbacks = feedbacks.Count;

            foreach (var feedback in feedbacks)
            {
                sumOfRatings += feedback.Rating;
            }

            //Here is an example of some validation
            //it checks to see that it is more than zero to avoid dividing by zero
            averageRating = totalFeedbacks > 0 ? (double)sumOfRatings / totalFeedbacks : 0;
        }
    }
}
