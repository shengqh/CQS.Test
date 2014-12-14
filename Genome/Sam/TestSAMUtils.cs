using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Sam
{
  [TestFixture]
  public class TestSAMUtils
  {
    [Test]
    public void TestGetChromosomes()
    {
      var chrs = SAMUtils.GetChromosomes("../../data/small.bam");
      Assert.IsNotNull(chrs);
      Assert.AreEqual(66, chrs.Count);
      Assert.AreEqual("chr1", chrs.First());
      Assert.AreEqual("chrY_JH584303_random", chrs.Last());
    }

    [Test]
    public void TestParseEnd()
    {
      Assert.AreEqual(10, SAMUtils.ParseEnd(1, "10M"));

      Assert.AreEqual(50, SAMUtils.ParseEnd(1, "11M1D10M1I19M1I9M"));

      Assert.AreEqual(41, SAMUtils.ParseEnd(1, "11M1D10M1I19M1I9D"));
    }
  }
}
