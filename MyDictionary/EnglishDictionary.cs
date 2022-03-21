using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    public class EnglishDictionary
    {
        public EnglishDictionary(List<DictionaryEntry> entries)
        {
            _entries = entries;
        }

        private List<DictionaryEntry> _entries { get; set; }

        public List<DictionaryEntry> Search(string query)
        {
            List<DictionaryEntry> output = new List<DictionaryEntry>();

            foreach (var entry in _entries)
            {
                if (entry.Word.Contains(query))
                {
                    output.Add(entry);
                }
            }

            return output;
        }

        public static EnglishDictionary Create(string rootPath)
        {
            string[] lines = System.IO.File.ReadAllLines(rootPath + "/DataFile/oed.txt");

            var entries = new List<DictionaryEntry>();
            foreach (var line in lines)
            {
                if (line.Length < 3)
                {
                    continue;
                }

                int indexOfDelimiter = line.IndexOf(" ");

                var entry = new DictionaryEntry
                {
                    Word = line.Substring(0, indexOfDelimiter),
                    Definition = line.Substring(indexOfDelimiter + 2, line.Length - indexOfDelimiter - 2).Trim()
                };
                entries.Add(entry);
            }

            var englishDictionary = new EnglishDictionary(entries);

            return englishDictionary;
        }

    }
}
