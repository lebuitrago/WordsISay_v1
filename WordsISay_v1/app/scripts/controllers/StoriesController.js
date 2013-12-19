// CONTROLLER

// GET api/Stories supports the following
// string q = null, 
// string sort = null, 
// bool desc = false,
// int limit = null,
// int offset = 0

// NOTES:
// $scope.items are the items that are currently being displayed on the UI Screen

angular.module('WordsApp')
    .controller('StoriesController', function ($scope, $routeParams, Stories) {
        // Function name : SEARCH()
        $scope.search = function () {
            // Calls the 'GET api/Stories' C# controller
            Stories.query({
                q: $scope.query,
                sort: $scope.sort_order,
                desc: $scope.is_desc,
                limit: $scope.limit,
                offset: $scope.offset
            },
            function (data) {
                // Determines if there are still more items left to extract
                // If $scope.more is true, then there are more items
                // If $scope.more is false, then there are no more items
                $scope.more = data.length === $scope.limit;
                // Concatenate to the existing list of items being displayed on the UI Screen
                $scope.items = $scope.items.concat(data);
            });
        };

        // Function name : SORT()
        $scope.sort = function (col) {
            if ($scope.sort_order === col) {
                $scope.is_desc = !$scope.is_desc;
            } else {
                $scope.sort_order = col;
                $scope.is_desc = false;
            }

            $scope.reset();
        };

        // Function name : DO_SHOW()
        $scope.do_show = function (asc, col) {
            return (asc != $scope.is_desc) && ($scope.sort_order == col);
        };

        // Function name : SHOW_MORE()
        //
        // Used by Pagination
        $scope.show_more = function () {
            $scope.offset += $scope.limit;
            $scope.search();
        };

        // Function name : HAS_MORE()
        $scope.has_more = function () {
            return $scope.more;
        };

        // Function name : DELETE()
        //
        // Calls Stories.delete() which calls "api/Stories/{id}"
        $scope.delete = function () {
            var id = this.item.StoryId;

            Stories.delete({ id: id }, function () {
                $('#item_' + id).fadeOut();
            });
        };

        // Function name : RESET()
        $scope.reset = function () {
            debugger;
            // Used by Pagination - limit of items to display at a time
            $scope.limit = 3;
            // What item to start with
            $scope.offset = 0;
            // The current items being displayed on the UI Screen
            $scope.items = [];
            // Used to display link to 'SHOW MORE'
            $scope.more = true;

            $scope.search();
        };

        $scope.sort_order = "DateCreated";
        $scope.query = null;
        $scope.is_desc = false;

        $scope.reset();
    });