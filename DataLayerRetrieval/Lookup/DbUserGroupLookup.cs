using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using CommonDataRetrieval.Administration;

namespace DataLayerRetrieval.Lookup
{
    public class DbUserGroupLookup : DbGetBase
    {
        public List<SelectListItem> GetLookUpList(string msgPrompt)
        {
            List<SelectListItem> lu = new List<SelectListItem> {new SelectListItem {Value = "0", Text = msgPrompt}};

            List<UserGroup> data = LoadRecords();

            if (data.Count == 0)
            {
                return lu;
            }

            lu.AddRange(data.Select(t => new SelectListItem {Value = t.RecordId.ToString(), Text = t.Name}));
            data.Clear();

            return lu;
        }

        private List<UserGroup> LoadRecords()
        {
            List<UserGroup> data = new List<UserGroup>();
            try
            {
                using (ConnSql)
                {
                    ConnSql.Open();
                    using (CmdSql)
                    {
                        using (SqlDataReader dr = CmdSql.ExecuteReader())
                        {
                            if (!dr.HasRows)
                            {
                                return data;
                            }

                            int ordUserRoleId = dr.GetOrdinal("UserRoleId");
                            int ordName = dr.GetOrdinal("Name");

                            while (dr.Read())
                            {
                                UserGroup item = new UserGroup
                                {
                                    RecordId = Convert.ToInt32(dr[ordUserRoleId]),
                                    Name = Convert.ToString(dr[ordName])
                                };
                                data.Add(item);
                            }
                        }
                    }
                    ConnSql.Close();
                }
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
            }
            return data;
        }
    }
}