/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('tedushop.posts', ['tedushop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('posts', {
            url: "/posts",
            templateUrl: "/app/components/posts/postListView.html",
            parent: 'base',
            controller: "postListController"
        })
            .state('add_post', {
                url: "/add_post",
                parent: 'base',
                templateUrl: "/app/components/posts/postAddView.html",
                controller: "postAddController"
            })
            .state('post_edit', {
                url: "/post_edit/:id",
                templateUrl: "/app/components/posts/postEditView.html",
                controller: "postEditController",
                parent: 'base',
            });
    }
})();