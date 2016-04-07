using System.ComponentModel.DataAnnotations;

namespace DataLayerCommon.BaseModels
{
    public abstract class AdminBase
    {
        protected AdminBase()
        {
            RecordId = 0;
            DisplayOrder = 0;
            IsSystem = false;
            Name = string.Empty;
            ErrMsg = string.Empty;
        }

        public string Name { get; set; }
        public int RecordId { get; set; }
        public bool IsSystem { get; set; }
        public string ErrMsg { get; set; }

        [Display(Name = "Order")]
        public short DisplayOrder { get; set; }
    }
}