// Cấu hình routeProvider
app.config(function ($stateProvider, $urlRouterProvider) {
    // Settings|Info
    $stateProvider.state('setting-info', {
        url: "/adm/settings/info",
        views: {
            main: {
                templateUrl: "/cts/adm/html/ucs/view-company-infos.html",
                controller: "ViewCompanyInfosCtrl"
            }
        }
    });
    // Settings|System
    $stateProvider.state('setting-system', {
        url: "/adm/settings/system",
        views: {
            main: {
                templateUrl: "/cts/adm/html/ucs/view-parameters.html",
                controller: "ViewParametersCtrl"
            }
        }
    });
});