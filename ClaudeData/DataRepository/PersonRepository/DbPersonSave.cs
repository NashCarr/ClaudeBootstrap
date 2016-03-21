﻿using System;
using System.Data;
using ClaudeCommon.BaseModels.Returns;
using ClaudeData.DataRepository.AdministrationRepository;
using ClaudeData.Models.People;
using static ClaudeCommon.Enums.PersonEnums;

namespace ClaudeData.DataRepository.PersonRepository
{
    public class DbPersonSave : DbSaveBase
    {
        private ReturnBase AddUpdatePerson(ref Person data)
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
                CmdSql.Parameters.Add("@IsActive", SqlDbType.Bit).Value = data.IsActive;

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

        protected internal ReturnBase SaveAssessor(ref Person data)
        {
            if (string.IsNullOrEmpty(data.FullName))
            {
                SetEmptyStringMessage("Name");
                return ReturnValues;
            }

            IdParameter = "@AssessorId";

            SetConnectToDatabase("[Admin].[usp_Assessor_Upsert]");
            return AddUpdatePerson(ref data);
        }

        protected internal ReturnBase SaveCustomerContact(ref Person data)
        {
            if (string.IsNullOrEmpty(data.FullName))
            {
                SetEmptyStringMessage("Name");
                return ReturnValues;
            }

            IdParameter = "@CustomerContactId";

            SetConnectToDatabase("[Admin].[usp_CustomerContact_Upsert]");
            return AddUpdatePerson(ref data);
        }

        protected internal ReturnBase SaveStaffUser(ref Person data)
        {
            if (string.IsNullOrEmpty(data.FullName))
            {
                SetEmptyStringMessage("Name");
                return ReturnValues;
            }

            IdParameter = "@StaffUserId";

            SetConnectToDatabase("[Admin].[usp_StaffUser_Upsert]");
            return AddUpdatePerson(ref data);
        }

        protected internal ReturnBase SaveOrganizationContact(ref Person data)
        {
            if (string.IsNullOrEmpty(data.FullName))
            {
                SetEmptyStringMessage("Name");
                return ReturnValues;
            }

            IdParameter = "@OrganizationContactId";

            SetConnectToDatabase("[FundRaising].[usp_OrganizationContact_Upsert]");
            return AddUpdatePerson(ref data);
        }

        protected ReturnBase SaveAssessorData(PersonData data, ref int personId)
        {
            Person p = data.Person;

            ReturnBase rb = SaveAssessor(ref p);
            if (rb.ErrMsg.Length != 0) return rb;

            if (p.PersonId != personId)
            {
                personId = p.PersonId;
            }

            string msg;
            if (data.AddressData?.Addresses != null)
            {
                if (data.AddressData.Addresses.Count != 0)
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
            }

            if (data.PhoneData == null) return rb;

            if (data.PhoneData.Phones != null)
            {
                if (data.PhoneData.Phones.Count != 0)
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
            Person p = data.Person;

            ReturnBase rb = SaveCustomerContact(ref p);
            if (rb.ErrMsg.Length != 0) return rb;

            if (p.PersonId != personId)
            {
                personId = p.PersonId;
            }

            string msg;
            if (data.AddressData?.Addresses != null)
            {
                if (data.AddressData.Addresses.Count != 0)
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
            }

            if (data.PhoneData == null) return rb;

            if (data.PhoneData.Phones != null)
            {
                if (data.PhoneData.Phones.Count != 0)
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

        protected internal ReturnBase SaveStaffUserData(PersonData data, ref int personId)
        {
            Person p = data.Person;

            ReturnBase rb = SaveStaffUser(ref p);
            if (rb.ErrMsg.Length != 0) return rb;

            if (p.PersonId != personId)
            {
                personId = p.PersonId;
            }

            string msg;
            using (DbFacilityStaffSave db = new DbFacilityStaffSave())
            {
                rb = db.AddUpdateStaffUser(p.PlaceId, personId);
                if (rb.ErrMsg.Length != 0)
                {
                    return rb;
                }
            }

            if (data.AddressData?.Addresses != null)
            {
                if (data.AddressData.Addresses.Count != 0)
                {
                    using (DbPersonAddressSave db = new DbPersonAddressSave())
                    {
                        msg = db.SaveStaffUserAddresses(personId, data.AddressData.Addresses);
                        if (msg.Length != 0)
                        {
                            rb.ErrMsg = msg;
                            return rb;
                        }
                    }
                }
            }

            if (data.PhoneData == null) return rb;

            if (data.PhoneData.Phones != null)
            {
                if (data.PhoneData.Phones.Count != 0)
                {
                    using (DbPersonPhoneSave db = new DbPersonPhoneSave())
                    {
                        msg = db.SaveStaffUserPhones(personId, data.PhoneData.Phones);
                        if (msg.Length != 0)
                        {
                            rb.ErrMsg = msg;
                            return rb;
                        }
                    }
                }
            }

            if (data.PhoneData.PhoneSettings == null) return rb;

            using (DbPersonPhoneSettingSave db = new DbPersonPhoneSettingSave())
            {
                msg = db.SaveStaffUserPhoneSetting(p.PersonId, data.PhoneData.PhoneSettings);
                if (msg.Length == 0) return rb;
                rb.ErrMsg = msg;
            }
            return rb;
        }

        protected ReturnBase SaveOrganizationContactData(PersonData data, ref int personId)
        {
            Person p = data.Person;

            ReturnBase rb = SaveOrganizationContact(ref p);
            if (rb.ErrMsg.Length != 0) return rb;

            if (p.PersonId != personId)
            {
                personId = p.PersonId;
            }

            string msg;
            if (data.AddressData?.Addresses != null)
            {
                if (data.AddressData.Addresses.Count != 0)
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
            }

            if (data.PhoneData == null) return rb;

            if (data.PhoneData.Phones != null)
            {
                if (data.PhoneData.Phones.Count != 0)
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
                    return SaveStaffUserData(data, ref personId);
                case PersonType.OrganizationContact:
                    return SaveOrganizationContactData(data, ref personId);
                default:
                    return new ReturnBase {ErrMsg = "Person Type Undetermined"};
            }
        }
    }
}