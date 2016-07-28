using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon
{
  public class Stylist
  {
    private int _id;
    private string _stylistName;

    public Stylist(string stylistName, int id = 0)
    {
      _id = id;
      _stylistName = stylistName;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetStylistName()
    {
      return _stylistName;
    }
    public void SetStylistName(string newStylistName)
    {
      _stylistName = newStylistName;
    }
  }
}
