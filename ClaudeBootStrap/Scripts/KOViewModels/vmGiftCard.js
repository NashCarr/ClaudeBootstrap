
GiftCardViewModel = function(data) {
    var self = this;
    var baseUrl = "/GiftCard/";

    //sorting
    self.sorttype = 1;
    self.direction = 1;
    self.sortdirection = ko.observable(1);
    self.IsDragDrop = ko.observable(false);

    self.editid = ko.observable(0);
    self.IsEdit = ko.observable(false);

    self.IsListAreaVisible = ko.observable(true);
    self.IsSearchAreaVisible = ko.observable(true);
    self.IsAddEditAreaVisible = ko.observable(false);
    self.IsMessageAreaVisible = ko.observable(false);

    self.IsDisplayOrderChanged = ko.observable(false);

    self.errmsg = ko.observable("");

    self.filter = "";
    self.searchvalue = ko.observable("");

    //listvalues
    self.name = ko.observable("");
    self.recordid = ko.observable(0);
    self.displaysort = ko.observable("");
    self.displayorder = ko.observable(0);
    self.stringlastupdate = ko.observable("");

    //list
    self.itemlist = ko.mapping.fromJS(data.ListEntity).extend({ deferred: true });

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
        self.recordid(returndata.Id);
        self.errmsg(returndata.ErrMsg);
        self.stringlastupdate(returndata.StringLastUpdate);

        self.setmessageview();
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

    self.SortCreateDate = {
        Filtered: function() {
            return ko.utils.arrayFilter(self.itemlist(), function(item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(self.filter) !== -1;
            }).sort(function(l, r) {
                return (self.direction * (l.StringLastUpdate().toLowerCase().localeCompare(r.StringLastUpdate().toLowerCase())));
            });
        },
        Unfiltered: function() {
            return self.itemlist().sort(function(l, r) {
                return (self.direction * (l.StringLastUpdate().toLowerCase().localeCompare(r.StringLastUpdate().toLowerCase())));
            });
        },
        Manage: function() {
            return (self.filter.length === 0)
                ? self.SortCreateDate.Unfiltered(self.sortdirection())
                : self.SortCreateDate.Filtered(self.sortdirection());
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
            return self.SortCreateDate.Manage();
        default:
            return self.SortDisplayOrder.Manage();
        }
    };

    self.clear = function() {
        self.name("");
        self.errmsg("");
        self.recordid(0);
        self.displaysort("");
        self.displayorder(0);

        self.IsEdit(false);
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
        self.name(editdata.Name());
        self.editid(editdata.RecordId());
        self.recordid(editdata.RecordId());
        self.displaysort(editdata.DisplaySort());
        self.displayorder(editdata.DisplayOrder());
        self.stringlastupdate(editdata.StringLastUpdate());

        self.IsEdit(true);
        self.toggleview();
    };

    self.add = function() {
        if (self.searchvalue().length === 0) {
            self.addscreen();
            return;
        };
        self.quickadd();
    };

    self.addscreen = function () {
        self.clearandtoggle();
        self.name(self.searchvalue());
    };

    self.quickadd = function () {
        self.name(self.searchvalue());
        self.save();
    };

    self.cancel = function () {
        self.clearandtoggle();
    };

    self.reset = function() {
        self.searchvalue("");
    };

    self.GiftCard = {
        Build: function() {
            return {
                Name: ko.observable(ko.unwrap(self.name())),
                RecordId: ko.observable(ko.unwrap(self.recordid())),
                DisplaySort: ko.observable(ko.unwrap(self.displaysort())),
                DisplayOrder: ko.observable(ko.unwrap(self.displayorder())),
                StringLastUpdate: ko.observable(ko.unwrap(self.stringlastupdate()))
            };
        },
        Clear: function() {
            self.name("");
            self.editid(0);
            self.recordid(0);
            self.displaysort("");
            self.displayorder(0);
        }
    };

    self.ProcessSave = {
        ProcessAdd: function() {
            self.ReorderList.ReorderDragDrop();
            self.itemlist.push(self.GiftCard.Build());
        },
        ItemExists: function() {
            var match = ko.utils.arrayFirst(self.itemlist(), function(item) {
                return item.RecordId() === self.recordid();
            });
            return match;
        },
        ItemToRemove: function () {
            var match = ko.utils.arrayFirst(self.itemlist(), function (item) {
                return item.RecordId() === self.editid();
            });
            return match;
        },
        ProcessEdit: function () {
            self.itemlist.replace(self.ProcessSave.ItemExists(), self.GiftCard.Build());
        },
        ValidateEdit: function () {
            if (self.editid() === self.recordid()) {
                return true;
            };
            self.itemlist.remove(self.ProcessSave.ItemToRemove());
            return false;
        },
        Manage: function () {
            if (self.IsEdit()) {
                self.IsEdit(self.ProcessSave.ValidateEdit());
            };
            if (self.IsEdit()) {
                self.ProcessSave.ProcessEdit();
            };
            if (self.ProcessSave.ItemExists()) {
                return;
            };
            self.ProcessSave.ProcessAdd();
        }
    };

    self.save = function() {
        $.ajax({
            url: baseUrl + "Save",
            type: "post",
            data: self.GiftCard.Build()
        }).then(function(returndata) {

            self.handlereturndata(returndata);
            if (self.IsMessageAreaVisible()) {
                return;
            };
            self.ProcessSave.Manage();
            if (self.IsAddEditAreaVisible()) {
                self.clearandtoggle();
            };
        });
    };

    self.RemoveItem = {
        SetListItemInactive: function(removedata) {
            $.ajax({
                url: baseUrl + removedata.RecordId(),
                type: "delete"
            }).then(function(returndata) {

                self.handlereturndata(returndata);
                if (self.IsMessageAreaVisible()) {
                    return;
                };
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
            Save: function () {
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
                return value;
            },
            EditList: function (recordid, value) {
                var match = ko.utils.arrayFirst(self.itemlist(), function(item) {
                    return parseInt(item.RecordId()) === recordid;
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
        Capture: function (recordid, value) {
            self.ReorderList.displayreorder.push(
            {
                Id: recordid,
                DisplayOrder: value
            });
        },
        ReorderInnerText: function() {
            var newindex = 0;
            var rowindex = 0;
            var rowrecordid = 0;
            var rowdisplayorder = 0;

            self.ReorderList.displayreorder([]);
            $("#datatable tbody").children().each(function() {
                newindex = newindex + 1;
                rowrecordid = parseInt($("#datatable tbody").children()[rowindex].children[1].innerText);
                rowdisplayorder = parseInt($("#datatable tbody").children()[rowindex].children[2].innerText);
                if (rowdisplayorder !== newindex) {
                    self.ReorderList.Capture(rowrecordid, newindex);
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