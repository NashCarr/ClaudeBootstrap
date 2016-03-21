namespace ClaudeCommon.Models.People
{
    public class PersonList
    {
        public PersonList()
        {
            PersonId = 0;
            DisplayOrder = 0;
            Email = string.Empty;
            FullName = string.Empty;
            DisplaySort = string.Empty;
            PrimaryPhone = string.Empty;
        }

        public int PersonId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string DisplaySort { get; set; }
        public short DisplayOrder { get; set; }
        public string PrimaryPhone { get; set; }
    }
}