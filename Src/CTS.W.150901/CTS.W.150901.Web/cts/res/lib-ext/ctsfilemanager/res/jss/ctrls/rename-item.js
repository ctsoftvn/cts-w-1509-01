// RenameItemCtrl
ctrls.controller('RenameItemCtrl', ['$scope', '$modalStack', '$modalInstance', 'param', function ($scope, $modalStack, $modalInstance, param) {
    /* Định nghĩa biến toàn cục */
    $scope.data = {};
    $scope.alert = {};
    // Gán giá trị init
    /* Định nghĩa phương thức xử lý */
    // Xử lý init
    $scope.init = function () {
        $pc(function () {
            if (param.Item.Type !== 'folder') {
                $scope.data.Name = $dataHelper.rightTrim(param.Item.Name, param.Item.Ext);
            } else {
                $scope.data.Name = param.Item.Name;
            }
        });
    };
    // Xử lý rename item
    $scope.renameItem = function () {
        $pc({
            action: 'Item.Rename',
            url: '/cts/web/file-manager.ashx',
            data: {
                Path: param.Path,
                Type: param.Item.Type,
                OriginName: param.Item.Name,
                ItemName: $scope.getName()
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
    // Xử lý lấy tên item
    $scope.getName = function () {
        if (param.Item.Type !== 'folder') {
            return $scope.data.Name + param.Item.Ext;
        } else {
            return $scope.data.Name;
        }
    };
    /* Định nghĩa các events */
    // Tiến hành xử lý init
    $scope.init();
    /* Đăng ký các events */
} ]);