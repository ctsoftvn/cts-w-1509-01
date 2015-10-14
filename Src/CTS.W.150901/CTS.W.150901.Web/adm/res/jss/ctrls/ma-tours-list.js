// MAToursEntryCtrl
ctrls.controller('MAToursListCtrl', ['$scope', '$state', '$stateParams', '$window', function ($scope, $state, $stateParams, $window) {
    /* Định nghĩa biến toàn cục */
    $scope.data = {};
    $scope.variable = {};
    $scope.tblResult = {};
    // Gán giá trị init
    $scope.data.HasAuth = false;
    $scope.variable.ShowSearchPane = true;
    $scope.tblResult.Page = 1;
    $scope.tblResult.Options = $optionHelper.gridBase({ width: 880 });
    /* Định nghĩa phương thức xử lý */
    // Xử lý init
    $scope.init = function () {
        $pc({
            action: 'InitLayout',
            url: '/adm/hdl/ma/tours/list.ashx',
            success: function (data) {
                // Ẩn/Hiện cửa sổ chính
                $scope.$parent.showViewMain(true);
                // Gán đối tượng dữ liệu 
                $scope.data = data;
                $scope.data.TourTypeCd = data.CboTourTypesSeleted;
                $scope.data.LocaleCd = data.CboLocalesSeleted;
                $scope.data.DeleteFlag = data.CboDeleteFlagSeleted;
                // Gán dữ liệu table
                $scope.tblResult.Limit = data.Limit;
                // Xử lý filter dữ liệu
                $scope.search();
                // Áp dụng trình tự di chuyển tab
                $ti('txtTourName');
            }
        });
    };
    // Xử lý filter
    $scope.filter = function () {
        $pc({
            action: 'Filter',
            url: '/adm/hdl/ma/tours/list.ashx',
            data: function () {
                // Lấy dữ liệu pager
                var data = $gridHelper.getPagerData($scope.tblResult);
                // Gán dữ liệu tìm kiếm
                data.LocaleCd = $scope.data.HdnLocaleCd;
                data.TourName = $scope.data.HdnTourName;
                data.Slug = $scope.data.HdnSlug;
                data.TourTypeCd = $scope.data.HdnTourTypeCd;
                data.DeleteFlag = $scope.data.HdnDeleteFlag;
                // Kết quả trả về
                return data;
            },
            success: function (data) {
                $scope.tblResult.Total = data.Total;
                $scope.tblResult.ListData = data.ListData;
            }
        });
    };
    // Xử lý lưu thông tin cập nhật
    $scope.saveBatch = function () {
        $pc({
            action: 'SaveBatch',
            url: '/adm/hdl/ma/tours/list.ashx',
            data: function () {
                // Khởi tạo biến cục bộ
                var fnObjData = function (obj) {
                    return {
                        LocaleCd: obj.LocaleCd,
                        TourCd: obj.TourCd,
                        TourName: obj.TourName,
                        SearchName: obj.SearchName,
                        Slug: obj.Slug,
                        TourTypeCd: obj.TourTypeCd,
                        Notes: obj.Notes,
                        MetaTitle: obj.MetaTitle,
                        MetaDesc: obj.MetaDesc,
                        MetaKeys: obj.MetaKeys,
                        SortKey: obj.SortKey,
                        DeleteFlag: obj.DeleteFlag
                    };
                }
                // Kết quả trả về
                return $gridHelper.getListData($scope.tblResult, fnObjData);
            },
            success: function (data) {
                $scope.filter();
            }
        });
    };
    // Xử lý thêm
    $scope.add = function () {
        var fnYes = function () {
            $pc(function () {
                var params = {
                    Status: 'add',
                    CallType: 'init'
                };
                $state.go('master-tours-list-entry', params);
            });
        };
        if ($gridHelper.hasDataChanged($scope.tblResult)) {
            $dialogHelper.showDialogConfirm($ms('I.MSG.00002'), fnYes);
        } else {
            fnYes();
        }
    };
    // Ẩn/Hiện panel tìm kiếm
    $scope.showHideSearchPanel = function () {
        $pc(function () {
            $scope.variable.ShowSearchPane = !$scope.variable.ShowSearchPane;
        });
    };
    // Xử lý thay đổi data
    $scope.tblResultChange = function (data, obj) {
        $pc(function () {
            obj.HasChanged = true;
        });
    };
    // Xử lý thay đổi tên
    $scope.blurTourName = function (obj) {
        $pc(function () {
            obj.SearchName = $dataHelper.toSearchName(obj.TourName);
        });
    };
    // Xử lý tìm kiếm
    $scope.search = function () {
        var fnYes = function () {
            $pc(function () {
                $scope.data.HdnLocaleCd = $scope.data.LocaleCd;
                $scope.data.HdnTourName = $scope.data.TourName;
                $scope.data.HdnSlug = $scope.data.Slug;
                $scope.data.HdnTourTypeCd = $scope.data.TourTypeCd;
                $scope.data.HdnDeleteFlag = $scope.data.DeleteFlag;
                $scope.filter();
            });
        };
        if ($gridHelper.hasDataChanged($scope.tblResult)) {
            $dialogHelper.showDialogConfirm($ms('I.MSG.00002'), fnYes);
        } else {
            fnYes();
        }
    };
    // Xử lý cập nhật
    $scope.edit = function (obj) {
        $pc(function () {
            var params = {
                Status: 'edit',
                CallType: 'init',
                TourCd: obj.TourCd
            };
            $state.go('master-tours-list-entry', params);
        });
    };
    // Xử lý sao chép
    $scope.copy = function (obj) {
        $pc(function () {
            var params = {
                Status: 'add',
                CallType: 'copy',
                TourCd: obj.TourCd
            };
            $state.go('master-tours-list-entry', params);
        });
    };
    // Hiển thị dialog editor
    $scope.editNotes = function (obj) {
        $pc(function () {
            obj.HasChanged = true;
            var modalInstance = $dialogHelper.showDialogEditor({
                Content: obj.Notes
            });
            // Lấy kết quả xử lý
            modalInstance.result.then(function (result) {
                obj.Notes = result.data;
            });
        });
    };
    // Hiển thị dialog seo
    $scope.editMetaInfo = function (obj) {
        $pc(function () {
            obj.HasChanged = true;
            var modalInstance = $dialogHelper.showDialogMeta({
                MetaTitle: obj.MetaTitle,
                MetaDesc: obj.MetaDesc,
                MetaKeys: obj.MetaKeys
            });
            // Lấy kết quả xử lý
            modalInstance.result.then(function (result) {
                obj.MetaTitle = result.data.MetaTitle;
                obj.MetaDesc = result.data.MetaDesc;
                obj.MetaKeys = result.data.MetaKeys;
            });
        });
    };
    /* Định nghĩa các events */
    // Ẩn/Hiện cửa sổ chính
    $scope.$parent.showViewMain(false);
    // Tiến hành xử lý init
    $scope.init();
    /* Đăng ký các events */
} ]);