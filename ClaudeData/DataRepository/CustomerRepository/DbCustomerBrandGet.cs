﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ClaudeCommon.Models.Customer;

namespace ClaudeData.DataRepository.CustomerRepository
{
    public class DbCustomerBrandGet : DbGetBase
    {
        public List<CustomerBrand> GetViewModel(int customerId)
        {
            return LoadRecords(customerId);
        }

        private List<CustomerBrand> LoadRecords(int customerId)
        {
            List<CustomerBrand> data = new List<CustomerBrand>();
            try
            {
                IdValue = customerId;
                IdParameter = "@CustomerId";
                SetConnectToDatabase("[ViewModel].[usp_CustomerBrand_GetActive]");
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
                            int ordLastUpdate = dr.GetOrdinal("LastUpdate");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");
                            int ordCustomerBrandId = dr.GetOrdinal("CustomerBrandId");

                            while (dr.Read())
                            {
                                CustomerBrand item = new CustomerBrand
                                {
                                    CustomerId = customerId,
                                    Name = Convert.ToString(dr[ordName]),
                                    RecordId = Convert.ToInt32(dr[ordCustomerBrandId]),
                                    DisplayOrder = Convert.ToInt16(dr[ordDisplayOrder]),
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