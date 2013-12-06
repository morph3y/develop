var Namespace =
{
    register: function (name) {
        var chk = false;
        var cob = "";
        var spc = name.split(".");
        for (var i = 0; i < spc.length; i++) {
            if (cob != "") { cob += "."; }
            cob += spc[i];
            chk = this.exists(cob);
            if (!chk) { this.create(cob); }
        }
        if (chk) { throw "Namespace: " + name + " is already defined."; }
    },

    create: function (src) {
        eval("window." + src + " = new Object();");
    },

    exists: function (src) {
        var toReturn = false;
        eval("try{if(" + src + "){toReturn = true;}else{toReturn = false;}}catch(err){toReturn=false;}");
        return toReturn;
    }
};

Namespace.register('System');

System = {
    init: function () {
        // initialize events
        this.initEvents();
    },
    initEvents: function () {
        
    }
};
