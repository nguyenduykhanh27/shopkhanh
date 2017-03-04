(function (app) {
    app.controller('pageAddController', pageAddController);

    pageAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function pageAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.page = {
            CreatedDate: new Date(),
            Status: true,
        }

        $scope.AddPage = AddPage;

        $scope.GetSeoTitle = GetSeoTitle;

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        function GetSeoTitle() {
            $scope.page.Alias = commonService.getSeoTitle($scope.page.Name);
        }

        function AddPage() {
            apiService.post('api/page/create', $scope.page,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('page');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }
       
    }

})(angular.module('tedushop.page'));