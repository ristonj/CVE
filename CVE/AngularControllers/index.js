var cveApp = angular.module('cveApp', ['ngResource']);

cveApp.controller('IndexController', function IndexController($scope, $resource) {

    function getValues() {
        var values = $resource('/api/values?page=:page&sev=:sev');
        return values.get({ page: $scope.currPage, sev: $scope.sevFilter });
    }

    $scope.sevFilter = null;
    $scope.currPage = 1;
    $scope.vulns = getValues();
    

    $scope.prevPage = function () {
        if ($scope.currPage > 1) {
            $scope.currPage--;
            $scope.vulns = getValues();
        }
    }

    $scope.nextPage = function () {
        if ($scope.currPage <= ($scope.vulns.count / 25)) {
            $scope.currPage++;
            $scope.vulns = getValues();
        }
    }

    $scope.filter = function (sev) {
        $scope.sevFilter = sev;
        $scope.currPage = 1;
        $scope.vulns = getValues();
    }
});