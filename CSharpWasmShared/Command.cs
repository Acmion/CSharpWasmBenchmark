using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpWasmShared
{
    public class Command
    {
        public string Content { get; set; }
        public string JavaScriptFunction { get; set; }

        public string ToJson() 
        {
            return $@"{{ ""{nameof(Content)}"": ""{Content}"", ""{nameof(JavaScriptFunction)}"": ""{JavaScriptFunction}"" }}";
        }
    }
}
