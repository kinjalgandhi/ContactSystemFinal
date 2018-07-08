# ContactSystemFinal

ContactSystemRepo
.Net rest API for maintaining contact information

Please download this project. You will find ContactController which has all required REST APIs. You can use Postman Application to run below services.

In Contact table FirstName and Email is must field. Email can not be same for two contacts.

If First Name and Email will be blank then HttpStatusCode for "Bad Request" code will be in response.

If email will be duplicated then HttpStatusCode for "Conflict" code will be in response.

This Web API has 5 methods.

GET All Contacts
Method Type : GET

http://localhost:50083/api/contact

2)Get Contact by Id

Method Type : GET

http://localhost:50083/api/contact/1

3)Add Contact

Method Type : POST

http://localhost:50083/api/contact

Below is the format of Contact object to input

{
"FirstName": "Nirav", "LastName": "Gandhi", "Email": "Nirav.Gandhi@hotmail.com", "PhoneNumber": "0001 111 222", "Status": true }

IF First Name/Email not passed : HttpStatusCode for "Bad Request" code will be in response.

If Email will be duplicated : HttpStatusCode for "Conflict" code will be in response.

Added sucessfully : HttpStatusCode for "Ok" code will be in response.

Edit/Update Contact
Method Type : PUT

http://localhost:50083/api/contact

Below is the format of Contact object JSON string to input

{ "Id":"3", "FirstName": "Nirav Renamed", "LastName": "Gandhi", "Email": "Nirav.Gandhi@hotmail.com", "PhoneNumber": "0001 111 222", "Status": true }

IF Id/First Name/Email not passed : HttpStatusCode for "Bad Request" code will be in response.

If Email will be duplicated : HttpStatusCode for "Conflict" code will be in response.

IF record for given id is not in system : HttpStatusCode for "Not Found" code will be in response.

Update sucessfully : HttpStatusCode for "Ok" code will be in response.

5)Remove Contact

Method Type : POST

http://localhost:50083/api/contact/3

IF Id <= 0 : HttpStatusCode for "Bad Request" code will be in response.

IF Id not in system : HttpStatusCode for "Not Found" code will be in response.

Delete sucessfully : HttpStatusCode for "Ok" code will be in response.

© 2018 GitHub, Inc.
Terms
Privacy
Security
Status
Help
Contact GitHub
API
Training
Shop
Blog
About
Press h to open a hovercard with more details.
