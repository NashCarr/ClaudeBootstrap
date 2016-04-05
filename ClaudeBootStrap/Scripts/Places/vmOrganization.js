
PlaceViewModel = function(data) {
    var self = this;
    var baseUrl = "/Organization/";

    self.placeHeader = "Organization";
    self.detailHeader = "Organization Details";
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

    self.IsPlaceFaxPhoneVisible = ko.observable(false);
    self.IsPlaceCellPhoneVisible = ko.observable(false);
    self.IsPlaceHomePhoneVisible = ko.observable(false);
    self.IsPlaceWorkPhoneVisible = ko.observable(false);
    self.IsPlaceAddressDetailVisible = ko.observable(false);
    self.IsPlaceMailingAddressVisible = ko.observable(false);
    self.IsPlaceShippingAddressVisible = ko.observable(false);

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
    self.placename = ko.observable("");
    self.placecountry = ko.observable("");
    self.placetimezone = ko.observable("");
    self.placedivision = ko.observable("");
    self.placedepartment = ko.observable("");
    self.placepostalcode = ko.observable("");
    self.placedisplaysort = ko.observable("");
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

    self.personfaxassociationid = 0;
    self.personcellassociationid = 0;
    self.personhomeassociationid = 0;
    self.personworkassociationid = 0;
    self.personmailingassociationid = 0;
    self.personshippingassociationid = 0;

    //ids
    self.placefaxid = 0;
    self.placecellid = 0;
    self.placehomeid = 0;
    self.placeworkid = 0;
    self.placemailingid = 0;
    self.placeshippingid = 0;
    self.placephonesettingid = 0;

    self.personfaxid = 0;
    self.personcellid = 0;
    self.personhomeid = 0;
    self.personworkid = 0;
    self.personmailingid = 0;
    self.personshippingid = 0;
    self.personphonesettingid = 0;

    //fax
    self.placefaxcountry = ko.observable(0);
    self.placefaxphonenumber = ko.observable("");

    self.personfaxcountry = ko.observable(0);
    self.personfaxphonenumber = ko.observable("");

    //cell
    self.placecellcountry = ko.observable(0);
    self.placecellcarrier = ko.observable(0);
    self.placecellphonenumber = ko.observable("");
    self.placecellaccepttext = ko.observable(true);

    self.personcellcountry = ko.observable(0);
    self.personcellcarrier = ko.observable(0);
    self.personcellphonenumber = ko.observable("");
    self.personcellaccepttext = ko.observable(true);

    //home
    self.placehomecountry = ko.observable(0);
    self.placehomephonenumber = ko.observable("");

    self.personhomecountry = ko.observable(0);
    self.personhomephonenumber = ko.observable("");

    //work
    self.placeworkcountry = ko.observable(0);
    self.placeworkextension = ko.observable("");
    self.placeworkphonenumber = ko.observable("");

    self.personworkcountry = ko.observable(0);
    self.personworkextension = ko.observable("");
    self.personworkphonenumber = ko.observable("");

    //mailing
    self.placemailingcity = ko.observable("");
    self.placemailingcountry = ko.observable(0);
    self.placemailingaddress1 = ko.observable("");
    self.placemailingaddress2 = ko.observable("");
    self.placemailingpostalcode = ko.observable("");
    self.placemailingstateprovinceid = ko.observable("");
    self.placeUseMailingforShipping = ko.observable(true);

    self.personmailingcity = ko.observable("");
    self.personmailingcountry = ko.observable(0);
    self.personmailingaddress1 = ko.observable("");
    self.personmailingaddress2 = ko.observable("");
    self.personmailingpostalcode = ko.observable("");
    self.personmailingstateprovinceid = ko.observable("");
    self.personUseMailingforShipping = ko.observable(true);

    //shipping
    self.placeshippingcity = ko.observable("");
    self.placeshippingcountry = ko.observable(0);
    self.placeshippingaddress1 = ko.observable("");
    self.placeshippingaddress2 = ko.observable("");
    self.placeshippingpostalcode = ko.observable("");
    self.placeshippingstateprovinceid = ko.observable("");

    self.personshippingcity = ko.observable("");
    self.personshippingcountry = ko.observable(0);
    self.personshippingaddress1 = ko.observable("");
    self.personshippingaddress2 = ko.observable("");
    self.personshippingpostalcode = ko.observable("");
    self.personshippingstateprovinceid = ko.observable("");

    self.itemdata = ko.observableArray([]);
    self.personlist = ko.observableArray([]);

    //list
    self.itemlist = ko.mapping.fromJS(data.ListEntity).extend({ deferred: true });

    //lookups
    self.timezones = ko.mapping.fromJS(data.TimeZones).extend({ deferred: true });
    self.countries = ko.mapping.fromJS(data.Countries).extend({ deferred: true });
    self.postalcodes = ko.mapping.fromJS(data.PostalCodes).extend({ deferred: true });
    self.mobilecarriers = ko.mapping.fromJS(data.MobileCarriers).extend({ deferred: true });
    self.statesprovinces = ko.mapping.fromJS(data.StatesProvinces).extend({ deferred: true });

    self.DefaultMailingValues = ko.computed(function() {
        if (self.placemailingpostalcode().length === 0) {
            return;
        };
        var match = ko.utils.arrayFirst(self.postalcodes(), function(item) {
            return ko.unwrap(item.Text()) === ko.unwrap(self.placemailingpostalcode());
        });
        if (match) {
            self.placemailingcity(ko.unwrap(match.City));
            self.placemailingcountry(ko.unwrap(match.Country));
            self.placemailingstateprovinceid(ko.unwrap(match.StateProvinceId));
        };
    });

    self.DefaultShippingValues = ko.computed(function() {
        if (self.placeshippingpostalcode().length === 0) {
            return;
        };
        var match = ko.utils.arrayFirst(self.postalcodes(), function(item) {
            return ko.unwrap(item.Text()) === ko.unwrap(self.placeshippingpostalcode());
        });
        if (match) {
            self.placeshippingcity(ko.unwrap(match.City));
            self.placeshippingcountry(ko.unwrap(match.Country));
            self.placeshippingstateprovinceid(ko.unwrap(match.StateProvinceId));
        };
    });

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
            };
        }
    };

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

    self.PlacePhoneView = {
        Fax: function() {
            self.IsPlaceFaxPhoneVisible(true);
            self.IsPlaceCellPhoneVisible(false);
            self.IsPlaceHomePhoneVisible(false);
            self.IsPlaceWorkPhoneVisible(false);
            self.phoneHeader("Phones: " + self.faxphonetype);
        },
        Cell: function() {
            self.IsPlaceFaxPhoneVisible(false);
            self.IsPlaceCellPhoneVisible(true);
            self.IsPlaceHomePhoneVisible(false);
            self.IsPlaceWorkPhoneVisible(false);
            self.phoneHeader("Phones: " + self.cellphonetype);
        },
        Home: function() {
            self.IsPlaceFaxPhoneVisible(false);
            self.IsPlaceCellPhoneVisible(false);
            self.IsPlaceHomePhoneVisible(true);
            self.IsPlaceWorkPhoneVisible(false);
            self.phoneHeader("Phones: " + self.homephonetype);
        },
        Work: function() {
            self.IsPlaceFaxPhoneVisible(false);
            self.IsPlaceCellPhoneVisible(false);
            self.IsPlaceHomePhoneVisible(false);
            self.IsPlaceWorkPhoneVisible(true);
            self.phoneHeader("Phones: " + self.workphonetype);
        },
        Default: function() {
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

    self.PersonPhoneView = {
        Fax: function () {
            self.PersonAddressView.Default();
            self.IsPersonFaxPhoneVisible(true);
            self.IsPersonCellPhoneVisible(false);
            self.IsPersonHomePhoneVisible(false);
            self.IsPersonWorkPhoneVisible(false);
            self.phoneHeader("Contact: " + self.faxphonetype);
        },
        Cell: function() {
            self.PersonAddressView.Default();
            self.IsPersonFaxPhoneVisible(false);
            self.IsPersonCellPhoneVisible(true);
            self.IsPersonHomePhoneVisible(false);
            self.IsPersonWorkPhoneVisible(false);
            self.phoneHeader("Contact: " + self.cellphonetype);
        },
        Home: function() {
            self.PersonAddressView.Default();
            self.IsPersonFaxPhoneVisible(false);
            self.IsPersonCellPhoneVisible(false);
            self.IsPersonHomePhoneVisible(true);
            self.IsPersonWorkPhoneVisible(false);
            self.phoneHeader("Contact: " + self.homephonetype);
        },
        Work: function() {
            self.PersonAddressView.Default();
            self.IsPersonFaxPhoneVisible(false);
            self.IsPersonCellPhoneVisible(false);
            self.IsPersonHomePhoneVisible(false);
            self.IsPersonWorkPhoneVisible(true);
            self.phoneHeader("Contact: " + self.workphonetype);
        },
        Default: function() {
            self.IsPersonFaxPhoneVisible(false);
            self.IsPersonCellPhoneVisible(false);
            self.IsPersonHomePhoneVisible(false);
            self.IsPersonWorkPhoneVisible(false);
        },
        Primary: function() {
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

    self.PlaceAddressView = {
        Mailing: function() {
            self.IsPlaceMailingAddressVisible(true);
            self.IsPlaceShippingAddressVisible(false);
        },
        Shipping: function() {
            self.IsPlaceMailingAddressVisible(false);
            self.IsPlaceShippingAddressVisible(true);
        },
        Default: function() {
            self.IsPlaceMailingAddressVisible(false);
            self.IsPlaceShippingAddressVisible(false);
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
            self.IsPlaceAddressDetailVisible(false);
            self.IsContactDetailVisible(false);
        },
        Contacts: function() {
            self.IsEditContact(true);
            self.IsEditContact(false);
            self.IsPhoneDetailVisible(false);
            self.IsPrimaryDetailVisible(false);
            self.IsPlaceAddressDetailVisible(false);
            self.IsContactDetailVisible(true);

            self.PersonPrimaryPhone.Set();
            self.PersonPhoneView.Primary();
            self.PersonAddressView.Default();
        },
        Phones: function() {
            self.IsPhoneDetailVisible(true);
            self.IsPrimaryDetailVisible(false);
            self.IsPlaceAddressDetailVisible(false);
            self.IsContactDetailVisible(false);

            self.PlacePhoneView.Primary();
            self.PlaceAddressView.Default();
        },
        Addresses: function() {
            self.IsPhoneDetailVisible(false);
            self.IsPlaceAddressDetailVisible(true);
            self.IsPrimaryDetailVisible(false);
            self.IsContactDetailVisible(false);

            self.PlacePhoneView.Default();
            self.PlaceAddressView.Mailing();
        }
    };

    self.DetailListEdit = {
        Fax: function() {
            self.DetailView.Phones();
            self.PlacePhoneView.Fax();
        },
        Cell: function() {
            self.DetailView.Phones();
            self.PlacePhoneView.Cell();
        },
        Home: function() {
            self.DetailView.Phones();
            self.PlacePhoneView.Home();
        },
        Work: function() {
            self.DetailView.Phones();
            self.PlacePhoneView.Work();
        },
        Mailing: function() {
            self.DetailView.Addresses();
            self.PlaceAddressView.Mailing();
        },
        Shipping: function() {
            self.DetailView.Addresses();
            self.PlaceAddressView.Shipping();
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
        };
        return "";
    };

    self.PlaceMailingAddress = {
        Address: ko.computed(function() {
            if (self.placemailingaddress1().length === 0) {
                return "";
            };
            if (self.placemailingaddress2().length === 0) {
                return ko.unwrap(self.placemailingaddress1());
            };
            return ko.unwrap(self.placemailingaddress1()) + ", " + ko.unwrap(self.placemailingaddress2());
        }),
        CityStateZip: ko.computed(function() {
            if (self.placemailingcity().length === 0) {
                return "";
            };
            return ko.unwrap(self.placemailingcity()) + ", " + (self.stateprovincename(ko.unwrap(self.placemailingstateprovinceid())) + " " + ko.unwrap(self.placemailingpostalcode())).trim();
        }),
        Value: function() {
            return (ko.unwrap(self.PlaceMailingAddress.Address()) + ", " + ko.unwrap(self.PlaceMailingAddress.CityStateZip())).trim();
        }
    };

    self.PlaceShippingAddress = {
        Address: ko.computed(function() {
            if (self.placeshippingaddress1().length === 0) {
                return "";
            };
            if (self.placeshippingaddress2().length === 0) {
                return ko.unwrap(self.placeshippingaddress1());
            };
            return ko.unwrap(self.placeshippingaddress1()) + ", " + ko.unwrap(self.placeshippingaddress2());
        }),
        CityStateZip: ko.computed(function() {
            if (self.placeshippingcity().length === 0) {
                return "";
            };
            return ko.unwrap(self.placeshippingcity()) + ", " + (self.stateprovincename(ko.unwrap(self.placeshippingstateprovinceid())) + " " + ko.unwrap(self.placeshippingpostalcode())).trim();
        }),
        Value: function() {
            return ko.unwrap(self.PlaceShippingAddress.Address()) + ", " + ko.unwrap(self.PlaceShippingAddress.CityStateZip());
        }
    };

    self.placecellcarriername = ko.computed(function() {
        var id = parseInt(self.placecellcarrier());
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

    self.ShowPlaceShipping = ko.computed(function() {
        return !self.placeUseMailingforShipping();
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

    self.handleplacereturndata = function(returndata) {
        self.placeid(returndata.Id);
        self.errmsg(returndata.ErrMsg);

        self.setmessageview();
    };

    self.DefaultPlaceCountry = {
        Fax: function() {
            if (typeof self.placefaxcountry() !== "undefined") {
                if (self.placefaxphonenumber().length !== 0) {
                    if (self.placefaxcountry() !== 0) {
                        return;
                    };
                };
            };
            self.placefaxcountry(self.placecountry());
        },
        Cell: function() {
            if (typeof self.placecellcountry() !== "undefined") {
                if (self.placecellphonenumber().length !== 0) {
                    if (self.placecellcountry() !== 0) {
                        return;
                    };
                };
            };
            self.placecellcountry(self.placecountry());
        },
        Home: function() {
            if (typeof self.placehomecountry() !== "undefined") {
                if (self.placehomephonenumber().length !== 0) {
                    if (self.placehomecountry() !== 0) {
                        return;
                    };
                };
            };
            self.placehomecountry(self.placecountry());
        },
        Work: function() {
            if (typeof self.placeworkcountry() !== "undefined") {
                if (self.placeworkphonenumber().length !== 0) {
                    if (self.placeworkcountry() !== 0) {
                        return;
                    };
                };
            };
            self.placeworkcountry(self.placecountry());
        },
        Mailing: function() {
            if (typeof self.placemailingcountry() !== "undefined") {
                if (self.placemailingaddress1().length !== 0) {
                    if (self.placemailingcountry() !== 0) {
                        return;
                    };
                };
            };
            self.placemailingcountry(self.placecountry());
        },
        Shipping: function() {
            if (typeof self.placeshippingcountry() !== "undefined") {
                if (self.placeshippingaddress1().length !== 0) {
                    if (self.placeshippingcountry() !== 0) {
                        return;
                    };
                };
            };
            self.placeshippingcountry(self.placecountry());
        },
        Set: function() {
            if (typeof self.placecountry() === "undefined") {
                return;
            };
            self.DefaultPlaceCountry.Fax();
            self.DefaultPlaceCountry.Cell();
            self.DefaultPlaceCountry.Home();
            self.DefaultPlaceCountry.Work();
            self.DefaultPlaceCountry.Mailing();
            self.DefaultPlaceCountry.Shipping();
        }
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
        Person: function() {
            if (typeof self.personcountry() !== "undefined") {
                if (self.personlast().length !== 0) {
                    if (self.personcountry() !== 0) {
                        return;
                    };
                };
            };
            self.personcountry(self.placecountry());
        },
        Set: function() {
            if (typeof self.personcountry() === "undefined") {
                return;
            };
            self.DefaultPersonCountry.Person();

            self.DefaultPersonCountry.Fax();
            self.DefaultPersonCountry.Cell();
            self.DefaultPersonCountry.Home();
            self.DefaultPersonCountry.Work();
            self.DefaultPersonCountry.Mailing();
            self.DefaultPersonCountry.Shipping();
        }
    };

    self.DefaultPlaceShipping = {
        Address1: function() {
            switch (typeof self.placemailingaddress1()) {
            case "undefined":
                break;
            default:
                self.placeshippingaddress1(self.placemailingaddress1());
                break;
            };
        },
        Address2: function() {
            switch (typeof self.placemailingaddress2()) {
            case "undefined":
                break;
            default:
                self.placeshippingaddress2(self.placemailingaddress2());
                break;
            };
        },
        City: function() {
            switch (typeof self.placemailingcity()) {
            case "undefined":
                break;
            default:
                if (
                    (self.placeUseMailingforShipping()) ||
                    (typeof self.placeshippingcity() === "undefined")
                ) {
                    self.placeshippingcity(self.placemailingcity());
                    return;
                };
                if (self.placeshippingcity().length === 0) {
                    self.placeshippingcity(self.placemailingcity());
                };
                break;
            };
        },
        PostalCode: function() {
            switch (typeof self.placemailingpostalcode()) {
            case "undefined":
                break;
            default:
                if (
                    (self.placeUseMailingforShipping()) ||
                    (typeof self.placeshippingpostalcode() === "undefined")
                ) {
                    self.placeshippingpostalcode(self.placemailingpostalcode());
                    return;
                };
                if (self.placeshippingpostalcode().length === 0) {
                    self.placeshippingpostalcode(self.placemailingpostalcode());
                };
                break;
            };
        },
        StateProvince: function() {
            switch (typeof self.placemailingstateprovinceid()) {
            case "undefined":
                break;
            default:
                if (
                    (self.placeUseMailingforShipping()) ||
                    (typeof self.placeshippingstateprovinceid() === "undefined")
                ) {
                    self.placeshippingstateprovinceid(self.placemailingstateprovinceid());
                    return;
                };
                if (self.placeshippingstateprovinceid() === 0) {
                    self.placeshippingstateprovinceid(self.placemailingstateprovinceid());
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
            if (self.placeUseMailingforShipping()) {
                self.DefaultPlaceShipping.Address1();
                self.DefaultPlaceShipping.Address2();
            };
            self.DefaultPlaceShipping.Basic();
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
            self.IsEditContact(true);
            self.personcountry(ko.unwrap(self.placecountry()));
            self.persontimezone(ko.unwrap(self.placetimezone()));

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
            self.IsEditContact(false);
            self.IsSaveContact(false);
        },
        Edit: function(editdata) {
            self.personid(ko.unwrap(editdata.PersonId()));
            self.personemail(ko.unwrap(editdata.Email()));
            self.personlast(ko.unwrap(editdata.LastName()));
            self.personfirst(ko.unwrap(editdata.FirstName()));
            self.personmiddle(ko.unwrap(editdata.MiddleName()));
            self.personcountry(ko.unwrap(self.placecountry()));
            self.persontimezone(ko.unwrap(self.placetimezone()));

            self.GetPersonData();

            self.IsEditContact(true);
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

    self.SavePerson = {
        BuildPersonData: function() {
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
        Build: function() {
            return {
                PersonType: ko.observable(0),
                PlaceId: ko.observable(ko.unwrap(self.placeid())),
                FullName: ko.observable(self.Person.FullName()),
                PersonId: ko.observable(ko.unwrap(self.personid())),
                Email: ko.observable(ko.unwrap(self.personemail())),
                LastName: ko.observable(ko.unwrap(self.personlast())),
                FirstName: ko.observable(ko.unwrap(self.personfirst())),
                MiddleName: ko.observable(ko.unwrap(self.personmiddle()))
            };
        },
        ProcessAdd: function() {
            self.personlist.push(self.SavePerson.Build());
        },
        ItemExists: function() {
            var match = ko.utils.arrayFirst(self.personlist(), function(item) {
                return item.PersonId() === self.personid();
            });
            return match;
        },
        ProcessEdit: function() {
            self.personlist.replace(self.SavePerson.ItemExists(), self.SavePerson.Build());
        },
        Process: function() {
            if (self.SavePerson.ItemExists()) {
                self.SavePerson.ProcessEdit();
                return;
            };
            self.SavePerson.ProcessAdd();
        },
        HandleReturn: function(returndata) {
            self.personid(returndata.Id);
            self.errmsg(returndata.ErrMsg);

            self.setmessageview();
        },
        ManageSave: function() {
            self.IsSaveClose(false);
            self.IsSaveContact(true);
            if (self.placeid() === 0) {
                self.SavePlaceData.Save();
            } else {
                self.SavePerson.Save();
            };
        },
        Save: function() {
            $.ajax({
                url: baseUrl + "SaveContact",
                type: "post",
                data: self.SavePerson.BuildPersonData()
            }).then(function(returndata) {
                self.IsSaveContact(false);
                self.SavePerson.HandleReturn(returndata);
                if (self.IsMessageAreaVisible()) {
                    return;
                }
                self.SavePerson.Process();
                self.DetailView.Contacts();

                if (self.IsSaveClose()) {
                    self.ProcessSave.Manage();
                    self.IsSaveClose(false);
                    self.clearandtoggle();
                };
            });
        }
    };
    self.PlaceFax = {
        Build: function() {
            if (self.placefaxphonenumber().length === 0) {
                return null;
            };
            return {
                PhoneType: 4,
                PhoneId: self.placefaxid,
                Country: ko.unwrap(self.placefaxcountry()),
                PhoneAssociationId: self.placefaxassociationid,
                PhoneNumber: ko.unwrap(self.placefaxphonenumber())
            };
        },
        Clear: function() {
            self.placefaxid = 0;
            self.placefaxassociationid = 0;

            self.placefaxcountry(0);
            self.placefaxphonenumber("");
        },
        Set: function() {
            self.placefaxassociationid = ko.unwrap(self.itemdata.PhoneAssociationId);
            if (self.placefaxassociationid === 0) {
                self.PlaceFax.Clear();
                return;
            };
            self.placefaxid = ko.unwrap(self.itemdata.PhoneId);
            self.placefaxcountry(ko.unwrap(self.itemdata.Country));
            self.placefaxphonenumber(ko.unwrap(self.itemdata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PlaceFax.Clear();
                return;
            };
            self.PlaceFax.Set();
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
        Default: function() {
            self.PersonFax.Clear();
            self.personfaxcountry(ko.unwrap(self.placefaxcountry()));
            self.personfaxphonenumber(ko.unwrap(self.placefaxphonenumber()));
        },
        Set: function() {
            self.personfaxassociationid = ko.unwrap(self.itemdata.PhoneAssociationId);
            if (self.personfaxassociationid === 0) {
                self.PersonFax.Default();
                return;
            };
            self.personfaxid = ko.unwrap(self.itemdata.PhoneId);
            self.personfaxcountry(ko.unwrap(self.itemdata.Country));
            self.personfaxphonenumber(ko.unwrap(self.itemdata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PersonFax.Default();
                return;
            };
            self.PersonFax.Set();
            self.itemdata = ko.observableArray([]);
        }
    };

    self.PlaceCell = {
        Build: function() {
            if (self.placecellphonenumber().length === 0) {
                return null;
            };
            return {
                PhoneType: 2,
                PhoneId: self.placecellid,
                Country: ko.unwrap(self.placecellcountry()),
                PhoneAssociationId: self.placecellassociationid,
                PhoneNumber: ko.unwrap(self.placecellphonenumber())
            };
        },
        Clear: function() {
            self.placecellid = 0;
            self.placecellassociationid = 0;

            self.placecellcountry(0);
            self.placecellcarrier(0);
            self.placecellphonenumber("");
            self.placecellaccepttext(true);
        },
        Set: function() {
            self.placecellassociationid = ko.unwrap(self.itemdata.PhoneAssociationId);
            if (self.placecellassociationid === 0) {
                self.PlaceCell.Clear();
                return;
            };
            self.placecellid = ko.unwrap(self.itemdata.PhoneId);
            self.placecellcountry(ko.unwrap(self.itemdata.Country));
            self.placecellphonenumber(ko.unwrap(self.itemdata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PlaceCell.Clear();
                return;
            };
            self.PlaceCell.Set();
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
        Default: function() {
            self.PersonCell.Clear();
            self.personcellcountry(ko.unwrap(self.placecellcountry()));
            self.personcellcarrier(ko.unwrap(self.placecellcountry()));
            self.personcellphonenumber(ko.unwrap(self.placecellphonenumber()));
            self.personcellaccepttext(ko.unwrap(self.placecellaccepttext()));
        },
        Set: function() {
            self.personcellassociationid = ko.unwrap(self.itemdata.PhoneAssociationId);
            if (self.personcellassociationid === 0) {
                self.PersonCell.Default();
                return;
            };
            self.personcellid = ko.unwrap(self.itemdata.PhoneId);
            self.personcellcountry(ko.unwrap(self.itemdata.Country));
            self.personcellphonenumber(ko.unwrap(self.itemdata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PersonCell.Default();
                return;
            };
            self.PersonCell.Set();
            self.itemdata = ko.observableArray([]);
        }
    };

    self.PlaceHome = {
        Build: function() {
            if (self.placehomephonenumber().length === 0) {
                return null;
            };
            return {
                PhoneType: 1,
                PhoneId: self.placehomeid,
                Country: ko.unwrap(self.placehomecountry()),
                PhoneAssociationId: self.placehomeassociationid,
                PhoneNumber: ko.unwrap(self.placehomephonenumber())
            };
        },
        Clear: function() {
            self.placehomeid = 0;
            self.placehomeassociationid = 0;

            self.placehomecountry(0);
            self.placehomephonenumber("");
        },
        Set: function() {
            self.placehomeassociationid = ko.unwrap(self.itemdata.PhoneAssociationId);
            if (self.placehomeassociationid === 0) {
                self.PlaceHome.Clear();
                return;
            };
            self.placehomeid = ko.unwrap(self.itemdata.PhoneId);
            self.placehomecountry(ko.unwrap(self.itemdata.Country));
            self.placehomephonenumber(ko.unwrap(self.itemdata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PlaceHome.Clear();
                return;
            };
            self.PlaceHome.Set();
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
        Default: function() {
            self.PersonHome.Clear();
            self.personhomecountry(ko.unwrap(self.placehomecountry()));
            self.personhomephonenumber(ko.unwrap(self.placehomephonenumber()));
        },
        Set: function() {
            self.personhomeassociationid = ko.unwrap(self.itemdata.PhoneAssociationId);
            if (self.personhomeassociationid === 0) {
                self.PersonHome.Default();
                return;
            };
            self.personhomeid = ko.unwrap(self.itemdata.PhoneId);
            self.personhomecountry(ko.unwrap(self.itemdata.Country));
            self.personhomephonenumber(ko.unwrap(self.itemdata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PersonHome.Default();
                return;
            };
            self.PersonHome.Set();
            self.itemdata = ko.observableArray([]);
        }
    };

    self.PlaceWork = {
        Build: function() {
            if (self.placeworkphonenumber().length === 0) {
                return null;
            };
            return {
                PhoneType: 3,
                PhoneId: self.placeworkid,
                Country: ko.unwrap(self.placeworkcountry()),
                PhoneAssociationId: self.placeworkassociationid,
                PhoneNumber: ko.unwrap(self.placeworkphonenumber())
            };
        },
        Clear: function() {
            self.placeworkid = 0;
            self.placeworkassociationid = 0;

            self.placeworkcountry(0);
            self.placeworkextension("");
            self.placeworkphonenumber("");
        },
        Set: function() {
            self.placeworkassociationid = ko.unwrap(self.itemdata.PhoneAssociationId);
            if (self.placeworkassociationid === 0) {
                self.PlaceWork.Clear();
                return;
            };
            self.placeworkid = ko.unwrap(self.itemdata.PhoneId);
            self.placeworkcountry(ko.unwrap(self.itemdata.Country));
            self.placeworkphonenumber(ko.unwrap(self.itemdata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PlaceWork.Clear();
                return;
            };
            self.PlaceWork.Set();
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
        Default: function() {
            self.PersonWork.Clear();
            self.placeworkcountry(ko.unwrap(self.placeworkcountry()));
            self.personworkextension(ko.unwrap(self.placeworkextension()));
            self.placeworkphonenumber(ko.unwrap(self.placeworkphonenumber()));
        },
        Set: function() {
            self.personworkassociationid = ko.unwrap(self.itemdata.PhoneAssociationId);
            if (self.personworkassociationid === 0) {
                self.PersonWork.Default();
                return;
            };
            self.personworkid = ko.unwrap(self.itemdata.PhoneId);
            self.personworkcountry(ko.unwrap(self.itemdata.Country));
            self.personworkphonenumber(ko.unwrap(self.itemdata.PhoneNumber));
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PersonWork.Default();
                return;
            };
            self.PersonWork.Set();
            self.itemdata = ko.observableArray([]);
        }
    };

    self.PlaceShipping = {
        Build: function() {
            if (self.placeshippingaddress1().length === 0) {
                return null;
            };
            return {
                AddressType: 1,
                AddressId: self.placeshippingid,
                City: ko.unwrap(self.placeshippingcity()),
                Country: ko.unwrap(self.placeshippingcountry()),
                Address1: ko.unwrap(self.placeshippingaddress1()),
                Address2: ko.unwrap(self.placeshippingaddress2()),
                ZipCode: ko.unwrap(self.placeshippingpostalcode()),
                AddressAssociationId: self.placeshippingassociationid,
                StateProvinceId: ko.unwrap(self.placeshippingstateprovinceid())
            };
        },
        Clear: function() {
            self.placeshippingid = 0;
            self.placeshippingassociationid = 0;

            self.placeshippingcity("");
            self.placeshippingcountry(0);
            self.placeshippingaddress1("");
            self.placeshippingaddress2("");
            self.placeshippingpostalcode("");
            self.placeshippingstateprovinceid("");
            self.placeshippingstateprovinceid("");
        },
        Set: function() {
            self.placeshippingassociationid = ko.unwrap(self.itemdata.AddressAssociationId);
            if (self.placeshippingassociationid === 0) {
                self.PlaceShipping.Clear();
                return;
            };
            self.placeshippingcity(ko.unwrap(self.itemdata.City));
            self.placeshippingcountry(ko.unwrap(self.itemdata.Country));
            self.placeshippingaddress1(ko.unwrap(self.itemdata.Address1));
            self.placeshippingaddress2(ko.unwrap(self.itemdata.Address2));
            self.placeshippingpostalcode(ko.unwrap(self.itemdata.ZipCode));
            self.placeshippingid = ko.unwrap(ko.unwrap(self.itemdata.AddressId));
            self.placeshippingstateprovinceid(ko.unwrap(self.itemdata.StateProvinceId));
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PlaceShipping.Clear();
                return;
            };
            self.PlaceShipping.Set();
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
        Default: function() {
            self.PersonShipping.Clear();
            self.personshippingcity(ko.unwrap(self.placeshippingcity()));
            self.personshippingcountry(ko.unwrap(self.placeshippingcountry()));
            self.personshippingaddress1(ko.unwrap(self.placeshippingaddress1()));
            self.personshippingaddress2(ko.unwrap(self.placeshippingaddress2()));
            self.personshippingpostalcode(ko.unwrap(self.placeshippingpostalcode()));
            self.personshippingstateprovinceid(ko.unwrap(self.placeshippingstateprovinceid()));
            self.personshippingstateprovinceid(ko.unwrap(self.placeshippingstateprovinceid()));
        },
        Set: function() {
            self.personshippingassociationid = ko.unwrap(self.itemdata.AddressAssociationId);
            if (self.personshippingassociationid === 0) {
                self.PersonShipping.Default();
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
                self.PersonShipping.Default();
                return;
            };
            self.PersonShipping.Set();
            self.itemdata = ko.observableArray([]);
        }
    };

    self.PlaceMailing = {
        Build: function() {
            if (self.placemailingaddress1().length === 0) {
                return null;
            };
            return {
                AddressType: 2,
                AddressId: self.placemailingid,
                City: ko.unwrap(self.placemailingcity()),
                Country: ko.unwrap(self.placemailingcountry()),
                Address1: ko.unwrap(self.placemailingaddress1()),
                Address2: ko.unwrap(self.placemailingaddress2()),
                ZipCode: ko.unwrap(self.placemailingpostalcode()),
                AddressAssociationId: self.placemailingassociationid,
                StateProvinceId: ko.unwrap(self.placemailingstateprovinceid())
            };
        },
        Clear: function() {
            self.placemailingid = 0;
            self.placemailingassociationid = 0;

            self.placemailingcity("");
            self.placemailingcountry(0);
            self.placemailingaddress1("");
            self.placemailingaddress2("");
            self.placemailingpostalcode("");
            self.placemailingstateprovinceid("");
        },
        Set: function() {
            self.placemailingassociationid = ko.unwrap(self.itemdata.AddressAssociationId);
            if (self.placemailingassociationid === 0) {
                self.PlaceMailing.Clear();
                return;
            };
            self.placemailingcity(ko.unwrap(self.itemdata.City));
            self.placemailingcountry(ko.unwrap(self.itemdata.Country));
            self.placemailingaddress1(ko.unwrap(self.itemdata.Address1));
            self.placemailingaddress2(ko.unwrap(self.itemdata.Address2));
            self.placemailingpostalcode(ko.unwrap(self.itemdata.ZipCode));
            self.placemailingid = ko.unwrap(ko.unwrap(self.itemdata.AddressId));
            self.placemailingstateprovinceid(ko.unwrap(self.itemdata.StateProvinceId));
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PlaceMailing.Clear();
                return;
            };
            self.PlaceMailing.Set();
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
        Default: function() {
            self.PersonMailing.Clear();
            self.personmailingcity(ko.unwrap(self.placemailingcity()));
            self.personmailingcountry(ko.unwrap(self.placemailingcountry()));
            self.personmailingaddress1(ko.unwrap(self.placemailingaddress1()));
            self.personmailingaddress2(ko.unwrap(self.placemailingaddress2()));
            self.personmailingpostalcode(ko.unwrap(self.placemailingpostalcode()));
            self.personmailingstateprovinceid(ko.unwrap(self.placemailingstateprovinceid()));
            self.personmailingstateprovinceid(ko.unwrap(self.placemailingstateprovinceid()));
        },
        Set: function() {
            self.personmailingassociationid = ko.unwrap(self.itemdata.AddressAssociationId);
            if (self.personmailingassociationid === 0) {
                self.PersonMailing.Default();
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
                self.PersonMailing.Default();
                return;
            };
            self.PersonMailing.Set();
            self.itemdata = ko.observableArray([]);
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
                DisplaySort: ko.observable(self.placedisplaysort()),
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
            self.placedisplaysort("");
        },
        Set: function() {
            self.placeid(ko.unwrap(self.itemdata.PlaceId));
            if (self.placeid() === 0) {
                self.Place.Clear();
                return;
            };
            self.placename(ko.unwrap(self.itemdata.Name));
            self.placecountry(ko.unwrap(self.itemdata.Country));
            self.placetimezone(ko.unwrap(self.itemdata.TimeZone));
            self.placedivision(ko.unwrap(self.itemdata.Division));
            self.placedepartment(ko.unwrap(self.itemdata.Department));
            self.placedisplayorder(ko.unwrap(self.itemdata.DisplayOrder));

            self.DefaultPlaceCountry.Set();
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.Place.Clear();
                return;
            };
            self.Place.Set();
            self.itemdata = ko.observableArray([]);
        }
    };

    self.PlacePhoneSettings = {
        Build: function() {
            return {
                RecordId: self.placephonesettingid,
                MobileCarrier: self.placecellcarrier,
                AllowText: self.placecellaccepttext(),
                PrimaryPhoneType: self.PlacePrimaryPhone.phoneprimaryid
            };
        },
        Clear: function() {
            self.placephonesettingid = 0;
            self.PlacePrimaryPhone.phoneprimaryid = 0;
        },
        Set: function() {
            self.placephonesettingid = ko.unwrap(self.itemdata.RecordId);
            if (self.placephonesettingid === 0) {
                self.PlacePhoneSettings.Clear();
                return;
            };
            self.placecellaccepttext(ko.unwrap(self.itemdata.AllowText));
            self.placecellcarrier(ko.unwrap(self.itemdata.MobileCarrier));
            self.PlacePrimaryPhone.phoneprimaryid = ko.unwrap(self.itemdata.PrimaryPhoneType);

            self.PlacePrimaryPhone.Set();
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PlacePhoneSettings.Clear();
                return;
            };
            self.PlacePhoneSettings.Set();
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
        Default: function() {
            self.PersonPhoneSettings.Clear();
            self.personcellaccepttext(ko.unwrap(self.placecellaccepttext()));
            self.personcellcarrier(ko.unwrap(self.placecellcarrier()));
            self.PersonPrimaryPhone.phoneprimaryid = self.PlacePrimaryPhone.phoneprimaryid;

            self.PersonPrimaryPhone.Set();
        },
        Set: function() {
            self.personphonesettingid = ko.unwrap(self.itemdata.RecordId);
            if (self.personphonesettingid === 0) {
                self.PersonPhoneSettings.Default();
                return;
            };
            self.personcellaccepttext(ko.unwrap(self.itemdata.AllowText));
            self.personcellcarrier(ko.unwrap(self.itemdata.MobileCarrier));
            self.PersonPrimaryPhone.phoneprimaryid = ko.unwrap(self.itemdata.PrimaryPhoneType);

            self.PersonPrimaryPhone.Set();
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.PersonPhoneSettings.Default();
                return;
            };
            self.PersonPhoneSettings.Set();
            self.itemdata = ko.observableArray([]);
        }
    };

    self.Contacts = {
        Clear: function() {
            self.personlist([]);
        },
        Set: function() {
            self.personlist = ko.mapping.fromJS(self.itemdata);
        },
        Populate: function() {
            if (typeof self.itemdata === "undefined") {
                self.Contacts.Clear();
                return;
            };
            if (typeof self.itemdata() === "undefined") {
                self.Contacts.Clear();
                return;
            };
            if (self.itemdata().length === 0) {
                self.Contacts.Clear();
                return;
            };
            self.Contacts.Set();
            self.itemdata = ko.observableArray([]);
        }
    };

    self.GetPlaceData = function() {
        $.ajax({
            url: baseUrl + "GetPlace/" + ko.unwrap(self.placeid()),
            type: "post"
        }).then(function(returndata) {

            self.itemdata = ko.mapping.fromJS(returndata.Phones.PhoneSettings);
            self.PlacePhoneSettings.Populate();

            self.itemdata = ko.mapping.fromJS(returndata.Phones.FaxPhone);
            self.PlaceFax.Populate();

            self.itemdata = ko.mapping.fromJS(returndata.Phones.CellPhone);
            self.PlaceCell.Populate();

            self.itemdata = ko.mapping.fromJS(returndata.Phones.HomePhone);
            self.PlaceHome.Populate();

            self.itemdata = ko.mapping.fromJS(returndata.Phones.WorkPhone);
            self.PlaceWork.Populate();

            self.itemdata = ko.mapping.fromJS(returndata.Addresses.ShippingAddress);
            self.PlaceShipping.Populate();

            self.itemdata = ko.mapping.fromJS(returndata.Addresses.MailingAddress);
            self.PlaceMailing.Populate();

            self.itemdata = ko.mapping.fromJS(returndata.Contacts);
            self.Contacts.Populate();

            self.itemdata = ko.mapping.fromJS(returndata.Place);
            self.Place.Populate();
        });
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
        ManageType: function (type) {
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
        ManageDirection: function (type) {
            self.ManageSort.ManageType(type);
            self.sortdirection(self.sortdirection() * -1);
        },
        DragDrop: function () {
            self.sorttype = 1;
            self.sortdirection(1);
        },
        Change: function (type) {
            if (type === 0) {
                self.ManageSort.IsSorting(!self.ManageSort.IsSorting());
            };
            if (!self.ManageSort.IsSorting() && (type !== 0)) {
                self.ManageSort.ManageDirection(type);
                self.ReorderList.ReorderAfterSort();
            };
        }
    };

    self.SortCountry = {
        Filtered: function () {
            return ko.utils.arrayFilter(self.itemlist(), function (item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function (l, r) {
                return (self.direction * (l.CountryName().toLowerCase().localeCompare(r.CountryName().toLowerCase())));
            });
        },
        Unfiltered: function () {
            return self.itemlist().sort(function (l, r) {
                return (self.direction * (l.CountryName().toLowerCase().localeCompare(r.CountryName().toLowerCase())));
            });
        },
        Manage: function () {
            return (self.filter.length === 0)
                ? self.SortCountry.Unfiltered(self.sortdirection())
                : self.SortCountry.Filtered(self.sortdirection());
        }
    };

    self.SortTimeZone = {
        Filtered: function () {
            return ko.utils.arrayFilter(self.itemlist(), function (item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function (l, r) {
                return (self.direction * (l.TimeZoneName().toLowerCase().localeCompare(r.TimeZoneName().toLowerCase())));
            });
        },
        Unfiltered: function () {
            return self.itemlist().sort(function (l, r) {
                return (self.direction * (l.TimeZoneName().toLowerCase().localeCompare(r.TimeZoneName().toLowerCase())));
            });
        },
        Manage: function () {
            return (self.filter.length === 0)
                ? self.SortTimeZone.Unfiltered(self.sortdirection())
                : self.SortTimeZone.Filtered(self.sortdirection());
        }
    };

    self.SortDepartment = {
        Filtered: function () {
            return ko.utils.arrayFilter(self.itemlist(), function (item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function (l, r) {
                return (self.direction * (l.Department().toLowerCase().localeCompare(r.Department().toLowerCase())));
            });
        },
        Unfiltered: function () {
            return self.itemlist().sort(function (l, r) {
                return (self.direction * (l.Department().toLowerCase().localeCompare(r.Department().toLowerCase())));
            });
        },
        Manage: function () {
            return (self.filter.length === 0)
                ? self.SortDepartment.Unfiltered(self.sortdirection())
                : self.SortDepartment.Filtered(self.sortdirection());
        }
    };

    self.SortDivision = {
        Filtered: function () {
            return ko.utils.arrayFilter(self.itemlist(), function (item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function (l, r) {
                return (self.direction * (l.Division().toLowerCase().localeCompare(r.Division().toLowerCase())));
            });
        },
        Unfiltered: function () {
            return self.itemlist().sort(function (l, r) {
                return (self.direction * (l.Division().toLowerCase().localeCompare(r.Division().toLowerCase())));
            });
        },
        Manage: function () {
            return (self.filter.length === 0)
                ? self.SortDivision.Unfiltered()
                : self.SortDivision.Filtered();
        }
    };

    self.SortName = {
        Filtered: function () {
            return ko.utils.arrayFilter(self.itemlist(), function (item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function (l, r) {
                return (self.direction * (l.Name().toLowerCase().localeCompare(r.Name().toLowerCase())));
            });
        },
        Unfiltered: function () {
            return self.itemlist().sort(function (l, r) {
                return (self.direction * (l.Name().toLowerCase().localeCompare(r.Name().toLowerCase())));
            });
        },
        Manage: function () {
            return (self.filter.length === 0)
                ? self.SortName.Unfiltered(self.sortdirection())
                : self.SortName.Filtered(self.sortdirection());
        }
    };

    self.SortDisplayOrder = {
        Filtered: function () {
            return ko.utils.arrayFilter(self.itemlist(), function (item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function (l, r) {
                return (self.direction * (l.DisplaySort().toLowerCase().localeCompare(r.DisplaySort().toLowerCase())));
            });
        },
        Unfiltered: function () {
            return self.itemlist().sort(function (l, r) {
                return (self.direction * (l.DisplaySort().toLowerCase().localeCompare(r.DisplaySort().toLowerCase())));
            });
        },
        Manage: function () {
            return (self.filter.length === 0)
                ? self.SortDisplayOrder.Unfiltered()
                : self.SortDisplayOrder.Filtered();
        }
    };

    self.filteredItems = function () {
        self.direction = ko.unwrap(self.sortdirection);
        self.filter = ko.unwrap(self.searchvalue).toLowerCase();
        if (self.IsDragDrop()) {
            return null;
        };
        switch (self.sorttype) {
            case 1:
                return self.SortDisplayOrder.Manage();
            case 2:
                return self.SortName.Manage();
            case 3:
                return self.SortDivision.Manage();
            case 4:
                return self.SortDepartment.Manage();
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
        self.IsSaveClose(false);
        self.IsEditContact(false);
        self.IsSaveContact(false);

        self.PlaceFax.Clear();
        self.PlaceCell.Clear();
        self.PlaceHome.Clear();
        self.PlaceWork.Clear();
        self.Place.Clear();
        self.Person.Clear();
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

    self.PlaceEdit = function(editdata) {
        self.IsEdit(true);
        self.placeid(ko.unwrap(editdata.PlaceId()));

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
            };
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
            };
            return "";
        },
        ProcessAdd: function() {
            self.ReorderList.ReorderDragDrop();
            self.itemlist.push(self.Place.Build());
        },
        ItemExists: function() {
            var match = ko.utils.arrayFirst(self.itemlist(), function(item) {
                return item.PlaceId() === self.placeid();
            });
            return match;
        },
        ProcessEdit: function() {
            self.itemlist.replace(self.ProcessSave.ItemExists(), self.Place.Build());
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
                UseMailingForShipping: self.placeUseMailingforShipping()
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
                };

                if (self.IsEditContact()) {
                    if (self.IsSaveContact()) {
                        self.IsSaveClose(false);
                        self.SavePerson.Save();
                    } else {
                        self.IsSaveClose(true);
                        self.SavePerson.Save();
                    };
                } else {
                    self.ProcessSave.Manage();
                    self.clearandtoggle();
                };
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
                self.itemlist.remove(removedata);
                self.clear();
            });
        },
        Validate: function(item) {
            if (!confirm("Delete Item: '" + ko.unwrap(item.Name) + "'?")) {
                return;
            };
            self.RemoveItem.SetListItemInactive(item);
        }
    };

    self.RemovePerson = {
        SetListItemInactive: function(item) {
            $.ajax({
                url: baseUrl + "DeleteContact/" + ko.unwrap(item.PersonId()),
                type: "post"
            }).then(function(returndata) {

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
        Validate: function(item) {
            if (!confirm("Delete Contact: '" + ko.unwrap(item.FullName) + "'?")) {
                return;
            };
            self.RemovePerson.SetListItemInactive(item);
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
            DisplaySortValue: function (value) {
                if (value < 10) {
                    return "00" + value;
                };
                if (value < 100) {
                    return "0" + value;
                };
                return value.toString();
            },
            EditList: function (placeid, value) {
                var match = ko.utils.arrayFirst(self.itemlist(), function (item) {
                    return parseInt(item.PlaceId()) === placeid;
                });
                if (match) {
                    self.pauseNotifications = true;
                    match.DisplayOrder(value);
                    match.DisplaySort(self.ReorderList.Reorder.DisplaySortValue(value));
                    self.pauseNotifications = false;
                };
            },
            ManageList: function () {
                for (var i = 0; i < self.ReorderList.displayreorder().length; i++) {
                    self.ReorderList.Reorder.EditList(
                        ko.unwrap(self.ReorderList.displayreorder()[i].Id),
                        ko.unwrap(self.ReorderList.displayreorder()[i].DisplayOrder)
                    );
                };
            },
            RefreshHtml: function () {
                self.IsDragDrop(true);
                self.ManageSort.DragDrop();
                self.IsDisplayOrderChanged(true);
                self.IsDisplayOrderChanged(false);
                self.makelistsortable();
                self.IsDragDrop(false);
            },
            ManageSort: function () {
                if (self.ReorderList.displayreorder().length === 0) {
                    return;
                };
                self.ReorderList.Reorder.Save();
                self.ReorderList.displayreorder([]);
            },
            ManageDragDrop: function () {
                if (self.ReorderList.displayreorder().length === 0) {
                    return;
                };
                self.ReorderList.Reorder.Save();
                self.ReorderList.Reorder.ManageList();
                self.ReorderList.Reorder.RefreshHtml();
                self.ReorderList.displayreorder([]);
            }
        },
        Capture: function (placeid, value) {
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