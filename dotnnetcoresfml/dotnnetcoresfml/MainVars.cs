using System;
using System.Collections.Generic;
using System.Text;

namespace dotnnetcoresfml
{
    static class MainVars
    {
        public static readonly int VISIBILITY_DISTANCE;
        public static readonly int CHUNK_SIZE;
        static MainVars()
        {
            VISIBILITY_DISTANCE = 4;
            CHUNK_SIZE = 16;
        }
    }
}
