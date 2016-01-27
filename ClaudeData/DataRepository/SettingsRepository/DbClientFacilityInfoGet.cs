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
    public class DbClientFacilityInfoGet : DbGetBase
    {
        public List<ClientFacilityInfo> GetActiveRecords()
        {
            SetConnectToDatabase("[ViewModel].[usp_Settings_ClientFacilityList]");

            return LoadList();
        }

        public List<ClientFacilityInfo> GetInactiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_ClientFacility_GetInactive]");

            return LoadList();
        }

        public ClientFacilityView GetRecord(int recordId)
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

            ClientFacilityView m = new ClientFacilityView
            {
                Facility = p.Place,
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

        public List<ClientFacilityInfo> GetRecords()
        {
            return GetRecords(0);
        }

        private List<ClientFacilityInfo> GetRecords(int clientFacilityId)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_ClientFacility_Get]");

                CmdSql.Parameters.Add("@ClientFacilityId", SqlDbType.Int).Value = clientFacilityId;

                return LoadList();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<ClientFacilityInfo>();
            }
        }

        private List<ClientFacilityInfo> LoadList()
        {
            List<ClientFacilityInfo> data = new List<ClientFacilityInfo>();
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
                                ClientFacilityInfo item = new ClientFacilityInfo
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