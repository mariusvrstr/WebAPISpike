
namespace Spike.API.Areas.sample
{
    using System.Web.Mvc;

    public class SampleAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "sample";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            // Make use of attribute routing
        }
    }
}