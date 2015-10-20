using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CQS.Genome.Gsnap
{
  [TestFixture]
  public class TestSAMAlignedItemCandidateGsnapBuilder
  {
    [Test]
    public void TestGetCigar()
    {
      var builder = new SAMAlignedItemCandidateGsnapBuilder();
      var mismatch = builder.GetMismatchPositions("CCCGGACTCTGGAGAAGGAA", "CCC..ACTgT..A.AA..AA");
      Assert.AreEqual("3AA3G1AA1A2AA2", mismatch);
    }
  }
}
