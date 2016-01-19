﻿
namespace Spike.API.Areas.V0
{
    using System.Web.Mvc;

    public class V01AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "V01";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            // Make use of attribute routing
        }
    }
}