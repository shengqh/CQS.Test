using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.CNV
{
  [TestFixture]
  public class TestCnvnatorReader
  {
    [Test]
    public void TestRead()
    {
      var file = "../../data/2110.call";
      var items = new CnvnatorReader().ReadFromFile(file);
      Assert.AreEqual(10, items.Count);
      Assert.AreEqual(CNVType.DELETION, items[0].ItemType);

      var item = items.First();
      Assert.AreEqual("1", item.Seqname);
      Assert.AreEqual(1, item.Start);
      Assert.AreEqual(10000, item.End);
      Assert.AreEqual(143550, item.PValue1);
      Assert.AreEqual(2.26482e-21, item.PValue2);
      Assert.AreEqual(179437, item.PValue3);
      Assert.AreEqual(2.37484e-15, item.PValue4);
      Assert.AreEqual(-1, item.Q0);

      item = items.Last();
      Assert.AreEqual("Y", item.Seqname);
      Assert.AreEqual(13103001, item.Start);
      Assert.AreEqual(14012200, item.End);
      Assert.AreEqual(0, item.PValue1);
      Assert.AreEqual(0, item.PValue2);
      Assert.AreEqual(0, item.PValue3);
      Assert.AreEqual(0, item.PValue4);
      Assert.AreEqual(0.403598, item.Q0, 0.000001);
    }
  }
}
