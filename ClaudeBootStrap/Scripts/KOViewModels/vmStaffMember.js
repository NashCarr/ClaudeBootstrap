
PersonViewModel = function(data) {
    var self = this;
    var baseUrl = "/StaffMember/";

    self.personHeader = "Staff Member";
    self.detailHeader = "Staff Member Details";
    self.phoneHeader = ko.observable("Phones");
    self.detailSubHeader = ko.observable("List");
    self.addressHeader = ko.observable("Mailing");

    self.faxphonetype = "Fax";
    self.cellphonetype = "Cell";
    self.homephonetype = "Home";
    self.workphonetype = "Work";
    self.mailingaddresstype = "Mailing";
    self.shippingaddresstype = "Shipping";

    self.sorttype = 1;
    self.direction = 1;
    self.sortdirection = ko.observable(1);
    self.IsDragDrop = ko.observable(false);

    self.IsEdit = ko.observable(false);
    self.IsSaveClose = ko.observable(false);
    self.IsEditContact = ko.observable(false);
    self.IsSaveContact = ko.observable(false);

    self.IsPersonFaxPhoneVisible = ko.observable(false);
    self.IsPersonCellPhoneVisible = ko.observable(false);
    self.IsPersonHomePhoneVisible = ko.observable(false);
    self.IsPersonWorkPhoneVisible = ko.observable(false);
    self.IsPersonAddressDetailVisible = ko.observable(false);
    self.IsPersonMailingAddressVisible = ko.observable(false);
    self.IsPersonShippingAddressVisible = ko.observable(false);

    self.IsPhoneDetailVisible = ko.observable(false);
    self.IsPrimaryDetailVisible = ko.observable(true);
    self.IsContactDetailVisible = ko.observable(false);

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
    self.personfaxassociationid = 0;
    self.personcellassociationid = 0;
    self.personhomeassociationid = 0;
    self.personworkassociationid = 0;
    self.personmailingassociationid = 0;
    self.personshippingassociationid = 0;

    //ids
    self.personfaxid = 0;
    self.personcellid = 0;
    self.personhomeid = 0;
    self.personworkid = 0;
    self.personmailingid = 0;
    self.personshippingid = 0;
    self.personphonesettingid = 0;

    //fax
    self.personfaxcountry = ko.observable(0);
    self.personfaxphonenumber = ko.observable("");

    //cell
    self.personcellcountry = ko.observable(0);
    self.personcellcarrier = ko.observable(0);
    self.personcellphonenumber = ko.observable("");
    self.personcellaccepttext = ko.observable(true);

    //home
    self.personhomecountry = ko.observable(0);
    self.personhomephonenumber = ko.observable("");

    //work
    self.personworkcountry = ko.observable(0);
    self.personworkextension = ko.observable("");
    self.personworkphonenumber = ko.observable("");

    //mailing
    self.personmailingcity = ko.observable("");
    self.personmailingcountry = ko.observable(0);
    self.personmailingaddress1 = ko.observable("");
    self.personmailingaddress2 = ko.observable("");
    self.personmailingpostalcode = ko.observable("");
    self.personmailingstateprovinceid = ko.observable("");
    self.personUseMailingforShipping = ko.observable(true);

    //shipping
    self.personshippingcity = ko.observable("");
    self.personshippingcountry = ko.observable(0);
    self.personshippingaddress1 = ko.observable("");
    self.personshippingaddress2 = ko.observable("");
    self.personshippingpostalcode = ko.observable("");
    self.personshippingstateprovinceid = ko.observable("");

    self.itemdata = ko.observableArray([]);
 
    //list
    self.listitems = ko.mapping.fromJS(data.ListEntity).extend({ deferred: true });

    //lookups
    self.timezones = ko.mapping.fromJS(data.TimeZones).extend({ deferred: true });
    self.countries = ko.mapping.fromJS(data.Countries).extend({ deferred: true });
    self.postalcodes = ko.mapping.fromJS(data.PostalCodes).extend({ deferred: true });
    self.mobilecarriers = ko.mapping.fromJS(data.MobileCarriers).extend({ deferred: true });
    self.statesprovinces = ko.mapping.fromJS(data.StatesProvinces).extend({ deferred: true });

    self.DefaultMailingValues = ko.computed(function() {
        if (self.personmailingpostalcode().length === 0) {
            return;
        };
        var match = ko.utils.arrayFirst(self.postalcodes(), function(item) {
            return ko.unwrap(item.Text()) === ko.unwrap(self.personmailingpostalcode());
        });
        if (match) {
            self.personmailingcity(ko.unwrap(match.City));
            self.personmailingcountry(ko.unwrap(match.Country));
            self.personmailingstateprovinceid(ko.unwrap(match.StateProvinceId));
        };
    });

    self.DefaultShippingValues = ko.computed(function() {
        if (self.personshippingpostalcode().length === 0) {
            return;
        };
        var match = ko.utils.arrayFirst(self.postalcodes(), function(item) {
            return ko.unwrap(item.Text()) === ko.unwrap(self.personshippingpostalcode());
        });
        if (match) {
            self.personshippingcity(ko.unwrap(match.City));
            self.personshippingcountry(ko.unwrap(match.Country));
            self.personshippingstateprovinceid(ko.unwrap(match.StateProvinceId));
        };
    });

    self.PersonPrimaryPhone = {
        phoneprimaryid: 0,
        workisprimary: ko.observable(true),
        cellisprimary: ko.observable(false),
        homeisprimary: ko.observable(false),

        Cell: function() {
            if (!self.PersonPrimaryPhone.cellisprimary()) {
                self.PersonPrimaryPhone.phoneprimaryid = 0;
                return;
            };
            self.PersonPrimaryPhone.homeisprimary(false);
            self.PersonPrimaryPhone.workisprimary(false);
            self.PersonPrimaryPhone.phoneprimaryid = 2;
        },
        Home: function() {
            if (!self.PersonPrimaryPhone.homeisprimary()) {
                self.PersonPrimaryPhone.phoneprimaryid = 0;
                return;
            };
            self.PersonPrimaryPhone.cellisprimary(false);
            self.PersonPrimaryPhone.workisprimary(false);
            self.PersonPrimaryPhone.phoneprimaryid = 1;
        },

        Work: function() {
            if (!self.PersonPrimaryPhone.workisprimary()) {
                self.PersonPrimaryPhone.phoneprimaryid = 0;
                return;
            };
            self.PersonPrimaryPhone.cellisprimary(false);
            self.PersonPrimaryPhone.homeisprimary(false);
            self.PersonPrimaryPhone.phoneprimaryid = 3;
        },
        Set: function() {
            switch (self.PersonPrimaryPhone.phoneprimaryid) {
            case 1:
                self.PersonPrimaryPhone.homeisprimarye(true);
                self.PersonPrimaryPhone.Home();
                break;
            case 2:
                self.PersonPrimaryPhone.cellisprimary(true);
                self.PersonPrimaryPhone.Cell();
                break;
            case 3:
                self.PersonPrimaryPhone.workisprimary(true);
                self.PersonPrimaryPhone.Work();
                break;
            default:
                self.PersonPrimaryPhone.workisprimary(true);
                self.PersonPrimaryPhone.Work();
                break;
            };
        }
    };

    self.PersonPhoneView = {
        Fax: function() {
            self.IsPersonFaxPhoneVisible(true);
            self.IsPersonCellPhoneVisible(false);
            self.IsPersonHomePhoneVisible(false);
            self.IsPersonWorkPhoneVisible(false);
            self.phoneHeader("Phones: " + self.faxphonetype);
        },
        Cell: function() {
            self.IsPersonFaxPhoneVisible(false);
            self.IsPersonCellPhoneVisible(true);
            self.IsPersonHomePhoneVisible(false);
            self.IsPersonWorkPhoneVisible(false);
            self.phoneHeader("Phones: " + self.cellphonetype);
        },
        Home: function() {
            self.IsPersonFaxPhoneVisible(false);
            self.IsPersonCellPhoneVisible(false);
            self.IsPersonHomePhoneVisible(true);
            self.IsPersonWorkPhoneVisible(false);
            self.phoneHeader("Phones: " + self.homephonetype);
        },
        Work: function() {
            self.IsPersonFaxPhoneVisible(false);
            self.IsPersonCellPhoneVisible(false);
            self.IsPersonHomePhoneVisible(false);
            self.IsPersonWorkPhoneVisible(true);
            self.phoneHeader("Phones: " + self.workphonetype);
        },
        Default: function() {
            self.IsPersonFaxPhoneVisible(false);
            self.IsPersonCellPhoneVisible(false);
            self.IsPersonHomePhoneVisible(false);
            self.IsPersonWorkPhoneVisible(false);
        },
        Primary: function() {
            if (self.PersonPrimaryPhone.phoneprimaryid === 0) {
                self.PersonPrimaryPhone.phoneprimaryid = self.PersonPrimaryPhone.phoneprimaryid;
            };
            switch (self.PersonPrimaryPhone.phoneprimaryid) {
            case 1:
                self.PersonPhoneView.Home();
                break;
            case 2:
                self.PersonPhoneView.Cell();
                break;
            case 3:
                self.PersonPhoneView.Work();
                break;
            default:
                self.PersonPhoneView.Work();
                break;
            }
        }
    };

    self.PersonAddressView = {
        Mailing: function() {
            self.PersonPhoneView.Default();
            self.IsPersonMailingAddressVisible(true);
            self.IsPersonShippingAddressVisible(false);
        },
        Shipping: function() {
            self.PersonPhoneView.Default();
            self.IsPersonMailingAddressVisible(false);
            self.IsPersonShippingAddressVisible(true);
        },
        Default: function() {
            self.IsPersonMailingAddressVisible(false);
            self.IsPersonShippingAddressVisible(false);
        }
    };

    self.DetailView = {
        Primary: function() {
            self.IsPhoneDetailVisible(false);
            self.IsPrimaryDetailVisible(true);
            self.IsPersonAddressDetailVisible(false);
            self.IsContactDetailVisible(false);
        },
        Phones: function() {
            self.IsPhoneDetailVisible(true);
            self.IsPrimaryDetailVisible(false);
            self.IsPersonAddressDetailVisible(false);
            self.IsContactDetailVisible(false);

            self.PersonPhoneView.Primary();
            self.PersonAddressView.Default();
        },
        Addresses: function() {
            self.IsPhoneDetailVisible(false);
            self.IsPersonAddressDetailVisible(true);
            self.IsPrimaryDetailVisible(false);
            self.IsContactDetailVisible(false);

            self.PersonPhoneView.Default();
            self.PersonAddressView.Mailing();
        }
    };

    self.DetailListEdit = {
        Fax: function() {
            self.DetailView.Phones();
            self.PersonPhoneView.Fax();
        },
        Cell: function() {
            self.DetailView.Phones();
            self.PersonPhoneView.Cell();
        },
        Home: function() {
            self.DetailView.Phones();
            self.PersonPhoneView.Home();
        },
        Work: function() {
            self.DetailView.Phones();
            self.PersonPhoneView.Work();
        },
        Mailing: function() {
            self.DetailView.Addresses();
            self.PersonAddressView.Mailing();
        },
        Shipping: function() {
            self.DetailView.Addresses();
            self.PersonAddressView.Shipping();
        }
    };

    self.stateprovincename = function(id) {
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

    self.PersonMailingAddress = {
        Address: ko.computed(function() {
            if (self.personmailingaddress1().length === 0) {
                return "";
            };
            if (self.personmailingaddress2().length === 0) {
                return ko.unwrap(self.personmailingaddress1());
            };
            return ko.unwrap(self.personmailingaddress1()) + ", " + ko.unwrap(self.personmailingaddress2());
        }),
        CityStateZip: ko.computed(function() {
            if (self.personmailingcity().length === 0) {
                return "";
            };
            return ko.unwrap(self.personmailingcity()) + ", " + (self.stateprovincename(ko.unwrap(self.personmailingstateprovinceid())) + " " + ko.unwrap(self.personmailingpostalcode())).trim();
        }),
        Value: function() {
            return (ko.unwrap(self.PersonMailingAddress.Address()) + ", " + ko.unwrap(self.PersonMailingAddress.CityStateZip())).trim();
        }
    };

    self.PersonShippingAddress = {
        Address: ko.computed(function() {
            if (self.personshippingaddress1().length === 0) {
                return "";
            };
            if (self.personshippingaddress2().length === 0) {
                return ko.unwrap(self.personshippingaddress1());
            };
            return ko.unwrap(self.personshippingaddress1()) + ", " + ko.unwrap(self.personshippingaddress2());
        }),
        CityStateZip: ko.computed(function() {
            if (self.personshippingcity().length === 0) {
                return "";
            };
            return ko.unwrap(self.personshippingcity()) + ", " + (self.stateprovincename(ko.unwrap(self.personshippingstateprovinceid())) + " " + ko.unwrap(self.personshippingpostalcode())).trim();
        }),
        Value: function() {
            return ko.unwrap(self.PersonShippingAddress.Address()) + ", " + ko.unwrap(self.PersonShippingAddress.CityStateZip());
        }
    };

    self.personcellcarriername = ko.computed(function() {
        var id = parseInt(self.personcellcarrier());
        if (id === 0) {
            return "";
        };
        var match = ko.utils.arrayFirst(self.mobilecarriers(), function(item) {
            return parseInt(item.Value()) === id;
        });
        if (match) {
            return ko.unwrap(match.Text);
        };
        return "";
    });

    self.ShowPersonShipping = ko.computed(function() {
        return !self.personUseMailingforShipping();
    });

    self.DragDropComplete = ko.computed(function() {
        return !self.IsDisplayOrderChanged();
    });

    self.returnmessage = ko.pureComputed(function() {
        return ko.unwrap(self.errmsg);
    });

    self.setmessageview = function() {
        self.IsMessageAreaVisible(self.errmsg().length);
    };

    self.handlepersonreturndata = function(returndata) {
        self.personid(returndata.Id);
        self.errmsg(returndata.ErrMsg);

        self.setmessageview();
    };

    self.DefaultPersonCountry = {
        Fax: function() {
            if (typeof self.personfaxcountry() !== "undefined") {
                if (self.personfaxphonenumber().length !== 0) {
                    if (self.personfaxcountry() !== 0) {
                        return;
                    };
                };
            };
            self.personfaxcountry(self.personcountry());
        },
        Cell: function() {
            if (typeof self.personcellcountry() !== "undefined") {
                if (self.personcellphonenumber().length !== 0) {
                    if (self.personcellcountry() !== 0) {
                        return;
                    };
                };
            };
            self.personcellcountry(self.personcountry());
        },
        Home: function() {
            if (typeof self.personhomecountry() !== "undefined") {
                if (self.personhomephonenumber().length !== 0) {
                    if (self.personhomecountry() !== 0) {
                        return;
                    };
                };
            };
            self.personhomecountry(self.personcountry());
        },
        Work: function() {
            if (typeof self.personworkcountry() !== "undefined") {
                if (self.personworkphonenumber().length !== 0) {
                    if (self.personworkcountry() !== 0) {
                        return;
                    };
                };
            };
            self.personworkcountry(self.personcountry());
        },
        Mailing: function() {
            if (typeof self.personmailingcountry() !== "undefined") {
                if (self.personmailingaddress1().length !== 0) {
                    if (self.personmailingcountry() !== 0) {
                        return;
                    };
                };
            };
            self.personmailingcountry(self.personcountry());
        },
        Shipping: function() {
            if (typeof self.personshippingcountry() !== "undefined") {
                if (self.personshippingaddress1().length !== 0) {
                    if (self.personshippingcountry() !== 0) {
                        return;
                    };
                };
            };
            self.personshippingcountry(self.personcountry());
        },
        Set: function() {
            if (typeof self.personcountry() === "undefined") {
                return;
            };
            self.DefaultPersonCountry.Fax();
            self.DefaultPersonCountry.Cell();
            self.DefaultPersonCountry.Home();
            self.DefaultPersonCountry.Work();
            self.DefaultPersonCountry.Mailing();
            self.DefaultPersonCountry.Shipping();
        }
    };

    self.DefaultPersonShipping = {
        Address1: function() {
            switch (typeof self.personmailingaddress1()) {
            case "undefined":
                break;
            default:
                self.personshippingaddress1(self.personmailingaddress1());
                break;
            };
        },
        Address2: function() {
            switch (typeof self.personmailingaddress2()) {
            case "undefined":
                break;
            default:
                self.personshippingaddress2(self.personmailingaddress2());
                break;
            };
        },
        City: function() {
            switch (typeof self.personmailingcity()) {
            case "undefined":
                break;
            default:
                if (
                    (self.personUseMailingforShipping()) ||
                    (typeof self.personshippingcity() === "undefined")
                ) {
                    self.personshippingcity(self.personmailingcity());
                    return;
                };
                if (self.personshippingcity().length === 0) {
                    self.personshippingcity(self.personmailingcity());
                };
                break;
            };
        },
        PostalCode: function() {
            switch (typeof self.personmailingpostalcode()) {
            case "undefined":
                break;
            default:
                if (
                    (self.personUseMailingforShipping()) ||
                    (typeof self.personshippingpostalcode() === "undefined")
                ) {
                    self.personshippingpostalcode(self.personmailingpostalcode());
                    return;
                };
                if (self.personshippingpostalcode().length === 0) {
                    self.personshippingpostalcode(self.personmailingpostalcode());
                };
                break;
            };
        },
        StateProvince: function() {
            switch (typeof self.personmailingstateprovinceid()) {
            case "undefined":
                break;
            default:
                if (
                    (self.personUseMailingforShipping()) ||
                    (typeof self.personshippingstateprovinceid() === "undefined")
                ) {
                    self.personshippingstateprovinceid(self.personmailingstateprovinceid());
                    return;
                };
                if (self.personshippingstateprovinceid() === 0) {
                    self.personshippingstateprovinceid(self.personmailingstateprovinceid());
                };
                break;
            };
        },
        Basic: function() {
            self.DefaultPersonShipping.City();
            self.DefaultPersonShipping.PostalCode();
            self.DefaultPersonShipping.StateProvince();
        },
        Set: function() {
            if (self.personUseMailingforShipping()) {
                self.DefaultPersonShipping.Address1();
                self.DefaultPersonShipping.Address2();
            };
            self.DefaultPersonShipping.Basic();
        }
    };

    self.Person = {
        FullName: function() {
            return ((ko.unwrap(self.personfirst()) + " " + ko.unwrap(self.personmiddle())).trim() + " " + ko.unwrap(self.personlast())).trim();
        },
        Build: function() {
            return {
                PersonType: 0,
                FullName: self.Person.FullName(),
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
        Clear: function() {
            self.personid(0);
            self.personlast("");
            self.personemail("");
            self.personfirst("");
            self.personmiddle("");
        },
        Add: function() {
            self.Person.Clear();
            self.IsEdit(true);
            self.personcountry(ko.unwrap(self.personcountry()));
            self.persontimezone(ko.unwrap(self.persontimezone()));

            self.PersonFax.Default();
            self.PersonCell.Default();
            self.PersonHome.Default();
            self.PersonWork.Default();
            self.PersonMailing.Default();
            self.PersonShipping.Default();
            self.DefaultPersonCountry.Set();
            self.PersonPhoneSettings.Default();

            self.PersonPhoneView.Primary();
            self.PersonAddressView.Default();
        },
        Cancel: function() {
            self.errmsg("");
            self.Person.Clear();
            self.setmessageview();
            self.IsEdit(false);
        },
        Edit: function(editdata) {
            self.personid(ko.unwrap(editdata.PersonId()));
            self.personemail(ko.unwrap(editdata.Email()));
            self.persondisplayorder(ko.unwrap(editdata.DisplayOrder()));

            self.GetPersonData();

            self.IsEdit(true);
            self.PersonPhoneView.Primary();
            self.PersonAddressView.Default();
        },
        Set: function() {
            self.personid(ko.unwrap(self.itemdata.PersonId()));
            if (self.personid() === 0) {
                self.Person.Clear();
                return;
            };
            self.personemail(ko.unwrap(self.itemdata.Email()));
            self.personcountry(ko.unwrap(self.itemdata.Country));
            self.personlast(ko.unwrap(self.itemdata.LastName()));
            self.personfirst(ko.unwrap(self.itemdata.FirstName()));
            self.persontimezone(ko.unwrap(self.itemdata.TimeZone));
            self.personmiddle(ko.unwrap(self.itemdata.MiddleName()));
            self.persondisplayorder(ko.unwrap(self.itemdata.DisplayOrder));

            self.DefaultPersonCountry.Set();
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.Person.Clear();
                return;
            };
            self.Person.Set();
            self.itemdata = ko.observableArray([]);
        }
    };

    self.PersonFax = {
        Build: function() {
            if (self.personfaxphonenumber().length === 0) {
                return null;
            };
            return {
                PhoneType: 4,
                PhoneId: self.personfaxid,
                Country: ko.unwrap(self.personfaxcountry()),
                PhoneAssociationId: self.personfaxassociationid,
                PhoneNumber: ko.unwrap(self.personfaxphonenumber())
            };
        },
        Clear: function() {
            self.personfaxid = 0;
            self.personfaxassociationid = 0;

            self.personfaxcountry(0);
            self.personfaxphonenumber("");
        },
        Set: function() {
            self.personfaxassociationid = ko.unwrap(self.itemdata.PhoneAssociationId);
            if (self.personfaxassociationid === 0) {
                self.PersonFax.Clear();
                return;
            };
            self.personfaxid = ko.unwrap(self.itemdata.PhoneId);
            self.personfaxcountry(ko.unwrap(self.itemdata.Country));
            self.personfaxphonenumber(ko.unwrap(self.itemdata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PersonFax.Clear();
                return;
            };
            self.PersonFax.Set();
            self.itemdata = ko.observableArray([]);
        }
    };

    self.PersonCell = {
        Build: function() {
            if (self.personcellphonenumber().length === 0) {
                return null;
            };
            return {
                PhoneType: 2,
                PhoneId: self.personcellid,
                Country: ko.unwrap(self.personcellcountry()),
                PhoneAssociationId: self.personcellassociationid,
                PhoneNumber: ko.unwrap(self.personcellphonenumber())
            };
        },
        Clear: function() {
            self.personcellid = 0;
            self.personcellassociationid = 0;

            self.personcellcountry(0);
            self.personcellcarrier(0);
            self.personcellphonenumber("");
            self.personcellaccepttext(true);
        },
        Set: function() {
            self.personcellassociationid = ko.unwrap(self.itemdata.PhoneAssociationId);
            if (self.personcellassociationid === 0) {
                self.PersonCell.Clear();
                return;
            };
            self.personcellid = ko.unwrap(self.itemdata.PhoneId);
            self.personcellcountry(ko.unwrap(self.itemdata.Country));
            self.personcellphonenumber(ko.unwrap(self.itemdata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PersonCell.Clear();
                return;
            };
            self.PersonCell.Set();
            self.itemdata = ko.observableArray([]);
        }
    };

    self.PersonHome = {
        Build: function() {
            if (self.personhomephonenumber().length === 0) {
                return null;
            };
            return {
                PhoneType: 1,
                PhoneId: self.personhomeid,
                Country: ko.unwrap(self.personhomecountry()),
                PhoneAssociationId: self.personhomeassociationid,
                PhoneNumber: ko.unwrap(self.personhomephonenumber())
            };
        },
        Clear: function() {
            self.personhomeid = 0;
            self.personhomeassociationid = 0;

            self.personhomecountry(0);
            self.personhomephonenumber("");
        },
        Set: function() {
            self.personhomeassociationid = ko.unwrap(self.itemdata.PhoneAssociationId);
            if (self.personhomeassociationid === 0) {
                self.PersonHome.Clear();
                return;
            };
            self.personhomeid = ko.unwrap(self.itemdata.PhoneId);
            self.personhomecountry(ko.unwrap(self.itemdata.Country));
            self.personhomephonenumber(ko.unwrap(self.itemdata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PersonHome.Clear();
                return;
            };
            self.PersonHome.Set();
            self.itemdata = ko.observableArray([]);
        }
    };

    self.PersonWork = {
        Build: function() {
            if (self.personworkphonenumber().length === 0) {
                return null;
            };
            return {
                PhoneType: 3,
                PhoneId: self.personworkid,
                Country: ko.unwrap(self.personworkcountry()),
                PhoneAssociationId: self.personworkassociationid,
                PhoneNumber: ko.unwrap(self.personworkphonenumber())
            };
        },
        Clear: function() {
            self.personworkid = 0;
            self.personworkassociationid = 0;

            self.personworkcountry(0);
            self.personworkextension("");
            self.personworkphonenumber("");
        },
        Set: function() {
            self.personworkassociationid = ko.unwrap(self.itemdata.PhoneAssociationId);
            if (self.personworkassociationid === 0) {
                self.PersonWork.Clear();
                return;
            };
            self.personworkid = ko.unwrap(self.itemdata.PhoneId);
            self.personworkcountry(ko.unwrap(self.itemdata.Country));
            self.personworkphonenumber(ko.unwrap(self.itemdata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PersonWork.Clear();
                return;
            };
            self.PersonWork.Set();
            self.itemdata = ko.observableArray([]);
        }
    };

    self.PersonShipping = {
        Build: function() {
            if (self.personshippingaddress1().length === 0) {
                return null;
            };
            return {
                AddressType: 1,
                AddressId: self.personshippingid,
                City: ko.unwrap(self.personshippingcity()),
                Country: ko.unwrap(self.personshippingcountry()),
                Address1: ko.unwrap(self.personshippingaddress1()),
                Address2: ko.unwrap(self.personshippingaddress2()),
                ZipCode: ko.unwrap(self.personshippingpostalcode()),
                AddressAssociationId: self.personshippingassociationid,
                StateProvinceId: ko.unwrap(self.personshippingstateprovinceid())
            };
        },
        Clear: function() {
            self.personshippingid = 0;
            self.personshippingassociationid = 0;

            self.personshippingcity("");
            self.personshippingcountry(0);
            self.personshippingaddress1("");
            self.personshippingaddress2("");
            self.personshippingpostalcode("");
            self.personshippingstateprovinceid("");
            self.personshippingstateprovinceid("");
        },
        Set: function() {
            self.personshippingassociationid = ko.unwrap(self.itemdata.AddressAssociationId);
            if (self.personshippingassociationid === 0) {
                self.PersonShipping.Clear();
                return;
            };
            self.personshippingcity(ko.unwrap(self.itemdata.City));
            self.personshippingcountry(ko.unwrap(self.itemdata.Country));
            self.personshippingaddress1(ko.unwrap(self.itemdata.Address1));
            self.personshippingaddress2(ko.unwrap(self.itemdata.Address2));
            self.personshippingpostalcode(ko.unwrap(self.itemdata.ZipCode));
            self.personshippingid = ko.unwrap(ko.unwrap(self.itemdata.AddressId));
            self.personshippingstateprovinceid(ko.unwrap(self.itemdata.StateProvinceId));
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PersonShipping.Clear();
                return;
            };
            self.PersonShipping.Set();
            self.itemdata = ko.observableArray([]);
        }
    };

    self.PersonMailing = {
        Build: function() {
            if (self.personmailingaddress1().length === 0) {
                return null;
            };
            return {
                AddressType: 2,
                AddressId: self.personmailingid,
                City: ko.unwrap(self.personmailingcity()),
                Country: ko.unwrap(self.personmailingcountry()),
                Address1: ko.unwrap(self.personmailingaddress1()),
                Address2: ko.unwrap(self.personmailingaddress2()),
                ZipCode: ko.unwrap(self.personmailingpostalcode()),
                AddressAssociationId: self.personmailingassociationid,
                StateProvinceId: ko.unwrap(self.personmailingstateprovinceid())
            };
        },
        Clear: function() {
            self.personmailingid = 0;
            self.personmailingassociationid = 0;

            self.personmailingcity("");
            self.personmailingcountry(0);
            self.personmailingaddress1("");
            self.personmailingaddress2("");
            self.personmailingpostalcode("");
            self.personmailingstateprovinceid("");
        },
        Set: function() {
            self.personmailingassociationid = ko.unwrap(self.itemdata.AddressAssociationId);
            if (self.personmailingassociationid === 0) {
                self.PersonMailing.Clear();
                return;
            };
            self.personmailingcity(ko.unwrap(self.itemdata.City));
            self.personmailingcountry(ko.unwrap(self.itemdata.Country));
            self.personmailingaddress1(ko.unwrap(self.itemdata.Address1));
            self.personmailingaddress2(ko.unwrap(self.itemdata.Address2));
            self.personmailingpostalcode(ko.unwrap(self.itemdata.ZipCode));
            self.personmailingid = ko.unwrap(ko.unwrap(self.itemdata.AddressId));
            self.personmailingstateprovinceid(ko.unwrap(self.itemdata.StateProvinceId));
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PersonMailing.Clear();
                return;
            };
            self.PersonMailing.Set();
            self.itemdata = ko.observableArray([]);
        }
    };

    self.PersonPhoneSettings = {
        Build: function() {
            return {
                RecordId: self.personphonesettingid,
                MobileCarrier: self.personcellcarrier,
                AllowText: self.personcellaccepttext(),
                PrimaryPhoneType: self.PersonPrimaryPhone.phoneprimaryid
            };
        },
        Clear: function() {
            self.personphonesettingid = 0;
            self.PersonPrimaryPhone.phoneprimaryid = 0;
        },
        Set: function() {
            self.personphonesettingid = ko.unwrap(self.itemdata.RecordId);
            if (self.personphonesettingid === 0) {
                self.PersonPhoneSettings.Clear();
                return;
            };
            self.personcellaccepttext(ko.unwrap(self.itemdata.AllowText));
            self.personcellcarrier(ko.unwrap(self.itemdata.MobileCarrier));
            self.PersonPrimaryPhone.phoneprimaryid = ko.unwrap(self.itemdata.PrimaryPhoneType);

            self.PersonPrimaryPhone.Set();
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PersonPhoneSettings.Clear();
                return;
            };
            self.PersonPhoneSettings.Set();
            self.itemdata = ko.observableArray([]);
        }
    };

    self.GetPersonData = function() {
        $.ajax({
            url: baseUrl + "GetPerson/" + ko.unwrap(self.personid()),
            type: "post"
        }).then(function(returndata) {

            self.itemdata = ko.mapping.fromJS(returndata.Phones.PhoneSettings);
            self.PersonPhoneSettings.Populate();

            self.itemdata = ko.mapping.fromJS(returndata.Phones.FaxPhone);
            self.PersonFax.Populate();

            self.itemdata = ko.mapping.fromJS(returndata.Phones.CellPhone);
            self.PersonCell.Populate();

            self.itemdata = ko.mapping.fromJS(returndata.Phones.HomePhone);
            self.PersonHome.Populate();

            self.itemdata = ko.mapping.fromJS(returndata.Phones.WorkPhone);
            self.PersonWork.Populate();

            self.itemdata = ko.mapping.fromJS(returndata.Addresses.ShippingAddress);
            self.PersonShipping.Populate();

            self.itemdata = ko.mapping.fromJS(returndata.Addresses.MailingAddress);
            self.PersonMailing.Populate();

            self.itemdata = ko.mapping.fromJS(returndata.Person);
            self.Person.Populate();
        });
    };

    self.ManageSort = {
        IsSorting: ko.observable(false),
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
        DragDrop: function() {
            self.sorttype = 1;
            self.sortdirection(1);
        },
        Change: function(type) {
            if (type === 0) {
                self.ManageSort.IsSorting(!self.ManageSort.IsSorting());
            };
            if (!self.ManageSort.IsSorting() && (type !== 0)) {
                self.ManageSort.ManageDirection(type);
                self.ReorderList.ReorderAfterSort();
            };
        }
    };

    self.SortLastLoginDate = {
        Filtered: function() {
            return ko.utils.arrayFilter(self.listitems(), function(item) {
                return ko.unwrap(item.FullName).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function(l, r) {
                return (self.direction * (l.LastLoginDate().toLowerCase().localeCompare(r.LastLoginDate().toLowerCase())));
            });
        },
        Unfiltered: function() {
            return self.listitems().sort(function(l, r) {
                return (self.direction * (l.LastLoginDate().toLowerCase().localeCompare(r.LastLoginDate().toLowerCase())));
            });
        },
        Manage: function() {
            return (self.filter.length === 0)
                ? self.SortLastLoginDate.Unfiltered(self.sortdirection())
                : self.SortLastLoginDate.Filtered(self.sortdirection());
        }
    };

    self.SortAccessRightName = {
        Filtered: function() {
            return ko.utils.arrayFilter(self.listitems(), function(item) {
                return ko.unwrap(item.FullName).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function(l, r) {
                return (self.direction * (l.AccessRightName().toLowerCase().localeCompare(r.AccessRightName().toLowerCase())));
            });
        },
        Unfiltered: function() {
            return self.listitems().sort(function(l, r) {
                return (self.direction * (l.AccessRightName().toLowerCase().localeCompare(r.AccessRightName().toLowerCase())));
            });
        },
        Manage: function() {
            return (self.filter.length === 0)
                ? self.SortAccessRightName.Unfiltered(self.sortdirection())
                : self.SortAccessRightName.Filtered(self.sortdirection());
        }
    };

    self.SortEmail = {
        Filtered: function() {
            return ko.utils.arrayFilter(self.listitems(), function(item) {
                return ko.unwrap(item.FullName).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function(l, r) {
                return (self.direction * (l.Email().toLowerCase().localeCompare(r.Email().toLowerCase())));
            });
        },
        Unfiltered: function() {
            return self.listitems().sort(function(l, r) {
                return (self.direction * (l.Email().toLowerCase().localeCompare(r.Email().toLowerCase())));
            });
        },
        Manage: function() {
            return (self.filter.length === 0)
                ? self.SortEmail.Unfiltered(self.sortdirection())
                : self.SortEmail.Filtered(self.sortdirection());
        }
    };

    self.SortUserName = {
        Filtered: function() {
            return ko.utils.arrayFilter(self.listitems(), function(item) {
                return ko.unwrap(item.FullName).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function(l, r) {
                return (self.direction * (l.UserName().toLowerCase().localeCompare(r.UserName().toLowerCase())));
            });
        },
        Unfiltered: function() {
            return self.listitems().sort(function(l, r) {
                return (self.direction * (l.UserName().toLowerCase().localeCompare(r.UserName().toLowerCase())));
            });
        },
        Manage: function() {
            return (self.filter.length === 0)
                ? self.SortUserName.Unfiltered()
                : self.SortUserName.Filtered();
        }
    };

    self.SortFullName = {
        Filtered: function() {
            return ko.utils.arrayFilter(self.listitems(), function(item) {
                return ko.unwrap(item.FullName).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function(l, r) {
                return (self.direction * (l.FullName().toLowerCase().localeCompare(r.FullName().toLowerCase())));
            });
        },
        Unfiltered: function() {
            return self.listitems().sort(function(l, r) {
                return (self.direction * (l.FullName().toLowerCase().localeCompare(r.FullName().toLowerCase())));
            });
        },
        Manage: function() {
            return (self.filter.length === 0)
                ? self.SortFullName.Unfiltered(self.sortdirection())
                : self.SortFullName.Filtered(self.sortdirection());
        }
    };

    self.SortDisplayOrder = {
        Filtered: function() {
            return ko.utils.arrayFilter(self.listitems(), function(item) {
                return ko.unwrap(item.FullName).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function(l, r) {
                return (self.direction * (l.DisplaySort().toLowerCase().localeCompare(r.DisplaySort().toLowerCase())));
            });
        },
        Unfiltered: function() {
            return self.listitems().sort(function(l, r) {
                return (self.direction * (l.DisplaySort().toLowerCase().localeCompare(r.DisplaySort().toLowerCase())));
            });
        },
        Manage: function() {
            return (self.filter.length === 0)
                ? self.SortDisplayOrder.Unfiltered()
                : self.SortDisplayOrder.Filtered();
        }
    };

    self.filteredItems = function() {
        if (typeof self.listitems === "undefined") {
            return null;
        };
        if (self.listitems().length === 0) {
            return null;
        };
        self.direction = ko.unwrap(self.sortdirection);
        self.filter = ko.unwrap(self.searchvalue).toLowerCase();
        if (self.IsDragDrop()) {
            return null;
        };
        switch (self.sorttype) {
        case 1:
            return self.SortDisplayOrder.Manage();
        case 2:
            return self.SortUserName.Manage();
        case 3:
            return self.SortFullName.Manage();
        case 4:
            return self.SortEmail.Manage();
        case 5:
            return self.SortAccessRightName.Manage();
        case 6:
            return self.SortLastLoginDate.Manage();
        default:
            return self.SortDisplayOrder.Manage();
        }
    };

    self.clear = function() {
        self.errmsg("");
        self.IsEdit(false);
        self.IsSaveClose(false);

        self.Person.Clear();
        self.PersonFax.Clear();
        self.PersonCell.Clear();
        self.PersonHome.Clear();
        self.PersonWork.Clear();
        self.PersonMailing.Clear();
        self.PersonShipping.Clear();
        self.PersonPhoneSettings.Clear();
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

    self.PersonEdit = function(editdata) {
        self.IsEdit(true);
        self.personid(ko.unwrap(editdata.PersonId()));

        self.GetPersonData();
        self.DetailView.Primary();

        self.toggleview();
    };

    self.add = function() {
        self.clearandtoggle();
    };

    self.cancel = function() {
        self.clearandtoggle();
    };

    self.reset = function() {
        self.searchvalue("");
    };

    self.ProcessSave = {
        CountryName: function() {
            var id = parseInt(self.personcountry());
            if (id === 0) {
                return "";
            };
            var match = ko.utils.arrayFirst(self.countries(), function(item) {
                return parseInt(item.Value()) === id;
            });
            if (match) {
                return ko.unwrap(match.Text);
            };
            return "";
        },
        TimeZoneName: function() {
            var id = parseInt(self.persontimezone());
            if (id === 0) {
                return "";
            };
            var match = ko.utils.arrayFirst(self.timezones(), function(item) {
                return parseInt(item.Value()) === id;
            });
            if (match) {
                return ko.unwrap(match.Text);
            };
            return "";
        },
        ProcessAdd: function() {
            self.ReorderList.ReorderDragDrop();
            self.listitems.push(self.Person.Build());
        },
        ItemExists: function() {
            var match = ko.utils.arrayFirst(self.listitems(), function(item) {
                return item.PersonId() === self.personid();
            });
            return match;
        },
        ProcessEdit: function() {
            self.listitems.replace(self.ProcessSave.ItemExists(), self.Person.Build());
        },
        Manage: function() {
            if (self.IsEdit()) {
                self.ProcessSave.ProcessEdit();
                return;
            };
            if (self.ProcessSave.ItemExists()) {
                return;
            };
            self.ProcessSave.ProcessAdd();
        }
    };

    self.SavePerson = {
        BuildPersonData: function () {
            return {
                Person: self.Person.Build(),
                FaxPhone: self.PersonFax.Build(),
                CellPhone: self.PersonCell.Build(),
                HomePhone: self.PersonHome.Build(),
                WorkPhone: self.PersonWork.Build(),
                MailingAddress: self.PersonMailing.Build(),
                ShippingAddress: self.PersonShipping.Build(),
                PhoneSetting: self.PersonPhoneSettings.Build(),
                UseMailingForShipping: self.personUseMailingforShipping()
            };
        },
        Build: function () {
            return {
                PersonType: ko.observable(0),
                FullName: ko.observable(self.Person.FullName()),
                PersonId: ko.observable(ko.unwrap(self.personid())),
                PlaceId: ko.observable(ko.unwrap(self.placeid())),
                Email: ko.observable(ko.unwrap(self.personemail())),
                LastName: ko.observable(ko.unwrap(self.personlast())),
                FirstName: ko.observable(ko.unwrap(self.personfirst())),
                MiddleName: ko.observable(ko.unwrap(self.personmiddle()))
            };
        },
        BuildListData: function () {
            return {
                UserName: ko.observable("Test"),
                DisplayOrder: ko.observable(0),
                PrimaryPhone: ko.observable(""),
                LastLoginDate: ko.observable(""),
                AccessRightName: ko.observable("Test"),
                DisplaySort: ko.observable("0000"),
                FullName: ko.observable(self.Person.FullName()),
                Email: ko.observable(ko.unwrap(self.personemail())),
                PersonId: ko.observable(ko.unwrap(self.personid()))
            };
        },
        ProcessAdd: function () {
            self.listitems.push(self.SavePerson.BuildListData());
        },
        ItemExists: function () {
            var match = ko.utils.arrayFirst(self.listitems(), function (item) {
                return item.PersonId() === self.personid();
            });
            return match;
        },
        ProcessEdit: function () {
            self.listitems.replace(self.SavePerson.ItemExists(), self.SavePerson.BuildListData());
        },
        Process: function () {
            if (self.SavePerson.ItemExists()) {
                self.SavePerson.ProcessEdit();
                return;
            };
            self.SavePerson.ProcessAdd();
        },
        Save: function () {
            $.ajax({
                url: baseUrl + "SavePerson",
                type: "post",
                data: self.SavePerson.BuildPersonData()
            }).then(function (returndata) {
                self.handlepersonreturndata(returndata);
                if (self.IsMessageAreaVisible()) {
                    return;
                };
                self.SavePerson.Process();
                self.clearandtoggle();
            });
        }
    };

    self.RemoveItem = {
        SetListItemInactive: function(removedata) {
            $.ajax({
                url: baseUrl + removedata.PersonId(),
                type: "delete"
            }).then(function(returndata) {

                self.handlepersonreturndata(returndata);
                if (self.IsMessageAreaVisible()) {
                    return;
                };
                self.listitems.remove(removedata);
                self.clear();
            });
        },
        Validate: function(item) {
            if (!confirm("Delete Item: '" + ko.unwrap(item.FullName) + "'?")) {
                return;
            }
            self.RemoveItem.SetListItemInactive(item);
        }
    };

    self.makelistsortable = function() {
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
            DisplaySortValue: function(value) {
                if (value < 10) {
                    return "000" + value;
                };
                if (value < 100) {
                    return "00" + value;
                };
                if (value < 1000) {
                    return "0" + value;
                };
                return value.toString();
            },
            EditList: function(personid, value) {
                var match = ko.utils.arrayFirst(self.listitems(), function(item) {
                    return parseInt(item.PersonId()) === personid;
                });
                if (match) {
                    self.pauseNotifications = true;
                    match.DisplayOrder(value);
                    match.DisplaySort(self.ReorderList.Reorder.DisplaySortValue(value));
                    self.pauseNotifications = false;
                };
            },
            ManageList: function() {
                for (var i = 0; i < self.ReorderList.displayreorder().length; i++) {
                    self.ReorderList.Reorder.EditList(
                        ko.unwrap(self.ReorderList.displayreorder()[i].Id),
                        ko.unwrap(self.ReorderList.displayreorder()[i].DisplayOrder)
                    );
                };
            },
            RefreshHtml: function() {
                self.IsDragDrop(true);
                self.ManageSort.DragDrop();
                self.IsDisplayOrderChanged(true);
                self.IsDisplayOrderChanged(false);
                self.makelistsortable();
                self.IsDragDrop(false);
            },
            ManageSort: function() {
                if (self.ReorderList.displayreorder().length === 0) {
                    return;
                };
                self.ReorderList.Reorder.Save();
                self.ReorderList.displayreorder([]);
            },
            ManageDragDrop: function() {
                if (self.ReorderList.displayreorder().length === 0) {
                    return;
                };
                self.ReorderList.Reorder.Save();
                self.ReorderList.Reorder.ManageList();
                self.ReorderList.Reorder.RefreshHtml();
                self.ReorderList.displayreorder([]);
            }
        },
        Capture: function(personid, value) {
            self.ReorderList.displayreorder.push(
            {
                Id: personid,
                DisplayOrder: value
            });
        },
        ReorderInnerText: function() {
            var newindex = 0;
            var rowindex = 0;
            var rowpersonid = 0;
            var rowdisplayorder = 0;

            self.ReorderList.displayreorder([]);
            $("#datatable tbody").children().each(function() {
                newindex = newindex + 1;
                rowpersonid = parseInt($("#datatable tbody").children()[rowindex].children[1].innerText);
                rowdisplayorder = parseInt($("#datatable tbody").children()[rowindex].children[2].innerText);
                if (rowdisplayorder !== newindex) {
                    self.ReorderList.Capture(rowpersonid, newindex);
                    $("#datatable tbody").children()[rowindex].children[2].innerText = newindex;
                };
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