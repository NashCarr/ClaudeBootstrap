﻿using DataManagement.BaseModels;

namespace DataManagement.Models.Administration
{
    public class RoleRight : AdminBase
    {
        public RoleRight()
        {
            UserRoleId = 0;
            ProgramOptionId = 0;
        }

        public int UserRoleId { get; set; }
        public int ProgramOptionId { get; set; }
    }
}