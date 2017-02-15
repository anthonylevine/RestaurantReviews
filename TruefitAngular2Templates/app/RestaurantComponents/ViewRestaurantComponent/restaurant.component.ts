import { Component, OnInit, Input } from '@angular/core';
import { Restaurant } from '../../ReviewModels/restaurant.model';
import { IRestaurant } from '../../ReviewModels/restaurant.interface';
import { RestaurantService } from '../../ReviewService/restaurant.service';
import { Subscription } from 'rxjs/Subscription';
@Component({
    templateUrl: 'restaurant.html'
})
export class RestaurantComponent extends OnInit {
    subscription: Subscription;
    Restaurants: IRestaurant[] = [];
    City: string;
    Users = [];

    search() {
        this._service.SearchForRestaurants(this.City).then(data => {
            this.Restaurants = data;
        })
    }
    constructor(private _service: RestaurantService) {
        super();
    }

    ngOnInit() {
      
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}