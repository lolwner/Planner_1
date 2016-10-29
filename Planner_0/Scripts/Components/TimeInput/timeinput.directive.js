var TI = angular.module('Planner');

TI.directive('timeInput', function () {
    var directive = {
        restrict: 'E',
        replace: false,
        templateUrl: '../Scripts/Components/TimeInput/timeinput.html',
        controller: timeInputController,
    };

    return directive;

    function timeInputController($scope) {
        $scope.picked = {
            value: new Date(2016, 0, 1, 14, 57, 0)
        };
    }

});
