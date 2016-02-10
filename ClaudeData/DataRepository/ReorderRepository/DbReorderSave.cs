﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClaudeCommon.BaseModels;

namespace ClaudeData.DataRepository.ReorderRepository
{
    public class DbReorderSave : DbReorder
    {
        //public void StudyDesignReorderSave(IEnumerable<StudyDesign> data)
        //{
        //    DataOrder dOrder = new DataOrder();
        //    dOrder.AddRange(
        //        data.Select(item => new DisplayOrder {Id = item.StudyDesignId, Order = item.DisplayOrder}));

        //    DisplayReorder("[Admin].[usp_StudyDesign_DisplayReorder]", dOrder);
        //}

        //public void BudgetCategoryReorderSave(IEnumerable<BudgetCategory> data)
        //{
        //    DataOrder dOrder = new DataOrder();
        //    dOrder.AddRange(
        //        data.Select(item => new DisplayOrder {Id = item.BudgetCategoryId, Order = item.DisplayOrder}));

        //    DisplayReorder("[Admin].[usp_BudgetCategory_DisplayReorder]", dOrder);
        //}

        //public void CustomerBrandReorderSave(IEnumerable<CustomerBrand> data)
        //{
        //    DataOrder dOrder = new DataOrder();
        //    dOrder.AddRange(
        //        data.Select(item => new DisplayOrder {Id = item.CustomerBrandId, Order = item.DisplayOrder}));

        //    DisplayReorder("[Admin].[usp_CustomerBrand_DisplayReorder]", dOrder);
        //}

        //public void FacilityResourceReorderSave(IEnumerable<FacilityResource> data)
        //{
        //    DataOrder dOrder = new DataOrder();
        //    dOrder.AddRange(
        //        data.Select(item => new DisplayOrder {Id = item.FacilityResourceId, Order = item.DisplayOrder}));

        //    DisplayReorder("[Admin].[usp_FacilityResource_DisplayReorder]", dOrder);
        //}

        public void GiftCardReorderSave(List<DisplayReorder> data)
        {
            DisplayReorder("[Admin].[usp_GiftCard_DisplayReorder]", data);
        }

        //public void HearAboutUsReorderSave(IEnumerable<HearAboutUs> data)
        //{
        //    DataOrder dOrder = new DataOrder();
        //    dOrder.AddRange(
        //        data.Select(item => new DisplayOrder {Id = item.HearAboutUsId, Order = item.DisplayOrder}));

        //    DisplayReorder("[Admin].[usp_HearAboutUs_DisplayReorder]", dOrder);
        //}

        //public void ProductGroupReorderSave(IEnumerable<ProductGroup> data)
        //{
        //    DataOrder dOrder = new DataOrder();
        //    dOrder.AddRange(
        //        data.Select(item => new DisplayOrder {Id = item.ProductGroupId, Order = item.DisplayOrder}));

        //    DisplayReorder("[Admin].[usp_ProductGroup_DisplayReorder]", dOrder);
        //}

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