using System;
using System.Collections.Generic;
using System.Data;
using CommonDataSave.DisplayReorder;

namespace DataLayerReorder
{
    public class DbReorderSave : DbReorder
    {
        public void FacilityReorderSave(List<DisplayReorder> data)
        {
            DisplayReorder("[Facility].[usp_DisplayReorder]", data);
        }

        public void CustomerReorderSave(List<DisplayReorder> data)
        {
            DisplayReorder("[Customer].[usp_DisplayReorder]", data);
        }

        public void GiftCardReorderSave(List<DisplayReorder> data)
        {
            DisplayReorder("[GiftCard].[usp_DisplayReorder]", data);
        }

        public void HearAboutUsReorderSave(List<DisplayReorder> data)
        {
            DisplayReorder("[HearAboutUs].[usp_DisplayReorder]", data);
        }

        public void TestTypeReorderSave(List<DisplayReorder> data)
        {
            DisplayReorder("[TestType].[usp_DisplayReorder]", data);
        }

        public void ProductGroupReorderSave(List<DisplayReorder> data)
        {
            DisplayReorder("[ProductGroup].[usp_DisplayReorder]", data);
        }

        public void TrainedPanelReorderSave(List<DisplayReorder> data)
        {
            DisplayReorder("[TrainedPanel].[usp_DisplayReorder]", data);
        }

        public void OrganizationReorderSave(List<DisplayReorder> data)
        {
            DisplayReorder("[Organization].[usp_DisplayReorder]", data);
        }

        public void CustomerBrandReorderSave(List<DisplayReorder> data)
        {
            DisplayReorder("[CustomerBrand].[usp_DisplayReorder]", data);
        }

        public void BudgetCategoryReorderSave(List<DisplayReorder> data)
        {
            DisplayReorder("[BudgetCategory].[usp_DisplayReorder]", data);
        }

        public void FacilityResourceReorderSave(List<DisplayReorder> data)
        {
            DisplayReorder("[FacilityResource].[usp_DisplayReorder]", data);
        }

        private void DisplayReorder(string storedProcedure, List<DisplayReorder> data)
        {
            //DataOrder dOrders = new DataOrder();
            //dOrders.AddRange(
            //    data.Select(item => new DisplayReorder { Id = item.Id, DisplayOrder = item.DisplayOrder }));

            DataTable dOrder = ConvertToDatatable(data);
            try
            {
                SetConnectToDatabase(storedProcedure);

                CmdSql.Parameters.Add("@DisplayOrder", SqlDbType.Structured).Value = dOrder;

                SetErrMsgParameter();

                SendNonQuery();

                dOrder.Clear();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
        }
    }
}