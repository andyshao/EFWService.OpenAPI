/* ======================================================================== 
 * Copyright (c) 同程网络科技股份有限公司. All rights reserved.
 * 文 件 名：IRouteHandler.cs   
 * 创 建 人：cgy6094 
 * 创建日期：2019/8/2 星期五 15:13:23
 * 用    途：
 * ======================================================================== */
using System;
using System.Collections.Generic;
using System.Text;

namespace EFWService.Route
{
    public interface IRouteHandler
    {
        IHttpHandler GetHttpHandler(RequestContext requestContext);
    }

    public interface IHttpHandler
    {

    }
}
