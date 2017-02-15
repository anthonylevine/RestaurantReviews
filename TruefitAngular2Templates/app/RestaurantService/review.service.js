"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('@angular/core');
var http_1 = require('@angular/http');
var Rx_1 = require('rxjs/Rx');
require('rxjs/add/operator/toPromise');
var ReviewService = (function () {
    function ReviewService(_http) {
        this._http = _http;
        this.pullData = new Rx_1.Subject();
        this.pullData$ = this.pullData.asObservable();
    }
    ReviewService.prototype.AnnounceChange = function (mission) {
        this.pullData.next(mission);
    };
    ReviewService.prototype.LoadUserReviews = function (userId) {
        var _this = this;
        return this._http.get('http://truefitweb20170213072553.azurewebsites.net/api/Reviews/GetReviews?userId=' + userId)
            .toPromise()
            .then(function (response) { return _this.extractArray(response); })
            .catch(this.handleErrorPromise);
    };
    ReviewService.prototype.LoadRestaurantReviews = function (restaurantId) {
        var _this = this;
        return this._http.get('http://truefitweb20170213072553.azurewebsites.net/api/Reviews/GetRestaurantReviews?restaurantId=' + restaurantId)
            .toPromise()
            .then(function (response) { return _this.extractArray(response); })
            .catch(this.handleErrorPromise);
    };
    ReviewService.prototype.AddUserReview = function (model) {
        var headers = new http_1.Headers({
            'Content-Type': 'application/json; charset=utf-8'
        });
        var options = new http_1.RequestOptions({ headers: headers });
        delete model["id"];
        var body = JSON.stringify(model);
        return this._http.post('http://truefitweb20170213072553.azurewebsites.net/api/Reviews/', body, options).toPromise().catch(this.handleErrorPromise);
    };
    ReviewService.prototype.DeleteUserReview = function (id) {
        return this._http.delete('http://truefitweb20170213072553.azurewebsites.net/api/Reviews/?id=' +
            id).toPromise().catch(this.handleErrorPromise);
    };
    ReviewService.prototype.extractArray = function (res, showprogress) {
        if (showprogress === void 0) { showprogress = true; }
        var data = res.json();
        return data || [];
    };
    ReviewService.prototype.handleErrorPromise = function (error) {
        try {
            error = JSON.parse(error._body);
        }
        catch (e) {
        }
        var errMsg = error.errorMessage
            ? error.errorMessage
            : error.message
                ? error.message
                : error._body
                    ? error._body
                    : error.status
                        ? error.status + " - " + error.statusText
                        : 'unknown server error';
        console.error(errMsg);
        return Promise.reject(errMsg);
    };
    ReviewService = __decorate([
        core_1.Injectable()
    ], ReviewService);
    return ReviewService;
}());
exports.ReviewService = ReviewService;
