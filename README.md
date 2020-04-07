## EFWService OpenAPI
**EFWService OpenAPI** is a Framwork based on Microsoft MVC,and design to solve the problem that a controller.cs file contains a lot of actions. It has the same performace as MVC.

Author: cgymy  

Contact me: cgyqu2639@163.com

#### Features

* Quick to create a api
* Quick test via test tool
* Integrated authentication

### Build

* Open with vs2017
* DotNetCore Version >=2.1

 ### Support
 * `.NetFromwark` >=4.5
 *  `DotNetCore` NETSTANDARD>=2.0

 ### Useage
 #### Config
 ##### .NETFramwork
 In Global file ,add  
    
```C#
      OpenAPIHelper.Init();
```
##### DotnetCore
 In ConfigureServices(),add
```
     services.AddMvc().AddOpenAPI();
```
#### API Definition
1. Create an assembly with the name ends with **API**
2. Create a class with the name ends with **Method**
3. Class Use `ApiMethodDescAttibute`

For example:

```
[ApiMethodDesc(module: APIModule.Test,
        category: APICategory.Query,
        httpMethodType: HttpMethodType.ALL,
        desc: "testapi")]
public class TestMethod : ApiMethodBase<TestModel, NormalResponseModel>
{
    public override NormalResponseModel ExecuteLogic(TestModel request)
    {
        NormalResponseModel response = new NormalResponseModel();
        response.HasResult();
        response.result = request;
        return response;
    }
}
```
##### ApiMethodDescAttibute Property
PropertyName |  Type| Desc
---|---|--
Mudule | 	string |	Mudule
Category| 	string | Category
HttpMethodType| 	enum| HttpMethod type: GET POST ALL
Desc	|String	| Api desc
MethodName|	String|If not specified ,use name with classname remove `Method`

#### API Path
 > http://{host}/{Module}/{Category}/{MethodName}

**For more detail, view the demo!**

