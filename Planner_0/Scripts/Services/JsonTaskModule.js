﻿var JsonTask = angular
    .module('Planner');

JsonTask.controller('JsonTaskController', function ($scope, JsonTaskService) {
    

    getTasks();
    function getTasks() {
        JsonTaskService.getTasks()
            .success(function (tsk) {
                $scope.tasks = tsk;
            })
            .error(function (error) {
                $scope.status = 'Unable to data: ' + error.message;
                console.log($scope.status);
            });
    };
});

JsonTask.factory('JsonTaskService', ['$http', function ($http) {

    var JsonTaskService = {};
    JsonTaskService.getTasks = function () {
        return $http.get('/Planner/GetTasks');
    };
    return JsonTaskService;

}]);