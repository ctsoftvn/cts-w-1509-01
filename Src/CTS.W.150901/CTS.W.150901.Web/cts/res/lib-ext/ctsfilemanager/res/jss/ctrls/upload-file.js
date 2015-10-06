// UploadFileCtrl
ctrls.controller('UploadFileCtrl', ['$scope', '$modalStack', '$modalInstance', 'param', function ($scope, $modalStack, $modalInstance, param) {
    /* Định nghĩa biến toàn cục */
    $scope.data = {};
    // Gán giá trị init
    /* Định nghĩa phương thức xử lý */
    // Xử lý init
    $scope.init = function () {
        $pc(function () {
            $scope.data.FileInfo = {};
        });
    };
    // Xử lý upload file
    $scope.uploadFile = function () {
        $pc({
            action: 'File.Upload',
            url: '/cts/web/file-manager.ashx',
            data: {
                Path: param.Path,
                Type: param.Type,
                FileInfo: {
                    FileStream: $scope.data.FileInfo.FileStream,
                    FileName: $scope.data.FileInfo.FileName,
                    Size: $scope.data.FileInfo.Size,
                    Ext: $scope.data.FileInfo.Ext
                }
            },
            success: function (data) {
                $scope.close();
            }
        });

    };
    // Xử lý close
    $scope.close = function () {
        $pc(function () {
            $modalInstance.close();
        });
    };
    /* Định nghĩa các events */
    // Tiến hành xử lý init
    $scope.init();
    /* Đăng ký các events */
    $scope.$on('modalLoaded', function (le) {
        angular.element('#filUpload').bind('change', function (event) {
            // Khởi tạo biến cục bộ
            var objFile = event.target.files[0];
            var reader = new FileReader();
            // Lấy thông tin file
            var filename = objFile.name;
            var size = objFile.size;
            var ext = '';
            // Lấy phần mở rộng file
            if (/[.]/.exec(filename)) {
                ext = /[^.]+$/.exec(filename);
            }
            // Đăng ký sự kiện load
            reader.onload = function (e) {
                $scope.$apply(function () {
                    $scope.data.FileInfo = {
                        FileStream: e.target.result,
                        FileName: filename,
                        Size: size,
                        Ext: ext.toString()
                    };
                });
            };
            // Tiến hành đọc file
            reader.readAsDataURL(objFile);
        });
    });
} ]);