using System;

namespace ClaudeData.BaseModels
{
    public abstract class ModelBase
    {
        protected ModelBase()
        {
            IsActive = true;
            ErrMsg = string.Empty;
            CreateDate = DateTime.Now;
        }

        public bool IsActive { get; set; }
        public string ErrMsg { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}