/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('tedushop.page', ['tedushop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('page', {
            url: "/page",
            templateUrl: "/app/components/page/pageListView.html",
            parent: 'base',
            controller: "pageListController"
        })
            .state('add_page', {
                url: "/add_page",
                parent: 'base',
                templateUrl: "/app/components/page/pageAddView.html",
                controller: "pageAddController"
            })
        .state('edit_page', {
            url: "/edit_page/:id",
            parent: 'base',
            templateUrl: "/app/components/page/pageEditView.html",
            controller: "pageEditController"
        });

    }
})();