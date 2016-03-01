using NUnit.Framework;
using System.Linq;

namespace CQS.Genome.Plink
{
  [TestFixture]
  public class TestPlinkIndividual
  {
    [Test]
    public void TestReadFromFile()
    {
      var data = PlinkIndividual.ReadFromFile("../../../data/plink/plink.fam");
      Assert.AreEqual(7, data.Count);
      var last = data.Last();

      Assert.AreEqual("8621206501", last.Fid);
      Assert.AreEqual("115", last.Iid);
      Assert.AreEqual("0", last.Pat);
      Assert.AreEqual("0", last.Mat);
      Assert.AreEqual("2", last.Sexcode);
      Assert.AreEqual(-9, last.Phenotype);
    }
  }
}
