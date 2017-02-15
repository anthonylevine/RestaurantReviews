import { Component, OnInit, Input } from '@angular/core';
import { Review } from '../../ReviewModels/review.model';
import { IReview } from '../../ReviewModels/review.interface';
import { ReviewService } from '../../ReviewService/review.service';

@Component({
    selector: 'ReviewForm',
    templateUrl: './app/review-add.html'
})

export class ReviewForm {
    @Input() UserId: number;
    @Input() UserName: string;
    @Input() RestaurantId: number;
    @Input() ResturantName: string;

    constructor(private _service: ReviewService) {
        
    }
    model = new Review();
    submitted = false;
   
    onSubmit() {
        console.log("form submitting");
        this.submitted = true;
        this.model.RestaurantId = this.RestaurantId;
        this.model.UserId = this.UserId;
        this.model.RestaurantName = this.ResturantName;
        this.model.UserName = this.UserName;

        this._service.AddUserReview(this.model).then(data => {
            this._service.AnnounceChange(1212);
        })
    }

    get diagnostic() { return JSON.stringify(this.model); }
}