using System;
using System.Collections.Generic;
using System.Text;

namespace BlockCaller.db
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
