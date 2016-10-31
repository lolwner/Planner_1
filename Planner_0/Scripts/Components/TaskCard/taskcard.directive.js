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
        bindToController: true,
        link: function (scope, elem, attrs) {
            elem.on('click', function (e) {
                this.style.zoom = this.style.zoom ? '' : 1.4;
            });
        }
    };
    return directive;


    function TaskCardController($scope) {
        var vm = this;
    }
});