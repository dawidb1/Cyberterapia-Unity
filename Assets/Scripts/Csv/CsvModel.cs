using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CsvModel {

    public static void AddRecordToCsv()
    {
        string PATH = "results.txt";
        var NEW_LINE = "\n";
        var ABSTRACT_LINE = 999;

        var currentLine = UserSingleton.Instance.LineInCsv;
        if (currentLine == ABSTRACT_LINE)
        {
            currentLine = File.ReadAllLines(PATH).Length;
            StreamWriter writer = new StreamWriter(PATH, append: true);
            var text = CsvLineFromSingleton() + NEW_LINE;
            writer.WriteLine(text);
            writer.Close();
            UserSingleton.Instance.LineInCsv = currentLine;
        }
        else
        {
            string[] lines = System.IO.File.ReadAllLines(PATH);
            lines[currentLine] = CsvLineFromSingleton();

            StreamWriter writer = new StreamWriter(PATH);
            foreach (var item in lines)
            {
                writer.WriteLine(item);
            }
            writer.Close();
        }
    }
    public static string CsvLineFromSingleton()
    {
        int sum = UserSingleton.Instance.NotesBest
          + UserSingleton.Instance.StarWarsBest
           + UserSingleton.Instance.SnakeBest
            + UserSingleton.Instance.MemoryBest;

        char semicolon = ';';
        string entity = UserSingleton.Instance.Username + semicolon
              + UserSingleton.Instance.NotesBest + semicolon
              + UserSingleton.Instance.StarWarsBest + semicolon
              + UserSingleton.Instance.SnakeBest + semicolon
              + UserSingleton.Instance.MemoryBest + semicolon
              + sum;

        return entity;
    }

    public CsvModel(string[] entityArray): this(entityArray[0], entityArray[1], entityArray[2],entityArray[3], entityArray[4])
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
