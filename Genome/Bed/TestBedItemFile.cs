using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Bed
{
  [TestFixture]
  public class TestBedItemFile
  {
    public static string filename = "../../data/peaks.slim.bed";

    [Test]
    public void TestReadSlimData()
    {
      List<BedItem> items =new  BedItemFile<BedItem>().ReadFromFile(filename);

      Assert.AreEqual(11, items.Count);
      Assert.AreEqual("21", items[0].Seqname);
      Assert.AreEqual(9827125, items[0].Start);
      Assert.AreEqual(9827151, items[0].End);
      Assert.AreEqual("21-1", items[0].Name);
      Assert.AreEqual(1182877.2, items[0].Score);
      Assert.AreEqual('+', items[0].Strand);

      Assert.AreEqual("12", items[10].Seqname);
      Assert.AreEqual(6647087, items[10].Start);
      Assert.AreEqual(6647113, items[10].End);
      Assert.AreEqual("12-4", items[10].Name);
      Assert.AreEqual(49330.1, items[10].Score);
      Assert.AreEqual('-', items[10].Strand);
    }
  }
}
