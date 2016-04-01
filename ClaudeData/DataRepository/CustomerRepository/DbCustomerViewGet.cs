﻿using CommonData.Enums;
using DataManagement.DataRepository.PlaceRepository;
using DataManagement.Models.Places;
using DataManagement.ViewModels;

namespace DataManagement.DataRepository.CustomerRepository
{
    public class DbCustomerViewGet : DbGetBase
    {
        public CustomerView GetCustomer(int recordId)
        {
            return SetCustomerView(recordId);
        }

        private static CustomerView SetCustomerView(int recordId)
        {
            PlaceData data;

            using (DbPlaceDataGet a = new DbPlaceDataGet())
            {
                data = a.GetCustomerData(recordId);
            }

            using (DbPlaceDataStub a = new DbPlaceDataStub())
            {
                data = a.Prefill(PlaceEnums.PlaceType.Customer, data);
            }

            CustomerView m = new CustomerView
            {
                Place = data.Place,
                Contacts = data.Contacts,
                Addresses =
                {
                    MailingAddress = data.AddressData.MailingAddress,
                    ShippingAddress = data.AddressData.PhysicalAddress
                },
                Phones =
                {
                    FaxPhone = data.PhoneData.FaxPhone,
                    CellPhone = data.PhoneData.CellPhone,
                    HomePhone = data.PhoneData.HomePhone,
                    WorkPhone = data.PhoneData.WorkPhone,
                    PhoneSettings = data.PhoneData.PhoneSettings
                }
            };

            using (DbCustomerBrandGet a = new DbCustomerBrandGet())
            {
                m.CustomerBrands = a.GetViewModel(recordId);
            }

            return m;
        }
    }
}