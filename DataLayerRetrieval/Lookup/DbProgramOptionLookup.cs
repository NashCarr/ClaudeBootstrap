﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataLayerCommon.Administration;
using DataLayerCommon.LookupLists;
using DataLayerRetrieval.Administration;

namespace DataLayerRetrieval.Lookup
{
    public class DbProgramOptionLookup : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ProgramOptionLookupList GetLookUpList(string msgPrompt)
        {
            ProgramOptionLookupList lu = new ProgramOptionLookupList();
            lu.LookupList.Add(new SelectListItem {Value = "0", Text = msgPrompt});

            List<ProgramOption> data;

            using (DbProgramOptionGet db = new DbProgramOptionGet())
            {
                data = db.GetActiveRecords();
            }

            if (data.Count == 0)
            {
                return lu;
            }

            foreach (ProgramOption t in data)
            {
                lu.LookupList.Add(new SelectListItem {Value = t.RecordId.ToString(), Text = t.Name});
            }
            data.Clear();

            return lu;
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}