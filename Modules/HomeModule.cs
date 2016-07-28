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
    Get["/stylist/add"] = _ => {
      List<Stylist> allStylists = Stylist.GetAll();
      return View["stylist_form.cshtml", allStylists];
    };
  }
}
