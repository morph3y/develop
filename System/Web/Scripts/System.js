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
    }
};

$(document).ready(function () {
    System.init();
});