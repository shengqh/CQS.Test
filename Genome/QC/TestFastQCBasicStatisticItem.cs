using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.QC
{
  [TestFixture]
  public class TestFastQCBasicStatisticItem
  {
    [Test]
    public void TestParse()
    {
      var actual = FastQCBasicStatisticItem.ParseFromFile("../../../data/G1_7143/s_2_1_sequence_fastqc/fastqc_data.txt");
      Assert.AreEqual("0.10.1", actual.FastQCVersion);
      Assert.True(actual.Passed);
      Assert.AreEqual("s_2_1_sequence.txt.gz", actual.FileName);
      Assert.AreEqual("Conventional base calls", actual.FileType);
      Assert.AreEqual("Illumina 1.5", actual.Encoding);
      Assert.AreEqual(29220457, actual.TotalSequences);
      Assert.AreEqual(0, actual.FilteredSequences);
      Assert.AreEqual(99, actual.SequenceLength);
      Assert.AreEqual(49, actual.GC);
    }
  }
}
