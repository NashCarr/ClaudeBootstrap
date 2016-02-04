
GiftCardViewModel = function(data) {
    var self = this;
    var baseUrl = "/GiftCard/";

    self.IsEdit = ko.observable(false);
    self.IsListAreaVisible = ko.observable(true);
    self.IsSearchAreaVisible = ko.observable(true);
    self.IsAddEditAreaVisible = ko.observable(false);
    self.IsMessageAreaVisible = ko.observable(false);

    self.errmsg = ko.observable("");
    self.searchvalue = ko.observable("");

    self.name = ko.observable("");
    self.recordid = ko.observable(0);
    self.displayorder = ko.observable(0);
    self.stringcreatedate = ko.observable("");

    self.listitems = ko.mapping.fromJS(data.ListEntity);

    self.filteredItems = ko.dependentObservable(function() {
        var filter = self.searchvalue().toLowerCase();
        if (!filter) {
            return self.listitems();
        } else {
            return ko.utils.arrayFilter(self.listitems(), function(item) {
                return ko.unwrap(item.Name).toLowerCase().indexOf(filter) !== -1;
            });
        }
    }, self);

    self.clear = function() {
        self.name("");
        self.errmsg("");
        self.recordid(0);
        self.displayorder(0);

        self.IsEdit(false);
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

    self.returnmessage = ko.computed(function() {
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

    self.search = function () {
        self.clear();
    };

    self.save = function () {
        var item = {
            Name: self.name(),
            RecordId: self.recordid(),
            DisplayOrder: self.displayorder(),
            StringCreateDate: self.stringcreatedate()
        };
        $.ajax({
            url: baseUrl,
            type: "post",
            data: item
        }).then(function(returndata) {

            self.handlereturndata(returndata);
            if (self.IsMessageAreaVisible()) {
                return;
            }

            if (self.IsEdit()) {
                self.updatelistitem(item);
                self.clearandtoggle();
                return;
            }

            item.RecordId = returndata.Id;
            self.listitems.push(
                {
                    Name: ko.observable(item.Name),
                    RecordId: ko.observable(item.RecordId),
                    DisplayOrder: ko.observable(item.DisplayOrder),
                    StringCreateDate: ko.observable(item.StringCreateDate)
                }
            );
            self.clearandtoggle();
        });
    };


    self.updatelistitem = function(item) {
        for (var i = 0; i < self.listitems().length; i++) {
            if (self.listitems()[i].RecordId() === item.RecordId) {
                self.listitems()[i].Name(item.Name);
                self.listitems()[i].DisplayOrder(item.DisplayOrder);
                break;
            }
        }
    };

    self.removelistitem = function(removedata) {

        self.name(removedata.Name());
        self.recordid(removedata.RecordId());

        if (!confirm("Delete Gift Card: '" + self.name() + "'?")) {
            return;
        }

        $.ajax({
            url: baseUrl + self.recordid(),
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
};