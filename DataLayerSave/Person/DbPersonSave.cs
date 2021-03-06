﻿using System;
using System.Data;
using CommonDataReturn;
using DataLayerCommon.People;
using DataLayerSave.Addresses;
using DataLayerSave.Facility;
using DataLayerSave.Phones;
using static CommonData.Enums.PersonEnums;

namespace DataLayerSave.Person
{
    public class DbPersonSave : DbSaveBase
    {
        private ReturnBase AddUpdatePerson(ref PersonBase data)
        {
            try
            {
                ReturnValues.Id = data.PersonId;
                IdParameter = "@PersonId";

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@PlaceId", SqlDbType.Int).Value = data.PlaceId;
                CmdSql.Parameters.Add("@FirstName", SqlDbType.NVarChar, 35).Value =
                    data.FirstName?.Trim() ?? string.Empty;
                CmdSql.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 35).Value =
                    data.MiddleName?.Trim() ?? string.Empty;
                CmdSql.Parameters.Add("@LastName", SqlDbType.NVarChar, 35).Value =
                    data.LastName?.Trim() ?? string.Empty;
                CmdSql.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = data.Email?.Trim() ?? string.Empty;
                CmdSql.Parameters.Add("@TimeZone", SqlDbType.TinyInt).Value = data.TimeZone;
                CmdSql.Parameters.Add("@Country", SqlDbType.SmallInt).Value = data.Country;
                CmdSql.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = data.DisplayOrder;

                SetErrMsgParameter();

                SendNonQueryGetId();

                data.PersonId = ReturnValues.Id;
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues;
        }

        protected internal ReturnBase SaveAssessor(ref PersonBase data)
        {
            if (string.IsNullOrEmpty(data.FullName))
            {
                SetEmptyStringMessage("Name");
                return ReturnValues;
            }

            SetConnectToDatabase("[Admin].[usp_Assessor_Upsert]");
            return AddUpdatePerson(ref data);
        }

        protected internal ReturnBase SaveCustomerContact(ref PersonBase data)
        {
            if (string.IsNullOrEmpty(data.FullName))
            {
                SetEmptyStringMessage("Name");
                return ReturnValues;
            }

            SetConnectToDatabase("[CustomerContact].[usp_Upsert]");
            return AddUpdatePerson(ref data);
        }

        protected internal ReturnBase SaveStaffMember(ref PersonBase data)
        {
            if (string.IsNullOrEmpty(data.FullName))
            {
                SetEmptyStringMessage("Name");
                return ReturnValues;
            }

            SetConnectToDatabase("[StaffMember].[usp_Upsert]");
            return AddUpdatePerson(ref data);
        }

        protected internal ReturnBase SaveOrganizationContact(ref PersonBase data)
        {
            if (string.IsNullOrEmpty(data.FullName))
            {
                SetEmptyStringMessage("Name");
                return ReturnValues;
            }

            SetConnectToDatabase("[FundRaising].[usp_OrganizationContact_Upsert]");
            return AddUpdatePerson(ref data);
        }

        protected ReturnBase SaveAssessorData(PersonData data, ref int personId)
        {
            PersonBase p = data.Person;

            ReturnBase rb = SaveAssessor(ref p);
            if (rb.ErrMsg.Length != 0) return rb;

            if (p.PersonId != personId)
            {
                personId = p.PersonId;
            }

            string msg;
            if (data.AddressData?.Addresses != null && data.AddressData.Addresses.Count != 0)
            {
                using (DbPersonAddressSave db = new DbPersonAddressSave())
                {
                    msg = db.SaveAssessorAddresses(personId, data.AddressData.Addresses);
                    if (msg.Length != 0)
                    {
                        rb.ErrMsg = msg;
                        return rb;
                    }
                }
            }

            if (data.PhoneData == null) return rb;

            if (data.PhoneData.Phones != null && data.PhoneData.Phones.Count != 0)
            {
                using (DbPersonPhoneSave db = new DbPersonPhoneSave())
                {
                    msg = db.SaveAssessorPhones(personId, data.PhoneData.Phones);
                    if (msg.Length != 0)
                    {
                        rb.ErrMsg = msg;
                        return rb;
                    }
                }
            }

            if (data.PhoneData.PhoneSettings == null) return rb;

            using (DbPersonPhoneSettingSave db = new DbPersonPhoneSettingSave())
            {
                msg = db.SaveAssessorPhoneSetting(p.PersonId, data.PhoneData.PhoneSettings);
                if (msg.Length == 0) return rb;
                rb.ErrMsg = msg;
            }
            return rb;
        }

