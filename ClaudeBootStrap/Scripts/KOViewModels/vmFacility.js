
FacilityViewModel = function(data) {
    var self = this;
    var baseUrl = "/Facility/";

    self.placeHeader = "Facility";
    self.detailHeader = "Facility Details";
    self.detailSubHeader = ko.observable("List");
    self.phoneHeader = ko.observable("Primary");
    self.addressHeader = ko.observable("Mailing");

    self.sorttype = 1;
    self.direction = 1;
    self.IsSorting = ko.observable(false);
    self.sortdirection = ko.observable(1);

    self.IsEdit = ko.observable(false);
    self.IsEditContact = ko.observable(true);

    self.IsPlaceFaxPhoneVisible = ko.observable(false);
    self.IsPlaceCellPhoneVisible = ko.observable(false);
    self.IsPlaceHomePhoneVisible = ko.observable(false);
    self.IsPlaceWorkPhoneVisible = ko.observable(false);
    self.IsPhoneDetailVisible = ko.observable(false);

    self.IsPrimaryDetailVisible = ko.observable(true);

    self.IsContactDetailVisible = ko.observable(false);
    self.IsPlaceAddressDetailVisible = ko.observable(false);
    self.IsPlaceMailingAddressVisible = ko.observable(false);
    self.IsPlaceShippingAddressVisible = ko.observable(false);

    self.IsListAreaVisible = ko.observable(true);
    self.IsSearchAreaVisible = ko.observable(true);
    self.IsAddEditAreaVisible = ko.observable(false);
    self.IsMessageAreaVisible = ko.observable(false);

    self.IsDisplayOrderChanged = ko.observable(false);

    self.errmsg = ko.observable("");

    self.filter = "";
    self.searchvalue = ko.observable("");

    //place
    self.placeid = ko.observable(0);
    self.placename = ko.observable("");
    self.placecountry = ko.observable("");
    self.placetimezone = ko.observable("");
    self.placedivision = ko.observable("");
    self.placedepartment = ko.observable("");
    self.placedisplayorder = ko.observable(0);

    //person
    self.personid = ko.observable(0);
    self.personlast = ko.observable("");
    self.personemail = ko.observable("");
    self.personfirst = ko.observable("");
    self.personmiddle = ko.observable("");
    self.personcountry = ko.observable("");
    self.persontimezone = ko.observable("");
    self.persondisplayorder = ko.observable(0);

    //associations
    self.placefaxassociationid = 0;
    self.placecellassociationid = 0;
    self.placehomeassociationid = 0;
    self.placeworkassociationid = 0;
    self.placemailingassociationid = 0;
    self.placeshippingassociationid = 0;

    //ids
    self.placefaxid = 0;
    self.placecellid = 0;
    self.placehomeid = 0;
    self.placeworkid = 0;
    self.placemailingid = 0;
    self.placeshippingid = 0;
    self.placephonesettingid = 0;

    self.faxphonetype = "Fax";
    self.cellphonetype = "Cell";
    self.homephonetype = "Home";
    self.workphonetype = "Work";
    self.mailingaddresstype = "Mailing";
    self.shippingaddresstype = "Shipping";

    //fax
    self.faxcountry = ko.observable(0);
    self.faxphonenumber = ko.observable("");

    //cell
    self.cellcountry = ko.observable(0);
    self.cellcarrier = ko.observable(0);
    self.cellphonenumber = ko.observable("");
    self.cellaccepttext = ko.observable(true);

    //home
    self.homecountry = ko.observable(0);
    self.homephonenumber = ko.observable("");

    //work
    self.workcountry = ko.observable(0);
    self.workextension = ko.observable("");
    self.workphonenumber = ko.observable("");

    //mailing
    self.mailingcity = ko.observable("");
    self.mailingcountry = ko.observable(0);
    self.mailingaddress1 = ko.observable("");
    self.mailingaddress2 = ko.observable("");
    self.mailingpostalcode = ko.observable("");
    self.mailingstateprovince = ko.observable("");
    self.UseMailingforShipping = ko.observable(true);

    //shipping
    self.shippingcity = ko.observable("");
    self.shippingcountry = ko.observable(0);
    self.shippingaddress1 = ko.observable("");
    self.shippingaddress2 = ko.observable("");
    self.shippingpostalcode = ko.observable("");
    self.shippingstateprovince = ko.observable("");

    self.placedata = ko.observableArray([]);
    self.personlist = ko.observableArray([]);

    //list
    self.listitems = ko.mapping.fromJS(data.ListEntity).extend({ deferred: true });

    //lookups
    self.timezones = ko.mapping.fromJS(data.TimeZones).extend({ deferred: true });
    self.countries = ko.mapping.fromJS(data.Countries).extend({ deferred: true });
    self.mobilecarriers = ko.mapping.fromJS(data.MobileCarriers).extend({ deferred: true });
    self.statesprovinces = ko.mapping.fromJS(data.StatesProvinces).extend({ deferred: true });

    self.PlacePrimaryPhone = {
        phoneprimaryid: 0,
        workisprimary: ko.observable(true),
        cellisprimary: ko.observable(false),
        homeisprimary: ko.observable(false),

        Cell: function () {
            if (!self.PlacePrimaryPhone.cellisprimary()) {
                self.PlacePrimaryPhone.phoneprimaryid = 0;
                return;
            };
            self.PlacePrimaryPhone.homeisprimary(false);
            self.PlacePrimaryPhone.workisprimary(false);
            self.PlacePrimaryPhone.phoneprimaryid = 2;
        },

        Home: function () {
            if (!self.PlacePrimaryPhone.homeisprimary()) {
                self.PlacePrimaryPhone.phoneprimaryid = 0;
                return;
            };
            self.PlacePrimaryPhone.cellisprimary(false);
            self.PlacePrimaryPhone.workisprimary(false);
            self.PlacePrimaryPhone.phoneprimaryid = 1;
        },

        Work: function () {
            if (!self.PlacePrimaryPhone.workisprimary()) {
                self.PlacePrimaryPhone.phoneprimaryid = 0;
                return;
            };
            self.PlacePrimaryPhone.cellisprimary(false);
            self.PlacePrimaryPhone.homeisprimary(false);
            self.PlacePrimaryPhone.phoneprimaryid = 3;
        },
        Set: function () {
            switch (self.PlacePrimaryPhone.phoneprimaryid) {
                case 1:
                    self.PlacePrimaryPhone.homeisprimarye(true);
                    self.PlacePrimaryPhone.Home();
                    break;
                case 2:
                    self.PlacePrimaryPhone.cellisprimary(true);
                    self.PlacePrimaryPhone.Cell();
                    break;
                case 3:
                    self.PlacePrimaryPhone.workisprimary(true);
                    self.PlacePrimaryPhone.Work();
                    break;
                default:
                    self.PlacePrimaryPhone.workisprimary(true);
                    self.PlacePrimaryPhone.Work();
                    break;
            };
        }
    };

    self.PlacePhoneView = {
        Fax: function () {
            self.IsPlaceFaxPhoneVisible(true);
            self.IsPlaceCellPhoneVisible(false);
            self.IsPlaceHomePhoneVisible(false);
            self.IsPlaceWorkPhoneVisible(false);
            self.phoneHeader("Phones: " + self.faxphonetype);
        },
        Cell: function () {
            self.IsPlaceFaxPhoneVisible(false);
            self.IsPlaceCellPhoneVisible(true);
            self.IsPlaceHomePhoneVisible(false);
            self.IsPlaceWorkPhoneVisible(false);
            self.phoneHeader("Phones: " + self.cellphonetype);
        },
        Home: function () {
            self.IsPlaceFaxPhoneVisible(false);
            self.IsPlaceCellPhoneVisible(false);
            self.IsPlaceHomePhoneVisible(true);
            self.IsPlaceWorkPhoneVisible(false);
            self.phoneHeader("Phones: " + self.homephonetype);
        },
        Work: function () {
            self.IsPlaceFaxPhoneVisible(false);
            self.IsPlaceCellPhoneVisible(false);
            self.IsPlaceHomePhoneVisible(false);
            self.IsPlaceWorkPhoneVisible(true);
            self.phoneHeader("Phones: " + self.workphonetype);
        },
        Default: function () {
            self.IsPlaceFaxPhoneVisible(false);
            self.IsPlaceCellPhoneVisible(false);
            self.IsPlaceHomePhoneVisible(false);
            self.IsPlaceWorkPhoneVisible(false);
        },
        Primary: function() {
            switch (self.PlacePrimaryPhone.phoneprimaryid) {
            case 1:
                self.PlacePhoneView.Home();
                break;
            case 2:
                self.PlacePhoneView.Cell();
                break;
            case 3:
                self.PlacePhoneView.Work();
                break;
            default:
                self.PlacePhoneView.Work();
                break;
            }
        }
    };

    self.PlaceAddressView = {
        Mailing: function() {
            self.IsPlaceMailingAddressVisible(true);
            self.IsPlaceShippingAddressVisible(false);
        },
        Shipping: function() {
            self.IsPlaceMailingAddressVisible(false);
            self.IsPlaceShippingAddressVisible(true);
        },
        Default: function () {
            self.IsPlaceMailingAddressVisible(false);
            self.IsPlaceShippingAddressVisible(false);
        }
    };

    self.DetailView = {
        Primary: function () {
            self.IsPhoneDetailVisible(false);
            self.IsPrimaryDetailVisible(true);
            self.IsPlaceAddressDetailVisible(false);
            self.IsContactDetailVisible(false);
        },
        Contacts: function () {
            self.IsEditContact(false);
            self.IsPhoneDetailVisible(false);
            self.IsPrimaryDetailVisible(false);
            self.IsPlaceAddressDetailVisible(false);
            self.IsContactDetailVisible(true);
        },
        Phones: function () {
            self.IsPhoneDetailVisible(true);
            self.IsPrimaryDetailVisible(false);
            self.IsPlaceAddressDetailVisible(false);
            self.IsContactDetailVisible(false);

            self.PlacePhoneView.Primary();
            self.PlaceAddressView.Default();
        },
        Addresses: function () {
            self.IsPhoneDetailVisible(false);
            self.IsPlaceAddressDetailVisible(true);
            self.IsPrimaryDetailVisible(false);
            self.IsContactDetailVisible(false);

            self.PlacePhoneView.Default();
            self.PlaceAddressView.Mailing();
        }
    };

    self.DetailListEdit = {
        Fax: function () {
            self.DetailView.Phones();
            self.PlacePhoneView.Fax();
        },
        Cell: function () {
            self.DetailView.Phones();
            self.PlacePhoneView.Cell();
        },
        Home: function () {
            self.DetailView.Phones();
            self.PlacePhoneView.Home();
        },
        Work: function () {
            self.DetailView.Phones();
            self.PlacePhoneView.Work();
        },
        Mailing: function () {
            self.DetailView.Addresses();
            self.PlaceAddressView.Mailing();
        },
        Shipping: function () {
            self.DetailView.Addresses();
            self.PlaceAddressView.Shipping();
        }
    };

    self.stateprovincename = function (id) {
        if (parseInt(id) === 0) {
            return "";
        };
        var match = ko.utils.arrayFirst(self.statesprovinces(), function(item) {
            return parseInt(item.Value()) === parseInt(id);
        });
        if (match) {
            return ko.unwrap(match.Text);
        }
        return "";
    };

    self.PlaceMailingAddress = {
        Address: ko.computed(function () {
            if (self.mailingaddress1().length === 0) {
                return "";
            };
            if (self.mailingaddress2().length === 0) {
                return ko.unwrap(self.mailingaddress1());
            };
            return ko.unwrap(self.mailingaddress1()) + ", " + ko.unwrap(self.mailingaddress2());
        }),
        CityStateZip: ko.computed(function () {
            if (self.mailingcity().length === 0) {
                return "";
            };
            return ko.unwrap(self.mailingcity()) + ", " + (self.stateprovincename(ko.unwrap(self.mailingstateprovince())) + " " + ko.unwrap(self.mailingpostalcode())).trim();
        }),
        Value: function () {
            return (ko.unwrap(self.PlaceMailingAddress.Address()) + ", " + ko.unwrap(self.PlaceMailingAddress.CityStateZip())).trim();
        }
    };

    self.PlaceShippingAddress = {
        Address: ko.computed(function () {
            if (self.shippingaddress1().length === 0) {
                return "";
            };
            if (self.shippingaddress2().length === 0) {
                return ko.unwrap(self.shippingaddress1());
            };
            return ko.unwrap(self.shippingaddress1()) + ", " + ko.unwrap(self.shippingaddress2());
        }),
        CityStateZip: ko.computed(function () {
            if (self.shippingcity().length === 0) {
                return "";
            };
            return ko.unwrap(self.shippingcity()) + ", " + (self.stateprovincename(ko.unwrap(self.shippingstateprovince())) + " " + ko.unwrap(self.shippingpostalcode())).trim();
        }),
        Value: function () {
            return ko.unwrap(self.PlaceShippingAddress.Address()) + ", " + ko.unwrap(self.PlaceShippingAddress.CityStateZip());
        }
    };

    self.cellcarriername = ko.computed(function () {
        var id = parseInt(self.cellcarrier());
        if (id === 0) {
            return "";
        };
        var match = ko.utils.arrayFirst(self.mobilecarriers(), function (item) {
            return parseInt(item.Value()) === id;
        });
        if (match) {
            return ko.unwrap(match.Text);
        }
        return "";
    });

    self.ShowPlaceShipping = ko.computed(function () {
        return !self.UseMailingforShipping();
    });

    self.DragDropComplete = ko.computed(function () {
        return !self.IsDisplayOrderChanged();
    });

    self.returnmessage = ko.pureComputed(function() {
        return ko.unwrap(self.errmsg);
    });

    self.setmessageview = function() {
        self.IsMessageAreaVisible(self.errmsg().length);
    };

    self.handleplacereturndata = function(returndata) {
        self.placeid(returndata.Id);
        self.errmsg(returndata.ErrMsg);

        self.setmessageview();
    };

    self.PlacePrimaryPhone = {
        phoneprimaryid: 0,
        workisprimary: ko.observable(true),
        cellisprimary: ko.observable(false),
        homeisprimary: ko.observable(false),

        Cell: function() {
            if (!self.PlacePrimaryPhone.cellisprimary()) {
                self.PlacePrimaryPhone.phoneprimaryid = 0;
                return;
            };
            self.PlacePrimaryPhone.homeisprimary(false);
            self.PlacePrimaryPhone.workisprimary(false);
            self.PlacePrimaryPhone.phoneprimaryid = 2;
        },

        Home: function() {
            if (!self.PlacePrimaryPhone.homeisprimary()) {
                self.PlacePrimaryPhone.phoneprimaryid = 0;
                return;
            };
            self.PlacePrimaryPhone.cellisprimary(false);
            self.PlacePrimaryPhone.workisprimary(false);
            self.PlacePrimaryPhone.phoneprimaryid = 1;
        },

        Work: function() {
            if (!self.PlacePrimaryPhone.workisprimary()) {
                self.PlacePrimaryPhone.phoneprimaryid = 0;
                return;
            };
            self.PlacePrimaryPhone.cellisprimary(false);
            self.PlacePrimaryPhone.homeisprimary(false);
            self.PlacePrimaryPhone.phoneprimaryid = 3;
        },
        Set: function() {
            switch (self.PlacePrimaryPhone.phoneprimaryid) {
            case 1:
                self.PlacePrimaryPhone.homeisprimarye(true);
                self.PlacePrimaryPhone.Home();
                break;
            case 2:
                self.PlacePrimaryPhone.cellisprimary(true);
                self.PlacePrimaryPhone.Cell();
                break;
            case 3:
                self.PlacePrimaryPhone.workisprimary(true);
                self.PlacePrimaryPhone.Work();
                break;
            default:
                self.PlacePrimaryPhone.workisprimary(true);
                self.PlacePrimaryPhone.Work();
                break;
            }
        }
    };

    self.DefaultPlaceCountry = {
        Fax: function() {
            if (typeof self.faxcountry() !== "undefined") {
                if (self.faxphonenumber().length !== 0) {
                    if (self.faxcountry() !== 0) {
                        return;
                    };
                };
            };
            self.faxcountry(self.placecountry());
        },
        Cell: function() {
            if (typeof self.cellcountry() !== "undefined") {
                if (self.cellphonenumber().length !== 0) {
                    if (self.cellcountry() !== 0) {
                        return;
                    };
                };
            };
            self.cellcountry(self.placecountry());
        },
        Home: function() {
            if (typeof self.homecountry() !== "undefined") {
                if (self.homephonenumber().length !== 0) {
                    if (self.homecountry() !== 0) {
                        return;
                    };
                };
            };
            self.homecountry(self.placecountry());
        },
        Work: function() {
            if (typeof self.workcountry() !== "undefined") {
                if (self.workphonenumber().length !== 0) {
                    if (self.workcountry() !== 0) {
                        return;
                    };
                };
            };
            self.workcountry(self.placecountry());
        },
        Mailing: function() {
            if (typeof self.mailingcountry() !== "undefined") {
                if (self.mailingaddress1().length !== 0) {
                    if (self.mailingcountry() !== 0) {
                        return;
                    };
                };
            };
            self.mailingcountry(self.placecountry());
        },
        Shipping: function() {
            if (typeof self.shippingcountry() !== "undefined") {
                if (self.shippingaddress1().length !== 0) {
                    if (self.shippingcountry() !== 0) {
                        return;
                    };
                };
            };
            self.shippingcountry(self.placecountry());
        },
        Set: function() {
            if (typeof self.placecountry() === "undefined") {
                return;
            }
            self.DefaultPlaceCountry.Fax();
            self.DefaultPlaceCountry.Cell();
            self.DefaultPlaceCountry.Home();
            self.DefaultPlaceCountry.Work();
            self.DefaultPlaceCountry.Mailing();
            self.DefaultPlaceCountry.Shipping();
        }
    };

    self.DefaultPlaceShipping = {
        Address1: function() {
            switch (typeof self.mailingaddress1()) {
            case "undefined":
                break;
            default:
                self.shippingaddress1(self.mailingaddress1());
                break;
            };
        },
        Address2: function() {
            switch (typeof self.mailingaddress2()) {
            case "undefined":
                break;
            default:
                self.shippingaddress2(self.mailingaddress2());
                break;
            };
        },
        City: function() {
            switch (typeof self.mailingcity()) {
            case "undefined":
                break;
            default:
                if (
                    (self.UseMailingforShipping()) ||
                    (typeof self.shippingcity() === "undefined")
                ) {
                    self.shippingcity(self.mailingcity());
                    return;
                };
                if (self.shippingcity().length === 0) {
                    self.shippingcity(self.mailingcity());
                };
                break;
            };
        },
        PostalCode: function() {
            switch (typeof self.mailingpostalcode()) {
            case "undefined":
                break;
            default:
                if (
                    (self.UseMailingforShipping()) ||
                    (typeof self.shippingpostalcode() === "undefined")
                ) {
                    self.shippingpostalcode(self.mailingpostalcode());
                    return;
                };
                if (self.shippingpostalcode().length === 0) {
                    self.shippingpostalcode(self.mailingpostalcode());
                };
                break;
            };
        },
        StateProvince: function() {
            switch (typeof self.mailingstateprovince()) {
            case "undefined":
                break;
            default:
                if (
                    (self.UseMailingforShipping()) ||
                    (typeof self.shippingstateprovince() === "undefined")
                ) {
                    self.shippingstateprovince(self.mailingstateprovince());
                    return;
                };
                if (self.shippingstateprovince() === 0) {
                    self.shippingstateprovince(self.mailingstateprovince());
                };
                break;
            };
        },
        Basic: function() {
            self.DefaultPlaceShipping.City();
            self.DefaultPlaceShipping.PostalCode();
            self.DefaultPlaceShipping.StateProvince();
        },
        Set: function() {
            if (self.UseMailingforShipping()) {
                self.DefaultPlaceShipping.Address1();
                self.DefaultPlaceShipping.Address2();
            };
            self.DefaultPlaceShipping.Basic();
        }
    };

    self.Contact = {
        FullName: function () {
            return ((ko.unwrap(self.personfirst()) + " " + ko.unwrap(self.personmiddle())).trim() + " " + ko.unwrap(self.personlast())).trim();
        },
        Build: function () {
            return {
                PersonType: 0,
                FullName: self.Contact.FullName(),
                PlaceId: ko.unwrap(self.placeid()),
                PersonId: ko.unwrap(self.personid()),
                Email: ko.unwrap(self.personemail()),
                LastName: ko.unwrap(self.personlast()),
                FirstName: ko.unwrap(self.personfirst()),
                MiddleName: ko.unwrap(self.personmiddle()),
                Country: ko.observable(self.personcountry()),
                TimeZone: ko.observable(self.persontimezone()),
                DisplayOrder: ko.observable(self.persondisplayorder())
            };
        },
        Clear: function () {
            self.personid(0);
            self.personlast("");
            self.personemail("");
            self.personfirst("");
            self.personmiddle("");
        },
        Add: function () {
            self.Contact.Clear();
            self.IsEditContact(true);
            self.personcountry(ko.unwrap(self.placecountry()));
            self.persontimezone(ko.unwrap(self.placetimezone()));
        },
        Cancel: function () {
            self.Contact.Clear();
            self.IsEditContact(false);
        },
        Edit: function (editdata) {
            self.IsEditContact(true);
            self.placeid(ko.unwrap(editdata.PlaceId()));
            self.personid(ko.unwrap(editdata.PersonId()));
            self.personemail(ko.unwrap(editdata.Email()));
            self.personlast(ko.unwrap(editdata.LastName()));
            self.personfirst(ko.unwrap(editdata.FirstName()));
            self.personmiddle(ko.unwrap(editdata.MiddleName()));
            self.personcountry(ko.unwrap(self.placecountry()));
            self.persontimezone(ko.unwrap(self.placetimezone()));
        }
    };

    self.SaveContact = {
        BuildPersonData: function () {
            return {
                Person: self.Contact.Build(),
                FaxPhone: self.PlaceFax.Build(),
                CellPhone: self.PlaceCell.Build(),
                HomePhone: self.PlaceHome.Build(),
                WorkPhone: self.PlaceWork.Build(),
                MailingAddress: self.PlaceMailing.Build(),
                ShippingAddress: self.PlaceShipping.Build(),
                PhoneSetting: self.PlacePhoneSettings.Build(),
                UseMailingForShipping: self.UseMailingforShipping()
            };
        },
        Build: function () {
            return {
                PersonType: 0,
                PlaceId: ko.unwrap(self.placeid()),
                FullName: self.Contact.FullName(),
                PersonId: ko.unwrap(self.personid()),
                Email: ko.unwrap(self.personemail()),
                LastName: ko.unwrap(self.personlast()),
                FirstName: ko.unwrap(self.personfirst()),
                MiddleName: ko.unwrap(self.personmiddle())
            };
        },
        ProcessAdd: function () {
            self.personlist.push(self.SaveContact.Build());
        },
        ItemExists: function () {
            var match = ko.utils.arrayFirst(self.personlist(), function (item) {
                return item.PersonId() === self.personid();
            });
            return match;
        },
        ProcessEdit: function () {
            self.personlist.replace(self.SaveContact.ItemExists(), self.SaveContact.Build());
        },
        Process: function () {
            if (self.SaveContact.ItemExists()) {
                self.SaveContact.ProcessEdit();
                return;
            };
            self.SaveContact.ProcessAdd();
        },
        HandleReturn: function (returndata) {
            self.personid(returndata.Id);
            self.errmsg(returndata.ErrMsg);

            self.setmessageview();
        },
        Save: function () {
            $.ajax({
                url: baseUrl + "SaveContact",
                type: "post",
                data: self.SaveContact.BuildPersonData()
            }).then(function (returndata) {

                self.SaveContact.HandleReturn(returndata);
                if (self.IsMessageAreaVisible()) {
                    return;
                }
                self.SaveContact.Process();
                self.DetailView.Contacts();
            });
        }
    };

    self.PlaceFax = {
        Build: function() {
            if (self.faxphonenumber().length === 0) {
                return null;
            };
            return {
                PhoneType: 4,
                PhoneId: self.placefaxid,
                Country: ko.unwrap(self.faxcountry()),
                PhoneAssociationId: self.placefaxassociationid,
                PhoneNumber: ko.unwrap(self.faxphonenumber())
            };
        },
        Clear: function() {
            self.placefaxid = 0;
            self.placefaxassociationid = 0;

            self.faxcountry(0);
            self.faxphonenumber("");
        },
        Set: function() {
            self.placefaxassociationid = ko.unwrap(self.placedata.PhoneAssociationId);
            if (self.placefaxassociationid === 0) {
                self.PlaceFax.Clear();
                return;
            };
            self.placefaxid = ko.unwrap(self.placedata.PhoneId);
            self.faxcountry(ko.unwrap(self.placedata.Country));
            self.faxphonenumber(ko.unwrap(self.placedata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.placedata === "undefined") {
                self.PlaceFax.Clear();
                return;
            }
            self.PlaceFax.Set();
            self.placedata = ko.observableArray([]);
        }
    };

    self.PlaceCell = {
        Build: function() {
            if (self.cellphonenumber().length === 0) {
                return null;
            };
            return {
                PhoneType: 2,
                PhoneId: self.placecellid,
                Country: ko.unwrap(self.cellcountry()),
                PhoneAssociationId: self.placecellassociationid,
                PhoneNumber: ko.unwrap(self.cellphonenumber())
            };
        },
        Clear: function() {
            self.placecellid = 0;
            self.placecellassociationid = 0;

            self.cellcountry(0);
            self.cellcarrier(0);
            self.cellphonenumber("");
            self.cellaccepttext(true);
        },
        Set: function() {
            self.placecellassociationid = ko.unwrap(self.placedata.PhoneAssociationId);
            if (self.placecellassociationid === 0) {
                self.PlaceCell.Clear();
                return;
            };
            self.placecellid = ko.unwrap(self.placedata.PhoneId);
            self.cellcountry(ko.unwrap(self.placedata.Country));
            self.cellphonenumber(ko.unwrap(self.placedata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.placedata === "undefined") {
                self.PlaceCell.Clear();
                return;
            }
            self.PlaceCell.Set();
            self.placedata = ko.observableArray([]);
        }
    };

    self.PlaceHome = {
        Build: function() {
            if (self.homephonenumber().length === 0) {
                return null;
            };
            return {
                PhoneType: 1,
                PhoneId: self.placehomeid,
                Country: ko.unwrap(self.homecountry()),
                PhoneAssociationId: self.placehomeassociationid,
                PhoneNumber: ko.unwrap(self.homephonenumber())
            };
        },
        Clear: function() {
            self.placehomeid = 0;
            self.placehomeassociationid = 0;

            self.homecountry(0);
            self.homephonenumber("");
        },
        Set: function() {
            self.placehomeassociationid = ko.unwrap(self.placedata.PhoneAssociationId);
            if (self.placehomeassociationid === 0) {
                self.PlaceHome.Clear();
                return;
            };
            self.placehomeid = ko.unwrap(self.placedata.PhoneId);
            self.homecountry(ko.unwrap(self.placedata.Country));
            self.homephonenumber(ko.unwrap(self.placedata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.placedata === "undefined") {
                self.PlaceHome.Clear();
                return;
            }
            self.PlaceHome.Set();
            self.placedata = ko.observableArray([]);
        }
    };

    self.PlaceWork = {
        Build: function() {
            if (self.workphonenumber().length === 0) {
                return null;
            };
            return {
                PhoneType: 3,
                PhoneId: self.placeworkid,
                Country: ko.unwrap(self.workcountry()),
                PhoneAssociationId: self.placeworkassociationid,
                PhoneNumber: ko.unwrap(self.workphonenumber())
            };
        },
        Clear: function() {
            self.placeworkid = 0;
            self.placeworkassociationid = 0;

            self.workcountry(0);
            self.workextension("");
            self.workphonenumber("");
        },
        Set: function() {
            self.placeworkassociationid = ko.unwrap(self.placedata.PhoneAssociationId);
            if (self.placeworkassociationid === 0) {
                self.PlaceWork.Clear();
                return;
            };
            self.placeworkid = ko.unwrap(self.placedata.PhoneId);
            self.workcountry(ko.unwrap(self.placedata.Country));
            self.workphonenumber(ko.unwrap(self.placedata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.placedata === "undefined") {
                self.PlaceWork.Clear();
                return;
            }
            self.PlaceWork.Set();
            self.placedata = ko.observableArray([]);
        }
    };

    self.PlaceShipping = {
        Build: function() {
            if (self.shippingaddress1().length === 0) {
                return null;
            };
            return {
                AddressType: 1,
                AddressId: self.placeshippingid,
                City: ko.unwrap(self.shippingcity()),
                Country: ko.unwrap(self.shippingcountry()),
                Address1: ko.unwrap(self.shippingaddress1()),
                Address2: ko.unwrap(self.shippingaddress2()),
                ZipCode: ko.unwrap(self.shippingpostalcode()),
                AddressAssociationId: self.placeshippingassociationid,
                StateProvince: ko.unwrap(self.shippingstateprovince())
            };
        },
        Clear: function() {
            self.placeshippingid = 0;
            self.placeshippingassociationid = 0;

            self.shippingcity("");
            self.shippingcountry(0);
            self.shippingaddress1("");
            self.shippingaddress2("");
            self.shippingpostalcode("");
            self.shippingstateprovince("");
            self.shippingstateprovince("");
        },
        Set: function() {
            self.placeshippingassociationid = ko.unwrap(self.placedata.AddressAssociationId);
            if (self.placeshippingassociationid === 0) {
                self.PlaceShipping.Clear();
                return;
            };
            self.shippingcity(ko.unwrap(self.placedata.City));
            self.shippingcountry(ko.unwrap(self.placedata.Country));
            self.shippingaddress1(ko.unwrap(self.placedata.Address1));
            self.shippingaddress2(ko.unwrap(self.placedata.Address2));
            self.shippingpostalcode(ko.unwrap(self.placedata.ZipCode));
            self.placeshippingid = ko.unwrap(ko.unwrap(self.placedata.AddressId));
            self.shippingstateprovince(ko.unwrap(self.placedata.StateProvince));
        },
        Populate: function() {
            if (typeof self.placedata === "undefined") {
                self.PlaceShipping.Clear();
                return;
            }
            self.PlaceShipping.Set();
            self.placedata = ko.observableArray([]);
        }
    };

    self.PlaceMailing = {
        Build: function() {
            if (self.mailingaddress1().length === 0) {
                return null;
            };
            return {
                AddressType: 2,
                AddressId: self.placemailingid,
                City: ko.unwrap(self.mailingcity()),
                Country: ko.unwrap(self.mailingcountry()),
                Address1: ko.unwrap(self.mailingaddress1()),
                Address2: ko.unwrap(self.mailingaddress2()),
                ZipCode: ko.unwrap(self.mailingpostalcode()),
                AddressAssociationId: self.placemailingassociationid,
                StateProvince: ko.unwrap(self.mailingstateprovince())
            };
        },
        Clear: function() {
            self.placemailingid = 0;
            self.placemailingassociationid = 0;

            self.mailingcity("");
            self.mailingcountry(0);
            self.mailingaddress1("");
            self.mailingaddress2("");
            self.mailingpostalcode("");
            self.mailingstateprovince("");
        },
        Set: function() {
            self.placemailingassociationid = ko.unwrap(self.placedata.AddressAssociationId);
            if (self.placemailingassociationid === 0) {
                self.PlaceMailing.Clear();
                return;
            };
            self.mailingcity(ko.unwrap(self.placedata.City));
            self.mailingcountry(ko.unwrap(self.placedata.Country));
            self.mailingaddress1(ko.unwrap(self.placedata.Address1));
            self.mailingaddress2(ko.unwrap(self.placedata.Address2));
            self.mailingpostalcode(ko.unwrap(self.placedata.ZipCode));
            self.placemailingid = ko.unwrap(ko.unwrap(self.placedata.AddressId));
            self.mailingstateprovince(ko.unwrap(self.placedata.StateProvince));
        },
        Populate: function() {
            if (typeof self.placedata === "undefined") {
                self.PlaceMailing.Clear();
                return;
            }
            self.PlaceMailing.Set();
            self.placedata = ko.observableArray([]);
        }
    };

    self.Place = {
        Build: function() {
            return {
                PlaceType: ko.observable(1),
                Name: ko.observable(self.placename()),
                PlaceId: ko.observable(self.placeid()),
                Country: ko.observable(self.placecountry()),
                TimeZone: ko.observable(self.placetimezone()),
                Division: ko.observable(self.placedivision()),
                Department: ko.observable(self.placedepartment()),
                DisplayOrder: ko.observable(self.placedisplayorder()),
                CountryName: ko.observable(self.ProcessSave.CountryName()),
                TimeZoneName: ko.observable(self.ProcessSave.TimeZoneName())
            };
        },
        Clear: function() {
            self.placeid(0);
            self.placename("");
            self.placecountry(0);
            self.placetimezone(0);
            self.placedivision("");
            self.placedepartment("");
            self.placedisplayorder(0);
        },
        Set: function() {
            self.placeid(ko.unwrap(self.placedata.PlaceId));
            if (self.placeid() === 0) {
                self.Place.Clear();
                return;
            }
            self.placename(ko.unwrap(self.placedata.Name));
            self.placecountry(ko.unwrap(self.placedata.Country));
            self.placetimezone(ko.unwrap(self.placedata.TimeZone));
            self.placedivision(ko.unwrap(self.placedata.Division));
            self.placedepartment(ko.unwrap(self.placedata.Department));
            self.placedisplayorder(ko.unwrap(self.placedata.DisplayOrder));

            self.DefaultPlaceCountry.Set();
        },
        Populate: function() {
            if (typeof self.placedata === "undefined") {
                self.Place.Clear();
                return;
            }
            self.Place.Set();
            self.placedata = ko.observableArray([]);
        }
    };

    self.PlacePhoneSettings = {
        Build: function() {
            return {
                RecordId: self.placephonesettingid,
                MobileCarrier: self.cellcarrier,
                AllowText: self.cellaccepttext(),
                PrimaryPhoneType: self.PlacePrimaryPhone.phoneprimaryid
            };
        },
        Clear: function() {
            self.placephonesettingid = 0;
            self.PlacePrimaryPhone.phoneprimaryid = 0;
        },
        Set: function() {
            self.placephonesettingid = ko.unwrap(self.placedata.RecordId);
            if (self.placephonesettingid === 0) {
                self.PlacePhoneSettings.Clear();
                return;
            };
            self.cellaccepttext(ko.unwrap(self.placedata.AllowText));
            self.cellcarrier(ko.unwrap(self.placedata.MobileCarrier));
            self.PlacePrimaryPhone.phoneprimaryid = ko.unwrap(self.placedata.PrimaryPhoneType);

            self.PlacePrimaryPhone.Set();
        },
        Populate: function() {
            if (typeof self.placedata === "undefined") {
                self.PlacePhoneSettings.Clear();
                return;
            }
            self.PlacePhoneSettings.Set();
            self.placedata = ko.observableArray([]);
        }
    };

    self.Contacts = {
        Clear: function () {
            self.personlist([]);
        },
        Set: function () {
            self.personlist = ko.mapping.fromJS(self.placedata);
        },
        Populate: function () {
            if (typeof self.placedata === "undefined") {
                self.Contacts.Clear();
                return;
            }
            self.Contacts.Set();
            self.placedata = ko.observableArray([]);
        }
    };

    self.GetPlaceData = function () {
        $.ajax({
            url: baseUrl + "GetPlace/" + ko.unwrap(self.placeid()),
            type: "post"
        }).then(function(returndata) {

            self.placedata = ko.mapping.fromJS(returndata.Phones.PhoneSettings);
            self.PlacePhoneSettings.Populate();

            self.placedata = ko.mapping.fromJS(returndata.Phones.FaxPhone);
            self.PlaceFax.Populate();

            self.placedata = ko.mapping.fromJS(returndata.Phones.CellPhone);
            self.PlaceCell.Populate();

            self.placedata = ko.mapping.fromJS(returndata.Phones.HomePhone);
            self.PlaceHome.Populate();

            self.placedata = ko.mapping.fromJS(returndata.Phones.WorkPhone);
            self.PlaceWork.Populate();

            self.placedata = ko.mapping.fromJS(returndata.Addresses.ShippingAddress);
            self.PlaceShipping.Populate();

            self.placedata = ko.mapping.fromJS(returndata.Addresses.MailingAddress);
            self.PlaceMailing.Populate();

            self.placedata = ko.mapping.fromJS(returndata.Contacts);
            self.Contacts.Populate();

            self.placedata = ko.mapping.fromJS(returndata.Place);
            self.Place.Populate();
        });
    };

    self.ManageSort = {
        ManageType: function(type) {
            if (type === 0) {
                type = 1;
            };
            if (self.sorttype === type) {
                return;
            };
            self.sorttype = type;

            self.pauseNotifications = true;
            self.sortdirection(-1);
            self.pauseNotifications = false;
        },
        ManageDirection: function(type) {
            self.ManageSort.ManageType(type);
            self.sortdirection(self.sortdirection() * -1);
        },
        Change: function(type) {
            if (type === 0) {
                self.IsSorting(!self.IsSorting());
            };
            if (!self.IsSorting() && (type !== 0)) {
                self.ManageSort.ManageDirection(type);
                self.ReorderList.ReorderAfterSort();
            };
        }
    };

    self.SortDisplayOrder = {
        Filtered: function() {
            return ko.utils.arrayFilter(self.listitems(), function(item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function(l, r) {
                return (parseInt(l.DisplayOrder()) > parseInt(r.DisplayOrder())) ^ (self.direction === -1);
            });
        },
        Unfiltered: function() {
            return self.listitems().sort(function(l, r) {
                return (parseInt(l.DisplayOrder()) > parseInt(r.DisplayOrder())) ^ (self.direction === -1);
            });
        },
        Manage: function() {
            return (self.filter.length === 0)
                ? self.SortDisplayOrder.Unfiltered()
                : self.SortDisplayOrder.Filtered();
        }
    };

    self.SortCountry = {
        Filtered: function() {
            return ko.utils.arrayFilter(self.listitems(), function(item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function(l, r) {
                return (parseInt(l.Country()) > parseInt(r.Country())) ^ (self.direction === -1);
            });
        },
        Unfiltered: function() {
            return self.listitems().sort(function(l, r) {
                return (parseInt(l.Country()) > parseInt(r.Country())) ^ (self.direction === -1);
            });
        },
        Manage: function() {
            return (self.filter.length === 0)
                ? self.SortCountry.Unfiltered(self.sortdirection())
                : self.SortCountry.Filtered(self.sortdirection());
        }
    };

    self.SortTimeZone = {
        Filtered: function() {
            return ko.utils.arrayFilter(self.listitems(), function(item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function(l, r) {
                return (l.TimeZoneName().toLowerCase() > r.TimeZoneName().toLowerCase()) ^ (self.direction === -1);
            });
        },
        Unfiltered: function() {
            return self.listitems().sort(function(l, r) {
                return (l.TimeZoneName().toLowerCase() > r.TimeZoneName().toLowerCase()) ^ (self.direction === -1);
            });
        },
        Manage: function() {
            return (self.filter.length === 0)
                ? self.SortTimeZone.Unfiltered(self.sortdirection())
                : self.SortTimeZone.Filtered(self.sortdirection());
        }
    };

    self.SortName = {
        Filtered: function() {
            return ko.utils.arrayFilter(self.listitems(), function(item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function(l, r) {
                return (l.Name().toLowerCase() > r.Name().toLowerCase()) ^ (self.direction === -1);
            });
        },
        Unfiltered: function() {
            return self.listitems().sort(function(l, r) {
                return (l.Name().toLowerCase() > r.Name().toLowerCase()) ^ (self.direction === -1);
            });
        },
        Manage: function() {
            return (self.filter.length === 0)
                ? self.SortName.Unfiltered(self.sortdirection())
                : self.SortName.Filtered(self.sortdirection());
        }
    };

    self.SortDepartment = {
        Filtered: function() {
            return ko.utils.arrayFilter(self.listitems(), function(item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function(l, r) {
                return (l.Department().toLowerCase() > r.Department().toLowerCase()) ^ (self.direction === -1);
            });
        },
        Unfiltered: function() {
            return self.listitems().sort(function(l, r) {
                return (l.Department().toLowerCase() > r.Department().toLowerCase()) ^ (self.direction === -1);
            });
        },
        Manage: function() {
            return (self.filter.length === 0)
                ? self.SortDepartment.Unfiltered(self.sortdirection())
                : self.SortDepartment.Filtered(self.sortdirection());
        }
    };

    self.SortDivision = {
        Filtered: function() {
            return ko.utils.arrayFilter(self.listitems(), function(item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function(l, r) {
                return (l.Division().toLowerCase() > r.Division().toLowerCase()) ^ (self.direction === -1);
            });
        },
        Unfiltered: function() {
            return self.listitems().sort(function(l, r) {
                return (l.Division().toLowerCase() > r.Division().toLowerCase()) ^ (self.direction === -1);
            });
        },
        Manage: function() {
            return (self.filter.length === 0)
                ? self.SortDivision.Unfiltered()
                : self.SortDivision.Filtered();
        }
    };

    self.filteredItems = function() {
        self.direction = ko.unwrap(self.sortdirection);
        self.filter = ko.unwrap(self.searchvalue).toLowerCase();
        switch (self.sorttype) {
        case 1:
            return self.SortDisplayOrder.Manage();
        case 2:
            return self.SortName.Manage();
        case 3:
            return self.SortDepartment.Manage();
        case 4:
            return self.SortDivision.Manage();
        case 5:
            return self.SortTimeZone.Manage();
        case 6:
            return self.SortCountry.Manage();
        default:
            return self.SortDisplayOrder.Manage();
        }
    };

    self.clear = function () {
        self.errmsg("");
        self.IsEdit(false);
        self.IsEditContact(true);

        self.PlaceFax.Clear();
        self.PlaceCell.Clear();
        self.PlaceHome.Clear();
        self.PlaceWork.Clear();
        self.Place.Clear();
        self.Contact.Clear();
        self.PlaceMailing.Clear();
        self.PlaceShipping.Clear();
        self.Contacts.Clear();
        self.PlacePhoneSettings.Clear();
    };

    self.toggleview = function() {
        self.setmessageview();
        self.IsListAreaVisible(!self.IsListAreaVisible());
        self.IsSearchAreaVisible(!self.IsSearchAreaVisible());
        self.IsAddEditAreaVisible(!self.IsAddEditAreaVisible());
    };

    self.clearandtoggle = function() {
        self.clear();
        self.toggleview();
    };

    self.edit = function(editdata) {
        self.IsEdit(true);
        self.placeid(ko.unwrap(editdata.PlaceId()));

        self.GetPlaceData();
        self.DetailView.Primary();

        self.toggleview();
    };

    self.add = function () {
        self.clearandtoggle();
        self.placename(self.searchvalue());
    };

    self.cancel = function() {
        self.clearandtoggle();
    };

    self.reset = function() {
        self.searchvalue("");
    };

    self.ProcessSave = {
        CountryName: function() {
            var id = parseInt(self.placecountry());
            if (id === 0) {
                return "";
            };
            var match = ko.utils.arrayFirst(self.countries(), function(item) {
                return parseInt(item.Value()) === id;
            });
            if (match) {
                return ko.unwrap(match.Text);
            }
            return "";
        },
        TimeZoneName: function() {
            var id = parseInt(self.placetimezone());
            if (id === 0) {
                return "";
            };
            var match = ko.utils.arrayFirst(self.timezones(), function(item) {
                return parseInt(item.Value()) === id;
            });
            if (match) {
                return ko.unwrap(match.Text);
            }
            return "";
        },
        ProcessAdd: function() {
            self.ReorderList.ReorderDragDrop();
            self.listitems.push(self.Place.Build());
        },
        ItemExists: function() {
            var match = ko.utils.arrayFirst(self.listitems(), function(item) {
                return item.PlaceId() === self.placeid();
            });
            return match;
        },
        ProcessEdit: function() {
            self.listitems.replace(self.ProcessSave.ItemExists(), self.Place.Build());
        },
        Manage: function() {
            if (self.IsEdit()) {
                self.ProcessSave.ProcessEdit();
                return;
            }
            if (self.ProcessSave.ItemExists()) {
                return;
            }
            self.ProcessSave.ProcessAdd();
        }
    };

    self.SavePlaceData = {
        BuildPlaceData: function() {
            return {
                Place: self.Place.Build(),
                FaxPhone: self.PlaceFax.Build(),
                CellPhone: self.PlaceCell.Build(),
                HomePhone: self.PlaceHome.Build(),
                WorkPhone: self.PlaceWork.Build(),
                MailingAddress: self.PlaceMailing.Build(),
                ShippingAddress: self.PlaceShipping.Build(),
                PhoneSetting: self.PlacePhoneSettings.Build(),
                UseMailingForShipping: self.UseMailingforShipping()
            };
        },
        Save: function() {
            $.ajax({
                url: baseUrl + "SavePlace",
                type: "post",
                data: self.SavePlaceData.BuildPlaceData()
            }).then(function(returndata) {

                self.handleplacereturndata(returndata);
                if (self.IsMessageAreaVisible()) {
                    return;
                }
                self.ProcessSave.Manage();
                self.clearandtoggle();
            });
        }
    };

    self.RemoveItem = {
        SetListItemInactive: function(removedata) {
            $.ajax({
                url: baseUrl + removedata.PlaceId(),
                type: "delete"
            }).then(function(returndata) {

                self.handleplacereturndata(returndata);
                if (self.IsMessageAreaVisible()) {
                    return;
                }
                self.listitems.remove(removedata);
                self.clear();
            });
        },
        Validate: function(item) {
            if (!confirm("Delete Item: '" + ko.unwrap(item.Name) + "'?")) {
                return;
            }
            self.RemoveItem.SetListItemInactive(item);
        }
    };

    self.RemoveContact = {
        SetListItemInactive: function (item) {
            $.ajax({
                url: baseUrl + "DeleteContact/" + ko.unwrap(item.PersonId()),
                type: "post"
            }).then(function (returndata) {

                self.errmsg(returndata);
                self.setmessageview();
                if (self.IsMessageAreaVisible()) {
                    return;
                }
                self.personlist.remove(item);
                self.IsEditContact(true);
                self.IsEditContact(false);
            });
        },
        Validate: function (item) {
            if (!confirm("Delete Contact: '" + ko.unwrap(item.FullName) + "'?")) {
                return;
            }
            self.RemoveContact.SetListItemInactive(item);
        }
    };

    self.makelistsortable = function () {
        var fixHelperModified = function(e, tr) {
            var $originals = tr.children();
            var $helper = tr.clone();
            $helper.children().each(function(index) {
                $(this).width($originals.eq(index).width());
            });
            return $helper;
        };
        $("#datatable tbody").sortable({
            helper: fixHelperModified,
            stop: self.ReorderList.ReorderDragDrop
        }).disableSelection();
    };

    self.ReorderList = {
        displayreorder: ko.observableArray(),
        Reorder: {
            Save: function() {
                $.ajax({
                    type: "post",
                    url: baseUrl + "DisplayOrder",
                    dataType: "json",
                    data: ko.toJSON(self.ReorderList.displayreorder),
                    contentType: "application/json; charset=utf-8"
                });
            },
            EditList: function(placeid, value) {
                var match = ko.utils.arrayFirst(self.listitems(), function(item) {
                    return parseInt(item.PlaceId()) === placeid;
                });
                if (match) {
                    self.pauseNotifications = true;
                    match.DisplayOrder(value);
                    self.pauseNotifications = false;
                }
            },
            ManageList: function() {
                for (var i = 0; i < self.ReorderList.displayreorder().length; i++) {
                    self.ReorderList.Reorder.EditList(
                        ko.unwrap(self.ReorderList.displayreorder()[i].Id),
                        ko.unwrap(self.ReorderList.displayreorder()[i].DisplayOrder)
                    );
                }
            },
            RefreshHtml: function() {
                self.IsDisplayOrderChanged(true);
                self.IsDisplayOrderChanged(false);
                self.makelistsortable();
            },
            ManageSort: function() {
                if (self.ReorderList.displayreorder().length === 0) {
                    return;
                }
                self.ReorderList.Reorder.Save();
                self.ReorderList.displayreorder([]);
            },
            ManageDragDrop: function() {
                if (self.ReorderList.displayreorder().length === 0) {
                    return;
                }
                self.ReorderList.Reorder.Save();
                self.ReorderList.Reorder.ManageList();
                self.ReorderList.Reorder.RefreshHtml();
                self.ReorderList.displayreorder([]);
            }
        },
        Capture: function(placeid, value) {
            self.ReorderList.displayreorder.push(
            {
                Id: placeid,
                DisplayOrder: value
            });
        },
        ReorderInnerText: function() {
            var newindex = 0;
            var rowindex = 0;
            var rowplaceid = 0;
            var rowdisplayorder = 0;

            self.ReorderList.displayreorder([]);
            $("#datatable tbody").children().each(function() {
                newindex = newindex + 1;
                rowplaceid = parseInt($("#datatable tbody").children()[rowindex].children[1].innerText);
                rowdisplayorder = parseInt($("#datatable tbody").children()[rowindex].children[2].innerText);
                if (rowdisplayorder !== newindex) {
                    self.ReorderList.Capture(rowplaceid, newindex);
                    $("#datatable tbody").children()[rowindex].children[2].innerText = newindex;
                }
                rowindex = rowindex + 1;
            });
        },
        ReorderAfterSort: function() {
            self.ReorderList.ReorderInnerText();
            self.ReorderList.Reorder.ManageSort();
        },
        ReorderDragDrop: function() {
            self.ReorderList.ReorderInnerText();
            self.ReorderList.Reorder.ManageDragDrop();
        }
    };

    self.makelistsortable();
};