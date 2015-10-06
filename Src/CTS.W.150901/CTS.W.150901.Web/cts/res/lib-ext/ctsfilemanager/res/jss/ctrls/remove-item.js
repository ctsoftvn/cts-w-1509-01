// CreateFolderCtrl
ctrls.controller('RemoveItemCtrl', ['$scope', '$modalStack', '$modalInstance', 'param', function ($scope, $modalStack, $modalInstance, param) {
    /* Định nghĩa biến toàn cục */
    $scope.data = {};
    // Gán giá trị init
    /* Định nghĩa phương thức xử lý */
    // Xử lý init
    $scope.init = function () {
    };
    // Xử lý remove item
    $scope.removeItem = function () {
        $pc({
            action: 'Item.Remove',
            url: '/cts/web/file-manager.ashx',
            data: {
                Path: param.Path,
                Type: param.Item.Type,
                ItemName: param.Item.Name
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