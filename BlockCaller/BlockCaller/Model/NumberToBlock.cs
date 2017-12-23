using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BlockCaller.Model
{
    public class NumberToBlock
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string numberToBlock { get; set; }
        public NumberToBlock()
        {
        }
    }
}
