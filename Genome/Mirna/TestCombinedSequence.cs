using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Mirna
{
  [TestFixture]
  public class TestCombinedSequence
  {
    [Test]
    public void TestGetAnnotatedSequence1()
    {
      var combined = new CombinedSequence()
      {
        Sequence1 = "CAAGCTTGTATCTATAGGTATG",
        Sequence2 = "ACAAGCTTGTGTCTATAGGTAT",
        Position1 = 0,
        Position2 = 1,
        MismatchPositions = new int[] { 0, 10, 22 }
      };

      Assert.AreEqual(".CAAGCTTGTaTCTATAGGTATg", combined.GetAnnotatedSequence1());
      Assert.AreEqual("aCAAGCTTGTgTCTATAGGTAT.", combined.GetAnnotatedSequence2());
    }
  }
}
