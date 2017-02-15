import { Component, OnInit, Input } from '@angular/core';
import { Restaurant } from '../../ReviewModels/restaurant.model';
import { IRestaurant } from '../../ReviewModels/restaurant.interface';
import { RestaurantService } from '../../ReviewService/restaurant.service';

@Component({
    selector: 'RestaurantForm',
    templateUrl: './app/restaurant-add.html'
})

export class ReviewForm {
    @Input() UserId: number;
    @Input() UserName: string;
    @Input() RestaurantId: number;
    @Input() ResturantName: string;

    constructor(private _service: RestaurantService) {
        
    }
    model = new Restaurant();
    submitted = false;
   
    onSubmit() {
        this.submitted = true;
        this.model.CategoryId = 0;
        this.model.PriceRangeId = 0;
        this.model.AdminId = this.UserId;

        this._service.AddRestaurant(this.model).then(data => {
            this._service.AnnounceChange(2352);
        })
    }

    get diagnostic() { return JSON.stringify(this.model); }
}