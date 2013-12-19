// SERVICE

// SERVICE to retreive a list of Stories from the StoriesController.cs
angular.module('WordsApp')
    .factory('Stories', function ($resource) {
        return $resource('/api/Stories/:id', { id: '@id' }, { update: { method: 'PUT' } });
    });