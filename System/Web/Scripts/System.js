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
        var js = document.createElement("script");
        js.type = "text/javascript";
        js.src = "Scripts/Login.js";
        document.body.appendChild(js);
    },
    postData: function (data, url, success, fail) {
        $.ajax({
            type: 'POST',
            url: url,
            data: data,
            success: function (response) {
                success(response);
            },
            error: function (response) {
                fail(response);
            }
        });
        return false;
    }
};

$(document).ready(function () {
    System.init();
});