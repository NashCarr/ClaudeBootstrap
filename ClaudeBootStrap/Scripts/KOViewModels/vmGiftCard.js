
GiftCardViewModel = function(data) {
    var self = this;
    var baseUrl = "/GiftCard/";

    self.init = true;
    self.sorttype = 1;
    self.sortdirection = ko.observable(1);

    self.namesortimage = ko.observable("glyphicon-arrow-down");
    self.ordersortimage = ko.observable("glyphicon-arrow-down");

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
    self.displayorder = ko.observable(0);
    self.stringcreatedate = ko.observable("");

    self.listitems = ko.mapping.fromJS(data.ListEntity).extend({ deferred: true });

    self.displayreorder = ko.observableArray();

    self.namesort = function() {
        self.managesortdirection(2);
    };

    self.displayordersort = function() {
        self.managesortdirection(1);
    };

    self.managesortdirection = function(type) {
        if (self.sorttype !== type) {
            self.sorttype = type;
            self.pauseNotifications = true;
            self.sortdirection(0);
            self.pauseNotifications = false;
        }
        if (self.sortdirection() === 1) {
            self.sortdirection(2);
            return;
        }
        self.sortdirection(1);
    };

    self.filtereddisplayordersort = function(filter) {

        if (!filter) {
            if (self.sortdirection() === 1) {
                return self.listitems().sort(
                    function(l, r) { return parseInt(l.DisplayOrder()) > parseInt(r.DisplayOrder()) ? 1 : -1 });
            }
            return self.listitems().sort(
                function(l, r) { return parseInt(l.DisplayOrder()) < parseInt(r.DisplayOrder()) ? 1 : -1 });
        }

        if (self.sortdirection() === 1) {
            return ko.utils.arrayFilter(self.listitems(), function(item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(filter) !== -1;
            }).sort(
                function(l, r) { return parseInt(l.DisplayOrder()) > parseInt(r.DisplayOrder()) ? 1 : -1 }
            );
        }

        return ko.utils.arrayFilter(self.listitems(), function(item) {
            return ko.unwrap(item.Name).toLowerCase().indexOf(filter) !== -1;
        }).sort(
            function(l, r) { return parseInt(l.DisplayOrder()) < parseInt(r.DisplayOrder()) ? 1 : -1 }
        );
    };

    self.initdisplayorder = function() {
        for (var i = 0; i < self.listitems().length; i++) {
            if (self.listitems()[i].DisplayOrder() !== (i + 1)) {
                self.listitems()[i].DisplayOrder(i + 1);
            }
        };
    };

    self.filteredItems = ko.dependentObservable(function() {

        if (self.init) {
            self.initdisplayorder();
            self.init = false;
        }

        var filter = self.searchvalue().toLowerCase();

        if (self.sorttype === 2) {
            return self.filterednamesort(filter);
        }
        return self.filtereddisplayordersort(filter);

    }, self);

    self.filterednamesort = function(filter) {

        if (!filter) {
            if (self.sortdirection() === 1) {
                return self.listitems().sort(
                    function(l, r) { return l.Name() > r.Name() ? 1 : -1 });
            }
            return self.listitems().sort(
                function(l, r) { return l.Name() < r.Name() ? 1 : -1 });
        }

        if (self.sortdirection() === 1) {
            return ko.utils.arrayFilter(self.listitems(), function(item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(filter) !== -1;
            }).sort(
                function(l, r) { return l.Name() > r.Name() ? 1 : -1 }
            );
        }

        return ko.utils.arrayFilter(self.listitems(), function(item) {
            return ko.unwrap(item.Name).toLowerCase().indexOf(filter) !== -1;
        }).sort(
            function(l, r) { return l.Name() < r.Name() ? 1 : -1 }
        );
    };

    self.setmessageview = function() {
        if (self.errmsg() === "") {
            self.IsMessageAreaVisible(false);
            return;
        }
        self.IsMessageAreaVisible(true);
    };

    self.toggleview = function() {
        self.setmessageview();
        self.IsListAreaVisible(!self.IsListAreaVisible());
        self.IsSearchAreaVisible(!self.IsSearchAreaVisible());
        self.IsAddEditAreaVisible(!self.IsAddEditAreaVisible());
    };

    self.clear = function() {
        self.name("");
        self.errmsg("");
        self.recordid(0);
        self.displayorder(0);

        self.IsEdit(false);
    };

    self.returnmessage = ko.pureComputed(function() {
        return ko.unwrap(self.errmsg);
    });

    self.handlereturndata = function(returndata) {
        self.recordid(returndata.Id);
        self.errmsg(returndata.ErrMsg);
        self.setmessageview();
    };

    self.edit = function(editdata) {
        self.name(editdata.Name());
        self.recordid(editdata.RecordId());
        self.displayorder(editdata.DisplayOrder());
        self.stringcreatedate(editdata.StringCreateDate());

        self.IsEdit(true);
        self.toggleview();
    };

    self.clearandtoggle = function() {
        self.clear();
        self.toggleview();
    };

    self.addorcancel = function() {
        self.clearandtoggle();
    };

    self.reset = function() {
        self.searchvalue("");
    };

    self.save = function() {
        var item = {
            Name: self.name(),
            RecordId: self.recordid(),
            DisplayOrder: self.displayorder(),
            StringCreateDate: self.stringcreatedate()
        };
        $.ajax({
            url: baseUrl + "Save",
            type: "post",
            data: item
        }).then(function(returndata) {

            self.handlereturndata(returndata);
            if (self.IsMessageAreaVisible()) {
                return;
            }

            self.managesave(item);
            self.clearandtoggle();
        });
    };

    self.managesave = function(item) {
        if (self.IsEdit()) {
            self.processedit(item);
            return;
        }
        item.RecordId = self.recordid();
        self.processadd(item);
    };

    self.processadd = function(item) {
        self.listitems.push(
            {
                Name: ko.observable(item.Name),
                RecordId: ko.observable(item.RecordId),
                DisplayOrder: ko.observable(item.DisplayOrder),
                StringCreateDate: ko.observable(item.StringCreateDate)
            }
        );
    };

    self.processedit = function(item) {
        for (var i = 0; i < self.listitems().length; i++) {
            if (self.listitems()[i].RecordId() === item.RecordId) {
                self.listitems()[i].Name(item.Name);
                self.listitems()[i].DisplayOrder(item.DisplayOrder);
                break;
            }
        }
    };

    self.removelistitem = function(item) {
        if (!confirm("Delete Gift Card: '" + ko.unwrap(item.Name) + "'?")) {
            return;
        }
        self.setiteminactive(item);
    };

    self.setiteminactive = function(removedata) {

        $.ajax({
            url: baseUrl + removedata.RecordId(),
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

    self.savedisplayorder = function() {
        $.ajax({
            type: "post",
            url: baseUrl + "DisplayOrder",
            dataType: "json",
            data: ko.toJSON(self.displayreorder),
            contentType: "application/json; charset=utf-8"
        });
        self.IsDisplayOrderChanged(false);
    };

    self.updatedisplayorder = function(recordid, value) {
        for (var i = 0; i < self.filteredItems().length; i++) {
            if (self.filteredItems()[i].RecordId() === recordid) {
                if (self.filteredItems()[i].DisplayOrder() !== (value)) {
                    self.pauseNotifications = true;
                    self.displayreorder.push(
                    {
                        Id: recordid,
                        DisplayOrder: value
                    });
                    self.filteredItems()[i].DisplayOrder(value);
                    self.pauseNotifications = false;
                    self.IsDisplayOrderChanged(true);
                }
                break;
            }
        }
    };

    self.reorder = function() {
        var rowindex = 0;
        $("#itemslist tbody").children().each(function() {
            var newwindex = rowindex + 1;
            var rowrecordid = parseInt($("#itemslist tbody").children()[rowindex].children[1].innerText);
            $("#itemslist tbody").children()[rowindex].children[4].innerText = newwindex;
            self.updatedisplayorder(rowrecordid, newwindex);
            rowindex = newwindex;
        });
        if (self.IsDisplayOrderChanged) {
            self.savedisplayorder();
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

    $("#itemslist tbody").sortable({
        helper: fixHelperModified,
        stop: self.reorder
    }).disableSelection();

};
