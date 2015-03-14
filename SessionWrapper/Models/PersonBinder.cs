using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SessionWrapper.Models
{
    public class PersonBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            string first_name = request.Form.Get("Forename");
            string last_name = request.Form.Get("Surname");
            string Power = request.Form.Get("Powers");

            HeroPowers hp = new HeroPowers();
            foreach (var item in hp.Powers )
            {
                if (item.Value ==Power)
                {
                    item.Selected = true;
                    break;
                }
            }

            return new Person() { Forename = first_name, Surname = last_name ,Powers = hp};

        }
    }
}
