# MusicAppApi

ASP.Net Api Server that manage songs, artists and users, using Microsoft.EntityFramwork SQL 

User can SignUp To the system using idemtity authentication.

Tables that referance to user need to pass authorization JWT.

Api validate only artist name collumns

For Migration : 
    * Create a Database
    * Past your connection string in "appSetting.csproj:connectionstrings"
    * Run - "Update-Database".

