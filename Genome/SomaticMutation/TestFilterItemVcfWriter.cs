using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CQS.Genome.SomaticMutation
{
  [TestFixture]
  public class TestFilterItemVcfWriter
  {
    [Test]
    public void TestWriteToFile()
    {
      var items = new FilterItemTextFormat().ReadFromFile("../../../data/TCGA-A7-A0D9-DNA-TP-NB.tsv");
      var writer = new FilterItemVcfWriter(new FilterProcessorOptions()
      {
        GlmPvalue = 0.01
      });
      var value = writer.GetValue(items[0]);
      Assert.AreEqual("1\t37568524\t.\tA\tG\t1.05\tGLM_FDR\tBC=TRUE;BGP=5.6E-2;BGF=8.9E-2\tAD:FA\t14,0:0\t7,5:0.417", value);
    }
  }
}
