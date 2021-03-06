﻿using SQLite;

namespace BlockCaller.Model
{
    public class NumberToBlock
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string number { get; set; }
        public string name { get; set; }
        public string blockType { get; set; }
    }
}
