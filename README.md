# Chattr Api and Websocket Controller
## backend for NSS Capstone

This is the C#/.NET/SignalR backend for Chattr. Built to be used with the [Chattr React Client](https://github.com/sdana/chattr-frontend)

## To Use:
1. Git clone the repo
2. dotnet restore
3. Open in VS
4. In package manager console, run add-migration and update-database
5. Run app

## API Endpoints:
* /Token:
    - [Post] - Requires an object with values username, password, firstname, and lastname
* /Login
    - [Post] - Requires email and password, returns auth token string

### Message and Chatroom endpoints require auth token from successful login