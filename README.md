# INTRO
- This framwork is base on mvc,and design to solve the problem that a controller.cs file has a lot of actions. So I call it 
 'Elegant Framework Service'
 - this framwork supporter .net fromwark and dotnet core.
 # How To Use
 - .net formwork
   - in Global file ,add： **OpenAPIHelper.Init()**
 - dotnetcore
    - in ConfigureServices(),add: **services.AddMvc().AddOpenAPI();**
 - for more detail, take a look at the demo in the code !
    - the path in the code
      - .net framwork:http://{host}/mytest/quest/test
      - dotnet core:http://{host}/api/quest/test
      
