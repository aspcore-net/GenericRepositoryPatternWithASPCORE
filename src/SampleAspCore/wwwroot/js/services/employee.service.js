app.service("empSvc", function ($http) {
    var instance = this;

    instance.getEmployees = function (pager) {
        return $http({
            method: "GET",
            url: "/api/employee",
            params: pager
        });
    };
});