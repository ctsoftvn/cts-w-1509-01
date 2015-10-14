// MAPagesEntryCtrl
ctrls.controller('MAPagesListCtrl', ['$scope', '$state', '$stateParams', '$window', function ($scope, $state, $stateParams, $window) {
    /* Định nghĩa biến toàn cục */
    $scope.data = {};
    $scope.variable = {};
    $scope.tblResult = {};
    // Gán giá trị init
    $scope.data.HasAuth = false;
    $scope.variable.ShowSearchPane = true;
    $scope.tblResult.Page = 1;
    $scope.tblResult.Options = $optionHelper.gridBase({ width: 790 });
    /* Định nghĩa phương thức xử lý */
    // Xử lý init
    $scope.init = function () {
        $pc({
            action: 'InitLayout',
            url: '/adm/hdl/ma/pages/list.ashx',
            success: function (data) {
                // Ẩn/Hiện cửa sổ chính
                $scope.$parent.showViewMain(true);
                // Gán đối tượng dữ liệu 
                $scope.data = data;
                // Gán dữ liệu table
                $scope.tblResult.Limit = data.Limit;
                // Xử lý filter dữ liệu
                $scope.search();
            }
        });
    };
    // Xử lý filter
    $scope.filter = function () {
        $pc({
            action: 'Filter',
            url: '/adm/hdl/ma/pages/list.ashx',
            data: function () {
                // Lấy dữ liệu pager
                var data = $gridHelper.getPagerData($scope.tblResult);
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
            url: '/adm/hdl/ma/pages/list.ashx',
            data: function () {
                // Khởi tạo biến cục bộ
                var fnObjData = function (obj) {
                    return {
                        LocaleCd: obj.LocaleCd,
                        PageCd: obj.PageCd,
                        PageName: obj.PageName,
                        SearchName: obj.SearchName,
                        // Slug: obj.Slug,
                        Content: obj.Content,
                        MetaTitle: obj.MetaTitle,
                        MetaDesc: obj.MetaDesc,
                        MetaKeys: obj.MetaKeys
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
    // Xử lý thay đổi data
    $scope.tblResultChange = function (data, obj) {
        $pc(function () {
            obj.HasChanged = true;
        });
    };
    // Xử lý thay đổi tên
    $scope.blurPageName = function (obj) {
        $pc(function () {
            obj.SearchName = $dataHelper.toSearchName(obj.PageName);
        });
    };
    // Xử lý tìm kiếm
    $scope.search = function () {
        var fnYes = function () {
            $pc(function () {
                $scope.filter();
            });
        };
        if ($gridHelper.hasDataChanged($scope.tblResult)) {
            $dialogHelper.showDialogConfirm($ms('I.MSG.00002'), fnYes);
        } else {
            fnYes();
        }
    };
    // Hiển thị dialog editor
    $scope.editContent = function (obj) {
        $pc(function () {
            obj.HasChanged = true;
            var modalInstance = $dialogHelper.showDialogEditor({
                Content: obj.Content
            });
            // Lấy kết quả xử lý
            modalInstance.result.then(function (result) {
                obj.Content = result.data;
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