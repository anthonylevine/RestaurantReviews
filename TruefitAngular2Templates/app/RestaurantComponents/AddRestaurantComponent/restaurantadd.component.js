"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('@angular/core');
var restaurant_model_1 = require('../../ReviewModels/restaurant.model');
var ReviewForm = (function () {
    function ReviewForm(_service) {
        this._service = _service;
        this.model = new restaurant_model_1.Restaurant();
        this.submitted = false;
    }
    ReviewForm.prototype.onSubmit = function () {
        var _this = this;
        this.submitted = true;
        this.model.CategoryId = 0;
        this.model.PriceRangeId = 0;
        this.model.AdminId = this.UserId;
        this._service.AddRestaurant(this.model).then(function (data) {
            _this._service.AnnounceChange(2352);
        });
    };
    Object.defineProperty(ReviewForm.prototype, "diagnostic", {
        get: function () { return JSON.stringify(this.model); },
        enumerable: true,
        configurable: true
    });
    __decorate([
        core_1.Input()
    ], ReviewForm.prototype, "UserId", void 0);
    __decorate([
        core_1.Input()
    ], ReviewForm.prototype, "UserName", void 0);
    __decorate([
        core_1.Input()
    ], ReviewForm.prototype, "RestaurantId", void 0);
    __decorate([
        core_1.Input()
    ], ReviewForm.prototype, "ResturantName", void 0);
    ReviewForm = __decorate([
        core_1.Component({
            selector: 'RestaurantForm',
            templateUrl: './app/restaurant-add.html'
        })
    ], ReviewForm);
    return ReviewForm;
}());
exports.ReviewForm = ReviewForm;
