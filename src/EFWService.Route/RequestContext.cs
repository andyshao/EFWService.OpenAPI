/* ======================================================================== 
 * Copyright (c) 同程网络科技股份有限公司. All rights reserved.
 * 文 件 名：RequestContext.cs   
 * 创 建 人：cgy6094 
 * 创建日期：2019/8/2 星期五 15:14:09
 * 用    途：
 * ======================================================================== */
using System;
using System.Collections.Generic;
using System.Text;

namespace EFWService.Route
{
    public class RequestContext
    {
        //public virtual HttpContextBase HttpContext { get; set; }
        public virtual RouteData RouteData { get; set; }
    }
}
