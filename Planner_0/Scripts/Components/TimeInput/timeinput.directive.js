
var TI = angular
      .module('Planner');
TI.directive('timeInput', function() {
    var directive = {
        restrict: 'E',
        replace: false,
        templateUrl: '../Scripts/Components/TimeInput/timeinput.html',
        controller: timeInputController,
    };



    return directive;

    function timeInputController($scope) {
        alert('ok2');
        $scope.picked = {
            value: new Date()
        };
        $scope.test = {
            value: new Date(1970, 0, 1, 14, 57, 0),
            flag: false,
        };
    }

}); 
TI.controller('timeInputController', function ($scope) {
    alert('ok');
    $scope.picked = {
        value: new Date()
    };
    $scope.test = {
        value: new Date(1970, 0, 1, 14, 57, 0),
        flag: false,
    };
});

/** @ngInject */
//function timeInputDirective() {


//    /** @ngInject */

//}

