### ng2-kestrel-appserver

Updated for RC2
Get ASP.NET RC2 @ http://dot.net

####Static Web Server for Angular 2
Blog post here: http://www.tattoocoder.com/kestrel-as-a-static-server-for-angular/

Install the dotnet-cli & SDK from https://github.com/dotnet/cli#installers-and-binaries

```
* git clone git@github.com:spboyer/ng2-kestrel-appserver.git
* cd ng2-kestrel-appserver
* dotnet restore
* dotnet run
```

Option to run the app with `nodemon` to develop and auto refresh the .NET portions
```
* npm install
* npm start
```

This watches all `*.cs` files and will auto restart the application.  If you add any new
dependencies in the `project.json` file; a stop `dotnet restore` is required.

