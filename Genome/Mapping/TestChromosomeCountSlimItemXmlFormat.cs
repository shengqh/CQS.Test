using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CQS.Genome.Mapping
{
  [TestFixture]
  public class TestChromosomeCountSlimItemXmlFormat
  {
    [Test]
    public void TestReadWrite()
    {
      var format = new ChromosomeCountSlimItemXmlFormat(false);

      var expectFile = @"../../../data/CMS-306.bam.count.mapped.xml";

      var items = TestFile(format, expectFile);

      var tempFile = expectFile + ".tmp";
      format.WriteToFile(tempFile, items);

      TestFile(format, tempFile);
      File.Delete(tempFile);
    }

    private static List<ChromosomeCountSlimItem> TestFile(ChromosomeCountSlimItemXmlFormat format, string expectFile)
    {
      var result = format.ReadFromFile(expectFile);

      Assert.AreEqual(3, result.Count);
      Assert.AreEqual(2, result[0].Queries.Count);
      Assert.AreEqual(1, result[0].Names.Count);
      Assert.AreEqual("gma-miR166k", result[0].Names.First());

      Assert.AreEqual(2, result[1].Queries.Count);
      Assert.AreEqual(1, result[1].Names.Count);
      Assert.AreEqual("gma-miR166h-3p", result[1].Names.First());

      Assert.AreEqual(1, result[2].Queries.Count);
      Assert.AreEqual(1, result[2].Names.Count);
      Assert.AreEqual("gma-miR166u", result[2].Names.First());

      return result;
    }
  }
}
