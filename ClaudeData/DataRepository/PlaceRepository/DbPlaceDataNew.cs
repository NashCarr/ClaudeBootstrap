using System;
using System.Collections.Generic;
using System.Linq;
using ClaudeData.Models.Addresses;
using ClaudeData.Models.Phones;
using ClaudeData.Models.Places;
using static ClaudeCommon.Enums.AddressEnums;
using static ClaudeCommon.Enums.PhoneEnums;
using static ClaudeCommon.Enums.PlaceEnums;

namespace ClaudeData.DataRepository.PlaceRepository
{
    public class DbPlaceDataNew : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected internal PlaceData GetNew(PlaceType placeType)
        {
            PlaceData data = new PlaceData();
            try
            {
                data.Place = new Place
                {
                    PlaceType = placeType
                };

                data.AddressData = new AddressData {Addresses = new List<AddressAssociation>()};

                foreach (
                    AddressAssociation aa in
                        from AddressType val in Enum.GetValues(typeof (AddressType))
                        where (short) val != 0
                        select new AddressAssociation {AddressType = val})
                {
                    data.AddressData.Addresses.Add(aa);
                }

                data.PhoneData = new PhoneData {Phones = new List<PhoneAssociation>()};

                foreach (
                    PhoneAssociation pa in
                        from PhoneType val in Enum.GetValues(typeof (PhoneType))
                        where (short) val != 0
                        select new PhoneAssociation {PhoneType = val})
                {
                    data.PhoneData.Phones.Add(pa);
                }
            }
            catch (Exception ex)
            {
                data.Place = new Place {ErrMsg = ex.ToString()};
            }
            return data;
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}