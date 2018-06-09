using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsvModel {

 
    public CsvModel(string[] entityArray):this(entityArray[0], entityArray[1], entityArray[2],entityArray[3], entityArray[4])
    {
    }
    public CsvModel(string name, string notes, string starWars, string snake, string memory)
    {
        Name = name;
        NotesScore = notes;
        StarWarsScore = starWars;
        SnakeScore = snake;
        MemoryScore = memory;
    }
    public CsvModel(string entity)
    {
        string[] entityArray = entity.Split(';');

        Name = entityArray[0];

        NotesScore = entityArray[1];
        StarWarsScore = entityArray[2];
        SnakeScore = entityArray[3];
        MemoryScore = entityArray[4];
    }
    public CsvModel()
    {
        Name = "noname";
        NotesScore = "";
        StarWarsScore = "";
        SnakeScore = "";
        MemoryScore = "";
    }

    public string Name { get; set; }
    public string NotesScore { get; set; }
    public string StarWarsScore { get; set; }
    public string SnakeScore { get; set; }
    public string MemoryScore { get; set; }
}
