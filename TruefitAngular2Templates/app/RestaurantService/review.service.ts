import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable, Subject } from 'rxjs/Rx';
import 'rxjs/add/operator/toPromise';
import { IReview } from './review.interface';
@Injectable()
export class ReviewService {

    constructor(private _http: Http) { }
    private pullData = new Subject<number>();
    pullData$ = this.pullData.asObservable();

    AnnounceChange(mission: number) {
        this.pullData.next(mission);
    }

    LoadUserReviews(userId): Promise<IReview[]> {
        return this._http.get('http://truefitweb20170213072553.azurewebsites.net/api/Reviews/GetReviews?userId=' + userId)
            .toPromise()
            .then(response => this.extractArray(response))
            .catch(this.handleErrorPromise);
    }

    LoadRestaurantReviews(restaurantId): Promise<IReview[]> {
        return this._http.get('http://truefitweb20170213072553.azurewebsites.net/api/Reviews/GetRestaurantReviews?restaurantId=' + restaurantId)
            .toPromise()
            .then(response => this.extractArray(response))
            .catch(this.handleErrorPromise);
    }

    AddUserReview(model) {
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        delete model["id"];
        let body = JSON.stringify(model);
        return this._http.post('http://truefitweb20170213072553.azurewebsites.net/api/Reviews/', body,
            options).toPromise().catch(this.handleErrorPromise);
    }
    DeleteUserReview(id: number) {
        return this._http.delete('http://truefitweb20170213072553.azurewebsites.net/api/Reviews/?id=' +
            id).toPromise().catch(this.handleErrorPromise);
    }

    protected extractArray(res: Response, showprogress: boolean = true) {
        let data = res.json();

        return data || [];
    }

    protected handleErrorPromise(error: any): Promise<void> {
        try {
            error = JSON.parse(error._body);
        } catch (e) {
        }

        let errMsg = error.errorMessage
            ? error.errorMessage
            : error.message
                ? error.message
                : error._body
                    ? error._body
                    : error.status
                        ? `${error.status} - ${error.statusText}`
                        : 'unknown server error';

        console.error(errMsg);
        return Promise.reject(errMsg);
    }
}
