using System;
using System.Data;
using ClaudeData.Models.People;
using static ClaudeCommon.Enums.PersonEnums;

namespace ClaudeData.DataRepository.PersonRepository
{
    public class DbPersonSave : DbSaveBase
    {
        private string AddUpdatePerson(string storedProcedure, ref Person data)
        {
            if (string.IsNullOrEmpty(data.FullName))
            {
                SetEmptyStringMessage("Name");
                return ReturnValues.ErrMsg;
            }

            try
            {
                ReturnValues.Id = data.PersonId;
                IdParameter = "@PersonId";

                SetConnectToDatabase(storedProcedure);

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@PlaceId", SqlDbType.Int).Value = data.PlaceId;
                CmdSql.Parameters.Add("@FirstName", SqlDbType.NVarChar, 35).Value = data.FirstName?.Trim() ??
                                                                                    string.Empty;
                CmdSql.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 35).Value = data.MiddleName?.Trim() ??
                                                                                     string.Empty;
                CmdSql.Parameters.Add("@LastName", SqlDbType.NVarChar, 35).Value = data.LastName?.Trim() ?? string.Empty;
                CmdSql.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = data.Email?.Trim() ?? string.Empty;
                CmdSql.Parameters.Add("@IsActive", SqlDbType.Bit).Value = data.IsActive;

                SetErrMsgParameter();

                SendNonQueryGetId();

                data.PersonId = ReturnValues.Id;
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues.ErrMsg;
        }

        protected internal string SaveAssessor(ref Person data)
        {
            return AddUpdatePerson("[Admin].[usp_Assessor_Upsert]", ref data);
        }

        protected internal string SaveCustomerContact(ref Person data)
        {
            return AddUpdatePerson("[Admin].[usp_CustomerContact_Upsert]", ref data);
        }

        protected internal string SaveStaffUser(ref Person data)
        {
            return AddUpdatePerson("[Admin].[usp_StaffUser_Upsert]", ref data);
        }

        protected internal string SaveAssessorData(PersonData data, ref int personId)
        {
            Person p = data.Person;

            string msg = SaveAssessor(ref p);

            if (p.PersonId != personId)
            {
                personId = p.PersonId;
            }

            if (msg.Length != 0) return msg;
            if (personId == 0) return msg;

            using (DbPersonAddressSave db = new DbPersonAddressSave())
            {
                msg = db.SaveAssessorAddresses(personId, data.AddressData.Addresses);
            }
            if (msg.Length != 0) return msg;

            using (DbPersonPhoneSave db = new DbPersonPhoneSave())
            {
                msg = db.SaveAssessorPhones(personId, data.PhoneData.Phones);
            }
            if (msg.Length != 0) return msg;

            using (DbPersonPhoneSettingSave db = new DbPersonPhoneSettingSave())
            {
                msg = db.SaveAssessorPhoneSetting(p.PersonId, data.PhoneData.PhoneSettings);
            }
            return msg;
        }

        protected internal string SaveCustomerContactData(PersonData data, ref int personId)
        {
            Person p = data.Person;

            string msg = SaveCustomerContact(ref p);

            if (p.PersonId != personId)
            {
                personId = p.PersonId;
            }

            if (msg.Length != 0) return msg;
            if (personId == 0) return msg;

            using (DbPersonAddressSave db = new DbPersonAddressSave())
            {
                msg = db.SaveCustomerContactAddresses(personId, data.AddressData.Addresses);
            }
            if (msg.Length != 0) return msg;

            using (DbPersonPhoneSave db = new DbPersonPhoneSave())
            {
                msg = db.SaveCustomerContactPhones(personId, data.PhoneData.Phones);
            }
            if (msg.Length != 0) return msg;

            using (DbPersonPhoneSettingSave db = new DbPersonPhoneSettingSave())
            {
                msg = db.SaveCustomerContactPhoneSetting(p.PersonId, data.PhoneData.PhoneSettings);
            }
            return msg;
        }

        protected internal string SaveStaffUserData(PersonData data, ref int personId)
        {
            Person p = data.Person;

            string msg = SaveStaffUser(ref p);

            if (p.PersonId != personId)
            {
                personId = p.PersonId;
            }

            if (msg.Length != 0) return msg;
            if (personId == 0) return msg;

            using (DbPersonAddressSave db = new DbPersonAddressSave())
            {
                msg = db.SaveStaffUserAddresses(personId, data.AddressData.Addresses);
            }
            if (msg.Length != 0) return msg;

            using (DbPersonPhoneSave db = new DbPersonPhoneSave())
            {
                msg = db.SaveStaffUserPhones(personId, data.PhoneData.Phones);
            }
            if (msg.Length != 0) return msg;

            using (DbPersonPhoneSettingSave db = new DbPersonPhoneSettingSave())
            {
                msg = db.SaveStaffUserPhoneSetting(p.PersonId, data.PhoneData.PhoneSettings);
            }
            return msg;
        }

        protected internal string SavePerson(PersonData data, ref int personId)
        {
            switch (data.Person.PersonType)
            {
                case PersonType.Assessor:
                    return SaveAssessorData(data, ref personId);
                case PersonType.CustomerContact:
                    return SaveCustomerContactData(data, ref personId);
                case PersonType.StaffUser:
                    return SaveStaffUserData(data, ref personId);
                default:
                    return "Person Type Undetermined";
            }
        }
    }
}