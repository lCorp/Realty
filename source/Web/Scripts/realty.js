
($(document).ready(function () {
    layout.Init();
}));


function AdvanceSearch(flag) {
    if (flag) {
        $("span._basic").hide();
        $("span._advance").show();
    }
    else
    {
        $("span._basic").show();
        $("span._advance").hide();
    }
}

var layout = {
    Event: function () {

    },

    Init: function () {
        $("div#tabsSearch").tabs();
        $("div#realyNewsTabs").tabs();
    }
}