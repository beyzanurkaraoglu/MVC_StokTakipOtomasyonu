using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_StokTakipOtomasyonu.ActiveFolder
{
    public static class ActiveClass
    {
        

    
            public static string ActivePage(this HtmlHelper html, string control, string action)
        {
            string active = "";

            var rauteData = html.ViewContext.RouteData;
            string rautecontrol = (string)rauteData.Values["controller"];
            string routeaction = (string)rauteData.Values["action"];
            if ( action == routeaction) active = "active";


            return active;
        }

    }
}