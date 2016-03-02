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
    public class DbOrganizationInfoGet : DbGetBase
    {
        public List<OrganizationInfo> GetActiveRecords()
        {
            SetConnectToDatabase("[ViewModel].[usp_Settings_OrganizationList]");

            return LoadList();
        }

        public List<OrganizationInfo> GetInactiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_Organization_GetInactive]");

            return LoadList();
        }

        public OrganizationView GetRecord(int recordId)
        {
            PlaceData p;

            using (DbPlaceDataGet a = new DbPlaceDataGet())
            {
                p = a.GetOrganizationData(recordId);
            }

            using (DbPlaceDataStub a = new DbPlaceDataStub())
            {
                p = a.Prefill(PlaceType.Organization, p);
            }

            OrganizationView m = new OrganizationView
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

        public List<OrganizationInfo> GetRecords()
        {
            return GetRecords(0);
        }

        private List<OrganizationInfo> GetRecords(int placeId)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_Organization_Get]");

                CmdSql.Parameters.Add("@OrganizationId", SqlDbType.Int).Value = placeId;

                return LoadList();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<OrganizationInfo>();
            }
        }

        private List<OrganizationInfo> LoadList()
        {
            List<OrganizationInfo> data = new List<OrganizationInfo>();
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
                                OrganizationInfo item = new OrganizationInfo
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