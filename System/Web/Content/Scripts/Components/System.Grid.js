Namespace.register('System.Grid');

System.Grid = (function () {
    var i, il;

    var defaultParams = {
    };

    var init = function (gridId, params) {
        params = $.extend({}, defaultParams, params);

        var grid = $('#' + gridId);
        if (grid == null || grid.length == 0) {
            return;
        }

        var rows = grid.find('tr:not(.headers)');
        for (i = 0, il = rows.length; i < il; i++) {
            var controls = $(rows[i]).find('td.options');
            var buttons = controls.find('span.option');
            for (var j = 0; j < buttons.length; j++) {
                $(buttons[j]).click(function () {
                    window.location = $(this).data('url');
                });
            }
        };
    };

    var publicObject = {};
    publicObject.init = init;
    return publicObject;
})();