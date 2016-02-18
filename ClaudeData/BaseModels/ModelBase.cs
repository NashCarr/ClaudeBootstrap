using System;
using static System.DateTime;

namespace ClaudeData.BaseModels
{
    public abstract class ModelBase
    {
        protected ModelBase()
        {
            IsActive = true;
            ErrMsg = string.Empty;
            CreateDate = Now;
            StringCreateDate = Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        }

        public bool IsActive { get; set; }
        public string ErrMsg { get; set; }
        public string StringCreateDate { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}