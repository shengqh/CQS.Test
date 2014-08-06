using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQS.Genome.Plink
{
  [TestFixture]
  public class TestPlinkIndividual
  {
    [Test]
    public void TestReadFromFile()
    {
      var data = PlinkIndividual.ReadFromFile("../../data/plink/plinknew.fam");
      Assert.AreEqual(5, data.Count);
      var last = data.Last();

      Assert.AreEqual("8621206496", last.Fid);
      Assert.AreEqual("112", last.Iid);
      Assert.AreEqual("0", last.Pat);
      Assert.AreEqual("0", last.Mat);
      Assert.AreEqual("2", last.Sexcode);
      Assert.AreEqual(-9, last.Phenotype);
    }
  }
}
