Namespace.register('System.Grid');

System.Grid = (function () {
    var defaultParams = {
    };

    var init = function (gridId, params) {
        params = $.extend({}, defaultParams, params);

        var grid = $('#' + gridId);
        if (grid == null || grid.length == 0) {
            return;
        }

        grid.parent().find('span.option').on('click', function () {
            window.location = $(this).data('url');
        });
    };

    var publicObject = {};
    publicObject.init = init;
    return publicObject;
})();