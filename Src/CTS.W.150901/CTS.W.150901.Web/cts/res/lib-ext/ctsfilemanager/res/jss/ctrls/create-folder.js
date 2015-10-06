// CreateFolderCtrl
ctrls.controller('CreateFolderCtrl', ['$scope', '$modalStack', '$modalInstance', 'param', function ($scope, $modalStack, $modalInstance, param) {
    /* Định nghĩa biến toàn cục */
    $scope.data = {};
    // Gán giá trị init
    /* Định nghĩa phương thức xử lý */
    // Xử lý init
    $scope.init = function () {
    };
    // Xử lý create folder
    $scope.createFolder = function () {
        $pc({
            action: 'Folder.Make',
            url: '/cts/web/file-manager.ashx',
            data: {
                Path: param.Path,
                FolderName: $scope.data.Name
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
} ]);