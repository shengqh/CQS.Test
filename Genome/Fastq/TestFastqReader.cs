using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Genome.Fastq
{
  [TestFixture]
  public class TestFastqReader
  {
    [Test]
    public void Test()
    {
      var reader = new FastqReader();
      //using (var sr = StreamUtils.GetReader("../../data/01-018-Post_CTTGTA_slim.fastq.gz"))
      using (var sr = StreamUtils.GetReader("h:/temp/3673-XJ-3_1_sequence.txt.gz"))
      {
        FastqSequence read;
        while ((read = reader.Parse(sr)) != null)
        {
          Console.WriteLine(read.Name);
          Console.Out.Flush();
        }
      }
    }
  }
}
