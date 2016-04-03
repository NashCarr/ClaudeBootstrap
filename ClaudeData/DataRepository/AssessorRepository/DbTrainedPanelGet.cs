using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CommonData.Models.Assessor;
using DataLayerRetrieval;

namespace DataManagement.DataRepository.AssessorRepository
{
    public class DbTrainedPanelGet : DbGetBase
    {
        public List<TrainedPanel> GetViewModel()
        {
            return LoadRecords(0);
        }

        public List<TrainedPanel> GetViewModel(int facilityId)
        {
            return LoadRecords(facilityId);
        }

        private List<TrainedPanel> LoadRecords(int facilityId)
        {
            List<TrainedPanel> data = new List<TrainedPanel>();
            try
            {
                SetConnectToDatabase("[TrainedPanel].[usp_GetActive]");
                CmdSql.Parameters.Add("@FacilityId", SqlDbType.Int).Value = facilityId;
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
                            int ordFacilityName = dr.GetOrdinal("FacilityName");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");
                            int ordTrainedPanelId = dr.GetOrdinal("TrainedPanelId");
                            int ordExcludeFromConsumerTesting = dr.GetOrdinal("ExcludeFromConsumerTesting");

                            while (dr.Read())
                            {
                                TrainedPanel item = new TrainedPanel
                                {
                                    Name = Convert.ToString(dr[ordName]),
                                    FacilityId = Convert.ToInt32(dr[ordFacilityId]),
                                    RecordId = Convert.ToInt32(dr[ordTrainedPanelId]),
                                    DisplayOrder = Convert.ToInt16(dr[ordDisplayOrder]),
                                    FacilityName = Convert.ToString(dr[ordFacilityName]),
                                    ExcludeFromConsumerTesting = Convert.ToBoolean(ordExcludeFromConsumerTesting),
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