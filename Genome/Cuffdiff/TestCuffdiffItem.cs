using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Cuffdiff
{
  [TestFixture]
  public class TestCuffdiffItem
  {
    [Test]
    public void TestParse()
    {
      var item = CuffdiffItem.Parse("XLOC_000168	XLOC_000168	RNU5E-1	1:11968208-11968328	WE6	WE5	OK	23.7791	0	-inf	-nan	0.08905	0.999234	no");
      Assert.AreEqual("XLOC_000168", item.TestId);
      Assert.AreEqual("XLOC_000168", item.GeneId);
      Assert.AreEqual("RNU5E-1", item.Gene);
      Assert.AreEqual("1:11968208-11968328", item.Locus);
      Assert.AreEqual(23.7791, item.Value1);
      Assert.AreEqual(0, item.Value2);
      Assert.AreEqual(double.NegativeInfinity, item.Log2FoldChange);
      Assert.AreEqual(double.NaN, item.TestStat);
      Assert.AreEqual(0.08905, item.PValue);
      Assert.AreEqual(0.999234, item.QValue);
      Assert.False(item.Significant);
    }
  }
}
