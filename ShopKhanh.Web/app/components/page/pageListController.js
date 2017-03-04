(function (app) {
    app.controller('pageListController', pageListController);

    pageListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function pageListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.pageAbout = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getPages = getPages;
        $scope.keyword = '';

        //$scope.search = search;

        //$scope.deleteProductCategory = deleteProductCategory;

        //$scope.selectAll = selectAll;

        //$scope.deleteMultiple = deleteMultiple;

        //function deleteMultiple() {
        //    var listId = [];
        //    $.each($scope.selected, function (i, item) {
        //        listId.push(item.ID);
        //    });
        //    var config = {
        //        params: {
        //            checkedProductCategories: JSON.stringify(listId)
        //        }
        //    }
        //    apiService.del('api/productcategory/deletemulti', config, function (result) {
        //        notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
        //        search();
        //    }, function (error) {
        //        notificationService.displayError('Xóa không thành công');
        //    });
        //}

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.pageAbout, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        //$scope.$watch("productCategories", function (n, o) {
        //    var checked = $filter("filter")(n, { checked: true });
        //    if (checked.length) {
        //        $scope.selected = checked;
        //        $('#btnDelete').removeAttr('disabled');
        //    } else {
        //        $('#btnDelete').attr('disabled', 'disabled');
        //    }
        //}, true);

        //function deleteProductCategory(id) {
        //    $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
        //        var config = {
        //            params: {
        //                id: id
        //            }
        //        }
        //        apiService.del('api/productcategory/delete', config, function () {
        //            notificationService.displaySuccess('Xóa thành công');
        //            search();
        //        }, function () {
        //            notificationService.displayError('Xóa không thành công');
        //        })
        //    });
        //}

        //function search() {
        //    getProductCagories();
        //}

        function getPages(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/page/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.pageAbout = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load page failed.');
            });
        }

        $scope.getPages();
    }
})(angular.module('tedushop.page'));