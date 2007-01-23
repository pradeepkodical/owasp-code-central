using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Document.Condition
{
    public interface ICondition
    {
        bool Result { get; }
        bool IsValid { get; }
        string ErrorMessage { get; }

        void SetResponseBody(string responseBody);
        void SetResponseStatusCode(int responseStatusCode);
    }
}
