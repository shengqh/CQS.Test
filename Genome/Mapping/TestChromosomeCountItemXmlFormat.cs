using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQS.Genome.Mapping
{
  [TestFixture]
  public class TestChromosomeCountItemXmlFormat
  {
    [Test]
    public void Test()
    {
      var data = new ChromosomeCountXmlFormat().ReadFromFile(@"../../data/01-18-Post.bam.xml");
    }
  }
}
