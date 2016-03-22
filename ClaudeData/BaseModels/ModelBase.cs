using System;
using static System.DateTime;

namespace ClaudeData.BaseModels
{
    public abstract class ModelBase
    {
        protected ModelBase()
        {
            IsActive = true;
            CreateDate = Now;
            ErrMsg = string.Empty;
            StringLastUpdate = Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        }

        public bool IsActive { get; set; }
        public string ErrMsg { get; set; }
        public string StringLastUpdate { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}