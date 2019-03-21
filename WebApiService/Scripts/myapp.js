function ViewModel() {

    var self = this;

    var tokenKeyName = "accessToken";

    self.result = ko.observable();
    self.user = ko.observable();

    self.registerEmail = ko.observable();
    self.registerPassword = ko.observable();
    self.registerPassword2 = ko.observable();

    self.loginEmail = ko.observable();
    self.loginPassword = ko.observable();
    self.errors = ko.observableArray([]);

    self.callApi = function () {

        var token = sessionStorage.getItem(tokenKeyName);
        var headers = {};
        if (token) {
            headers.Authorization = 'Bearer ' + token;
        }

        $.ajax({
            type: 'GET',
            url: '/api/values',
            headers: headers
        }).done(function (data) {
            console.log("YEP CALLAPI");
            console.log(data);
        }).fail(function (err) {
            console.log("WHAT DA HELL CALLAPI");
        })
    }

    self.register = function () {

        var data = {
            Email: self.registerEmail(),
            Password: self.registerPassword(),
            ConfirmPassword: self.registerPassword2()
        };

        $.ajax({
            type: 'POST',
            url: '/api/Account/Register',
            contentType: "application/json",
            data: JSON.stringify(data)
        }).done(function (data) {
            console.log("YEP REGISTER");
            self.user(data.userName);
            sessionStorage.setItem(tokenKeyName, data.access_token);
        }).fail(function (err) {
            console.log("WHAT DA HELL REGISTER");
        });

    }

    self.login = function () {
        console.log("LOGINSTART");
        var loginData = {
            grant_type: 'password',
            username: self.loginEmail(),
            password: self.loginPassword()
        };

        $.ajax({
            type: 'POST',
            url: '/Token',
            data: loginData
        }).done(function (data) {
            console.log("YEP LOGIN");
            self.user(data.userName);
            sessionStorage.setItem(tokenKeyName, data.access_token);
        }).fail(function (err) {
            console.log("WHAT DA HELL LOGIN");
        });

    }

    self.logout = function () {

        var token = sessionStorage.getItem(tokenKeyName);
        var headers = {};
        if (token) {
            headers.Authorization = 'Bearer ' + token;
        }

        $.ajax({
            type: 'POST',
            url: '/api/Account/Logout',
            headers: headers
        }).done(function (data) {
            console.log("YEP LOGOUT");
            self.user('');
            sessionStorage.removeItem(tokenKeyName);
        }).fail(function (err) {
            console.log("WHAT DA HELL LOGOUT");
        })
    }
}

var app = new ViewModel();
ko.applyBindings(app);