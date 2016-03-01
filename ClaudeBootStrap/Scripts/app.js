(function($) {
    var _dashboard = {
      viewModel: function() {
        return this;
      },

      toggleSubNav: function() {
        $('aside .menu li.parent > a').click(function(e) {
          e.preventDefault();
          $(this)
            .parent('li')
            .toggleClass('active')
            .find('ul').slideToggle(500);
        });
      },

      toggleAvatarDropdown: function() {
        $('.avatar-dropdown .toggle').click(function() {
          $(this).parent().find('ul').fadeToggle();
        });
      },

      initDatepicker: function() {
        $('input.datepicker').pickadate();
      },

      init: function() {
        vm.toggleSubNav();
        vm.toggleAvatarDropdown();
        vm.initDatepicker();
      }
    };

    var vm = _dashboard.viewModel();
    _dashboard.init();

})(jQuery);
