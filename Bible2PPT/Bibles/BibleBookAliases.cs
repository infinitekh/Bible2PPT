﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bible2PPT.Bibles
{
    class BibleBookAliases
    {
        public static List<List<string>> Map = new List<List<string>>();

        static BibleBookAliases()
        {
            using (var reader = new StringReader(Properties.Resources.BibleBookAliases))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Map.Add(line.Split(',').ToList());
                }
            }
        }
    }
}