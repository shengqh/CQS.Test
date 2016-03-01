using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Genome.QC
{
  [TestFixture]
  public class TestSamToolsStatItemReader
  {
    [Test]
    public void TestMethod()
    {
      var item = new SamToolsStatItemReader().ReadFromFile(@"../../../data/2476-JP-01.bam.stat");
      Assert.AreEqual(122383979, item.Total);
      Assert.AreEqual(0, item.Duplicates);
      Assert.AreEqual(122092264, item.Mapped);
      Assert.AreEqual(122383979, item.PairedInSequencing);
      Assert.AreEqual(61183108, item.Read1);
      Assert.AreEqual(61200871, item.Read2);
      Assert.AreEqual(121137215, item.ProperlyPaired);
      Assert.AreEqual(121839842, item.WithItselfAndMateMapped);
      Assert.AreEqual(252422, item.Singletons);
      Assert.AreEqual(482135, item.WithMateMappedToADifferentChr);
      Assert.AreEqual(375411, item.WithMateMappedToADifferentChrMapQ);
    }
  }
}
