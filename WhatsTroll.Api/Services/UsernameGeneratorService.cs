using WhatsTroll.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using WhatsTroll.Data;

namespace WhatsTroll.Api.Util
{
    public class UsernameGeneratorService
    {
        private DataContext _dataContext;
        public UsernameGeneratorService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public String GenerateNew()
        {
            String username;
            while (true)
            {
                username = Generate();
                if (!CheckExists(username))
                    break;
            }
            return username;
        }

        private bool CheckExists(String username)
        {
                var user = _dataContext.User.Where(u => u.Username == username).SingleOrDefault();
                return user != null;
        }

        private String Generate()
        {
            int r = new Random().Next(nameList.Count);
            var f = nameList[r];
            int v = new Random().Next(9999);
            f = f + v;
            return f;
        }

        private readonly List<String> nameList = new List<string> {
            //Fruits
            "apple",
            "apricot",
            "avocado",
            "banana",
            "berry",
            "cantaloupe",
            "cherry",
            "citron",
            "citrus",
            "coconut",
            "date",
            "fig",
            "grape",
            "guava",
            "kiwi",
            "lemon",
            "lime",
            "mango",
            "melon",
            "mulberry",
            "nectarine",
            "orange",
            "papaya",
            "peach",
            "pear",
            "pineapple",
            "plum",
            "prune",
            "raisin",
            "raspberry",
            "tangerine",

            //Colors
            "amber",
            "beige",
            "black",
            "blue",
            "bronze",
            "brown",
            "carmine",
            "chocolate",
            "copper",
            "cyan",
            "emerald",
            "fuchsia",
            "gold",
            "green",
            "grey",
            "indigo",
            "jade",
            "lilac",
            "magenta",
            "mustard",
            "orange",
            "pink",
            "platinum",
            "purple",
            "red",
            "salmon",
            "sepia",
            "silver",
            "turquoise",
            "violet",
            "white",
            "yellow",

            //Animals
            "alligator",
            "ant",
            "bear",
            "bee",
            "bird",
            "camel",
            "cat",
            "cheetah",
            "chicken",
            "chimpanzee",
            "cow",
            "crocodile",
            "eer",
            "dog",
            "dolphin",
            "duck",
            "eagle",
            "elephant",
            "fish",
            "fly",
            "fox",
            "frog",
            "giraffe",
            "goat",
            "goldfish",
            "hamster",
            "hippopotamus",
            "horse",
            "kangaroo",
            "kitten",
            "lion",
            "lobster",

            //Adjectives
            "adventurous",
            "affable",
            "affectionate",
            "agreeable",
            "amicable",
            "charming",
            "communicative",
            "compassionate",
            "conscientious",
            "considerate",
            "emotional",
            "enthusiastic",
            "faithful",
            "friendly",
            "funny",
            "generous",
            "gentle",
            "good",
            "kind",
            "loving",
            "modest",
            "nice",
            "optimistic",
            "passionate",
            "rational",
            "sensible",
            "sensitive",
            "sociable",
            "sympathetic",
            "thoughtful",
            "understanding",
            "warmhearted",
            "loving"
        };
    }
}