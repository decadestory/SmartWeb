(function ($) {
    $.fn.go = function (callback, attach) {
        var objs = {};
        var destUrl = $(this).attr("action");
        var retVal;
        if (typeof (attach) != "undefined") objs = attach;
        $(this).find("*[name]").each(function () {
            objs[$(this).attr("name")] = $(this).val();
        });
        $.ajax({ url: destUrl, type: "post", data: objs, async: false, success: function (d) { retVal = d; } });
        if (callback) { callback(retVal); }
    };
})(jQuery);