app.controller("employee-controller", function ($scope, empSvc, blockUI) {

    var blockContainer = null;

    $scope.employeesList = [];
    $scope.filterKey = "";
    $scope.pageSummary = "";

    var pager = {
        filterKey: "",
        page: 1
    };

    $scope.loadData = function () {
        //showing loader
        blockContainer.start();
        //setting pager data
        pager.filterKey = $scope.filterKey;
        //resetting page summary
        $scope.pageSummary = "";
        //loading employee list
        empSvc.getEmployees(pager)
            .then
            //on success
            (function (response) {
                //hiding loader
                blockContainer.stop();
                //destrying previous instance if any
                $("#pager").twbsPagination("destroy");
                //processing response
                $scope.employeesList = response.data.resultSet;
                //returning if no record found
                if ($scope.employeesList.length === 0) return;
                //initiating pagination
                $("#pager").twbsPagination({
                    initiateStartPageClick: false,
                    totalPages: response.data.totalPages,
                    visiblePages: 10,
                    startPage: pager.page,
                    onPageClick: function (event, page) {
                        //setting new page
                        pager.page = page;
                        //loading new data
                        $scope.loadData();
                    }
                });
                //setting page summary
                $scope.pageSummary = response.data.pageSummary;
            },
            //on error
            function () {
                //hiding loader
                blockContainer.stop();
            });
    };

    $scope.doFilter = function (e) {
        if (e.which === 13) {
            $scope.loadData();
        }
    };

    function init() {
        //setting block container
        blockContainer = blockUI.instances.get("blockContainer");
        //loading data
        $scope.loadData();
    }
    //initiating controller
    init();
});