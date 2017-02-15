"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('@angular/core');
var ReviewComponent = (function (_super) {
    __extends(ReviewComponent, _super);
    function ReviewComponent(_service) {
        var _this = this;
        _super.call(this);
        this._service = _service;
        this.Reviews = [];
        this.Users = [];
        this.subscription = _service.pullData$.subscribe(function (mission) {
            console.log("success", mission);
            _this.refresh();
        });
    }
    ReviewComponent.prototype.refresh = function () {
        var _this = this;
        if (this.ReviewType == "User") {
            this.ReviewTitle = "My Review";
            this.IsUsersReviews = true;
            this._service.LoadUserReviews(this.ReviewTypeId).then(function (data) {
                _this.Reviews = data;
            });
        }
        else {
            this.ReviewTitle = "This Restaurant's Reviews";
            this.IsUsersReviews = false;
            this._service.LoadUserReviews(this.ReviewTypeId).then(function (data) {
                _this.Reviews = data;
            });
        }
    };
    ReviewComponent.prototype.ngOnInit = function () {
        this.Users = [];
        this.Users.push({ Id: "11", UserName: "Anthony" });
        this.refresh();
    };
    ReviewComponent.prototype.onDelete = function (elem) {
        var _this = this;
        console.log("Delete review");
        console.log(elem);
        if (this.ReviewType == "User") {
            this._service.DeleteUserReview(elem).then(function (data) {
                _this.refresh();
            });
        }
        else {
        }
    };
    ReviewComponent.prototype.ngOnDestroy = function () {
        this.subscription.unsubscribe();
    };
    ReviewComponent = __decorate([
        core_1.Component({
            templateUrl: 'review.html'
        })
    ], ReviewComponent);
    return ReviewComponent;
}(core_1.OnInit));
exports.ReviewComponent = ReviewComponent;
