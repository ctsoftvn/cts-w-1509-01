// MainCtrl
ctrls.controller('MainCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
    /* Định nghĩa biến toàn cục */
    $scope.data = {};
    $scope.cmnItems = {};
    $scope.params = $location.search();
    // Gán giá trị init
    $scope.rootPath = rootPathInfos[$scope.params.type];
    $scope.currPath = $scope.rootPath;
    $scope.cmnItems.Options = [
        [$nm('CTS.PLUGIN.FILEMANAGER.MAIN.SeleteItem'), function ($itemScope) {
            $scope.selectItem($itemScope.obj);
        } ],
        null, // Dividier
        [$nm('CTS.PLUGIN.FILEMANAGER.MAIN.RenameItem'), function ($itemScope) {
            $scope.renameItem($itemScope.obj);
        } ],
        [$nm('CTS.PLUGIN.FILEMANAGER.MAIN.RemoveItem'), function ($itemScope) {
            $scope.removeItem($itemScope.obj);
        } ]
    ];
    /* Định nghĩa phương thức xử lý */
    // Xử lý init
    $scope.init = function () {
        $pc(function () {
            $scope.filter();
        });
    };
    // Xử lý filter
    $scope.filter = function () {
        $pc({
            action: 'Item.Filter',
            url: '/cts/web/file-manager.ashx',
            data: {
                Type: $scope.params.type,
                Path: $scope.currPath
            },
            success: function (data) {
                $scope.data.ListFiles = data.ListItems;
                $scope.loadPaths();
            }
        });
    };
    // Xử lý chọn items
    $scope.selectItem = function (obj) {
        $pc(function () {
            if (obj.Type !== 'folder') {
                var url = $pageHelper.encodeURL(obj.Path);
                parent.tinymce.activeEditor.windowManager.getParams().setUrl(url);
                parent.tinymce.activeEditor.windowManager.close();
            } else {
                $scope.currPath = obj.Path;
                $scope.filter();
            }
        });
    };
    // Xử lý upload file
    $scope.uploadFile = function () {
        var modalInstance = $dialogHelper.showDialog({
            templateUrl: 'vws/upload-file.html',
            controller: 'UploadFileCtrl',
            param: { Path: $scope.currPath, Type: $scope.params.type }
        });
        // Lấy kết quả xử lý
        modalInstance.result.then(function (result) {
            $scope.filter();
        });
    };
    // Xử lý tạo folder
    $scope.createFolder = function () {
        var modalInstance = $dialogHelper.showDialog({
            templateUrl: 'vws/create-folder.html',
            controller: 'CreateFolderCtrl',
            param: { Path: $scope.currPath }
        });
        // Lấy kết quả xử lý
        modalInstance.result.then(function (result) {
            $scope.filter();
        });
    };
    // Xử lý sửa tên item
    $scope.renameItem = function (obj) {
        var modalInstance = $dialogHelper.showDialog({
            templateUrl: 'vws/rename-item.html',
            controller: 'RenameItemCtrl',
            param: { Path: $scope.currPath, Item: obj }
        });
        // Lấy kết quả xử lý
        modalInstance.result.then(function (result) {
            $scope.filter();
        });
    };
    // Xử lý xóa item
    $scope.removeItem = function (obj) {
        var modalInstance = $dialogHelper.showDialog({
            templateUrl: 'vws/remove-item.html',
            controller: 'RemoveItemCtrl',
            param: { Path: $scope.currPath, Item: obj }
        });
        // Lấy kết quả xử lý
        modalInstance.result.then(function (result) {
            $scope.filter();
        });
    };
    // Xử lý load đường dẫn
    $scope.loadPaths = function () {
        var listPaths = [];
        var rootPath = $scope.rootPath;
        var currPath = $scope.currPath;
        var strPath = $dataHelper.leftTrim(currPath, rootPath);
        strPath = $dataHelper.trim(strPath, '/');
        listPaths.push($scope.getRootItem());
        var arrPath = [];
        if (strPath.length !== 0) {
            arrPath = strPath.split('/');
        }
        var name = '';
        var path = rootPath;
        for (var idx in arrPath) {
            name = arrPath[idx];
            path = path + '/' + name;
            listPaths.push({
                Name: name,
                Type: 'folder',
                Path: path
            });
        }
        $scope.data.ListPaths = listPaths;
    };
    // Lấy root item
    $scope.getRootItem = function () {
        return {
            Name: '',
            Type: 'folder',
            Path: $scope.rootPath,
            Icon: 'glyphicon glyphicon-home'
        };
    };
    /* Định nghĩa các events */
    // Tiến hành xử lý init
    $scope.init();
    /* Đăng ký các events */
    angular.element(document).bind('ready', function () {
        $('#listFiles').height($(window).height() - 150);
    });
} ]);