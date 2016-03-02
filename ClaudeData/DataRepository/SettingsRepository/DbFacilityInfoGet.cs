using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ClaudeData.DataRepository.PlaceRepository;
using ClaudeData.Models.Lists.Settings;
using ClaudeData.Models.Places;
using ClaudeData.ViewModels.Settings;
using static ClaudeCommon.Enums.PlaceEnums;

namespace ClaudeData.DataRepository.SettingsRepository
{
    public class DbFacilityInfoGet : DbGetBase
    {
        public List<FacilityInfo> GetActiveRecords()
        {
            SetConnectToDatabase("[ViewModel].[usp_Settings_FacilityList]");

            return LoadList();
        }

        public List<FacilityInfo> GetInactiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_Facility_GetInactive]");

            return LoadList();
        }

        public FacilityView GetRecord(int recordId)
        {
            PlaceData p;

            using (DbPlaceDataGet a = new DbPlaceDataGet())
            {
                p = a.GetFacilityData(recordId);
            }

            using (DbPlaceDataStub a = new DbPlaceDataStub())
            {
                p = a.Prefill(PlaceType.Facility, p);
            }

            FacilityView m = new FacilityView
            {
                Place = p.Place,
                Addresses =
                {
                    MailingAddress = p.AddressData.MailingAddress,
                    ShippingAddress = p.AddressData.PhysicalAddress
                },
                Phones =
                {
                    FaxPhone = p.PhoneData.FaxPhone,
                    CellPhone = p.PhoneData.CellPhone,
                    HomePhone = p.PhoneData.HomePhone,
                    WorkPhone = p.PhoneData.WorkPhone,
                    PhoneSettings = p.PhoneData.PhoneSettings
                }
            };

            return m;
        }

        public List<FacilityInfo> GetRecords()
        {
            return GetRecords(0);
        }

        private List<FacilityInfo> GetRecords(int placeId)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_Facility_Get]");

                CmdSql.Parameters.Add("@FacilityId", SqlDbType.Int).Value = placeId;

                return LoadList();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<FacilityInfo>();
            }
        }

        private List<FacilityInfo> LoadList()
        {
            List<FacilityInfo> data = new List<FacilityInfo>();
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

                            int ordName = dr.GetOrdinal("Name");
                            int ordPlaceId = dr.GetOrdinal("PlaceId");
                            int ordDivision = dr.GetOrdinal("Division");
                            int ordDepartment = dr.GetOrdinal("Department");

                            while (dr.Read())
                            {
                                FacilityInfo item = new FacilityInfo
                                {
                                    Name = Convert.ToString(dr[ordName]),
                                    PlaceId = Convert.ToInt32(dr[ordPlaceId]),
                                    Division = Convert.ToString(dr[ordDivision]),
                                    Department = Convert.ToString(dr[ordDepartment])
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