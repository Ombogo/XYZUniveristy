# XYZUniveristy
XYZ University wants to streamline its tuition payment process by receiving real-time payment notifications and detailed transaction information from Family Bank

# Installation Guide 
Install Net SDK : https://dotnet.microsoft.com/en-us/download
Install MYSQL DB :https://en.softonic.com/mac/database and follow the prompt windows to install and run 
for Mac user intialising a database  might be a problem one can use MSQL Workbench for the purposes of intialising the tables and inserting of data.

# Running the Project:

Go to your project directory and run the following command :
dotnet run

# Testing the API: 
Set up the End points on Postman and send a sample request as provided and ensure you get a success response for a successful connection.
If using cURL . use the following 
Submit as JSON Request Body

curl -d '{"admNo": "123456", "studentName": “Velma Vee","dateOfBirth": "1995-09-25"}' -H 'Content-Type: application/json' http://webapi/student/validate/
