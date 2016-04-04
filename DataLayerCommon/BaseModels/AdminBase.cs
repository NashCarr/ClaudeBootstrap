﻿using System.ComponentModel.DataAnnotations;

namespace DataLayerCommon.BaseModels
{
    public abstract class AdminBase : ModelBase
    {
        protected AdminBase()
        {
            RecordId = 0;
            DisplayOrder = 0;
            IsSystem = false;
            Name = string.Empty;
        }

        public string Name { get; set; }
        public int RecordId { get; set; }
        public bool IsSystem { get; set; }

        [Display(Name = "Order")]
        public short DisplayOrder { get; set; }
    }
}