        protected ReturnBase SaveCustomerContactData(PersonData data, ref int personId)
        {
            PersonBase p = data.Person;

            ReturnBase rb = SaveCustomerContact(ref p);
            if (rb.ErrMsg.Length != 0) return rb;

            if (p.PersonId != personId)
            {
                personId = p.PersonId;
            }

            string msg;
            if (data.AddressData?.Addresses != null && data.AddressData.Addresses.Count != 0)
            {
                using (DbPersonAddressSave db = new DbPersonAddressSave())
                {
                    msg = db.SaveCustomerContactAddresses(personId, data.AddressData.Addresses);
                    if (msg.Length != 0)
                    {
                        rb.ErrMsg = msg;
                        return rb;
                    }
                }
            }

            if (data.PhoneData == null) return rb;

            if (data.PhoneData.Phones != null && data.PhoneData.Phones.Count != 0)
            {
                using (DbPersonPhoneSave db = new DbPersonPhoneSave())
                {
                    msg = db.SaveCustomerContactPhones(personId, data.PhoneData.Phones);
                    if (msg.Length != 0)
                    {
                        rb.ErrMsg = msg;
                        return rb;
                    }
                }
            }

            if (data.PhoneData.PhoneSettings == null) return rb;

            using (DbPersonPhoneSettingSave db = new DbPersonPhoneSettingSave())
            {
                msg = db.SaveCustomerContactPhoneSetting(p.PersonId, data.PhoneData.PhoneSettings);
                if (msg.Length == 0) return rb;
                rb.ErrMsg = msg;
            }
            return rb;
        }

        protected internal ReturnBase SaveStaffMemberData(PersonData data, ref int personId)
        {
            PersonBase p = data.Person;

            ReturnBase rb = SaveStaffMember(ref p);
            if (rb.ErrMsg.Length != 0) return rb;

            if (p.PersonId != personId)
            {
                personId = p.PersonId;
            }

            if (p.PlaceId != 0)
            {
                using (DbFacilityStaffSave db = new DbFacilityStaffSave())
                {
                    rb = db.AddUpdateStaffMember(p.PlaceId, personId);
                    rb.Id = personId;

                    if (rb.ErrMsg.Length != 0)
                    {
                        return rb;
                    }
                }
            }

            string msg;
            if (data.AddressData?.Addresses != null && data.AddressData.Addresses.Count != 0)
            {
                using (DbPersonAddressSave db = new DbPersonAddressSave())
                {
                    msg = db.SaveStaffMemberAddresses(personId, data.AddressData.Addresses);
                    if (msg.Length != 0)
                    {
                        rb.ErrMsg = msg;
                        return rb;
                    }
                }
            }

            if (data.PhoneData == null) return rb;

            if (data.PhoneData.Phones != null && data.PhoneData.Phones.Count != 0)
            {
                using (DbPersonPhoneSave db = new DbPersonPhoneSave())
                {
                    msg = db.SaveStaffMemberPhones(personId, data.PhoneData.Phones);
                    if (msg.Length != 0)
                    {
                        rb.ErrMsg = msg;
                        return rb;
                    }
                }
            }

            if (data.PhoneData.PhoneSettings == null) return rb;

            using (DbPersonPhoneSettingSave db = new DbPersonPhoneSettingSave())
            {
                msg = db.SaveStaffMemberPhoneSetting(p.PersonId, data.PhoneData.PhoneSettings);
                if (msg.Length == 0) return rb;
                rb.ErrMsg = msg;
            }
            return rb;
        }

        protected internal ReturnBase SaveOrganizationContactData(PersonData data, ref int personId)
        {
            PersonBase p = data.Person;

            ReturnBase rb = SaveOrganizationContact(ref p);
            if (rb.ErrMsg.Length != 0) return rb;

            if (p.PersonId != personId)
            {
                personId = p.PersonId;
            }

            string msg;
            if (data.AddressData?.Addresses != null && data.AddressData.Addresses.Count != 0)
            {
                using (DbPersonAddressSave db = new DbPersonAddressSave())
                {
                    msg = db.SaveOrganizationContactAddresses(personId, data.AddressData.Addresses);
                    if (msg.Length != 0)
                    {
                        rb.ErrMsg = msg;
                        return rb;
                    }
                }
            }

            if (data.PhoneData == null) return rb;

            if (data.PhoneData.Phones != null && data.PhoneData.Phones.Count != 0)
            {
                using (DbPersonPhoneSave db = new DbPersonPhoneSave())
                {
                    msg = db.SaveOrganizationContactPhones(personId, data.PhoneData.Phones);
                    if (msg.Length != 0)
                    {
                        rb.ErrMsg = msg;
                        return rb;
                    }
                }
            }

            if (data.PhoneData.PhoneSettings == null) return rb;

            using (DbPersonPhoneSettingSave db = new DbPersonPhoneSettingSave())
            {
                msg = db.SaveOrganizationContactPhoneSetting(p.PersonId, data.PhoneData.PhoneSettings);
                if (msg.Length == 0) return rb;
                rb.ErrMsg = msg;
            }
            return rb;
        }

        public ReturnBase SavePerson(PersonData data, ref int personId)
        {
            switch (data.Person.PersonType)
            {
                case PersonType.Assessor:
                    return SaveAssessorData(data, ref personId);
                case PersonType.CustomerContact:
                    return SaveCustomerContactData(data, ref personId);
                case PersonType.StaffMember:
                    return SaveStaffMemberData(data, ref personId);
                case PersonType.OrganizationContact:
                    return SaveOrganizationContactData(data, ref personId);
                default:
                    return new ReturnBase {ErrMsg = "Person Type Undetermined"};
            }
        }
    }
}