using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_BooleanOverride()
    {
      Client firstClient = new Client("Dan", 1);
      Client secondClient = new Client("Dan", 1);
      Assert.Equal(firstClient, secondClient);
    }
    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
