using NUnit.Framework;
using System.Collections.Generic;

namespace MyDictionary.Tests
{
    public class EnglishDictionaryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanSearchAnywhereInWord()
        {
            var entries = new List<DictionaryEntry>
            {
                new DictionaryEntry { Word = "cow", Definition = "Bovine creature" },
                new DictionaryEntry { Word = "clam", Definition = "Shell animal" },
                new DictionaryEntry { Word = "lamp", Definition = "Small light source" }
            };

            var dict = new EnglishDictionary(entries);
            var output = dict.Search("am");

            Assert.AreEqual(2, output.Count);
            Assert.AreEqual("clam", output[0].Word);
            Assert.AreEqual("lamp", output[1].Word);

            Assert.Pass();
        }
    }
}