// application-configuration.js

"use strict";
define(['angularAMD', 'angular-route', 'ui-bootstrap', 'angular-sanitize', 'blockUI', ],
function (angularAMD) {

    var app = angular.module("mainModule",
        ['ngRoute', 'blockUI', 'ngSanitize', 'ui.bootstrap']);

    app.config(['$routeProvider', function ($routeProvider) {

        $routeProvider

        .when("/", angularAMD.route({

            templateUrl: function (rp) { return 'Views/Main/default.html'; },
            controllerUrl: "Views/Main/defaultController"
        }))

        .when("/:section/:tree", angularAMD.route({

            templateUrl: function (rp) {
                return 'views/' + rp.section + '/' + rp.tree + '.html';
            },

            resolve: {
                load: ['$q', '$rootScope', '$location',
                    function ($q, $rootScope, $location) {

                        var path = $location.path();
                        var parsePath = path.split("/");
                        var parentPath = parsePath[1];
                        var controllerName = parsePath[2];
                        var loadController = "Views/" + parentPath + "/" +
                                              controllerName + "Controller";

                        var deferred = $q.defer();
                        require([loadController], function () {
                            $rootScope.$apply(function () {
                                deferred.resolve();
                            });
                        });
                        return deferred.promise;
                    }]
            }
        }))

        .when("/:section/:tree/:id", angularAMD.route({

            templateUrl: function (rp) {
                return 'views/' + rp.section + '/' + rp.tree + '.html';
            },

            resolve: {
                load: ['$q', '$rootScope', '$location',
                    function ($q, $rootScope, $location) {
                        var path = $location.path();
                        var parsePath = path.split("/");
                        var parentPath = parsePath[1];
                        var controllerName = parsePath[2];
                        var loadController = "Views/" + parentPath + "/" +
                                              controllerName + "Controller";

                        var deferred = $q.defer();
                        require([loadController], function () {
                            $rootScope.$apply(function () {
                                deferred.resolve();
                            });
                        });
                        return deferred.promise;
                    }]
            }
        }))
            .otherwise({ redirectTo: '/' })
    }]);

    // Bootstrap Angular when DOM is ready
    angularAMD.bootstrap(app);

    return app;
});