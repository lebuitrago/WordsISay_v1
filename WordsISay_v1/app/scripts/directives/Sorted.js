// DIRECTIVE

// Used to SORT STORIES queried by a certain column
// Usage Syntax:
// <td sorted="ColumnName"> ColumnName </td>

angular.module('WordsApp')
    .directive('sorted', function () {
        return {
            scope: true,
            transclude: true,
            template: '<a ng-click="do_sort()" ng-transclude></a>' +
                      '<span ng-show="do_show(true)"><i class="glyphicon glyphicon-chevron-down"></i></span>' +
                      '<span ng-show="do_show(false)"><i class="glyphicon glyphicon-chevron-up"></i></span>',
            controller: function ($scope, $element, $attrs) {
                // [Column Name to Sort] - by via following usage:
                // <th sorted="ColNameHere">XXXXX</th>
                $scope.sort_col = $attrs.sorted;

                // This function calls the $scope.sort function in the StoriesController.js
                $scope.do_sort = function () { $scope.sort($scope.sort_col); };

                $scope.do_show = function (asc) {
                    return (asc != $scope.is_desc) && ($scope.sort_order == $scope.sort_col);
                };
            }
        }
    });