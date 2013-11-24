Namespace.register('System.Dialog');

System.Dialog = {
    init: function (container, params) {
        container.dialog({
            autoOpen: params.autoOpen == null ? false : params.autoOpen,
            height: params.height == null ? 350 : params.height,
            width: params.width == null ? 500 : params.width,
            modal: params.isModal == null ? false : params.IsModal,
            buttons: params.buttons == null ? { "Ok": function () { } } : params.buttons(container),
            close: params.close == null ? function() {} : params.close
        });
    }
};