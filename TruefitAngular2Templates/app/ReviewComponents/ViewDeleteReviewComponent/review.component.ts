import { Component, OnInit, Input } from '@angular/core';
import { ReviewService } from '../../ReviewService/review.service';
import { IReview } from '../../ReviewModels/review.interface';
import { Subscription } from 'rxjs/Subscription';
@Component({
    templateUrl: 'review.html'
})
export class ReviewComponent extends OnInit {
    subscription: Subscription;
    Reviews: IReview[] = [];
    ReviewTitle: string;
    IsUsersReviews: boolean;
    ReviewType: string;
    ReviewTypeId: string;
    Users = [];

    refresh() {
        if (this.ReviewType == "User") {
            this.ReviewTitle = "My Review";
            this.IsUsersReviews = true;
            this._service.LoadUserReviews(this.ReviewTypeId).then(data => {
                this.Reviews = data;
            })
        }
        else {
            this.ReviewTitle = "This Restaurant's Reviews";
            this.IsUsersReviews = false;
            this._service.LoadUserReviews(this.ReviewTypeId).then(data => {
                this.Reviews = data;
            })
        }
        
    }
    constructor(private _service: ReviewService) {
        super();
        this.subscription = _service.pullData$.subscribe(
            mission => {
                console.log("success", mission);
                this.refresh();
            });
    }

    ngOnInit() {
        this.Users = [];
        this.Users.push({ Id: "11", UserName: "Anthony" });
        this.refresh();        
    }
    onDelete(elem: number) {
        console.log("Delete review");
        console.log(elem);
        if (this.ReviewType == "User") {
            this._service.DeleteUserReview(elem).then(data => {
                this.refresh();
            })
        }
        else {

        }
    }
    

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}