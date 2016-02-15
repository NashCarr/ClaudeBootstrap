
GiftCardViewModel = function (data) {
    var self = this;
    var baseUrl = "/GiftCard/";

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
    self.recordid = ko.observable(0);
    self.issystem = ko.observable(false);
    self.displayorder = ko.observable(0);
    self.stringcreatedate = ko.observable("");

    self.displayreorder = ko.observableArray();

    self.listitems = ko.mapping.fromJS(data.ListEntity).extend({ deferred: true });

    self.setmessageview = function () {
        self.IsMessageAreaVisible((self.errmsg().length === 0));
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
        self.recordid(0);
        self.displayorder(0);
        self.issystem(false);

        self.IsEdit(false);
    };

    self.returnmessage = ko.pureComputed(function () {
        return ko.unwrap(self.errmsg);
    });

    self.handlereturndata = function (returndata) {
        self.recordid(returndata.Id);
        self.errmsg(returndata.ErrMsg);
        self.stringcreatedate(returndata.StringCreateDate);

        self.setmessageview();
    };

    self.edit = function (editdata) {
        self.name(editdata.Name());
        self.recordid(editdata.RecordId());
        self.issystem(editdata.IsSystem());
        self.displayorder(editdata.DisplayOrder());
        self.stringcreatedate(editdata.StringCreateDate());

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
            return item.RecordId() === id;
        });
        return match;
    };

    self.processadd = function (itemToAdd) {
        self.reorderfilteredlist();
        var newitem = {
            Name: ko.observable(itemToAdd.Name),
            RecordId: ko.observable(itemToAdd.RecordId),
            IsSystem: ko.observable(itemToAdd.IsSystem),
            DisplayOrder: ko.observable(itemToAdd.DisplayOrder),
            StringCreateDate: ko.observable(itemToAdd.StringCreateDate)
        };
        self.listitems.push(newitem);
    };

    self.processedit = function (item) {
        for (var i = 0; i < self.listitems().length; i++) {
            if (self.listitems()[i].RecordId() !== item.RecordId)
                continue;
            self.listitems()[i].Name(item.Name);
            self.listitems()[i].DisplayOrder(item.DisplayOrder);
            break;
        }
    };

    self.managesave = function (item) {
        if (self.IsEdit()) {
            self.processedit(item);
            return;
        }

        if (self.itemExists(self.recordid())) {
            return;
        }

        item.RecordId = self.recordid();
        item.StringCreateDate = self.stringcreatedate();
        self.processadd(item);
    };

    self.save = function () {
        var item = {
            Name: self.name(),
            RecordId: self.recordid(),
            IsSystem: self.issystem(),
            DisplayOrder: self.displayorder(),
            StringCreateDate: self.stringcreatedate()
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
            url: baseUrl + removedata.RecordId(),
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

    self.editlistdisplayorder = function (recordid, value) {
        for (var i = 0; i < self.filteredItems().length; i++) {
            if (self.filteredItems()[i].RecordId() !== recordid)
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

    self.capturenewdisplayorder = function (recordid, value) {
        self.displayreorder.push(
        {
            Id: recordid,
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
        var rowrecordid = 0;
        var rowdisplayorder = 0;
        var newindex = self.initnewindex();

        self.displayreorder([]);
        $("#datatable tbody").children().each(function () {
            newindex = self.getnewindex(newindex);
            rowrecordid = parseInt($("#datatable tbody").children()[rowindex].children[1].innerText);
            rowdisplayorder = parseInt($("#datatable tbody").children()[rowindex].children[4].innerText);
            if (rowdisplayorder !== newindex) {
                self.capturenewdisplayorder(rowrecordid, newindex);
                $("#datatable tbody").children()[rowindex].children[4].innerText = newindex;
            }
            rowindex = rowindex + 1;
        });
        self.managedisplayreorder();
    };

    self.makelistsortable();
};