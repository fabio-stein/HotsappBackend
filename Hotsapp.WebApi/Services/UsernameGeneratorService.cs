﻿using Hotsapp.Data.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotsapp.WebApi.Util
{
    public class UsernameGeneratorService
    {
        public static async Task<string> GenerateNew()
        {
            string username;
            for (int i = 0; i < 10; i++)
            {
                username = Generate();
                if (!await UserAlreadyExists(username))
                    return username;
            }
            throw new Exception("Can't create a non existing username");

        }

        private static async Task<bool> UserAlreadyExists(string username)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var user = await ctx.User.Where(u => u.Username == username).FirstOrDefaultAsync();
                return user != null;
            }
        }

        private static string Generate()
        {
            int r = new Random().Next(nameList.Count);
            var f = nameList[r];
            int v = new Random().Next(9999);
            f = f + v;
            return f;
        }

        private static readonly List<string> nameList = new List<string> {
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