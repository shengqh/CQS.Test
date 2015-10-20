using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Genome.Quantification
{
  [TestFixture]
  public class TestGeneCountTable
  {
    [Test]
    public void TestReadFromFile()
    {
      var counts = new GeneCountTableFormat().ReadFromFile(@"../../../data/genetable.tsv");

      Assert.AreEqual(2, counts.GeneValues.Count);
      Assert.AreEqual(4, counts.Samples.Length);

      Assert.AreEqual("ENSG00000000003", counts.GeneValues[0][0]);
      Assert.AreEqual("TSPAN6", counts.GeneValues[0][1]);
      Assert.AreEqual("IG-001", counts.Samples[0]);

      Assert.AreEqual(128, counts.Count[0, 0]);
      Assert.AreEqual(60, counts.Count[0, 1]);
      Assert.AreEqual(288, counts.Count[0, 2]);
      Assert.AreEqual(9, counts.Count[0, 3]);
    }
  }
}
