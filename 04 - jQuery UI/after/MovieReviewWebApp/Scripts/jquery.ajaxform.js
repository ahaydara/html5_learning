/// <reference path="jquery-1.8.2.js" />

(function ($) {
    $.fn.ajaxForm = function (resultSelector) {
        this.submit(function () {
            var me = $(this);
            if (me.valid()) {
                var url = me.attr("action");
                var data = me.serialize();
                $.post(url, data, function (html) {
                    $(resultSelector).html(html);
                }, "html");
            }
            return false;
        });
        return this;
    };
})(jQuery);