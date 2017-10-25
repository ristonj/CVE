var cveApp = angular.module('cveApp', ['ngResource']);

cveApp.controller('IndexController', function IndexController($scope, $resource) {

    var values = $resource('/api/Values', {}, {
        query: {
            method: 'GET',
            isArray: false
        }
    });
    $scope.vulns = values.query();
});