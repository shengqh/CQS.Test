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

      Assert.AreEqual(5, last.Chromosome);
      Assert.AreEqual("RS168753", last.MarkerId);
      Assert.AreEqual(0, last.PhysicalPosition);
      Assert.AreEqual(76028124, last.GeneticDistance);
      Assert.AreEqual("T", last.Allele1);
      Assert.AreEqual("A", last.Allele2);
    }
  }
}
