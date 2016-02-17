
CustomerViewModel = function (data) {
    var self = this;
    var baseUrl = "/Customer/";

    self.sorttype = 1;
    self.sortdirection = ko.observable(1);

    self.IsEdit = ko.observable(false);
    self.IsListAreaVisible = ko.observable(true);
    self.IsSearchAreaVisible = ko.observable(true);
    self.IsAddEditAreaVisible = ko.observable(false);
    self.IsMessageAreaVisible = ko.observable(false);
    self.IsDisplayOrderChanged = ko.observable(false);

    self.errmsg = ko.observable("");
    self.searchvalue = ko.observable("");

    self.name = ko.observable("");
    self.placeid = ko.observable(0);
    self.timezone = ko.observable(0);
    self.placetype = ko.observable(2);
    self.division = ko.observable("");
    self.department = ko.observable("");
    self.displayorder = ko.observable(0);

    self.displayreorder = ko.observableArray();

    self.timezones = ko.observableArray();

    self.listitems = ko.mapping.fromJS(data.ListEntity).extend({ deferred: true });
    self.timezones = ko.mapping.fromJS(data.TimeZones).extend({ deferred: true });

    self.setmessageview = function () {
        self.IsMessageAreaVisible(self.errmsg().length);
    };

    self.DragDropComplete = ko.computed(function () {
        return !self.IsDisplayOrderChanged();
    });

    self.managesorttype = function (type) {
        if (self.sorttype === type) {
            return;
        }
        self.sorttype = type;
        self.pauseNotifications = true;
        self.sortdirection(-1);
        self.pauseNotifications = false;
    };

    self.managesortdirection = function (type) {
        self.managesorttype(type);
        self.sortdirection(self.sortdirection() * -1);
    };

    self.namesort = function () {
        self.managesortdirection(2);
    };

    self.displayordersort = function () {
        self.managesortdirection(1);
    };

    self.unfilteredsortbyorder = function (sortDirection) {
        return self.listitems().sort(function (l, r) {
            return (parseInt(l.DisplayOrder()) > parseInt(r.DisplayOrder())) ^ (sortDirection === -1);
        });
    };

    self.filteredsortbyorder = function (filter, sortDirection) {
        return ko.utils.arrayFilter(self.listitems(), function (item) {
            return ko.unwrap(item.Name).toLowerCase().indexOf(filter) !== -1;
        }).sort(function (l, r) {
            return (parseInt(l.DisplayOrder()) > parseInt(r.DisplayOrder())) ^ (sortDirection === -1);
        });
    };

    self.unfilteredsortbyname = function (sortDirection) {
        return self.listitems().sort(function (l, r) {
            return (l.Name().toLowerCase() > r.Name().toLowerCase()) ^ (sortDirection === -1);
        });
    };

    self.filteredsortbyname = function (filter, sortDirection) {
        return ko.utils.arrayFilter(self.listitems(), function (item) {
            return ko.unwrap(item.Name).toLowerCase().indexOf(filter) !== -1;
        }).sort(function (l, r) {
            return (l.Name().toLowerCase() > r.Name().toLowerCase()) ^ (sortDirection === -1);
        });
    };

    self.managedisplayordersort = function (filter) {
        return (filter.length === 0)
            ? self.unfilteredsortbyorder(self.sortdirection())
            : self.filteredsortbyorder(filter, self.sortdirection());
    };

    self.managenamesort = function (filter) {
        return (filter.length === 0)
            ? self.unfilteredsortbyname(self.sortdirection())
            : self.filteredsortbyname(filter, self.sortdirection());
    };

    self.filteredItems = function () {
        var filter = self.searchvalue().toLowerCase();
        return self.sorttype === 1
            ? self.managedisplayordersort(filter)
            : self.managenamesort(filter);
    };

    self.toggleview = function () {
        self.setmessageview();
        self.IsListAreaVisible(!self.IsListAreaVisible());
        self.IsSearchAreaVisible(!self.IsSearchAreaVisible());
        self.IsAddEditAreaVisible(!self.IsAddEditAreaVisible());
    };

    self.clear = function () {
        self.name("");
        self.errmsg("");
        self.placeid(0);
        self.timezone(0);
        self.division("");
        self.department("");
        self.displayorder(0);

        self.IsEdit(false);
    };

    self.returnmessage = ko.pureComputed(function () {
        return ko.unwrap(self.errmsg);
    });

    self.handlereturndata = function (returndata) {
        self.placeid(returndata.Id);
        self.errmsg(returndata.ErrMsg);

        self.setmessageview();
    };

    self.edit = function (editdata) {
        self.name(editdata.Name());
        self.placeid(editdata.PlaceId());
        self.timezone(editdata.TimeZone());
        self.division(editdata.Division());
        self.department(editdata.Department());
        self.displayorder(editdata.DisplayOrder());

        self.IsEdit(true);
        self.toggleview();
    };

    self.clearandtoggle = function () {
        self.clear();
        self.toggleview();
    };

    self.add = function () {
        self.clearandtoggle();
        self.name(self.searchvalue());
    };

    self.cancel = function () {
        self.clearandtoggle();
    };

    self.reset = function () {
        self.searchvalue("");
    };

    self.itemExists = function (id) {
        var match = ko.utils.arrayFirst(self.listitems(), function (item) {
            return item.PlaceId() === id;
        });
        return match;
    };

    self.processadd = function (itemToAdd) {
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

    self.processedit = function (item) {
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

    self.managesave = function (item) {
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

    self.save = function () {
        var item = {
            Name: self.name(),
            PlaceId: self.placeid(),
            TimeZone: self.timezone(),
            Division: self.division(),
            Department: self.department(),
            DisplayOrder: self.displayorder()
        };
        $.ajax({
            url: baseUrl + "Save",
            type: "post",
            data: item
        }).then(function (returndata) {

            self.handlereturndata(returndata);
            if (self.IsMessageAreaVisible()) {
                return;
            }

            self.managesave(item);
            self.clearandtoggle();
        });
    };

    self.setlistiteminactive = function (removedata) {
        $.ajax({
            url: baseUrl + removedata.PlaceId(),
            type: "delete"
        }).then(function (returndata) {

            self.handlereturndata(returndata);
            if (self.IsMessageAreaVisible()) {
                return;
            }
            self.listitems.remove(removedata);
            self.clear();
        });
    };

    self.removelistitem = function (item) {
        if (!confirm("Delete Item: '" + ko.unwrap(item.Name) + "'?")) {
            return;
        }
        self.setlistiteminactive(item);
    };

    self.savenewdisplayorder = function () {
        $.ajax({
            type: "post",
            url: baseUrl + "DisplayOrder",
            dataType: "json",
            data: ko.toJSON(self.displayreorder),
            contentType: "application/json; charset=utf-8"
        });
    };

    self.editlistdisplayorder = function (placeid, value) {
        for (var i = 0; i < self.filteredItems().length; i++) {
            if (self.filteredItems()[i].PlaceId() !== placeid)
                continue;
            if (self.filteredItems()[i].DisplayOrder() !== (value)) {
                self.filteredItems()[i].DisplayOrder(value);
            }
            break;
        }
    };

    self.managelistdisplayorder = function () {
        for (var i = 0; i < self.displayreorder().length; i++) {
            self.editlistdisplayorder(
                ko.unwrap(self.displayreorder()[i].Id),
                ko.unwrap(self.displayreorder()[i].DisplayOrder)
            );
        }
    };

    var fixHelperModified = function (e, tr) {
        var $originals = tr.children();
        var $helper = tr.clone();
        $helper.children().each(function (index) {
            $(this).width($originals.eq(index).width());
        });
        return $helper;
    };

    self.makelistsortable = function () {
        $("#datatable tbody").sortable({
            helper: fixHelperModified,
            stop: self.reorderfilteredlist
        }).disableSelection();
    };

    self.refreshlisthtml = function () {
        self.IsDisplayOrderChanged(true);
        self.IsDisplayOrderChanged(false);
        self.makelistsortable();
    };

    self.managedisplayreorder = function () {
        if (self.displayreorder().length === 0) {
            return;
        }
        self.savenewdisplayorder();
        self.managelistdisplayorder();
        self.refreshlisthtml();
        self.displayreorder([]);
    };

    self.capturenewdisplayorder = function (placeid, value) {
        self.displayreorder.push(
        {
            Id: placeid,
            DisplayOrder: value
        });
    };

    self.getnewindex = function (n) {
        if (ko.unwrap(self.sortdirection) === 1) {
            return n + 1;
        }
        return n - 1;
    };

    self.initnewindex = function () {
        if (ko.unwrap(self.sortdirection) === 1) {
            return 0;
        }
        return (self.filteredItems().length) + 1;
    };

    self.reorderfilteredlist = function () {
        var rowindex = 0;
        var rowplaceid = 0;
        var rowdisplayorder = 0;
        var newindex = self.initnewindex();

        self.displayreorder([]);
        $("#datatable tbody").children().each(function () {
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