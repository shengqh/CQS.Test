using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Sam
{
  [TestFixture]
  public class TestSAMAlignedItem
  {
    [Test]
    public void TestGetGetSequences()
    {
      SAMAlignedItem item = new SAMAlignedItem();
      item.AddLocation(new SAMAlignedLocation(item)
      {
        Cigar = "5S18M2D19M5S",
        Start = 39979942,
        MismatchPositions = "18^CA10T8",
        Sequence = "aaaaaGTAGTACCAACTGTAAGTCCTTATCTTCATACTTTGTaaaaa"
      });

      string align, refer;
      item.GetSequences(out align, out refer);

      Assert.AreEqual("GTAGTACCAACTGTAAGT  CCTTATCTTCATACTTTGT", align);
      Assert.AreEqual("GTAGTACCAACTGTAAGTCACCTTATCTTCTTACTTTGT", refer);
    }
  }
}
