
GiftCardViewModel = function(data) {
    var self = this;
    var baseUrl = "/KoGiftCard/";

    self.IsListAreaVisible = ko.observable();
    self.IsSearchAreaVisible = ko.observable();
    self.IsAddEditAreaVisible = ko.observable();

    self.errmsg = data.Entity.ErrMsg;
    self.isactive = data.Entity.IsActive;
    self.recordid = data.Entity.RecordId;
    self.name = ko.observable(data.Entity.Name);
    self.displayorder = ko.observable(data.Entity.DisplayOrder);
    self.listentity = ko.observableArray(data.ListEntity);

    self.searchvalue = "";

    self.list = ko.computed(function() {
        this.IsListAreaVisible = ko.observable(true);
        this.IsSearchAreaVisible = ko.observable(true);
        this.IsAddEditAreaVisible = ko.observable(false);
    }, this);

    self.addedit = function () {
        this.IsListAreaVisible = ko.observable(false);
        this.IsSearchAreaVisible = ko.observable(false);
        this.IsAddEditAreaVisible = ko.observable(true);
        return this;
    };

    self.edit = function () {
        location.href = "/KoGiftCard/" + self.recordid;
    };

    self.description = ko.computed(function () {
        return ko.unwrap(self.displayorder) + " " + ko.unwrap(self.name) + " (" + ko.unwrap(self.recordid) + ")";
    });

    self.show = function() {
        alert(self.description());
    };

    self.edit = function() {
        location.href = "/KoGiftCard/" + self.recordid;
    };

    self.save = function() {
        $.ajax({
            url: baseUrl,
            type: "post",
            data: {
                entity: {
                    Name: self.name(),
                    RecordId: self.recordid,
                    DisplayOrder: self.displayorder()
                }
            }
        }).then(function(result) {
            self.recordid = result.Entity.RecordId;
            location.href = baseUrl;
        });
    };

    self.remove = function() {
        if (confirm("Delete '" + self.description() + "'?")) {
            $.ajax({
                url: baseUrl +  self.recordid,
                type: "delete"
        }).then(function () {
                //I'm deleted now
            });
        }
    };
}


