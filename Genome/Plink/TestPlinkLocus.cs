using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQS.Genome.Plink
{
  [TestFixture]
  public class TestPlinkLocus
  {
    [Test]
    public void TestReadFromFile()
    {
      var data = PlinkLocus.ReadFromBimFile("../../data/plink/plinknew.bim");
      Assert.AreEqual(2, data.Count);
      var last = data.Last();

      Assert.AreEqual(5, last.Chr);
      Assert.AreEqual("RS168753", last.Name);
      Assert.AreEqual(0, last.Pos);
      Assert.AreEqual(76028124, last.Bp);
      Assert.AreEqual("T", last.Allele1);
      Assert.AreEqual("A", last.Allele2);
    }
  }
}
