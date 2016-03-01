using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.QC
{
  [TestFixture]
  public class TestFastQCItem
  {
    [Test]
    public void TestParse()
    {
      var actual = FastQCItem.ParseFromDirectory("../../../data/G1_7143");
      Assert.AreEqual("G1_7143", actual.Name);
      Assert.AreEqual(2, actual.Items.Count);
      Assert.AreEqual("s_2_1_sequence;s_2_2_sequence", actual.FileNames);
      Assert.AreEqual("Conventional base calls", actual.FileType);
      Assert.AreEqual("Illumina 1.5", actual.Encoding);
      Assert.AreEqual(58440914, actual.TotalSequences);
      Assert.AreEqual(0, actual.FilteredSequences);
      Assert.AreEqual(99, actual.SequenceLength);
      Assert.AreEqual(49, actual.GC);
    }
  }
}
