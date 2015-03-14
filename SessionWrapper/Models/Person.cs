using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc;

namespace SessionWrapper.Models
{
    public class Person
    {
        public Person ()
        {
            Powers = new HeroPowers();
        }
        public string Forename{ get; set;}
        public string Surname { get; set; }
        public HeroPowers  Powers { get; set; }

    }

    public class HeroPowers
    {
        public SelectListItem SelectedPower{get;set;}
        public List<SelectListItem > Powers 
        {
            get{return _powers; }
            set{
                Console.WriteLine("do nothing");
            }
        }
        private List<SelectListItem> _powers = new List<SelectListItem>
        {
            new SelectListItem{Selected = false, Text = "Flight" , Value= "vFlight"},
            new SelectListItem{Selected = false, Text = "Heat Vision" , Value= "vHeatVision"},
            new SelectListItem{Selected = false, Text = "Telekenisis" , Value ="vTelekenisis"},
            new SelectListItem{Selected = false, Text = "Strength" , Value ="vStrong"},
            new SelectListItem{Selected = false, Text = "Speed" , Value ="vFast"},
            new SelectListItem{Selected = false, Text = "Healing" , Value= "vTough"}
        };
        }
    }

 
