//ClassRoom Controller
app.controller("TodoListController", function ($http) {
    var vm = this;
    vm.items = [];
    vm.itemAdd = { "Id": "", "Todo": "", "IsCompleted": false, "CreatedAt": "" };
    vm.itemUpdate = {};
    vm.itemDelete = {};

    vm.message = "This is angular";

    //Load Operatoin
    vm.Get = function ()
    {
        $http.get("api/TodoList/Gets")
            .then(function success(response) {
                vm.items = response.data;
            }, function error(response) {
                    vm.message = response.data;
            });
    };
    vm.Add = function () {
        $http.post("api/TodoList/Add", vm.itemAdd)
            .then(function success(response) {
                vm.itemAdd = { "Id": "", "Todo": "", "IsCompleted": false, "CreatedAt": "" };
                vm.items.push(response.data);
            }, function error(response) {
                vm.message = response;
            });
           
    }

    vm.checksatus = function ()
    {
        vm.items.forEach((item) => {
            if (item.IsCompleted) {
                document.getElementById(item.id).className = 'checked';
            }
            else {
                document.getElementById(item.id).className = '';
            }
        });
    }
    //Update Operation
    vm.Update = function (item) {
        if (!item.IsCompleted) {
            document.getElementById(item.id).className = 'checked';
            item.IsCompleted = true;
        }
        else {
            document.getElementById(item.id).className = '';
            item.IsCompleted = false;
        }
        
        $http.post("api/TodoList/Update", item)
            .then(function success(response) {
            }, function error(response) {
                vm.message = response;
            });
    }

    //Delete Operation
    vm.Delete = function (item) {

        var indexof = vm.items.indexOf(item);
        vm.items.splice(indexof, 1);
        $http.delete("api/TodoList/Delete/" + item.id)
            .then(function success(response) {
            }, function error(response) {
                vm.message = response;
            });
    }


});