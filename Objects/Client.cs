using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class Client
  {
    private int _id;
    private string _clientName;
    private int _stylistId;

    public Client(stringm clientName, int stylistId, int id = 0)
    {
      _id = id;
      _clientName = clientName;
      _stylistId = stylistId;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetClientName()
    {
      return _clientName;
    }
    public int GetStylistId()
    {
      return _stylistId;
    }
    public void SetClientName(string clientName)
    {
      _clientName = clientName;
    }
    public void SetSytlistId(int stylistId)
    {
      _stylistId = stylistId;
    }
    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = this.GetId() == newClient.GetId();
        bool clientNameEquality = this.GetName() == newClient.GetClientName();
        return (idEquality && clientNameEquality);
      }
    }
  }
}
