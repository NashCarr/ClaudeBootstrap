using System;
using DataLayerCommon.Phones;

namespace CommonDataRetrieval.Phones
{
    public class PhoneViewModel : IDisposable
    {
        public PhoneViewModel()
        {
            FaxPhone = new PhoneAssociation();
            CellPhone = new PhoneAssociation();
            HomePhone = new PhoneAssociation();
            WorkPhone = new PhoneAssociation();
            PhoneSettings = new PhoneSetting();
        }

        public PhoneAssociation FaxPhone { get; set; }
        public PhoneAssociation CellPhone { get; set; }
        public PhoneAssociation HomePhone { get; set; }
        public PhoneAssociation WorkPhone { get; set; }
        public PhoneSetting PhoneSettings { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
            FaxPhone = null;
            CellPhone = null;
            HomePhone = null;
            WorkPhone = null;
            PhoneSettings = null;
        }
    }
}