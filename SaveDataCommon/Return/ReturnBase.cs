using System;

namespace SaveDataCommon.Return
{
    public class ReturnBase
    {
        public ReturnBase()
        {
            Id = 0;
            ErrMsg = string.Empty;
            StringLastUpdate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        }

        public int Id { get; set; }
        public string ErrMsg { get; set; }
        public string StringLastUpdate { get; set; }
    }
}