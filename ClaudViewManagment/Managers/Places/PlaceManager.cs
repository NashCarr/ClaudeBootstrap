using System;
using System.Collections.Generic;
using ClaudeCommon.BaseModels;
using ClaudeCommon.Models;
using ClaudeData.DataRepository.PlacesRepository;
using static ClaudeCommon.Enums.PlaceEnums;

namespace ClaudeViewManagement.Managers.Places
{
    public class PlaceManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public List<Place> GetList(PlaceType pt)
        {
            using (DbPlacesGetActive data = new DbPlacesGetActive())
            {
                return data.GetActive(pt);
            }
        }

        public void SaveDisplayReorder(PlaceType pt, List<DisplayReorder> data)
        {
            //using (DbReorderSave db = new DbReorderSave())
            //{
            //    db.PlaceReorderSave(data);
            //}
        }

        public ReturnBase DeleteRecord(PlaceType pt, int id)
        {
            //using (DbPlaceSave data = new DbPlaceSave())
            //{
            //    return data.(recordId);
            //}
            return null;
        }
    }
}