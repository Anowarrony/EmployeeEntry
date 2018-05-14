var app = angular.module("Homeapp", []);

app.controller("EmployeeController", function ($scope, $http) {

 

    $http.get("/Employee/GetEmployees").then(function (d) {
        $scope.record = d.data;
    }, function (error) {
        alert("error");
    });

    $scope.loadrecord = function (id) {
        $http.get("/Employee/GetEmployeeById?id=" + id).then(function (d) {
            $scope.Employee = d.data[0];
           
        }, function (error) {
            alert('Failed');
        });
    };
 
    $scope.reload = function (id) {
        window.location.href = "/Employee/Create";
    };



    $scope.deleterecord = function (id) {
        if(confirm("Are you sure to delete this record permantly?")){
            $http.get("/Employee/DeleteEmployee?id=" + id).then(function (d) {
                window.location.href = "/Employee/Create";

               $http.get("/Employees/Create").then(function (d) {
                $scope.record = d.data;
        }, function (error) {
                //alert('Failed');
        });
        }, function (error) {
            alert('Failed');
        });
        }
    };
    $scope.updatedata = function () {
        $scope.btntext = "Please Wait..";
        $http({
            method: 'POST',
            url: '/Home/update_record',
            data: $scope.register
        }).success(function (d) {
            $scope.btntext = "Update";
            $scope.register = null;
            alert(d);
        }).error(function () {
            alert('Failed');
        });
    };

   

});
      

