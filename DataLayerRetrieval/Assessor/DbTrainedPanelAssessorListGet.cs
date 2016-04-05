using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CommonDataRetrieval.Assessor;

namespace DataLayerRetrieval.Assessor
{
    public class DbTrainedPanelAssessorListGet : DbGetBase
    {
        public List<TrainedPanelAssessor> GetViewModel(int trainedPanelId)
        {
            return LoadRecords(trainedPanelId);
        }

        private List<TrainedPanelAssessor> LoadRecords(int trainedPanelId)
        {
            List<TrainedPanelAssessor> data = new List<TrainedPanelAssessor>();
            try
            {
                SetConnectToDatabase("[TrainedPanelAssessor].[usp_GetList]");
                CmdSql.Parameters.Add("@TrainedPanelId", SqlDbType.Int).Value = trainedPanelId;
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

                            int ordEmail = dr.GetOrdinal("Email");
                            int ordUserId = dr.GetOrdinal("UserId");
                            int ordUserName = dr.GetOrdinal("UserName");
                            int ordPersonId = dr.GetOrdinal("PersonId");
                            int ordLastName = dr.GetOrdinal("LastName");
                            int ordFirstName = dr.GetOrdinal("FirstName");
                            int ordYtdAmount = dr.GetOrdinal("YTDAmount");
                            int ordMiddleName = dr.GetOrdinal("MiddleName");
                            int ordCompletions = dr.GetOrdinal("Completions");
                            int ordPrimaryPhone = dr.GetOrdinal("PrimaryPhone");
                            int ordLastParticipation = dr.GetOrdinal("LastParticipation");
                            int ordTrainedPanelAssessorId = dr.GetOrdinal("TrainedPanelAssessorId");

                            while (dr.Read())
                            {
                                TrainedPanelAssessor item = new TrainedPanelAssessor
                                {
                                    Email = Convert.ToString(dr[ordEmail]),
                                    UserId = Convert.ToString(dr[ordUserId]),
                                    PersonId = Convert.ToInt32(dr[ordPersonId]),
                                    UserName = Convert.ToString(dr[ordUserName]),
                                    LastName = Convert.ToString(dr[ordLastName]),
                                    FirstName = Convert.ToString(dr[ordFirstName]),
                                    YtdVisits = Convert.ToInt32(dr[ordCompletions]),
                                    YtdIncome = Convert.ToDecimal(dr[ordYtdAmount]),
                                    MiddleName = Convert.ToString(dr[ordMiddleName]),
                                    PrimaryPhone = Convert.ToInt64(dr[ordPrimaryPhone]),
                                    RecordId = Convert.ToInt32(dr[ordTrainedPanelAssessorId]),
                                    StringLastParticipated = dr[ordLastParticipation] == DBNull.Value
                                        ? string.Empty
                                        : Convert.ToDateTime(dr[ordLastParticipation])
                                            .ToString("MM/dd/yyyy hh:mm:ss tt")
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