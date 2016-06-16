using System.Web.Mvc;

namespace WebPage.Areas.SysManage
{
    public class SysManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SysManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "SysManage_default",
                url: "SysManage/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebPage.Areas.SysManage.Controllers" }
            );
        }
    }
}