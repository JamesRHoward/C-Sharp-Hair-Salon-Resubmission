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
    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool stylistEquality = (this.GetStylistName() == newStylist.GetStylistName());
        return (stylistEquality);
      }
    }
    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist>{};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        Stylist newStylist = new Stylist(stylistName, stylistId);
        allStylists.Add(newStylist);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allStylists;
    }
  }
}
