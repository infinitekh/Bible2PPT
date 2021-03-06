﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bible2PPT.Bibles;
using Bible2PPT.Extensions;

namespace Bible2PPT.Sources
{
    class GoodtvBible : BibleSource
    {
        private const string BASE_URL = "http://goodtvbible.goodtv.co.kr";

        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri(BASE_URL),
            Timeout = TimeSpan.FromSeconds(5),
        };

        public GoodtvBible()
        {
            Name = "GOODTV 성경";
        }

        public override async Task<List<Bible>> GetBiblesOnlineAsync()
        {
            var data = await client.GetStringAsync("/bible.asp").ConfigureAwait(false);
            var matches = Regex.Matches(data, @"bible_check"".+?value=""(\d+)""[\s\S]+?<span.+?>(.+?)<");
            return matches.Cast<Match>().Select(i => new Bible
            {
                OnlineId = i.Groups[1].Value,
                Name = i.Groups[2].Value,
            }).ToList();
        }

        public override async Task<List<Book>> GetBooksOnlineAsync(Bible bible)
        {
            using var oldContent = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["bible_idx"] = "1",
                ["otnt"] = "1",
            });
            using var newContent = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["bible_idx"] = "1",
                ["otnt"] = "2",
            });
            var data = string.Join("", await Task.WhenAll(
                client.PostAndGetStringAsync("/bible_otnt_exc.asp", oldContent),
                client.PostAndGetStringAsync("/bible_otnt_exc.asp", newContent)).ConfigureAwait(false));
            var matches = Regex.Matches(data, @"""idx"":(\d+).+?""bible_name"":""(.+?)"".+?""max_jang"":(\d+)");
            return matches.Cast<Match>().Select(i => new Book
            {
                OnlineId = i.Groups[1].Value,
                Name = i.Groups[2].Value,
                ChapterCount = int.Parse(i.Groups[3].Value, CultureInfo.InvariantCulture),
            }).ToList();
        }

        public override Task<List<Chapter>> GetChaptersOnlineAsync(Book book) =>
            Task.FromResult(Enumerable.Range(1, book.ChapterCount)
                .Select(i => new Chapter
                {
                    OnlineId = $"{i}",
                    Number = i,
                }).ToList());

        private static string StripHtmlTags(string s) => Regex.Replace(s, @"<.+?>", "", RegexOptions.Singleline);

        public override async Task<List<Verse>> GetVersesOnlineAsync(Chapter chapter)
        {
            using var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["bible_idx"] = chapter.Book.OnlineId,
                ["jang_idx"] = chapter.OnlineId,
                ["bible_version_1"] = chapter.Book.Bible.OnlineId,
                ["bible_version_2"] = "0",
                ["bible_version_3"] = "0",
                ["count"] = "1",
            });
            var data = await client.PostAndGetStringAsync("/bible.asp", content).ConfigureAwait(false);
            data = Regex.Match(data, @"<p id=""one_jang""><b>([\s\S]+?)</b></p>").Groups[1].Value;
            var matches = Regex.Matches(data, @"<b>(\d+).*?</b>(.*?)<br>");
            return matches.Cast<Match>().Select(i => new Verse
            {
                Number = int.Parse(i.Groups[1].Value, CultureInfo.InvariantCulture),
                Text = StripHtmlTags(i.Groups[2].Value),
            }).ToList();
        }
    }
}
