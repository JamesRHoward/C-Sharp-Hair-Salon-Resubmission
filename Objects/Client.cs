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
    public static List<Client> GetAll()
     {
       List<Client> allClients = new List<Client>{};

       SqlConnection conn = DB.Connection();
       SqlDataReader rdr = null;
       conn.Open();

       SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
       rdr = cmd.ExecuteReader();

       while(rdr.Read())
       {
         int clientId = rdr.GetInt32(0);
         string clientName = rdr.GetString(1);
         int clientSylistId = rdr.GetInt32(2);
         Client newClient = new Client(clientName, clientSylistId, clientId);
         allClients.Add(newClient);
       }

       if (rdr != null)
       {
         rdr.Close();
       }
       if (conn != null)
       {
         conn.Close();
       }
     return allClients;
    }
  }
}
