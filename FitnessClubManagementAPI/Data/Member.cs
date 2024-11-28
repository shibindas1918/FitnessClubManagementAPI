namespace FitnessClubManagementAPI.Data
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
    }
}
