
angular.module('WordsApp')
    .controller('CreateController', function ($scope, $location, Stories) {
        $scope.action = "Add";

        // Function name : SAVE()
        //
        // Calls PUT api/Stories/{id}
        $scope.save = function () {
            Stories.save($scope.item, function () {
                $location.path('/list');
            });
        };
    });