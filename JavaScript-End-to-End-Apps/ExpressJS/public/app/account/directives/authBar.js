"use strict";

app.directive("authBar", function() {
    return {
        restrict: "A",
        templateUrl: "/partials/account/auth-bar",
        link: function(scope, element, attrs) {
            var $slideMenu = $(".slide-menu");

            $(".show-slide-menu").click(function() {
                $slideMenu.slideToggle(250);

                return false;
            });

            $(document).click(function(e) {

                if($(e.target).closest("#login-form").length > 0) {
                    return false;
                } else {
                    $slideMenu.hide();
                    return true;
                }

            });
        },
        replace: true
    }
});