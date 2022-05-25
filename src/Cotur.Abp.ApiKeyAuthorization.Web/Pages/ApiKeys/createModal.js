var abp = abp || {};

abp.modals.apiKeyCreateModal = function () {
    var initModal = function (publicApi, args) {

        $('input.datepicker').datepicker({
            todayBtn: "linked",
            autoclose: true,
            language: abp.localization.currentCulture.cultureName
        }).on('hide', function (e) { e.stopPropagation(); });
    };

    return {
        initModal: initModal
    };
};