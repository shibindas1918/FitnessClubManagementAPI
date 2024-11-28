namespace FitnessClubManagementAPI.Data
{
    public class Session
    {
        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public int TrainerId { get; set; }
        public DateTime Schedule { get; set; }
    }
}
