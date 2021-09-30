using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class RecordTests : IDisposable
  {
    public void Dispose()
    {
      Record.ClearAll();
    }

    [TestMethod]
    public void RecordConstructor_CreatesInstanceOfRecord_Record()
    {
      Record newRecord = new Record("test record");
      Assert.AreEqual(typeof(Record), newRecord.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "Thriller";
      Record newRecord = new Record(name);
      string result = newRecord.Name;
      Assert.AreEqual(name, result);
    }
    
    [TestMethod]
    public void SetName_SetsName_String()
    {
      string name = "Thriller";
      Record newRecord = new Record(name);
      string updatedName = "Bad";
      newRecord.Name = updatedName;
      string result = newRecord.Name;
      Assert.AreEqual(updatedName, result);
    }
    
    [TestMethod]
    public void GetAll_ReturnsEmptyList_RecordList()
    {
      List<Record> newList = new List<Record> { };
      List<Record> result = Record.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsRecords_RecordList()
    {
      string name01 = "Thriller";
      string name02 = "Abbey Road";
      Record newRecord1 = new Record(name01);
      Record newRecord2 = new Record(name02);
      List<Record> newList = new List<Record> { newRecord1, newRecord2 };
      List<Record> result = Record.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetID_RecordsInstantiateWithAnIdAndGetterReturns_Int()
    {
      string description = "Abbey Road";
      Record newRecord = new Record(description);
      int result = newRecord.Id;
      Assert.AreEqual(1, result);
    }

        [TestMethod]
    public void Find_ReturnsCorrectRecord_Record()
    {
      string description01 = "Abbey Road";
      string description02 = "The Wall";
      Record newRecord1 = new Record(description01);
      Record newRecord2 = new Record(description02);
      Record result = Record.Find(2);
      Assert.AreEqual(newRecord2, result);
    }
  }
}