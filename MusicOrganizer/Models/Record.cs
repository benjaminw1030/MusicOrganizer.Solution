using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Record
  {
    private static List<Record> _instances = new List<Record> {};
    public string Name { get; set; }
    public int Id { get; }
    public List<Record> Records { get; set; }

    public Record(string recordName)
    {
      Name = recordName;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}