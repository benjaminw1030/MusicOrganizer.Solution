using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class ArtistTests : IDisposable
  {
    public void Dispose()
    {
      Artist.ClearAll();
    }

    [TestMethod]
    public void ArtistConstructor_CreatesInstanceOfArtist_Artist()
    {
      Artist newArtist = new Artist("test artist");
      Assert.AreEqual(typeof(Artist), newArtist.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "Test Artist";
      Artist newArtist = new Artist(name);
      string result = newArtist.Name;
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetId_ReturnsArtistId_Int()
    {
      string name = "Test Artist";
      Artist newArtist = new Artist(name);
      int result = newArtist.Id;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllArtistObjects_ArtistList()
    {
      string name01 = "Michael Jackson";
      string name02 = "Queen";
      Artist newArtist1 = new Artist(name01);
      Artist newArtist2 = new Artist(name02);
      List<Artist> newList = new List<Artist> { newArtist1, newArtist2 };
      List<Artist> result = Artist.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectArtist_Artist()
    {
      string name01 = "Michael Jackson";
      string name02 = "Queen";
      Artist newArtist1 = new Artist(name01);
      Artist newArtist2 = new Artist(name02);
      Artist result = Artist.Find(2);
      Assert.AreEqual(newArtist2, result);
    }

    [TestMethod]
    public void AddRecord_AssociatesRecordWithArtist_RecordList()
    {
      string recordName = "Thriller";
      Record newRecord = new Record(recordName);
      List<Record> newList = new List<Record> { newRecord };
      string artistName = "Michael Jackson";
      Artist newArtist = new Artist(artistName);
      newArtist.AddRecord(newRecord);
      List<Record> result = newArtist.Records;
      CollectionAssert.AreEqual(newList, result);
    }
  }
}