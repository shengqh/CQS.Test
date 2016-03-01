using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Bio.IO.SAM;
using Bio.IO.BAM;
using System.IO;

namespace CQS.Genome.Sam
{
  [TestFixture]
  public class TestCQSBAMParser
  {
    [Test]
    public void TestSAMAlignedSequenceBAMParser()
    {
      Func<string, dynamic> getParser1 = m => new SAMAlignedSequenceBAMParser(m);
      Func<string, string, dynamic> getParser11 = (m, n) => new SAMAlignedSequenceBAMParser(m, n);
      Func<string, dynamic> getParser2 = m => new SAMAlignedItemBAMParser(SAMFormat.Bwa, m);
      Func<string, string, dynamic> getParser22 = (m, n) => new SAMAlignedItemBAMParser(SAMFormat.Bwa, m, n);

      RunTest(getParser1, getParser11);
      RunTest(getParser2, getParser22);
    }

    public void RunTest(Func<string, dynamic> get1, Func<string, string, dynamic> get2)
    {
      var file = "../../../data/2562-JP-1.small.bam";

      int minMapQ = 50;
      using (var parser = get1(file))
      {
        //samtools view -c 2562-JP-1.small.bam
        var list = parser.ParseToEnd();
        Assert.AreEqual(1972, list.Count);

        //samtools view -c -F 0x4 2562-JP-1.small.bam
        parser.Filter = new BAMMappedFilter();
        parser.Reset();
        list = parser.ParseToEnd();
        Assert.AreEqual(1944, list.Count);

        //samtools view -c -F 0x4 -q 50 2562-JP-1.small.bam
        parser.Filter = new BAMMapQFilter(minMapQ);
        parser.Reset();
        list = parser.ParseToEnd();
        Assert.AreEqual(976, list.Count);
      }

      //Filter by chromosome
      using (var parser = get2(file, "2"))
      {
        //samtools view -c 2562-JP-1.small.bam 2
        var list = parser.ParseToEnd();
        Assert.AreEqual(1000, list.Count);

        //samtools view -c -F 0x4 2562-JP-1.small.bam 2
        parser.Filter = new BAMMappedFilter();
        parser.Reset();
        list = parser.ParseToEnd();
        Assert.AreEqual(995, list.Count);

        //samtools view -c -F 0x4 -q 50 2562-JP-1.small.bam 2
        parser.Filter = new BAMMapQFilter(minMapQ);
        parser.Reset();
        list = parser.ParseToEnd();
        Assert.AreEqual(966, list.Count);
      }
    }
  }
}
