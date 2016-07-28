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
    [Fact]
    public void Test_SaveMethod_SavesToDatabase()
    {
      Client testClient = new Client("Mike", 1);

      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_SaveMethod_GivesIdToObject()
    {
      Client testClient = new Client("Mike", 1);

      testClient.Save();
      Client savedClient = Client.GetAll()[0];

      int restult = savedClient.GetId();
      int testId = testClient.GetId();

      Assert.Equal(testId, restult);
    }
    [Fact]
    public void Test_FindMethodLocatesObjectInDataBase()
    {
      Client testClient = new Client("Dave", 1);
      testClient.Save();

      Client foundClient = Client.Find(testClient.GetId());

      Assert.Equal(testClient, foundClient);
    }
    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
