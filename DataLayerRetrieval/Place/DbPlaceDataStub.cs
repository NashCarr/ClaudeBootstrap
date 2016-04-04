﻿using System;
using System.Collections.Generic;
using DataLayerCommon.Addresses;
using DataLayerCommon.Enums;
using DataLayerCommon.Phones;
using DataLayerCommon.Places;

namespace DataLayerRetrieval.Place
{
    public class DbPlaceDataStub : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public PlaceData Prefill(PlaceEnums.PlaceType placeType, PlaceData data)
        {
            try
            {
                if (data.Place == null)
                {
                    data.Place = new DataLayerCommon.Places.Place
                    {
                        PlaceType = placeType
                    };
                }

                if (data.AddressData == null)
                {
                    data.AddressData = new AddressData {Addresses = new List<AddressAssociation>()};
                }

                if (data.AddressData.PhysicalAddress == null)
                {
                    AddressAssociation a = new AddressAssociation {AddressType = AddressEnums.AddressType.Physical};
                    data.AddressData.Addresses.Add(a);
                }

                if (data.AddressData.MailingAddress == null)
                {
                    AddressAssociation a = new AddressAssociation {AddressType = AddressEnums.AddressType.Mailing};
                    data.AddressData.Addresses.Add(a);
                }

                if (data.PhoneData == null)
                {
                    data.PhoneData = new PhoneData {Phones = new List<PhoneAssociation>()};
                }

                if (data.PhoneData.HomePhone == null)
                {
                    PhoneAssociation p = new PhoneAssociation {PhoneType = PhoneEnums.PhoneType.Home};
                    data.PhoneData.Phones.Add(p);
                }

                if (data.PhoneData.CellPhone == null)
                {
                    PhoneAssociation p = new PhoneAssociation {PhoneType = PhoneEnums.PhoneType.Cell};
                    data.PhoneData.Phones.Add(p);
                }

                if (data.PhoneData.WorkPhone == null)
                {
                    PhoneAssociation p = new PhoneAssociation {PhoneType = PhoneEnums.PhoneType.Work};
                    data.PhoneData.Phones.Add(p);
                }

                if (data.PhoneData.FaxPhone == null)
                {
                    PhoneAssociation p = new PhoneAssociation {PhoneType = PhoneEnums.PhoneType.Fax};
                    data.PhoneData.Phones.Add(p);
                }
            }
            catch (Exception ex)
            {
                data.Place = new DataLayerCommon.Places.Place {ErrMsg = ex.ToString()};
            }
            return data;
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}