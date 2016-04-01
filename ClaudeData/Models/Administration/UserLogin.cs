using DataManagement.BaseModels;

namespace DataManagement.Models.Administration
{
    public class UserLogin : ModelBase
    {
        public UserLogin()
        {
            PersonId = 0;
            UserIndex = 0;
            PersonType = 0;
            UserLoginId = 0;
            Pin = string.Empty;
            UserId = string.Empty;
            PinHint = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
        }

        public string Pin { get; set; }
        public int PersonId { get; set; }
        public int UserIndex { get; set; }
        public string UserId { get; set; }
        public string PinHint { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserLoginId { get; set; }
        public short PersonType { get; set; }
    }
}