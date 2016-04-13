using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataRetrieval.People;

namespace CommonDataRetrieval.Assessor
{
    public class AssessorView : IDisposable
    {
        public AssessorView()
        {
            Income = new IncomeInfo();
            Status = new StatusInfo();
            Assessor = new PersonView();
            Events = new List<EventInfo>();
            Panels = new List<SelectList>();
            Calls = new List<CallHistory>();
            Notes = new List<AssessorNote>();
            Emails = new List<EmailHistory>();
            Schedule = new List<SelectList>();
            Household = new List<HouseholdInfo>();
            Participation = new ParticipationInfo();
            Questionnaires = new List<ProfileInfo>();
        }

        public IncomeInfo Income { get; set; }
        public StatusInfo Status { get; set; }
        public PersonView Assessor { get; set; }
        public List<EventInfo> Events { get; set; }
        public List<SelectList> Panels { get; set; }
        public List<CallHistory> Calls { get; set; }
        public List<AssessorNote> Notes { get; set; }
        public List<EmailHistory> Emails { get; set; }
        public List<SelectList> Schedule { get; set; }
        public List<HouseholdInfo> Household { get; set; }
        public ParticipationInfo Participation { get; set; }
        public List<ProfileInfo> Questionnaires { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
            Assessor?.Dispose();
            Panels?.Clear();
            Schedule?.Clear();

            Status = null;
            Panels = null;
            Assessor = null;
            Schedule = null;
        }
    }
}