using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Sam
{
  [TestFixture]
  public class TestBwaFormat
  {
    [Test]
    public void TestParseAlternativeHits()
    {
      var bwaformat = new BwaFormat();
      var sam = new SAMAlignedItem();
      Assert.IsTrue(bwaformat.HasAlternativeHits);
      var parts = "HWI-ST508:275:D2A2JACXX:3:1105:21234:49676\t0\t1_hsa\t564952\t0\t36M\t*\t0\t0\tAGTAAGGTCAGCTAATTAAGCTATCGGGCCCATAAA\t@@?DDFF?FFFDBHIIJIJIJJGJJJJJJJJJJJJJ\tRG:Z:2570-KCV-01-19\tXT:A:R\tNM:i:3\tX0:i:4\tX1:i:0\tXM:i:3\tXO:i:0\tXG:i:0\tMD:Z:15A18C0C0\tXA:Z:M_hsa,+4403,36M,3;17_hsa,+19506660,36M,3;X_hsa,-55206629,36M,3;".Split('\t');
      bwaformat.ParseAlternativeHits(parts, sam);
    }
  }
}
