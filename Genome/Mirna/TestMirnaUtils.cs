using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Mirna
{
  [TestFixture]
  public class TestMirnaUtils
  {
    [Test]
    public void TestGetCombinedSequence()
    {
      var seq1 = "CAAGCTTGTATCTATAGGTATG";
      var seq2 = "ACAAGCTTGTGTCTATAGGTAT";

      var combined = MirnaUtils.GetCombinedSequence(seq1,seq2 );

      Assert.AreEqual(seq1, combined.Sequence1);
      Assert.AreEqual(seq2, combined.Sequence2);
      Assert.AreEqual(0, combined.Position1);
      Assert.AreEqual(1, combined.Position2);
      Assert.True(combined.MismatchPositions.Contains(0));
      Assert.True(combined.MismatchPositions.Contains(10));
      Assert.True(combined.MismatchPositions.Contains(22));
    }
  }
}
