// Cấu hình routeProvider
app.config(function ($stateProvider, $urlRouterProvider) {
    // Master|RoomTypes|List
    $stateProvider.state('master-room-types-list', {
        url: "/administer/ma/room-types/list",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/room-types/list.html",
                controller: "MARoomTypesListCtrl"
            }
        }
    });
    // Master|RoomTypes|Entry
    $stateProvider.state('master-room-types-entry', {
        url: "/administer/ma/room-types/entry",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/room-types/entry.html",
                controller: "MARoomTypesEntryCtrl"
            }
        }
    });
    $stateProvider.state('master-room-types-list-entry', {
        url: "/administer/ma/room-types/entry/{Status}/{CallType}/{TypeCd}",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/room-types/entry.html",
                controller: "MARoomTypesEntryCtrl"
            }
        }
    });
    // Master|TourTypes|List
    $stateProvider.state('master-tour-types-list', {
        url: "/administer/ma/tour-types/list",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/tour-types/list.html",
                controller: "MATourTypesListCtrl"
            }
        }
    });
    // Master|TourTypes|Entry
    $stateProvider.state('master-tour-types-entry', {
        url: "/administer/ma/tour-types/entry",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/tour-types/entry.html",
                controller: "MATourTypesEntryCtrl"
            }
        }
    });
    $stateProvider.state('master-tour-types-list-entry', {
        url: "/administer/ma/tour-types/entry/{Status}/{CallType}/{TypeCd}",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/tour-types/entry.html",
                controller: "MATourTypesEntryCtrl"
            }
        }
    });
    // Master|Tours|List
    $stateProvider.state('master-tours-list', {
        url: "/administer/ma/tours/list",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/tours/list.html",
                controller: "MAToursListCtrl"
            }
        }
    });
    // Master|Tours|Entry
    $stateProvider.state('master-tours-entry', {
        url: "/administer/ma/tours/entry",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/tours/entry.html",
                controller: "MAToursEntryCtrl"
            }
        }
    });
    $stateProvider.state('master-tours-list-entry', {
        url: "/administer/ma/tours/entry/{Status}/{CallType}/{TourCd}",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/tours/entry.html",
                controller: "MAToursEntryCtrl"
            }
        }
    });
    // Master|Accoms|List
    $stateProvider.state('master-accoms-list', {
        url: "/administer/ma/accoms/list",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/accoms/list.html",
                controller: "MAAccomsListCtrl"
            }
        }
    });
    // Master|Accoms|Entry
    $stateProvider.state('master-accoms-entry', {
        url: "/administer/ma/accoms/entry",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/accoms/entry.html",
                controller: "MAAccomsEntryCtrl"
            }
        }
    });
    $stateProvider.state('master-accoms-list-entry', {
        url: "/administer/ma/accoms/entry/{Status}/{CallType}/{AccomCd}",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/accoms/entry.html",
                controller: "MAAccomsEntryCtrl"
            }
        }
    });
    // Master|Services|List
    $stateProvider.state('master-services-list', {
        url: "/administer/ma/services/list",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/services/list.html",
                controller: "MAServicesListCtrl"
            }
        }
    });
    // Master|Services|Entry
    $stateProvider.state('master-services-entry', {
        url: "/administer/ma/services/entry",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/services/entry.html",
                controller: "MAServicesEntryCtrl"
            }
        }
    });
    $stateProvider.state('master-services-list-entry', {
        url: "/administer/ma/services/entry/{Status}/{CallType}/{ServiceCd}",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/services/entry.html",
                controller: "MAServicesEntryCtrl"
            }
        }
    });
    // Master|Banners|List
    $stateProvider.state('master-banners-list', {
        url: "/administer/ma/banners/list",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/banners/list.html",
                controller: "MABannersListCtrl"
            }
        }
    });
    // Master|Banners|Entry
    $stateProvider.state('master-banners-entry', {
        url: "/administer/ma/banners/entry",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/banners/entry.html",
                controller: "MABannersEntryCtrl"
            }
        }
    });
    $stateProvider.state('master-banners-list-entry', {
        url: "/administer/ma/banners/entry/{Status}/{CallType}/{BannerCd}",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/banners/entry.html",
                controller: "MABannersEntryCtrl"
            }
        }
    });
    // Master|Photos|List
    $stateProvider.state('master-photos-list', {
        url: "/administer/ma/photos/list",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/photos/list.html",
                controller: "MAPhotosListCtrl"
            }
        }
    });
    // Master|Photos|Entry
    $stateProvider.state('master-photos-entry', {
        url: "/administer/ma/photos/entry",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/photos/entry.html",
                controller: "MAPhotosEntryCtrl"
            }
        }
    });
    $stateProvider.state('master-photos-list-entry', {
        url: "/administer/ma/photos/entry/{Status}/{CallType}/{PhotoCd}",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/photos/entry.html",
                controller: "MAPhotosEntryCtrl"
            }
        }
    });
    // Users|Account
    $stateProvider.state('users-account', {
        url: "/administer/users/account",
        views: {
            main: {
                templateUrl: "/cts/adm/html/ucs/view-change-password.html",
                controller: "ViewChangePasswordCtrl"
            }
        }
    });
    // Settings|Info
    $stateProvider.state('setting-info', {
        url: "/administer/setting/info",
        views: {
            main: {
                templateUrl: "/cts/adm/html/ucs/view-company-infos.html",
                controller: "ViewCompanyInfosCtrl"
            }
        }
    });
    // Settings|System
    $stateProvider.state('setting-system', {
        url: "/administer/setting/system",
        views: {
            main: {
                templateUrl: "/cts/adm/html/ucs/view-parameters.html",
                controller: "ViewParametersCtrl"
            }
        }
    });
    // Settings|Pages
    $stateProvider.state('setting-pages', {
        url: "/administer/setting/pages",
        views: {
            main: {
                templateUrl: "/adm/vws/ma/pages/list.html",
                controller: "MAPagesListCtrl"
            }
        }
    });
});