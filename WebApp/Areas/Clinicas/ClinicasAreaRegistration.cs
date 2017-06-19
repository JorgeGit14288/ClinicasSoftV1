using System.Web.Mvc;

namespace WebApp.Areas.Clinicas
{
    public class ClinicasAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Clinicas";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Clinicas_default",
                //describe como sera mapeada la direccion, y la accion por defecto
                "Clinicas/{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional },
                //direccion donde se encuentran los controladores del area
                namespaces: new string[] { "WebApp.Areas.Clinicas.Controllers" }
            );
        }
    }
}