using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ClaudeCommon.Models.Facility;

namespace ClaudeData.DataRepository.FacilityRepository
{
    public class DbFacilityResourceGet : DbGetBase
    {
        public List<FacilityResource> GetViewModel()
        {
            return LoadRecords(0);
        }

        public List<FacilityResource> GetFacilityViewModel(int facilityId)
        {
            return LoadRecords(facilityId);
        }

        private List<FacilityResource> LoadRecords(int facilityId)
        {
            List<FacilityResource> data = new List<FacilityResource>();
            try
            {
                IdValue = facilityId;
                IdParameter = "@FacilityId";
                SetConnectToDatabase("[Facility].[usp_FacilityResource_GetActive]");
                CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = IdValue;

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

                            int ordName = dr.GetOrdinal("Name");
                            int ordFacilityId = dr.GetOrdinal("FacilityId");
                            int ordLastUpdate = dr.GetOrdinal("LastUpdate");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");
                            int ordFacilityResourceId = dr.GetOrdinal("FacilityResourceId");

                            while (dr.Read())
                            {
                                FacilityResource item = new FacilityResource
                                {
                                    Name = Convert.ToString(dr[ordName]),
                                    FacilityId = Convert.ToInt32(dr[ordFacilityId]),
                                    DisplayOrder = Convert.ToInt16(dr[ordDisplayOrder]),
                                    RecordId = Convert.ToInt32(dr[ordFacilityResourceId]),
                                    StringLastUpdate =
                                        Convert.ToDateTime(dr[ordLastUpdate]).ToString("MM/dd/yyyy hh:mm:ss tt")
                                };
                                item.DisplaySort = item.DisplayOrder.ToString("D3");
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