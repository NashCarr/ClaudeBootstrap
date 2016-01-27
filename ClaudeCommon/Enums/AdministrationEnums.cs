using System.ComponentModel;

namespace ClaudeCommon.Enums
{
    public class AdministrationEnums
    {
        public enum DefaultRight : byte
        {
            [Description("None")] N,
            [Description("Read")] R,
            [Description("Write")] W
        }

        public enum PasswordCharacterType : byte
        {
            None,
            UpperLowerNumberSpecialCharacter,
            UpperLowerNumber
        }

        public enum UserType : byte
        {
            None,
            Staff,
            Assessor
        }
    }
}