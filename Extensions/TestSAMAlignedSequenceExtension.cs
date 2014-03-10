using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Bio.IO.SAM;

namespace CQS.Extensions
{
  [TestFixture]
  public class TestSAMAlignedSequenceExtension
  {
    [Test]
    public void Test()
    {
      var sam1 = SAMParser.ParseSequence("HWI-ST829:190:D24JJACXX:5:1101:6936:7755	256	8	123338600	1	14M	*	0	0	TTAGAATACCGGCC	;+=BDBAB?A:?DE	AS:i:-3	XS:i:0	XN:i:0	XM:i:1	XO:i:0	XG:i:0	NM:i:1	MD:Z:1C12	YT:Z:UU	RG:Z:2516-10-identical");
      Assert.IsFalse(sam1.Flag.HasFlag(SAMFlags.QueryOnReverseStrand));
      Assert.AreEqual("TTAGAATACCGGCC", SAMAlignedSequenceExtension.GetQuerySequenceString(sam1));
      Assert.AreEqual(";+=BDBAB?A:?DE", SAMAlignedSequenceExtension.GetQualityScoresString(sam1));

      var sam2 = SAMParser.ParseSequence("HWI-ST829:190:D24JJACXX:5:1101:6936:7755	272	5	93693865	1	14M	*	0	0	GGCCGGTATTCTAA	ED?:A?BABDB=+;	AS:i:-3	XS:i:0	XN:i:0	XM:i:1	XO:i:0	XG:i:0	NM:i:1	MD:Z:12T1	YT:Z:UU	RG:Z:2516-10-identical");
      Assert.IsTrue(sam2.Flag.HasFlag(SAMFlags.QueryOnReverseStrand));
      Assert.AreEqual("TTAGAATACCGGCC", SAMAlignedSequenceExtension.GetQuerySequenceString(sam2));
      Assert.AreEqual(";+=BDBAB?A:?DE", SAMAlignedSequenceExtension.GetQualityScoresString(sam2));
    }
  }
}
