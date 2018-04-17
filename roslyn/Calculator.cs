using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
namespace roslyn
{
    class Calculator : System.MarshalByRefObject
    {
        public double Calc(string expression, Globals globals)
        {
            return CSharpScript.EvaluateAsync<double>(expression,
                ScriptOptions.Default.WithImports("System.Math"), globals: globals).Result;
        }
    }
}
