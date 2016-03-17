(function($) {
    $(document).foundation();

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

      toggleNav: function() {
        var sideNav = $('aside.left');
        $('.menu-icon').click(function() {
          if ($('aside.left.active-nav').length < 1) {
            sideNav.addClass('active-nav');
            sideNav.animate({"left": "0", "position":"fixed"}, 500);
            $('.main-content').fadeOut();
          } else {
            sideNav.animate({"left": "-500px", "position":"fixed"}, 500);
            sideNav.removeClass('active-nav');
            $('.main-content').fadeIn();
          }
        });
      },

      init: function() {
        vm.toggleSubNav();
        vm.toggleAvatarDropdown();
        vm.initDatepicker();
        vm.toggleNav();
      }
    };

    var vm = _dashboard.viewModel();
    _dashboard.init();

})(jQuery);
