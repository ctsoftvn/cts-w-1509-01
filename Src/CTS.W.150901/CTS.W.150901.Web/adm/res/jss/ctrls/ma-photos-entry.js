// MAPhotosEntryCtrl
ctrls.controller('MAPhotosEntryCtrl', ['$scope', '$state', '$stateParams', '$window', function ($scope, $state, $stateParams, $window) {
    /* Định nghĩa biến toàn cục */
    $scope.data = {};
    $scope.variable = {};
    $scope.objEntry = {};
    $scope.objLocale = {};
    $scope.edtNotes = {};
    // Gán giá trị init
    $scope.data.HasAuth = false;
    $scope.variable.ShowLinkBack = $state.is('master-photos-list-entry');
    $scope.variable.BasicInfo = $dataHelper.toBasicInfo($stateParams);
    $scope.objEntry.tblResultOptions = $optionHelper.gridBase({ width: 300 });
    $scope.edtNotes.options = $optionHelper.editorBase();
    /* Định nghĩa phương thức xử lý */
    // Xử lý init
    $scope.init = function () {
        $pc({
            action: 'InitLayout',
            url: '/adm/hdl/ma/photos/entry.ashx',
            data: {
                Status: $scope.variable.BasicInfo.Status,
                CallType: $scope.variable.BasicInfo.CallType,
                PhotoCd: $stateParams.PhotoCd
            },
            success: function (data) {
                // Ẩn/Hiện cửa sổ chính
                $scope.$parent.showViewMain(true);
                // Gán dữ liệu xử lý
                $scope.data = data;
                $scope.objEntry.DataInfo = data.LocaleModel.DataInfo;
                $scope.objEntry.ListLocale = data.LocaleModel.ListLocale;
                $scope.objLocale.LocaleCd = $scope.data.CboLocalesSeleted;
                // Trường hợp kết quả trả về không phải mảng
                if (!$.isArray($scope.objEntry.ListLocale)) {
                    $scope.objEntry.ListLocale = [];
                }
                // Xử lý select thông tin dòng đầu tiên
                $scope.selectRow($scope.objLocale.LocaleCd);
                // Xử lý focus
                $ti('txtPhotoName');
            }
        });
    };
    // Xử lý save
    $scope.save = function () {
        $pc({
            action: 'Save',
            url: '/adm/hdl/ma/photos/entry.ashx',
            data: {
                Status: $scope.variable.BasicInfo.Status,
                CallType: $scope.variable.BasicInfo.CallType,
                LocaleModel: {
                    DataInfo: $scope.objEntry.DataInfo,
                    ListLocale: $scope.objEntry.ListLocale
                }
            },
            success: function (data) {
                if ($scope.variable.BasicInfo.IsEdit) {
                    $scope.back();
                } else {
                    var fnYes = function () {
                        $scope.init();
                    };
                    var fnNo = function () {
                        $scope.back();
                    };
                    $dialogHelper.showDialogConfirm($ms('I.MSG.00003'), fnYes, fnNo);
                }
            }
        });
    };
    // Xử lý back
    $scope.back = function () {
        $pc(function () {
            $state.go('master-photos-list');
        });
    };
    // Tạo mới mã
    $scope.genCd = function () {
        $pc({
            action: 'GenCd',
            url: '/adm/hdl/ma/photos/entry.ashx',
            data: {
                Status: $scope.variable.BasicInfo.Status,
                CallType: $scope.variable.BasicInfo.CallType
            },
            success: function (data) {
                if ($scope.variable.BasicInfo.IsAdd && data.PhotoCd) {
                    $scope.objEntry.DataInfo.PhotoCd = data.PhotoCd;
                }
            }
        });
    };
    // Xử lý tải lên hình ảnh
    $scope.uploadImage = function (obj) {
        $pc(function () {
            var modalInstance = $dialogHelper.showDialogUpload({
                LocaleCd: obj.LocaleCd,
                FileCd: obj.FileCd,
                HasGen: obj.HasGen,
                FileGroupCd: 'stg.ma.photos.file-cd'
            });
            // Lấy kết quả xử lý
            modalInstance.result.then(function (result) {
                obj.FileCd = result.data;
                obj.HasGen = result.hasGen;
            });
        });
    };
    // Xử lý cố định dòng
    $scope.fixRow = function () {
        $pc(function () {
            // Khởi tạo biến cục bộ
            var obj = $scope.objLocale;
            // Trường hợp là ngôn ngữ chuẩn
            if ($scope.data.BasicLocale === obj.LocaleCd) {
                $dialogHelper.showDialogError($resourceHelper.getMessage('E.MSG.00004', 'ADM.MA.PHOTOS.ENTRY.LocaleCd'));
                return;
            }
            // Lấy số dòng hợp lệ
            obj.RowNo = $gridHelper.genRowNo(obj.RowNo, $scope.objEntry.ListLocale);
            // Lấy chỉ số dòng trong mảng
            var rowIdx = $dataHelper.getRowIndex(obj.LocaleCd, $scope.objEntry.ListLocale, 'LocaleCd');
            if (rowIdx === -1) {
                // Thêm dữ liệu vào danh sách
                $scope.objEntry.ListLocale.push(obj);
            } else {
                // Cập nhật dữ liệu vào danh sách
                $scope.objEntry.ListLocale[rowIdx] = obj;
            }
            // Xử lý select thông tin dòng
            $scope.selectRow(obj.LocaleCd);
        });
    };
    // Xử lý clear thông tin dòng
    $scope.clearRow = function () {
        $pc(function () {
            $scope.objLocale.RowNo = '';
            $scope.objLocale.PhotoName = '';
            $scope.objLocale.SearchName = '';
            $scope.objLocale.Notes = '';
        });
    };
    // Xử lý select thông tin dòng
    $scope.selectRow = function (localeCd) {
        $pc(function () {
            // Lấy chỉ số dòng trong mảng
            var rowIdx = $dataHelper.getRowIndex(localeCd, $scope.objEntry.ListLocale, 'LocaleCd');
            // Trường hợp không tồn tại dòng
            if (rowIdx === -1) {
                // Xử lý clear thông tin dòng
                $scope.clearRow();
            } else {
                // Khởi tạo biến cục bộ
                var tmp = {};
                var obj = $scope.objEntry.ListLocale[rowIdx];
                // Gán dữ liệu vào đối tượng
                angular.copy(obj, tmp);
                $scope.objLocale = tmp;
            }
        });
    };
    // Xử lý copy thông tin chính
    $scope.copyInfo = function () {
        var fnYes = function () {
            $pc(function () {
                $scope.objLocale.PhotoName = $scope.objEntry.DataInfo.PhotoName;
                $scope.objLocale.SearchName = $scope.genSearchName($scope.objLocale);
                $scope.objLocale.Notes = $scope.objEntry.DataInfo.Notes;
            });
        };
        $dialogHelper.showDialogConfirm($ms('I.MSG.00002'), fnYes);
    };
    // Xử lý thay đổi tên
    $scope.blurPhotoName = function (data, obj) {
        $pc(function () {
            $scope.genSearchName(obj);
        });
    };
    // Xử lý thay đổi ngôn ngữ
    $scope.changedLocaleCd = function (data) {
        $pc(function () {
            // Lấy thông tin dữ liệu
            var rowData = $dataHelper.getRowData(data, $scope.data.CboLocales, 'Code');
            $scope.objLocale.LocaleName = rowData.Name;
            // Xử lý select thông tin dòng
            $scope.selectRow(rowData.Code);
        });
    };
    // Tạo tự động tên tìm kiếm
    $scope.genSearchName = function (obj) {
        obj.SearchName = $dataHelper.toSearchName(obj.PhotoName);
    };
    /* Định nghĩa các events */
    // Ẩn/Hiện cửa sổ chính
    $scope.$parent.showViewMain(false);
    // Tiến hành xử lý init
    $scope.init();
    /* Đăng ký các events */
    // $watch('objLocale.LocaleCd')
    $scope.$watch('objLocale.LocaleCd', function (newValue, oldValue) {
        if (newValue) {
            $scope.changedLocaleCd(newValue);
        }
    });
} ]);