using System;

namespace DataManagement.BaseModels
{
    public abstract class ModelBase
    {
        protected ModelBase()
        {
            IsActive = true;
            CreateDate = DateTime.Now;
            ErrMsg = string.Empty;
            StringLastUpdate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        }

        public bool IsActive { get; set; }
        public string ErrMsg { get; set; }
        public string StringLastUpdate { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}