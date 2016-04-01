namespace CommonData.Models.SiteConfiguration
{
    public class PasswordRequirement
    {
        public PasswordRequirement()
        {
            MinimumLength = 0;
            ExpirationDays = 0;
            RequireNumber = false;
            PasswordRequirementId = 0;
            RequireMinimumLength = false;
            RequireCapitalLetter = false;
            RequireSpecialCharacter = false;
        }

        public int MinimumLength { get; set; }
        public int ExpirationDays { get; set; }
        public int PasswordRequirementId { get; set; }

        public bool RequireNumber { get; set; }
        public bool RequireMinimumLength { get; set; }
        public bool RequireCapitalLetter { get; set; }
        public bool RequireSpecialCharacter { get; set; }
    }
}