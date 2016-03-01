using NUnit.Framework;
using System.Linq;

namespace CQS.Genome.Plink
{
  [TestFixture]
  public class TestPlinkLocus
  {
    [Test]
    public void TestReadFromFile()
    {
      var data = PlinkLocus.ReadFromBimFile("../../../data/plink/plink.bim");
      Assert.AreEqual(2, data.Count);
      var last = data.Last();

      Assert.AreEqual(5, last.Chromosome);
      Assert.AreEqual("RS168753", last.MarkerId);
      Assert.AreEqual(0, last.GeneticDistance);
      Assert.AreEqual(76028124, last.PhysicalPosition);
      Assert.AreEqual("T", last.Allele1);
      Assert.AreEqual("A", last.Allele2);
    }
  }
}
