
OrganizationViewModel = function(data) {
    var self = this;
    var baseUrl = "/Organization/";

    self.placeHeader = "Organization";
    self.detailHeader = "Organization Details";
    self.detailSubHeader = ko.observable("List");

    self.sorttype = 1;
    self.direction = 1;
    self.IsSorting = ko.observable(false);
    self.sortdirection = ko.observable(1);

    self.IsEdit = ko.observable(false);

    self.IsFaxPhoneVisible = ko.observable(false);
    self.IsCellPhoneVisible = ko.observable(false);
    self.IsHomePhoneVisible = ko.observable(false);
    self.IsWorkPhoneVisible = ko.observable(false);
    self.IsPhoneDetailVisible = ko.observable(false);

    self.IsPrimaryDetailVisible = ko.observable(true);

    self.IsAddressDetailVisible = ko.observable(false);
    self.IsMailingAddressVisible = ko.observable(false);
    self.IsShippingAddressVisible = ko.observable(false);

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
    self.persondisplayorder = ko.observable(0);

    //associations
    self.faxassociationid = 0;
    self.cellassociationid = 0;
    self.homeassociationid = 0;
    self.workassociationid = 0;
    self.mailingassociationid = 0;
    self.shippingassociationid = 0;

    //ids
    self.faxid = 0;
    self.cellid = 0;
    self.homeid = 0;
    self.workid = 0;
    self.mailingid = 0;
    self.shippingid = 0;
    self.phonesettingid = 0;

    //fax
    self.faxphonetype = "Fax";
    self.faxcountry = ko.observable(0);
    self.faxphonenumber = ko.observable("");

    //cell
    self.cellphonetype = "Cell";
    self.cellcountry = ko.observable(0);
    self.cellcarrier = ko.observable(0);
    self.cellphonenumber = ko.observable("");
    self.cellaccepttext = ko.observable(true);

    //home
    self.homephonetype = "Home";
    self.homecountry = ko.observable(0);
    self.homephonenumber = ko.observable("");

    //work
    self.workphonetype = "Work";
    self.workcountry = ko.observable(0);
    self.workextension = ko.observable("");
    self.workphonenumber = ko.observable("");

    //mailing
    self.mailingaddresstype = "Mailing";
    self.mailingcity = ko.observable("");
    self.mailingcountry = ko.observable(0);
    self.mailingaddress1 = ko.observable("");
    self.mailingaddress2 = ko.observable("");
    self.mailingpostalcode = ko.observable("");
    self.mailingstateprovince = ko.observable("");
    self.UseMailingforShipping = ko.observable(true);

    //shipping
    self.shippingaddresstype = "Shipping";
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

    self.PrimaryPhone = {
        phoneprimaryid: 0,
        workisprimary: ko.observable(true),
        cellisprimary: ko.observable(false),
        homeisprimary: ko.observable(false),

        Cell: function() {
            if (!self.PrimaryPhone.cellisprimary()) {
                self.PrimaryPhone.phoneprimaryid = 0;
                return;
            };
            self.PrimaryPhone.homeisprimary(false);
            self.PrimaryPhone.workisprimary(false);
            self.PrimaryPhone.phoneprimaryid = 2;
        },

        Home: function() {
            if (!self.PrimaryPhone.homeisprimary()) {
                self.PrimaryPhone.phoneprimaryid = 0;
                return;
            };
            self.PrimaryPhone.cellisprimary(false);
            self.PrimaryPhone.workisprimary(false);
            self.PrimaryPhone.phoneprimaryid = 1;
        },

        Work: function() {
            if (!self.PrimaryPhone.workisprimary()) {
                self.PrimaryPhone.phoneprimaryid = 0;
                return;
            };
            self.PrimaryPhone.cellisprimary(false);
            self.PrimaryPhone.homeisprimary(false);
            self.PrimaryPhone.phoneprimaryid = 3;
        },
        Set: function() {
            switch (self.PrimaryPhone.phoneprimaryid) {
            case 1:
                self.PrimaryPhone.homeisprimarye(true);
                self.PrimaryPhone.Home();
                break;
            case 2:
                self.PrimaryPhone.cellisprimary(true);
                self.PrimaryPhone.Cell();
                break;
            case 3:
                self.PrimaryPhone.workisprimary(true);
                self.PrimaryPhone.Work();
                break;
            default:
                self.PrimaryPhone.workisprimary(true);
                self.PrimaryPhone.Work();
                break;
            };
        }
    };

    self.PhoneView = {
        Fax: function() {
            self.IsFaxPhoneVisible(true);
            self.IsCellPhoneVisible(false);
            self.IsHomePhoneVisible(false);
            self.IsWorkPhoneVisible(false);
        },
        Cell: function() {
            self.IsFaxPhoneVisible(false);
            self.IsCellPhoneVisible(true);
            self.IsHomePhoneVisible(false);
            self.IsWorkPhoneVisible(false);
        },
        Home: function() {
            self.IsFaxPhoneVisible(false);
            self.IsCellPhoneVisible(false);
            self.IsHomePhoneVisible(true);
            self.IsWorkPhoneVisible(false);
        },
        Work: function() {
            self.IsFaxPhoneVisible(false);
            self.IsCellPhoneVisible(false);
            self.IsHomePhoneVisible(false);
            self.IsWorkPhoneVisible(true);
        },
        Default: function() {
            self.IsFaxPhoneVisible(false);
            self.IsCellPhoneVisible(false);
            self.IsHomePhoneVisible(false);
            self.IsWorkPhoneVisible(false);
        },
        Primary: function() {
            switch (self.PrimaryPhone.phoneprimaryid) {
            case 1:
                self.PhoneView.Home();
                break;
            case 2:
                self.PhoneView.Cell();
                break;
            case 3:
                self.PhoneView.Work();
                break;
            default:
                self.PhoneView.Work();
                break;
            }
        }
    };

    self.AddressView = {
        Mailing: function() {
            self.IsMailingAddressVisible(true);
            self.IsShippingAddressVisible(false);
        },
        Shipping: function() {
            self.IsMailingAddressVisible(false);
            self.IsShippingAddressVisible(true);
        },
        Default: function() {
            self.IsMailingAddressVisible(false);
            self.IsShippingAddressVisible(false);
        }
    };

    self.DetailView = {
        Primary: function() {
            self.IsPhoneDetailVisible(false);
            self.IsPrimaryDetailVisible(true);
            self.IsAddressDetailVisible(false);
        },
        Phones: function() {
            self.IsPhoneDetailVisible(true);
            self.IsPrimaryDetailVisible(false);
            self.IsAddressDetailVisible(false);

            self.PhoneView.Primary();
            self.AddressView.Default();
        },
        Addresses: function() {
            self.IsPhoneDetailVisible(false);
            self.IsAddressDetailVisible(true);
            self.IsPrimaryDetailVisible(false);

            self.PhoneView.Default();
            self.AddressView.Mailing();
        }
    };

    self.DetailListEdit = {
        Fax: function () {
            self.DetailView.Phones();
            self.PhoneView.Fax();
        },
        Cell: function () {
            self.DetailView.Phones();
            self.PhoneView.Cell();
        },
        Home: function () {
            self.DetailView.Phones();
            self.PhoneView.Home();
        },
        Work: function () {
            self.DetailView.Phones();
            self.PhoneView.Work();
        },
        Mailing: function () {
            self.DetailView.Addresses();
            self.AddressView.Mailing();
        },
        Shipping: function () {
            self.DetailView.Addresses();
            self.AddressView.Shipping();
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

    self.MailingAddress = {
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
            return (ko.unwrap(self.MailingAddress.Address()) + ", " + ko.unwrap(self.MailingAddress.CityStateZip())).trim();
        }
    };

    self.ShippingAddress = {
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
            return ko.unwrap(self.ShippingAddress.Address()) + ", " + ko.unwrap(self.ShippingAddress.CityStateZip());
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

    self.ShowShipping = ko.computed(function () {
        return !self.UseMailingforShipping();
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

    self.handlereturndata = function(returndata) {
        self.placeid(returndata.Id);
        self.errmsg(returndata.ErrMsg);

        self.setmessageview();
    };

    self.DefaultCountry = {
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
            self.DefaultCountry.Fax();
            self.DefaultCountry.Cell();
            self.DefaultCountry.Home();
            self.DefaultCountry.Work();
            self.DefaultCountry.Mailing();
            self.DefaultCountry.Shipping();
        }
    };

    self.DefaultShipping = {
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
            self.DefaultShipping.City();
            self.DefaultShipping.PostalCode();
            self.DefaultShipping.StateProvince();
        },
        Set: function() {
            if (self.UseMailingforShipping()) {
                self.DefaultShipping.Address1();
                self.DefaultShipping.Address2();
            };
            self.DefaultShipping.Basic();
        }
    };

    self.Fax = {
        Build: function() {
            if (self.faxphonenumber().length === 0) {
                return null;
            };
            return {
                PhoneType: 4,
                PhoneId: self.faxid,
                Country: ko.unwrap(self.faxcountry()),
                PhoneAssociationId: self.faxassociationid,
                PhoneNumber: ko.unwrap(self.faxphonenumber())
            };
        },
        Clear: function() {
            self.faxid = 0;
            self.faxassociationid = 0;

            self.faxcountry(0);
            self.faxphonenumber("");
        },
        Set: function() {
            self.faxassociationid = ko.unwrap(self.placedata.PhoneAssociationId);
            if (self.faxassociationid === 0) {
                self.Fax.Clear();
                return;
            };
            self.faxid = ko.unwrap(self.placedata.PhoneId);
            self.faxcountry(ko.unwrap(self.placedata.Country));
            self.faxphonenumber(ko.unwrap(self.placedata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.placedata === "undefined") {
                self.Fax.Clear();
                return;
            }
            self.Fax.Set();
            self.placedata = ko.observableArray([]);
        }
    };

    self.Cell = {
        Build: function() {
            if (self.cellphonenumber().length === 0) {
                return null;
            };
            return {
                PhoneType: 2,
                PhoneId: self.cellid,
                Country: ko.unwrap(self.cellcountry()),
                PhoneAssociationId: self.cellassociationid,
                PhoneNumber: ko.unwrap(self.cellphonenumber())
            };
        },
        Clear: function() {
            self.cellid = 0;
            self.cellassociationid = 0;

            self.cellcountry(0);
            self.cellcarrier(0);
            self.cellphonenumber("");
            self.cellaccepttext(true);
        },
        Set: function() {
            self.cellassociationid = ko.unwrap(self.placedata.PhoneAssociationId);
            if (self.cellassociationid === 0) {
                self.Cell.Clear();
                return;
            };
            self.cellid = ko.unwrap(self.placedata.PhoneId);
            self.cellcountry(ko.unwrap(self.placedata.Country));
            self.cellphonenumber(ko.unwrap(self.placedata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.placedata === "undefined") {
                self.Cell.Clear();
                return;
            }
            self.Cell.Set();
            self.placedata = ko.observableArray([]);
        }
    };

    self.Home = {
        Build: function() {
            if (self.homephonenumber().length === 0) {
                return null;
            };
            return {
                PhoneType: 1,
                PhoneId: self.homeid,
                Country: ko.unwrap(self.homecountry()),
                PhoneAssociationId: self.homeassociationid,
                PhoneNumber: ko.unwrap(self.homephonenumber())
            };
        },
        Clear: function() {
            self.homeid = 0;
            self.homeassociationid = 0;

            self.homecountry(0);
            self.homephonenumber("");
        },
        Set: function() {
            self.homeassociationid = ko.unwrap(self.placedata.PhoneAssociationId);
            if (self.homeassociationid === 0) {
                self.Home.Clear();
                return;
            };
            self.homeid = ko.unwrap(self.placedata.PhoneId);
            self.homecountry(ko.unwrap(self.placedata.Country));
            self.homephonenumber(ko.unwrap(self.placedata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.placedata === "undefined") {
                self.Home.Clear();
                return;
            }
            self.Home.Set();
            self.placedata = ko.observableArray([]);
        }
    };

    self.Work = {
        Build: function() {
            if (self.workphonenumber().length === 0) {
                return null;
            };
            return {
                PhoneType: 3,
                PhoneId: self.workid,
                Country: ko.unwrap(self.workcountry()),
                PhoneAssociationId: self.workassociationid,
                PhoneNumber: ko.unwrap(self.workphonenumber())
            };
        },
        Clear: function() {
            self.workid = 0;
            self.workassociationid = 0;

            self.workcountry(0);
            self.workextension("");
            self.workphonenumber("");
        },
        Set: function() {
            self.workassociationid = ko.unwrap(self.placedata.PhoneAssociationId);
            if (self.workassociationid === 0) {
                self.Work.Clear();
                return;
            };
            self.workid = ko.unwrap(self.placedata.PhoneId);
            self.workcountry(ko.unwrap(self.placedata.Country));
            self.workphonenumber(ko.unwrap(self.placedata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.placedata === "undefined") {
                self.Work.Clear();
                return;
            }
            self.Work.Set();
            self.placedata = ko.observableArray([]);
        }
    };

    self.Shipping = {
        Build: function() {
            if (self.shippingaddress1().length === 0) {
                return null;
            };
            return {
                AddressType: 1,
                AddressId: self.shippingid,
                City: ko.unwrap(self.shippingcity()),
                Country: ko.unwrap(self.shippingcountry()),
                Address1: ko.unwrap(self.shippingaddress1()),
                Address2: ko.unwrap(self.shippingaddress2()),
                ZipCode: ko.unwrap(self.shippingpostalcode()),
                AddressAssociationId: self.shippingassociationid,
                StateProvince: ko.unwrap(self.shippingstateprovince())
            };
        },
        Clear: function() {
            self.shippingid = 0;
            self.shippingassociationid = 0;

            self.shippingcity("");
            self.shippingcountry(0);
            self.shippingaddress1("");
            self.shippingaddress2("");
            self.shippingpostalcode("");
            self.shippingstateprovince("");
            self.shippingstateprovince("");
        },
        Set: function() {
            self.shippingassociationid = ko.unwrap(self.placedata.AddressAssociationId);
            if (self.shippingassociationid === 0) {
                self.Shipping.Clear();
                return;
            };
            self.shippingcity(ko.unwrap(self.placedata.City));
            self.shippingcountry(ko.unwrap(self.placedata.Country));
            self.shippingaddress1(ko.unwrap(self.placedata.Address1));
            self.shippingaddress2(ko.unwrap(self.placedata.Address2));
            self.shippingpostalcode(ko.unwrap(self.placedata.ZipCode));
            self.shippingid = ko.unwrap(ko.unwrap(self.placedata.AddressId));
            self.shippingstateprovince(ko.unwrap(self.placedata.StateProvince));
        },
        Populate: function() {
            if (typeof self.placedata === "undefined") {
                self.Shipping.Clear();
                return;
            }
            self.Shipping.Set();
            self.placedata = ko.observableArray([]);
        }
    };

    self.Mailing = {
        Build: function() {
            if (self.mailingaddress1().length === 0) {
                return null;
            };
            return {
                AddressType: 2,
                AddressId: self.mailingid,
                City: ko.unwrap(self.mailingcity()),
                Country: ko.unwrap(self.mailingcountry()),
                Address1: ko.unwrap(self.mailingaddress1()),
                Address2: ko.unwrap(self.mailingaddress2()),
                ZipCode: ko.unwrap(self.mailingpostalcode()),
                AddressAssociationId: self.mailingassociationid,
                StateProvince: ko.unwrap(self.mailingstateprovince())
            };
        },
        Clear: function() {
            self.mailingid = 0;
            self.mailingassociationid = 0;

            self.mailingcity("");
            self.mailingcountry(0);
            self.mailingaddress1("");
            self.mailingaddress2("");
            self.mailingpostalcode("");
            self.mailingstateprovince("");
        },
        Set: function() {
            self.mailingassociationid = ko.unwrap(self.placedata.AddressAssociationId);
            if (self.mailingassociationid === 0) {
                self.Mailing.Clear();
                return;
            };
            self.mailingcity(ko.unwrap(self.placedata.City));
            self.mailingcountry(ko.unwrap(self.placedata.Country));
            self.mailingaddress1(ko.unwrap(self.placedata.Address1));
            self.mailingaddress2(ko.unwrap(self.placedata.Address2));
            self.mailingpostalcode(ko.unwrap(self.placedata.ZipCode));
            self.mailingid = ko.unwrap(ko.unwrap(self.placedata.AddressId));
            self.mailingstateprovince(ko.unwrap(self.placedata.StateProvince));
        },
        Populate: function() {
            if (typeof self.placedata === "undefined") {
                self.Mailing.Clear();
                return;
            }
            self.Mailing.Set();
            self.placedata = ko.observableArray([]);
        }
    };

    self.Place = {
        Build: function() {
            return {
                PlaceType: ko.observable(3),
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

            self.DefaultCountry.Set();
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

    self.PhoneSettings = {
        Build: function() {
            return {
                RecordId: self.phonesettingid,
                MobileCarrier: self.cellcarrier,
                AllowText: self.cellaccepttext(),
                PrimaryPhoneType: self.PrimaryPhone.phoneprimaryid
            };
        },
        Clear: function() {
            self.phonesettingid = 0;
            self.PrimaryPhone.phoneprimaryid = 0;
        },
        Set: function() {
            self.phonesettingid = ko.unwrap(self.placedata.RecordId);
            if (self.phonesettingid === 0) {
                self.PhoneSettings.Clear();
                return;
            };
            self.cellaccepttext(ko.unwrap(self.placedata.AllowText));
            self.cellcarrier(ko.unwrap(self.placedata.MobileCarrier));
            self.PrimaryPhone.phoneprimaryid = ko.unwrap(self.placedata.PrimaryPhoneType);

            self.PrimaryPhone.Set();
        },
        Populate: function() {
            if (typeof self.placedata === "undefined") {
                self.PhoneSettings.Clear();
                return;
            }
            self.PhoneSettings.Set();
            self.placedata = ko.observableArray([]);
        }
    };

    self.GetPlaceData = function() {
        $.ajax({
            url: baseUrl + "GetPlace/" + ko.unwrap(self.placeid()),
            type: "post"
        }).then(function(returndata) {

            self.placedata = ko.mapping.fromJS(returndata.Phones.PhoneSettings);
            self.PhoneSettings.Populate();

            self.placedata = ko.mapping.fromJS(returndata.Phones.FaxPhone);
            self.Fax.Populate();

            self.placedata = ko.mapping.fromJS(returndata.Phones.CellPhone);
            self.Cell.Populate();

            self.placedata = ko.mapping.fromJS(returndata.Phones.HomePhone);
            self.Home.Populate();

            self.placedata = ko.mapping.fromJS(returndata.Phones.WorkPhone);
            self.Work.Populate();

            self.placedata = ko.mapping.fromJS(returndata.Addresses.ShippingAddress);
            self.Shipping.Populate();

            self.placedata = ko.mapping.fromJS(returndata.Addresses.MailingAddress);
            self.Mailing.Populate();

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

    self.clear = function() {
        self.errmsg("");
        self.IsEdit(false);

        self.Fax.Clear();
        self.Cell.Clear();
        self.Home.Clear();
        self.Work.Clear();
        self.Place.Clear();
        self.Mailing.Clear();
        self.Shipping.Clear();
        self.PhoneSettings.Clear();
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
        self.placeid(editdata.PlaceId());

        self.GetPlaceData();
        self.DetailView.Primary();

        self.toggleview();
    };

    self.add = function() {
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
                FaxPhone: self.Fax.Build(),
                CellPhone: self.Cell.Build(),
                HomePhone: self.Home.Build(),
                WorkPhone: self.Work.Build(),
                MailingAddress: self.Mailing.Build(),
                ShippingAddress: self.Shipping.Build(),
                PhoneSetting: self.PhoneSettings.Build(),
                UseMailingForShipping: self.UseMailingforShipping()
            };
        },
        Save: function() {
            $.ajax({
                url: baseUrl + "SavePlace",
                type: "post",
                data: self.SavePlaceData.BuildPlaceData()
            }).then(function(returndata) {

                self.handlereturndata(returndata);
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

                self.handlereturndata(returndata);
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