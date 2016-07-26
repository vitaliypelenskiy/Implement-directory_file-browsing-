
var stack =[];

 var browmodulApp = angular.module("browmodulApp", []);

 browmodulApp.controller("browcontrCtrl", ['$scope','$http',function ($scope, $http) {

     $http.get('/api/File').success(function (data, status, headers, config) {
         $scope.directories = data;}).error(function (data, status, headers, config) {
             $scope.title = "Oops... something went wrong";
             $scope.working = false;
         });

    

 

     
     $scope.temps = "";
     $scope.Ways = function (temp) {

         if ($scope.temps == undefined)
         {
             $scope.temps ="";
         }

         $scope.temps += temp+ "\\";
         
         stack.push($scope.temps);

         
         
         var mas = { 'put': $scope.temps };
         $http.post('/api/File', mas).success(function (data) {
             $scope.directories = data;
         }).error(function (data, status, headers, config) {
             $scope.title = "Oops... something went wrong";
         });

        
         $http.post('/api/Number', mas).success(function (data) {
             $scope.number = data;
         }).error(function (data, status, headers, config) {
             $scope.title = "Oops... something went wrong";
         });


     };

    
     

     $scope.BackWays = function () {
        
         stack.pop();
         $scope.temps = stack.pop();
         stack.push($scope.temps);

         if ($scope.temps == undefined) {
             $http.get('/api/File').success(function (data, status, headers, config) {
                 $scope.directories = data;
             }).error(function (data, status, headers, config) {
                 $scope.title = "Oops... something went wrong";
                 $scope.working = false;
             });
         }
         else {

             

             var mas = { 'put': $scope.temps };
             $http.post('/api/File', mas).success(function (data) {
                 $scope.directories = data;
             }).error(function (data, status, headers, config) {
                 $scope.title = "Oops... something went wrong";
             });


             $http.post('/api/Number', mas).success(function (data) {
                 $scope.number = data;
             }).error(function (data, status, headers, config) {
                 $scope.title = "Oops... something went wrong";
             });

         };
     }
 }]);