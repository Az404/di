﻿using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization.WordDictionaries
{
    public class SimpleDictionary : IWordDictionary
    {
        private readonly Dictionary<SpeechPart, string[]> dictionary = new Dictionary<SpeechPart, string[]>()
        {
            [SpeechPart.Preposition] = new[]
            {
                "без", "безо", "близ", "в", "во", "вместо", "вне", "для",
                "до", "за", "из", "изо", "из-за", "из-под", "к", "ко", "кроме", "между", "меж", "на", "над",
                "надо", "о", "об, обо", "от", "ото", "перед", "передо", "пред", "предо", "пo", "под", "подо",
                "при", "про", "ради", "с", "со", "сквозь", "среди", "у", "через", "чрез"
            },
            [SpeechPart.Pronoun] = new[]
            {
                "я", "ты", "он", "она", "оно", "мы", "вы", "они", "себя", "мой", "твой", "свой", "ваш", "наш", "его",
                "её", "их", "кто", "что", "какой", "чей", "где", "который", "откуда", "сколько", "каковой", "каков",
                "зачем", "кто", "что", "какой", "который", "чей", "сколько", "каковой", "каков", "зачем", "когда", "тот",
                "этот", "столько", "такой", "таков", "сей", "всякий", "каждый", "сам", "самый", "любой", "иной",
                "другой", "весь", "никто", "ничто", "никакой", "ничей", "некого", "нечего", "незачем", "некто", "весь",
                "нечто", "некоторый", "несколько", "кто-то", "что-нибудь", "какой-либо"
            }
        };

        public IEnumerable<string> GetWords(SpeechPart speechPart)
        {
            return dictionary.ContainsKey(speechPart)
                ? dictionary[speechPart]
                : Enumerable.Empty<string>();
        }
    }
}