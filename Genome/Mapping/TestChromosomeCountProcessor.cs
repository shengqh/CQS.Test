using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Genome.Mapping
{
  [TestFixture]
  public class TestChromosomeCountProcessor
  {
    [Test]
    public void Test()
    {
      var processor = new ChromosomeCountProcessor(new ChromosomeCountProcessorOptions()
      {
        InputFile = "../../data/TestChromosomeCountProcessor.sam",
        CountFile = "../../data/TestChromosomeCountProcessor.dupcount",
        OutputFile = "../../data/TestChromosomeCountProcessor.sam.count",
        KeepSequence=true
      });
      processor.Process();
    }
  }
}
