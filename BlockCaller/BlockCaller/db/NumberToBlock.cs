using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BlockCaller.db
{
    public class NumberToBlock
    {
        [PrimaryKey,AutoIncrement]
        public static int Id { get; set; }
        public static string numberToBlock { get; set; }
        public NumberToBlock()
        {
        }
    }
}
