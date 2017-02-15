TruefitAPI and TruefitAngular2Templates

TruefitAPI Description:

The TruefitAPI was built using .NET's Web API framework and leveraging the Entity framework (since we talked about).
CORS was added to the project to enable Cross-Origin requests, and the Web API was published to Azure (since we also talked about that).
Date-Transfer-Objects (DTOs) were created to allow for simpler representations and prevent circular reference errors that come with 
entities that reference each other. Since pure REST did not offer the complete functionality that was needed, the routes were altered
to allow for additional methods to be created and used. For example, a GET request to the Reviews Controller had to be broken out 
to allow for Reviews to be returned based on User or Restaurant.

TruefitAngular2Templates
This project contains Angular 2 components to accompany the API. Each component grouping allows for the creation, viewing, deletion  of
the specified type. Each type has it's own service that relies on Promise based calls and uses Reactive Extensions (rxjs) to 
compose these services using observable sequences. 

NOTE: I began the second portion with hopes to include it in a mock-up mobile app leveraging Cordova and Ionic, however, time
restrictions and practicality of having you download an Android app and run it for an interview candidate seemed like too much to ask. 

The Web API services are hosted at http://truefitweb20170213072553.azurewebsites.net. Here are a few examples of how the API can be used:

URL: http://truefitweb20170213072553.azurewebsites.net/api/Reviews/GetRestaurantReviews?restaurantId=4
Description: Get all restaurant reviews for the restaurant with Id 4.

URL: http://truefitweb20170213072553.azurewebsites.net/api/Restaurants/GetRestaurants?city=Pittsburgh
Description: Get all restaurants located in Pittsburgh.

URL: http://truefitweb20170213072553.azurewebsites.net/api/Reviews/GetReviews?userId=11
Description: Get all reviews for the user with Id 11.