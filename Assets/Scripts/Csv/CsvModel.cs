using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CsvModel {

    public CsvModel(string[] entityArray): this(entityArray[0], entityArray[1], entityArray[2],entityArray[3], entityArray[4], entityArray[5])
    {
    }
    public CsvModel(string name, string notes, string starWars, string snake, string memory, string suma)
    {
        Name = name;
        NotesScore = notes;
        StarWarsScore = starWars;
        SnakeScore = snake;
        MemoryScore = memory;
        Suma = suma;
    }
    public CsvModel(string entity)
    {
        string[] entityArray = entity.Split(';');

        Name = entityArray[0];

        NotesScore = entityArray[1];
        StarWarsScore = entityArray[2];
        SnakeScore = entityArray[3];
        MemoryScore = entityArray[4];
        Suma = entityArray[5];

    }
    public CsvModel()
    {
        Name = "noname";
        NotesScore = "00";
        StarWarsScore = "00";
        SnakeScore = "00";
        MemoryScore = "00";
        Suma = "00";
    }

    public string Name { get; set; }
    public string NotesScore { get; set; }
    public string StarWarsScore { get; set; }
    public string SnakeScore { get; set; }
    public string MemoryScore { get; set; }
    public string Suma { get; set; }
}
