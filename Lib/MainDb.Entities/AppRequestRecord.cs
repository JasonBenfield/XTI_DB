﻿using System;

namespace MainDB.Entities
{
    public sealed class AppRequestRecord
    {
        public int ID { get; set; }
        public string RequestKey { get; set; } = "";
        public int SessionID { get; set; }
        public string Path { get; set; } = "";
        public int ResourceID { get; set; }
        public int ModifierID { get; set; }
        public DateTimeOffset TimeStarted { get; set; } = DateTimeOffset.MinValue;
        public DateTimeOffset TimeEnded { get; set; } = DateTimeOffset.MaxValue;
    }
}
