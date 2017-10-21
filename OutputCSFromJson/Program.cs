using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJsonSchema.CodeGeneration.CSharp;


namespace OutputCSFromJson
{
    class Program
    {
        static void Main(string[] args)
        {
            NJsonSchema.JsonSchema4 mySchema = NJsonSchema.JsonSchema4.FromFileAsync("nvd_cve_feed_json_0.1_beta.schema").Result;
            CSharpGenerator myGenerator = new CSharpGenerator(mySchema);
            Console.Out.WriteLine(myGenerator.GenerateFile());
        }
    }
}
