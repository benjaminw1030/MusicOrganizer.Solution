using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Controllers
{
  public class ArtistsController : Controller
  {
    [HttpGet("/artists")]
    public ActionResult Index()
    {
      List<Artist> allArtists = Artist.GetAll();
      return View(allArtists);
    }

    [HttpGet("/artists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpGet("/artists/search_by_artist")]
    public ActionResult SearchByArtist()
    {
      return View();
    }

    [HttpPost("/artists")]
    public ActionResult Create(string artistName)
    {
      Artist newArtist = new Artist(artistName);
      return RedirectToAction("Index");
    }

    [HttpGet("/artists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      List<Record> artistRecords = selectedArtist.Records;
      model.Add("artist", selectedArtist);
      model.Add("records", artistRecords);
      return View(model);
    }

    [HttpPost("/artists/{artistId}/records")]
    public ActionResult Create(int artistId, string recordName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist foundArtist = Artist.Find(artistId);
      Record newRecord = new Record(recordName);
      foundArtist.AddRecord(newRecord);
      List<Record> artistRecords = foundArtist.Records;
      model.Add("records", artistRecords);
      model.Add("artist", foundArtist);
      return View("Show", model);
    }

    [HttpPost("/artists/search_results")]
    public ActionResult SearchResults(string artistName)
    {
      List<Artist> searchResults = new List<Artist>();
      List<Artist> allArtists = Artist.GetAll();
      string searchName = artistName.ToLower();
      foreach (Artist artist in allArtists)
      {
        string name = artist.Name.ToLower();
        if (name.Contains(searchName))
        {
          searchResults.Add(artist);
        }
      }
      return View(searchResults);
    }
  }
}