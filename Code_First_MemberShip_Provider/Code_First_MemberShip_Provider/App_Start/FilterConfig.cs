﻿using System.Web;
using System.Web.Mvc;

namespace Code_First_MemberShip_Provider
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
