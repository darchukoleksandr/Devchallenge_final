
<h2>Structure</h2>
Solution contains single project. Services, models and controllers are located in separated folders.
Project is fully documented.

<h2>CallCenterController</h2>
<h4>Employee registration</h4>
Register employee.<br/>
<code>GET /register?name=Employee&area=area1&area=area2</code><br/>
Responce - 200 status code and "WELCOME" plain text.

<h4>Call request</h4>
Allocates registered employees to calls. <br/>
<code>GET /call?area=a1&area=a2</code><br/>
Responce - 200 status code and calls asig1nments.

<h4>Reset request</h4>
Clears all registered employees.<br/>
<code>GET /reset</code><br/>
Responce - 200 status code.

<h2>Testing</h2>
Project is tested with xUnit. To test the project, enter in WebApp.Test folderand do 
<code>dotnet test</code>.

<h2>Docker</h2>
Succesfully tested on linux container (17.03.1-ce, build c6d412e). Deploy instructions: <br />
1. <code>dotnet restore Devchallenge_semifinal.sln</code> - restoring NuGet-packages. <br />
2. <code>dotnet publish Devchallenge_final.core.sln -c Release -o ./obj/Docker/publish</code> -
project compilation (output files will be copied into container) <br />
3. <code>docker-compose build</code> - container build <br />
4. <code>docker-compose up - container run</code>
