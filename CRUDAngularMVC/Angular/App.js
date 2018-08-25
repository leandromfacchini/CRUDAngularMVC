/// <reference path="../scripts/angular.js" />

//definir aplicação angular e controlador
var app = angular.module("livrosApp", []);

//registrar o controller
app.controller("livrosCtrl", function ($scope, $http) {

    //lista todos os livros
    $http.get('/home/GetAll')
        .then(function (result) {

            $scope.livros = result.data;

        }, function (data) {

            console.log(data);

        });

    $scope.livro = $scope.livros;
    $scope.Selecionar = function (livro) {

        $scope.livro = livro;
    }

    //incluir livro
    $scope.Incluir = function (livro) {

        $http.post('/home/AdicionarLivro', { livro })
            .then(function (result) {

                $scope.livros = result;
                delete $scope.livro;
                $scope.TodosLivros();

            }, function (data) {

                console.log(data);

            });
    }

    $scope.Alterar = function (livro) {

        $http.post('/home/AtualizadorLivro', { livro })
            .then(function (result) {

                $scope.livros = result;
                delete $scope.livro;
                $scope.TodosLivros();

            }, function (data) {

                console.log(data);

            });
    }

    $scope.Deletar = function (livro) {

        $http.post('/home/Deletar', { livro })
            .then(function (result) {

                $scope.livros = result;
                $scope.TodosLivros();

            }, function (data) {

                console.log(data);

            });
    }

    $scope.TodosLivros = function () {

        $http.get('/home/GetAll')

            .then(function (result) {

                $scope.livros = result.data;

            }, function (data) {

                console.log(data);

            });
    }
})