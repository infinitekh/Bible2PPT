﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Bible2PPT.Bibles
{
    class BibleBook : Bible
    {
        [IgnoreDataMember]
        public virtual BibleVersion Bible { get; set; }
        public Guid BibleId { get; set; }

        public string OnlineId { get; set; }
        public string Title { get; set; }

        private string shortTitle;
        public string ShortTitle
        {
            get => shortTitle ?? BibleBookAliases.Map.FirstOrDefault(i => i.Any(a => a == OnlineId || a == Title))?.First() ?? "";
            set => shortTitle = value;
        }

        public int ChapterCount { get; set; }

        public List<BibleChapter> Chapters => Source.GetChapters(this);
    }
}
