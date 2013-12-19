// APP

angular.module('WordsApp', ['ngRoute', 'ngResource'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.
            // MAIN PAGE
            when('/', {
                templateUrl: 'app/views/Main.html'
            }).
            // LIST STORIES
            when('/list', {
                templateUrl: 'app/views/listStories.html',
                controller: 'StoriesController',
                resolve: {
                    // it will cause a 1 sec delay
                    delay: function ($q, $timeout) {
                        var delay = $q.defer();
                        $timeout(delay.resolve, 50);
                        return delay.promise;
                    }
                }
            }).
            // ADD STORY
            when('/new', {
                templateUrl: 'app/views/details.html',
                controller: 'CreateController'
            }).
            // EDIT STORY
            when('/edit/:editId', {
                templateUrl: 'app/views/details.html',
                controller: 'EditController'
            }).
            // CONTRIBUTE TO STORY
            when('/play/:editId', {
                templateUrl: 'app/views/play.html',
                controller: 'PlayController'
            }).
            otherwise( { redirectTo: '/' } );
    });