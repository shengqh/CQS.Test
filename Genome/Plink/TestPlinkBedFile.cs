using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Genome.Plink
{
  [TestFixture]
  public class TestPlinkBedFile
  {
    [Test]
    public void TestMethod()
    {
      var data = new PlinkBedFile().ReadFromFile("../../data/plink/plinknew.bed");
      Assert.AreEqual(2, data.Locus.Count);
      Assert.AreEqual(5, data.Individual.Count);

      Assert.AreEqual("GCCCG", data.LocusAllele1(0));
      Assert.AreEqual("2,1,1,0,2", data.LocusGenoType(0, ","));
      Assert.AreEqual("2,0,1,1,2", data.LocusGenoType(1, ","));
    }
  }
}
