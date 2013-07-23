registerNamespace("System.Grid");

System.Grid = {
    init: function (id) {
        System.Grid.id = id;
        System.Grid.grid = $("#" + System.Grid.id + "-grid");
        System.Grid.grid.find("#grid-next").on("click", function (e) {
            e.preventDefault();
            if (System.Grid.count() == System.Grid.getPageSize()) {
            var url = $(this).attr("href");
            System.Grid.switchPage(url);
            }
        });
        System.Grid.grid.find("#grid-prev").on("click", function (e) {
            e.preventDefault();
            if (System.Grid.getCurrentPage() != 0) {
                var url = $(this).attr("href");
                System.Grid.switchPage(url);
            }
        });
    },
    switchPage: function (url) {
        var successMethod = function (response) {
            System.Grid.bindData(response);
            System.hideAjaxLoader();
        };

        var failMethod = function (response) {
            System.hideAjaxLoader();
        };
        System.bindAjaxLoader(System.Grid.grid);
        System.postData({}, url, successMethod, failMethod);
    },
    getCurrentPage: function () {
        return System.Grid.grid.data('currentpage');
    },
    getPageSize: function () {
        return System.Grid.grid.data('pagesize');
    },
    count: function () {
        return System.Grid.grid.find('tbody > tr').length;
    },
    bindData: function (data) {
        if (data != undefined && data != null) {
            var test = $(data).filter(function () {
                return $(this).is('div.grid-container');
            }).html();
            var container = System.Grid.grid.closest("div.grid-container");
            container.html('');
            container.html(test);
            System.Grid.init(System.Grid.id);
        }
    }
};
