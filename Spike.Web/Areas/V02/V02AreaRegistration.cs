
namespace Spike.Web.Areas.V02
{
    using System.Web.Mvc;

    public class V02AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "V02";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            // Make use of attribute routing
        }
    }
}