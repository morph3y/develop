function registerNamespace(ns) {
    var arr = ns.split(".");
    var parentNS = "";
    for (var i = 0; i < arr.length; i++) {
        var newNS = parentNS + arr[i];
        if (i == 0) window[newNS] = window[newNS] || {};
        if (i != 0) eval(newNS + " = " + newNS + " || {};");
        parentNS += arr[i] + ".";
    }
}

registerNamespace("System");

System = {
    init: function () {

    },
    postData: function (data, url, success, fail) {
        $.ajax({
            type: 'POST',
            url: url,
            data: data,
            success: function (response) {
                if (success != null) {
                    success(response);
                }
            },
            error: function (response) {
                if (fail != null) {
                    fail(response);
                }
            }
        });
        return false;
    },
    bindAjaxLoader: function (jQueryElement) {
        var w = jQueryElement.width();
        var h = jQueryElement.height();
        var style = "width:" + w + "px; height:" + h + "px;";
        jQueryElement.append("<div class=\"overlay\" style='" + style + "'></div><img src='../Content/Images/Web.Grid/ajax-loader.gif' style=top:" + (h - 10) / 2 + "px;bottom:0px;left:" + (w - 10) / 2 + "px;right:0px;' class='overlay-img' />");
    },
    hideAjaxLoader: function () {
        $(".overlay").remove();
        $(".overlay-img").remove();
    }
};

$(document).ready(function () {
    System.init();
});