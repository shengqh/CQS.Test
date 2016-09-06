using NUnit.Framework;
using RCPA;
using System.Collections.Generic;
using System.IO;

namespace CQS.Genome.Feature
{
  [TestFixture]
  public class TestFeatureItemGroupXmlFormat
  {
    private void RunTest(IFileFormat<List<FeatureItemGroup>> format)
    {
      var inputFile = @"../../../data/CMS-001.count.mapped.xml";
      var features = format.ReadFromFile(inputFile);
      var tempFile = inputFile + ".tmp";
      format.WriteToFile(tempFile, features);
      FileAssert.AreEqual(inputFile, tempFile);
      File.Delete(tempFile);
    }

    [Test]
    public void Test()
    {
      RunTest(new FeatureItemGroupXmlFormatLinq());
    }

    [Test]
    public void TestStreamReader()
    {
      RunTest(new FeatureItemGroupXmlFormat());
    }

    [Test]
    public void TestHandWriter()
    {
      RunTest(new FeatureItemGroupXmlFormatHand());
    }
  }
}
