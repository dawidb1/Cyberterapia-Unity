using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Csv
{
    public class CsvSnapshot
    {
        static string PATH = "results.txt";
        public static List<CsvModel> AllEntries;
        #region generate csv model
        public static List<CsvModel> GetRecordList()
        {
            AllEntries = new List<CsvModel>();

            StreamReader reader = new StreamReader(PATH);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                AllEntries.Add(new CsvModel(line));
            }
            return AllEntries;
        }
        #endregion

        #region add entry
        public static void AddRecordToCsv()
        {
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
        #endregion
    }
}
