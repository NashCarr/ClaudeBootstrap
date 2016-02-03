
GiftCardViewModel = function(data) {
    var self = this;
    var baseUrl = "/GiftCard/";

    self.IsListAreaVisible = ko.observable(true);
    self.IsSearchAreaVisible = ko.observable(true);
    self.IsAddEditAreaVisible = ko.observable(false);
    self.IsMessageAreaVisible = ko.observable(false);

    self.errmsg = ko.observable();
    self.searchvalue = ko.observable("");

    self.name = ko.observable();
    self.recordid = ko.observable();
    self.displayorder = ko.observable();

    self.listitems = ko.observableArray(data.ListEntity);

    self.setmessageview = function() {
        if (self.errmsg() === "") {
            self.IsMessageAreaVisible(false);
        } else {
            self.IsMessageAreaVisible(true);
        }
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

    self.edit = function(data) {
        self.name(data.Name);
        self.recordid(data.RecordId);
        self.displayorder(data.DisplayOrder);
        self.toggleview();
    };

    self.addorcancel = function() {
        self.clear();
        self.toggleview();
    };

    self.reset = function() {
        self.searchvalue("");
    };

    self.clear = function() {
        self.name("");
        self.errmsg("");
        self.recordid(0);
        self.displayorder(0);
    };

    self.save = function() {
        var item = {
            Name: self.name(),
            RecordId: self.recordid(),
            DisplayOrder: self.displayorder(),
            StringCreateDate: ""
        };
        $.ajax({
            url: baseUrl,
            type: "post",
            data: item
        }).then(function(returndata) {
            self.handlereturndata(returndata);
            if (!self.IsMessageAreaVisible()) {
                item.RecordId = returndata.id;
                self.listitems.push(item);
                self.clear();
            }
        });
    };

    self.removelistitem = function(id) {
        self.name(id.Name);
        self.recordid(id.RecordId);
        if (confirm("Delete Gift Card: '" + self.name() + "'?")) {
            $.ajax({
                url: baseUrl + self.recordid(),
                type: "delete"
            }).then(function(returndata) {
                self.handlereturndata(returndata);
                if (!self.IsMessageAreaVisible()) {
                    self.listitems.remove(id);
                    self.clear();
                }
            });
        }
    };
};