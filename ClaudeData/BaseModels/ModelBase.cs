using System;
using System.Globalization;

namespace ClaudeData.BaseModels
{
    public abstract class ModelBase
    {
        protected ModelBase()
        {
            IsActive = true;
            ErrMsg = string.Empty;
            CreateDate = DateTime.Now;
            StringCreateDate = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }

        public bool IsActive { get; set; }
        public string ErrMsg { get; set; }
        public string StringCreateDate { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}