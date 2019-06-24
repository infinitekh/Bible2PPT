﻿using System;

namespace Bible2PPT.Bibles
{
    class BibleBase
    {
        [IndexKey(Name = nameof(SourceId))]
        public int SourceId { get; set; }
        public virtual Sources.Source Source { get; set; } //Sources.BibleSource.AvailableSources.FirstOrDefault(i => i.Id == SourceId)

        [IndexKey(Name = nameof(Id))]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
