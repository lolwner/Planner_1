var TC = angular.module('Planner');

TC.directive('taskcard', function () {
    var directive = {
        restrict: 'E',
        templateUrl: '../Scripts/Components/TaskCard/taskcard.html',
        scope: {
            item: '=',
            id: "@"
        },
        controller: TaskCardController,
        controllerAs: 'taskcard',
        bindToController: true
    };
    return directive;


    function TaskCardController($scope) {
        var vm = this;
    }
});