﻿
CustomerViewModel = function(data) {
    var self = this;
    var baseUrl = "/Customer/";

    self.sorttype = 1;
    self.sortdirection = ko.observable(1);

    self.IsEdit = ko.observable(false);

    //visibles
    self.IsPhoneDetailVisible = ko.observable(false);
    self.IsPrimaryDetailVisible = ko.observable(true);
    self.IsAddressDetailVisible = ko.observable(false);


    self.IsListAreaVisible = ko.observable(true);
    self.IsSearchAreaVisible = ko.observable(true);
    self.IsAddEditAreaVisible = ko.observable(false);
    self.IsMessageAreaVisible = ko.observable(false);
    //visibles

    self.errmsg = ko.observable("");
    self.searchvalue = ko.observable("");

    //displayorder
    self.IsDisplayOrderChanged = ko.observable(false);

    //place
    self.placeid = ko.observable(0);
    self.placename = ko.observable("");
    self.placecountry = ko.observable("");
    self.placetimezone = ko.observable("");
    self.placedivision = ko.observable("");
    self.placedepartment = ko.observable("");

    self.placedata = ko.observableArray([]);

    //associations
    self.faxassociationid = 0;
    self.cellassociationid = 0;
    self.homeassociationid = 0;
    self.workassociationid = 0;
    self.mailingassociationid = 0;
    self.shippingassociationid = 0;
    //associations

    //ids
    self.faxid = 0;
    self.cellid = 0;
    self.homeid = 0;
    self.workid = 0;
    self.mailingid = 0;
    self.shippingid = 0;
    self.phonesettingid = 0;
    //ids

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

    //list
    self.listitems = ko.observableArray([]);
    self.listitems = ko.mapping.fromJS(data.ListEntity).extend({ deferred: true });
    //list

    //lookups
    self.timezones = ko.observableArray([]);
    self.countries = ko.observableArray([]);
    self.mobilecarriers = ko.observableArray([]);
    self.statesprovinces = ko.observableArray([]);

    self.timezones = ko.mapping.fromJS(data.TimeZones).extend({ deferred: true });
    self.countries = ko.mapping.fromJS(data.Countries).extend({ deferred: true });
    self.mobilecarriers = ko.mapping.fromJS(data.MobileCarriers).extend({ deferred: true });
    self.statesprovinces = ko.mapping.fromJS(data.StatesProvinces).extend({ deferred: true });
    //lookups

    self.DragDropComplete = ko.computed(function() {
        return !self.IsDisplayOrderChanged();
    });

    self.ShowShipping = ko.computed(function() {
        return !self.UseMailingforShipping();
    });

    self.returnmessage = ko.pureComputed(function() {
        return ko.unwrap(self.errmsg);
    });

    self.setmessageview = function() {
        self.IsMessageAreaVisible(self.errmsg().length);
    };

    self.toggleview = function() {
        self.setmessageview();
        self.IsListAreaVisible(!self.IsListAreaVisible());
        self.IsSearchAreaVisible(!self.IsSearchAreaVisible());
        self.IsAddEditAreaVisible(!self.IsAddEditAreaVisible());
    };

    self.handleeturndata = function(returndata) {
        self.placeid(returndata.Id);
        self.errmsg(returndata.ErrMsg);

        self.setmessageview();
    };

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
        }
    };

    //country defaults
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
    //country defaults

    //shipping defaults
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
    //shipping defaults

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
        },
        Addresses: function() {
            self.IsPhoneDetailVisible(false);
            self.IsAddressDetailVisible(true);
            self.IsPrimaryDetailVisible(false);
        }
    };

    self.Fax = {
        Build: function() {
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
            return {
                AddressType: 2,
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
                PlaceType: 2,
                Name: self.placename(),
                PlaceId: self.placeid(),
                Country: self.placecountry(),
                TimeZone: self.placetimezone(),
                Division: self.placedivision(),
                Department: self.placedepartment()
            };
        },
        Clear: function() {
            self.placeid(0);
            self.placename("");
            self.placecountry(0);
            self.placetimezone(0);
            self.placedivision("");
            self.placedepartment("");
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
            if (self.sorttype === type) {
                return;
            }
            self.sorttype = type;

            self.pauseNotifications = true;
            self.sortdirection(-1);
            self.pauseNotifications = false;
        },
        ManageDirection: function(type) {
            self.ManageSort.ManageType(type);
            self.sortdirection(self.sortdirection() * -1);
        }
    };

    self.namesort = function() {
        self.ManageSort.ManageDirection(2);
    };

    self.displayordersort = function() {
        self.ManageSort.ManageDirection(1);
    };

    self.SortDisplayOrder = {
        Filtered: function(filter, sortDirection) {
            return ko.utils.arrayFilter(self.listitems(), function(item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(filter) !== -1;
            }).sort(function(l, r) {
                return (parseInt(l.DisplayOrder()) > parseInt(r.DisplayOrder())) ^ (sortDirection === -1);
            });
        },
        Unfiltered: function(sortDirection) {
            return self.listitems().sort(function(l, r) {
                return (parseInt(l.DisplayOrder()) > parseInt(r.DisplayOrder())) ^ (sortDirection === -1);
            });
        },
        Manage: function(filter) {
            return (filter.length === 0)
                ? self.SortDisplayOrder.Unfiltered(self.sortdirection())
                : self.SortDisplayOrder.Filtered(filter, self.sortdirection());
        }

    };

    self.SortName = {
        Filtered: function(filter, sortDirection) {
            return ko.utils.arrayFilter(self.listitems(), function(item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(filter) !== -1;
            }).sort(function(l, r) {
                return (l.Name().toLowerCase() > r.Name().toLowerCase()) ^ (sortDirection === -1);
            });
        },
        Unfiltered: function(sortDirection) {
            return self.listitems().sort(function(l, r) {
                return (l.Name().toLowerCase() > r.Name().toLowerCase()) ^ (sortDirection === -1);
            });
        },
        Manage: function(filter) {
            return (filter.length === 0)
                ? self.SortName.Unfiltered(self.sortdirection())
                : self.SortName.Filtered(filter, self.sortdirection());
        }
    };

    self.filteredItems = function() {
        var filter = self.searchvalue().toLowerCase();
        return self.sorttype === 1
            ? self.SortDisplayOrder.Manage(filter)
            : self.SortName.Manage(filter);
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

    self.edit = function(editdata) {
        self.IsEdit(true);
        self.placeid(editdata.PlaceId());

        self.GetPlaceData();
        self.toggleview();
    };

    self.clearandtoggle = function() {
        self.clear();
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
            var n = "";
            var match = ko.utils.arrayFirst(self.countries(), function (item) {
                return parseInt(item.Value()) === id;
            });
            if (match) {
                n = match.Text();
            }
            return n;
        },
        TimeZoneName: function() {
            var id = parseInt(self.placetimezone());
            if (id === 0) {
                return "";
            };
            var n = "";
            var match = ko.utils.arrayFirst(self.timezones(), function (item) {
                return parseInt(item.Value()) === id;
            });
            if (match) {
                n = match.Text();
            }
            return n;
        },
        ProcessAdd: function() {
            self.ReorderList.ReorderFilteredList();
            var newitem = {
                PlaceType: ko.observable(0),
                DisplayOrder: ko.observable(0),
                PlaceId: ko.observable(self.placeid()),
                Name: ko.observable(self.placename()),
                Country: ko.observable(self.placecountry()),
                TimeZone: ko.observable(self.placetimezone()),
                Division: ko.observable(self.placedivision()),
                Department: ko.observable(self.placedepartment()),
                CountryName: ko.observable(self.ProcessSave.CountryName()),
                TimeZoneName: ko.observable(self.ProcessSave.TimeZoneName())
            };
            self.listitems.push(newitem);
        },
        ProcessEdit: function() {
            for (var i = 0; i < self.listitems().length; i++) {
                if (self.listitems()[i].PlaceId() !== self.placeid())
                    continue;
                self.listitems()[i].Name(self.placename());
                self.listitems()[i].Country(self.placecountry());
                self.listitems()[i].Division(self.placedivision());
                self.listitems()[i].TimeZone(self.placetimezone());
                self.listitems()[i].Department(self.placedepartment());
                self.listitems()[i].CountryName(self.ProcessSave.CountryName());
                self.listitems()[i].TimeZoneName(self.ProcessSave.TimeZoneName());
                break;
            }
        },
        ItemExists: function () {
            var match = ko.utils.arrayFirst(self.listitems(), function (item) {
                return item.PlaceId() === self.placeid();
            });
            return match;
        },
        Manage: function () {
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

    self.BuildPlaceData = function() {
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
    };

    self.save = function() {
        $.ajax({
            url: baseUrl + "SavePlace",
            type: "post",
            data: self.BuildPlaceData()
        }).then(function(returndata) {

            self.handleeturndata(returndata);
            if (self.IsMessageAreaVisible()) {
                return;
            }
            self.ProcessSave.Manage();
            self.clearandtoggle();
        });
    };

    self.setlistiteminactive = function(removedata) {
        $.ajax({
            url: baseUrl + removedata.PlaceId(),
            type: "delete"
        }).then(function(returndata) {

            self.handleeturndata(returndata);
            if (self.IsMessageAreaVisible()) {
                return;
            }
            self.listitems.remove(removedata);
            self.clear();
        });
    };

    self.removelistitem = function(item) {
        if (!confirm("Delete Item: '" + ko.unwrap(item.Name) + "'?")) {
            return;
        }
        self.setlistiteminactive(item);
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
            stop: self.ReorderList.ReorderFilteredList
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
                for (var i = 0; i < self.filteredItems().length; i++) {
                    if (self.filteredItems()[i].PlaceId() !== placeid)
                        continue;
                    if (self.filteredItems()[i].DisplayOrder() !== (value)) {
                        self.filteredItems()[i].DisplayOrder(value);
                    }
                    break;
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
            Manage: function() {
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
        GetNewIndex: function(n) {
            if (ko.unwrap(self.sortdirection) === 1) {
                return n + 1;
            }
            return n - 1;
        },
        InitNewIndex: function() {
            if (ko.unwrap(self.sortdirection) === 1) {
                return 0;
            }
            return (self.filteredItems().length) + 1;
        },
        ReorderFilteredList: function() {
            var rowindex = 0;
            var rowplaceid = 0;
            var rowdisplayorder = 0;
            var newindex = self.ReorderList.InitNewIndex();

            self.ReorderList.displayreorder([]);
            $("#datatable tbody").children().each(function() {
                newindex = self.ReorderList.GetNewIndex(newindex);
                rowplaceid = parseInt($("#datatable tbody").children()[rowindex].children[1].innerText);
                rowdisplayorder = parseInt($("#datatable tbody").children()[rowindex].children[2].innerText);
                if (rowdisplayorder !== newindex) {
                    self.ReorderList.Capture(rowplaceid, newindex);
                    $("#datatable tbody").children()[rowindex].children[2].innerText = newindex;
                }
                rowindex = rowindex + 1;
            });
            self.ReorderList.Reorder.Manage();
        }
    };

    self.makelistsortable();
};