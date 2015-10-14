// LoginCtrl
ctrls.controller('LoginCtrl', ['$scope', '$state', '$window', function ($scope, $state, $window) {
    /* Định nghĩa biến toàn cục */
    $scope.data = {};
    // Gán giá trị init
    /* Định nghĩa phương thức xử lý */
    // Xử lý init
    $scope.init = function () {
        $pc({
            app: 'adm',
            action: 'Login.InitLayout',
            url: '/cts/web/users',
            success: function (data) {
                $scope.data = data;
                $scope.data.Remember = $dataHelper.toBoolean(data.Remember);
                if ($scope.data.Remember) {
                    $scope.auth();
                }
                $ti('txtUser');
            }
        });
    };
    // Xử lý xác thực
    $scope.auth = function () {
        $pc({
            app: 'adm',
            action: 'Login.Auth',
            url: '/cts/web/users',
            validate: '/adm/res/jss/ctrls/login_auth.json',
            data: {
                UserName: $scope.data.UserName,
                Password: $scope.data.Password,
                Remember: $scope.data.Remember
            },
            success: function (data) {
                $window.open('/administer/main', '_self');
            }
        });
    };
    /* Định nghĩa các events */
    // Tiến hành xử lý init
    $scope.init();
} ]);