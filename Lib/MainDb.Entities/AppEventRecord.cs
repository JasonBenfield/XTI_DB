﻿using System;

namespace MainDB.Entities
{
    public sealed class AppEventRecord
    {
        public int ID { get; set; }
        public string EventKey { get; set; } = "";
        public int RequestID { get; set; }
        public int Severity { get; set; }
        public string Caption { get; set; } = "";
        public string Message { get; set; } = "";
        public string Detail { get; set; } = "";
        public DateTimeOffset TimeOccurred { get; set; } = DateTimeOffset.MaxValue;
    }
}
