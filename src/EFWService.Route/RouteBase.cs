/* ======================================================================== 
 * Copyright (c) 同程网络科技股份有限公司. All rights reserved.
 * 文 件 名：RouteBase.cs   
 * 创 建 人：cgy6094 
 * 创建日期：2019/8/2 星期五 15:15:02
 * 用    途：
 * ======================================================================== */
using System;
using System.Collections.Generic;
using System.Text;

namespace EFWService.Route
{
    public abstract class RouteBase
    {
        public abstract RouteData GetRouteData(HttpContextBase httpContext);
    }
}
