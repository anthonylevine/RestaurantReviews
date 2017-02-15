export interface IReview {
    Id: number;
    RestaurantId: number;
    UserId: number;
    RestaurantName: string;
    UserName: string;
    ReviewComment: string;
    Rating: number;
    DateTimeVisited: string;
    DateReviewWritten: string;
}