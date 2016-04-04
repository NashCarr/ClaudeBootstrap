namespace DataRetrievalCommon.Assessor
{
    public class TrainedPanelAssessor
    {
        public TrainedPanelAssessor()
        {
            RecordId = 0;
            PersonId = 0;
            YtdVisits = 0;
            YtdIncome = 0;
            PrimaryPhone = 0;
            Email = string.Empty;
            UserId = string.Empty;
            UserName = string.Empty;
            LastName = string.Empty;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            StringLastParticipated = string.Empty;
        }

        public int RecordId { get; set; }
        public int PersonId { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }

        public long PrimaryPhone { get; set; }

        public int YtdVisits { get; set; }
        public decimal YtdIncome { get; set; }

        public string StringLastParticipated { get; set; }

        public string FullName => ((FirstName + ' ' + MiddleName).Trim() + ' ' + LastName).Trim();
    }
}