using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Tophat
{
  [TestFixture]
  public class TestTophatJunctionBedReader
  {
    [Test]
    public void TestRead()
    {
      var lst = new TophatJunctionBedReader().ReadFromFile(@"../../data/junctions.bed");
      Assert.AreEqual(5, lst.Count);
      Assert.AreEqual("1", lst[0].Chr);
      Assert.AreEqual("JUNC00000001", lst[0].Name);
      Assert.AreEqual(14776, lst[0].Start1);
      Assert.AreEqual(14828, lst[0].End1);
      Assert.AreEqual(14929, lst[0].Start2);
      Assert.AreEqual(14975, lst[0].End2);
    }
  }
}
