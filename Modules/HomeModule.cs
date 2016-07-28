using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using System.Linq;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
      Get["/stylist/new"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylist_form.cshtml", allStylists];
      };
      Post["/stylist/add"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist_name"]);
        newStylist.Save();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
    }
  }
}
