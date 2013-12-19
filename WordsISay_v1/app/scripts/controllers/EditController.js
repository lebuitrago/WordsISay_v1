angular.module('WordsApp')
    .controller('EditController', function ($scope, $location, $routeParams, Stories) {
        $scope.action = "Update";
        var id = $routeParams.editId;

        $scope.item = Stories.get({ id: id });

        // Function name : UPDATE()
        //
        // Calls PUT api/Stories/5
        $scope.save = function () {
            Stories.update({ id: id }, $scope.item, function () {
                $location.path('/list');
            });
        };
    });