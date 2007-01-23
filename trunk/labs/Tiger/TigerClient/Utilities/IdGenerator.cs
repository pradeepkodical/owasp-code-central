using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Utilities
{
    static class IdGenerator
    {
        static int nextID = 0;

        public static int GetID()
        {
            nextID++;
            if (nextID == int.MaxValue) nextID = int.MinValue;
            return nextID;
        }
    }
}
