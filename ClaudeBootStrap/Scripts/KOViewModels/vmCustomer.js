﻿
CustomerViewModel = function(data) {
    var self = this;
    var baseUrl = "/Customer/";

    self.sorttype = 1;
    self.sortdirection = ko.observable(1);

    self.IsEdit = ko.observable(false);

    self.IsPhoneDetailVisible = ko.observable(false);
    self.IsPrimaryDetailVisible = ko.observable(true);
    self.IsAddressDetailVisible = ko.observable(false);

    self.IsListAreaVisible = ko.observable(true);
    self.IsSearchAreaVisible = ko.observable(true);
    self.IsAddEditAreaVisible = ko.observable(false);
    self.IsMessageAreaVisible = ko.observable(false);
    self.IsDisplayOrderChanged = ko.observable(false);

    self.errmsg = ko.observable("");
    self.searchvalue = ko.observable("");

    self.displayorder = ko.observable(0);
    self.displayreorder = ko.observableArray();

    self.UseMailingforShipping = ko.observable(true);

    self.placeid = ko.observable(0);
    self.placename = ko.observable("");
    self.placecountry = ko.observable("");
    self.placetimezone = ko.observable("");
    self.placedivision = ko.observable("");
    self.placedepartment = ko.observable("");

    self.workisprimary = ko.observable(true);
    self.cellisprimary = ko.observable(false);
    self.homeisprimary = ko.observable(false);

    self.phonesettingid = 0;
    self.phoneprimaryid = 0;

    self.faxassociationid = 0;
    self.cellassociationid = 0;
    self.homeassociationid = 0;
    self.workassociationid = 0;
    self.mailingassociationid = 0;
    self.shippingassociationid = 0;

    self.faxcountry = ko.observable(0);
    self.faxphonenumber = ko.observable(0);

    self.cellcountry = ko.observable(0);
    self.cellcarrier = ko.observable(0);
    self.cellphonenumber = ko.observable("");
    self.cellaccepttext = ko.observable(true);

    self.homecountry = ko.observable(0);
    self.homephonenumber = ko.observable(0);

    self.workcountry = ko.observable(0);
    self.workextension = ko.observable(0);
    self.workphonenumber = ko.observable(0);

    self.mailingcity = ko.observable("");
    self.mailingcountry = ko.observable(0);
    self.mailingaddress1 = ko.observable("");
    self.mailingaddress2 = ko.observable("");
    self.mailingpostalcode = ko.observable("");
    self.mailingstateprovince = ko.observable("");

    self.shippingcity = ko.observable("");
    self.shippingcountry = ko.observable(0);
    self.shippingaddress1 = ko.observable("");
    self.shippingaddress2 = ko.observable("");
    self.shippingpostalcode = ko.observable("");
    self.shippingstateprovince = ko.observable("");

    self.listitems = ko.observableArray([]);
    self.timezones = ko.observableArray([]);
    self.countries = ko.observableArray([]);
    self.mobilecarriers = ko.observableArray([]);
    self.statesprovinces = ko.observableArray([]);

    self.timezones = ko.mapping.fromJS(data.TimeZones).extend({ deferred: true });
    self.countries = ko.mapping.fromJS(data.Countries).extend({ deferred: true });
    self.listitems = ko.mapping.fromJS(data.ListEntity).extend({ deferred: true });
    self.mobilecarriers = ko.mapping.fromJS(data.MobileCarriers).extend({ deferred: true });
    self.statesprovinces = ko.mapping.fromJS(data.StatesProvinces).extend({ deferred: true });

    self.placedata = ko.observableArray([]);

    self.cellprimarychange = function() {
        if (!self.cellisprimary()) {
            return;
        };
        self.homeisprimary(false);
        self.workisprimary(false);
    };

    self.homeprimarychange = function() {
        if (!self.homeisprimary()) {
            return;
        };
        self.cellisprimary(false);
        self.workisprimary(false);
    };

    self.workprimarychange = function() {
        if (!self.workisprimary()) {
            return;
        };
        self.cellisprimary(false);
        self.homeisprimary(false);
    };

    self.defaultfaxcountry = function() {
        if (typeof self.faxcountry() !== "undefined") {
            if (self.faxcountry() !== 0) {
                return;
            };
        };
        self.faxcountry(self.placecountry());
    };

    self.defaultcellcountry = function() {
        if (typeof self.cellcountry() !== "undefined") {
            if (self.cellcountry() !== 0) {
                return;
            };
        };
        self.cellcountry(self.placecountry());
    };

    self.defaulthomecountry = function() {
        if (typeof self.homecountry() !== "undefined") {
            if (self.homecountry() !== 0) {
                return;
            };
        };
        self.homecountry(self.placecountry());
    };

    self.defaultworkcountry = function() {
        if (typeof self.workcountry() !== "undefined") {
            if (self.workphonenumber() !== 0) {
                if (self.workcountry() !== 0) {
                    return;
                };
            };
        };
        self.workcountry(self.placecountry());
    };

    self.defaultmailingcountry = function() {
        if (typeof self.mailingcountry() !== "undefined") {
            if (self.mailingaddress1().length !== 0) {
                if (self.mailingcountry() !== 0) {
                    return;
                };
            };
        };
        self.mailingcountry(self.placecountry());
    };

    self.defaultshippingcountry = function() {
        if (typeof self.shippingcountry() !== "undefined") {
            if (self.shippingcountry() !== 0) {
                return;
            };
        };
        self.shippingcountry(self.placecountry());
    };

    self.defaultshippingcity = function() {
        if (typeof self.mailingcity() !== "undefined") {
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
        };
    };

    self.defaultshippingaddress1 = function() {
        if (typeof self.mailingaddress1() !== "undefined") {
            self.shippingaddress1(self.mailingaddress1());
        };
    };

    self.defaultshippingaddress2 = function() {
        if (typeof self.mailingaddress2() !== "undefined") {
            self.shippingaddress2(self.mailingaddress2());
        };
    };

    self.defaultshippingpostalcode = function() {
        if (typeof self.mailingpostalcode() !== "undefined") {
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
        };
    };

    self.defaultshippingstateprovince = function() {
        if (typeof self.mailingstateprovince() !== "undefined") {
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
        };
    };

    self.viewprimary = function() {
        self.IsPhoneDetailVisible(false);
        self.IsPrimaryDetailVisible(true);
        self.IsAddressDetailVisible(false);
    };

    self.viewphones = function() {
        self.IsPhoneDetailVisible(true);
        self.IsPrimaryDetailVisible(false);
        self.IsAddressDetailVisible(false);
    };

    self.viewaddresses = function() {
        self.IsPhoneDetailVisible(false);
        self.IsAddressDetailVisible(true);
        self.IsPrimaryDetailVisible(false);
    };

    self.setshippingbasicdefaults = function() {
        self.defaultshippingcity();
        self.defaultshippingpostalcode();
        self.defaultshippingstateprovince();
    };

    self.setshippingdefaults = function() {
        if (self.UseMailingforShipping()) {
            self.defaultshippingaddress1();
            self.defaultshippingaddress2();
        };
        self.setshippingbasicdefaults();
    };

    self.setcountrydefaults = function() {
        if (typeof self.placecountry() !== "undefined") {
            self.defaultfaxcountry();
            self.defaultcellcountry();
            self.defaulthomecountry();
            self.defaultworkcountry();
            self.defaultmailingcountry();
            self.defaultshippingcountry();
        }
    };

    self.clearfaxvalues = function() {
        self.faxassociationid = 0;
        self.faxcountry = ko.observable(0);
        self.faxphonenumber = ko.observable(0);
    };

    self.clearcellvalues = function() {
        self.cellassociationid = 0;
        self.cellcountry = ko.observable(0);
        self.cellcarrier = ko.observable(0);
        self.cellphonenumber = ko.observable("");
        self.cellaccepttext = ko.observable(true);
    };

    self.clearhomevalues = function() {
        self.homeassociationid = 0;
        self.homecountry = ko.observable(0);
        self.homephonenumber = ko.observable(0);
    };

    self.clearworkvalues = function() {
        self.workassociationid = 0;
        self.workcountry = ko.observable(0);
        self.workextension = ko.observable(0);
        self.workphonenumber = ko.observable(0);
    };

    self.clearmailingvalues = function() {
        self.mailingassociationid = 0;
        self.mailingcity = ko.observable("");
        self.mailingcountry = ko.observable(0);
        self.mailingaddress1 = ko.observable("");
        self.mailingaddress2 = ko.observable("");
        self.mailingpostalcode = ko.observable("");
        self.mailingstateprovince = ko.observable("");
    };

    self.clearshippingvalues = function() {
        self.shippingassociationid = 0;
        self.shippingcity = ko.observable("");
        self.shippingcountry = ko.observable(0);
        self.shippingaddress1 = ko.observable("");
        self.shippingaddress2 = ko.observable("");
        self.shippingpostalcode = ko.observable("");
        self.shippingstateprovince = ko.observable("");
        self.shippingstateprovince = ko.observable("");
    };

    self.clearplacevalues = function() {
        self.placeid = ko.observable(0);
        self.placename = ko.observable("");
        self.placecountry = ko.observable(0);
        self.placetimezone = ko.observable(0);
        self.placedivision = ko.observable("");
        self.placedepartment = ko.observable("");
    };

    self.setfaxvalues = function() {
        self.faxcountry(ko.unwrap(self.placedata.Country));
        self.faxphonenumber(ko.unwrap(self.placedata.PhoneNumber));
        self.faxassociationid = ko.unwrap(self.placedata.PhoneAssociationId);
    };

    self.setcellvalues = function() {
        self.cellcountry(ko.unwrap(self.placedata.Country));
        self.cellphonenumber(ko.unwrap(self.placedata.PhoneNumber));
        self.cellassociationid = ko.unwrap(self.placedata.PhoneAssociationId);
    };

    self.sethomevalues = function() {
        self.homecountry(ko.unwrap(self.placedata.Country));
        self.homephonenumber(ko.unwrap(self.placedata.PhoneNumber));
        self.homeassociationid = ko.unwrap(self.placedata.PhoneAssociationId);
    };

    self.setworkvalues = function() {
        self.workcountry(ko.unwrap(self.placedata.Country));
        self.workphonenumber(ko.unwrap(self.placedata.PhoneNumber));
        self.workassociationid = ko.unwrap(self.placedata.PhoneAssociationId);
    };

    self.setshippingvalues = function() {
        //self.workcountry(ko.unwrap(self.placedata.Country));
        //self.workphonenumber(ko.unwrap(self.placedata.PhoneNumber));
        self.shippingassociationid = ko.unwrap(self.placedata.AddressAssociationId);
    };

    self.setmailingvalues = function() {
        //self.workcountry(ko.unwrap(self.placedata.Country));
        //self.workphonenumber(ko.unwrap(self.placedata.PhoneNumber));
        self.mailingassociationid = ko.unwrap(self.placedata.AddressAssociationId);
    };

    self.setplacevalues = function() {
        self.placename(ko.unwrap(self.placedata.Name));
        self.placeid(ko.unwrap(self.placedata.PlaceId));
        self.placecountry(ko.unwrap(self.placedata.Country));
        self.placetimezone(ko.unwrap(self.placedata.TimeZone));
        self.placedivision(ko.unwrap(self.placedata.Division));
        self.placedepartment(ko.unwrap(self.placedata.Department));

        self.setcountrydefaults();
    };

    self.managefaxvalues = function() {
        if (typeof self.placedata === "undefined") {
            self.clearfaxvalues();
            return;
        }
        self.setfaxvalues();
    };

    self.managecellvalues = function() {
        if (typeof self.placedata === "undefined") {
            self.clearcellvalues();
            return;
        }
        self.setcellvalues();
    };

    self.managehomevalues = function() {
        if (typeof self.placedata === "undefined") {
            self.clearhomevalues();
            return;
        }
        self.sethomevalues();
    };

    self.manageworkvalues = function() {
        if (typeof self.placedata === "undefined") {
            self.clearworkvalues();
            return;
        }
        self.setworkvalues();
    };

    self.manageshippingvalues = function() {
        if (typeof self.placedata === "undefined") {
            self.clearshippingvalues();
            return;
        }
        self.setshippingvalues();
    };

    self.managemailingvalues = function() {
        if (typeof self.placedata === "undefined") {
            self.clearmailingvalues();
            return;
        }
        self.setmailingvalues();
    };

    self.manageplacevalues = function() {
        if (typeof self.placedata === "undefined") {
            self.clearplacevalues();
            return;
        }
        self.setplacevalues();
    };

    self.managephonesettings = function () {
        if (typeof self.placedata === "undefined") {
            //self.clearplacevalues();
            return;
        }
        //self.setplacevalues();
    };

    self.GetPlaceData = function () {
        $.ajax({
            url: baseUrl + "GetCustomer/" + ko.unwrap(self.placeid()),
            type: "post"
        }).then(function(returndata) {

            self.placedata = ko.mapping.fromJS(returndata.Phones.PhoneSettings);
            self.managephonesettings();

            self.placedata = ko.mapping.fromJS(returndata.Phones.FaxPhone);
            self.managefaxvalues();

            self.placedata = ko.mapping.fromJS(returndata.Phones.CellPhone);
            self.managecellvalues();

            self.placedata = ko.mapping.fromJS(returndata.Phones.HomePhone);
            self.managehomevalues();

            self.placedata = ko.mapping.fromJS(returndata.Phones.WorkPhone);
            self.manageworkvalues();

            self.placedata = ko.mapping.fromJS(returndata.Phones.ShippingAddress);
            self.manageshippingvalues();

            self.placedata = ko.mapping.fromJS(returndata.Phones.MailingAddress);
            self.managemailingvalues();

            self.placedata = ko.mapping.fromJS(returndata.Place);
            self.manageplacevalues();
        });
    };

    self.setmessageview = function() {
        self.IsMessageAreaVisible(self.errmsg().length);
    };

    self.DragDropComplete = ko.computed(function() {
        return !self.IsDisplayOrderChanged();
    });

    self.ShowShipping = ko.computed(function() {
        return !self.UseMailingforShipping();
    });

    self.managesorttype = function(type) {
        if (self.sorttype === type) {
            return;
        }
        self.sorttype = type;

        self.pauseNotifications = true;
        self.sortdirection(-1);
        self.pauseNotifications = false;
    };

    self.managesortdirection = function(type) {
        self.managesorttype(type);
        self.sortdirection(self.sortdirection() * -1);
    };

    self.namesort = function() {
        self.managesortdirection(2);
    };

    self.displayordersort = function() {
        self.managesortdirection(1);
    };

    self.unfilteredsortbyorder = function(sortDirection) {
        return self.listitems().sort(function(l, r) {
            return (parseInt(l.DisplayOrder()) > parseInt(r.DisplayOrder())) ^ (sortDirection === -1);
        });
    };

    self.filteredsortbyorder = function(filter, sortDirection) {
        return ko.utils.arrayFilter(self.listitems(), function(item) {
            return ko.unwrap(item.Name).toLowerCase().indexOf(filter) !== -1;
        }).sort(function(l, r) {
            return (parseInt(l.DisplayOrder()) > parseInt(r.DisplayOrder())) ^ (sortDirection === -1);
        });
    };

    self.unfilteredsortbyname = function(sortDirection) {
        return self.listitems().sort(function(l, r) {
            return (l.Name().toLowerCase() > r.Name().toLowerCase()) ^ (sortDirection === -1);
        });
    };

    self.filteredsortbyname = function(filter, sortDirection) {
        return ko.utils.arrayFilter(self.listitems(), function(item) {
            return ko.unwrap(item.Name).toLowerCase().indexOf(filter) !== -1;
        }).sort(function(l, r) {
            return (l.Name().toLowerCase() > r.Name().toLowerCase()) ^ (sortDirection === -1);
        });
    };

    self.managedisplayordersort = function(filter) {
        return (filter.length === 0)
            ? self.unfilteredsortbyorder(self.sortdirection())
            : self.filteredsortbyorder(filter, self.sortdirection());
    };

    self.managenamesort = function(filter) {
        return (filter.length === 0)
            ? self.unfilteredsortbyname(self.sortdirection())
            : self.filteredsortbyname(filter, self.sortdirection());
    };

    self.filteredItems = function() {
        var filter = self.searchvalue().toLowerCase();
        return self.sorttype === 1
            ? self.managedisplayordersort(filter)
            : self.managenamesort(filter);
    };

    self.toggleview = function() {
        self.setmessageview();
        self.IsListAreaVisible(!self.IsListAreaVisible());
        self.IsSearchAreaVisible(!self.IsSearchAreaVisible());
        self.IsAddEditAreaVisible(!self.IsAddEditAreaVisible());
    };

    self.clear = function() {
        self.errmsg("");
        self.IsEdit(false);
        self.displayorder(0);
        self.clearfaxvalues();
        self.clearcellvalues();
        self.clearhomevalues();
        self.clearworkvalues();
        self.clearplacevalues();
        self.clearmailingvalues();
        self.clearshippingvalues();
    };

    self.returnmessage = ko.pureComputed(function() {
        return ko.unwrap(self.errmsg);
    });

    self.handlereturndata = function(returndata) {
        self.placeid(returndata.Id);
        self.errmsg(returndata.ErrMsg);

        self.setmessageview();
    };

    self.edit = function(editdata) {
        self.IsEdit(true);
        //self.placename(editdata.Name());
        self.placeid(editdata.PlaceId());
        //self.placetimezone(editdata.TimeZone());
        //self.placedivision(editdata.Division());
        //self.displayorder(editdata.DisplayOrder());
        //self.placedepartment(editdata.Department());

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

    self.itemExists = function(id) {
        var match = ko.utils.arrayFirst(self.listitems(), function(item) {
            return item.PlaceId() === id;
        });
        return match;
    };

    self.processadd = function(itemToAdd) {
        self.reorderfilteredlist();
        var newitem = {
            Name: ko.observable(itemToAdd.Name),
            PlaceId: ko.observable(itemToAdd.PlaceId),
            TimeZone: ko.observable(itemToAdd.TimeZone),
            Division: ko.observable(itemToAdd.Division),
            Department: ko.observable(itemToAdd.Department),
            DisplayOrder: ko.observable(itemToAdd.DisplayOrder)
        };
        self.listitems.push(newitem);
    };

    self.processedit = function(item) {
        for (var i = 0; i < self.listitems().length; i++) {
            if (self.listitems()[i].PlaceId() !== item.PlaceId)
                continue;
            self.listitems()[i].Name(item.Name);
            self.listitems()[i].TimeZone(item.TimeZone);
            self.listitems()[i].Division(item.Division);
            self.listitems()[i].Department(item.Department);
            self.listitems()[i].DisplayOrder(item.DisplayOrder);
            break;
        }
    };

    self.managesave = function(item) {
        if (self.IsEdit()) {
            self.processedit(item);
            return;
        }

        if (self.itemExists(self.placeid())) {
            return;
        }

        item.PlaceId = self.placeid();
        self.processadd(item);
    };

    self.savePlace = function() {
        var item = {
            Name: self.placename(),
            PlaceId: self.placeid(),
            Country: self.placecountry(),
            TimeZone: self.placetimezone(),
            Division: self.placedivision(),
            Department: self.placedepartment()
        };
        $.ajax({
            url: baseUrl + "SavePlace",
            type: "post",
            data: item
        }).then(function(returndata) {

            //self.handlereturndata(returndata);
            //if (self.IsMessageAreaVisible()) {
            //    return;
            //}

            //self.managesave(item);
            //self.clearandtoggle();
        });
    };

    self.save = function() {
        self.savePlace();
        //var item = {
        //    Name: self.name(),
        //    PlaceId: self.placeid(),
        //    TimeZone: self.timezone(),
        //    Division: self.division(),
        //    Department: self.department(),
        //    DisplayOrder: self.displayorder()
        //};
        //$.ajax({
        //    url: baseUrl + "Save",
        //    type: "post",
        //    data: item
        //}).then(function(returndata) {

        //    self.handlereturndata(returndata);
        //    if (self.IsMessageAreaVisible()) {
        //        return;
        //    }

        //    self.managesave(item);
        //    self.clearandtoggle();
        //});
    };

    self.setlistiteminactive = function(removedata) {
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
    };

    self.removelistitem = function(item) {
        if (!confirm("Delete Item: '" + ko.unwrap(item.Name) + "'?")) {
            return;
        }
        self.setlistiteminactive(item);
    };

    self.savenewdisplayorder = function() {
        $.ajax({
            type: "post",
            url: baseUrl + "DisplayOrder",
            dataType: "json",
            data: ko.toJSON(self.displayreorder),
            contentType: "application/json; charset=utf-8"
        });
    };

    self.editlistdisplayorder = function(placeid, value) {
        for (var i = 0; i < self.filteredItems().length; i++) {
            if (self.filteredItems()[i].PlaceId() !== placeid)
                continue;
            if (self.filteredItems()[i].DisplayOrder() !== (value)) {
                self.filteredItems()[i].DisplayOrder(value);
            }
            break;
        }
    };

    self.managelistdisplayorder = function() {
        for (var i = 0; i < self.displayreorder().length; i++) {
            self.editlistdisplayorder(
                ko.unwrap(self.displayreorder()[i].Id),
                ko.unwrap(self.displayreorder()[i].DisplayOrder)
            );
        }
    };

    var fixHelperModified = function(e, tr) {
        var $originals = tr.children();
        var $helper = tr.clone();
        $helper.children().each(function(index) {
            $(this).width($originals.eq(index).width());
        });
        return $helper;
    };

    self.makelistsortable = function() {
        $("#datatable tbody").sortable({
            helper: fixHelperModified,
            stop: self.reorderfilteredlist
        }).disableSelection();
    };

    self.refreshlisthtml = function() {
        self.IsDisplayOrderChanged(true);
        self.IsDisplayOrderChanged(false);
        self.makelistsortable();
    };

    self.managedisplayreorder = function() {
        if (self.displayreorder().length === 0) {
            return;
        }
        self.savenewdisplayorder();
        self.managelistdisplayorder();
        self.refreshlisthtml();
        self.displayreorder([]);
    };

    self.capturenewdisplayorder = function(placeid, value) {
        self.displayreorder.push(
        {
            Id: placeid,
            DisplayOrder: value
        });
    };

    self.getnewindex = function(n) {
        if (ko.unwrap(self.sortdirection) === 1) {
            return n + 1;
        }
        return n - 1;
    };

    self.initnewindex = function() {
        if (ko.unwrap(self.sortdirection) === 1) {
            return 0;
        }
        return (self.filteredItems().length) + 1;
    };

    self.reorderfilteredlist = function() {
        var rowindex = 0;
        var rowplaceid = 0;
        var rowdisplayorder = 0;
        var newindex = self.initnewindex();

        self.displayreorder([]);
        $("#datatable tbody").children().each(function() {
            newindex = self.getnewindex(newindex);
            rowplaceid = parseInt($("#datatable tbody").children()[rowindex].children[1].innerText);
            rowdisplayorder = parseInt($("#datatable tbody").children()[rowindex].children[4].innerText);
            if (rowdisplayorder !== newindex) {
                self.capturenewdisplayorder(rowplaceid, newindex);
                $("#datatable tbody").children()[rowindex].children[4].innerText = newindex;
            }
            rowindex = rowindex + 1;
        });
        self.managedisplayreorder();
    };

    self.makelistsortable();
};