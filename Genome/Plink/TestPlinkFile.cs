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
  public class TestPlinkFile
  {
    [Test]
    public void TestReadFromBedFile()
    {
      Validate(new PlinkBedFile().ReadFromFile("../../../data/plink/plink.bed"));
    }

    [Test]
    public void TestReadFromPedFile()
    {
      Validate(new PlinkPedFile().ReadFromFile("../../../data/plink/plink.ped"));
    }

    private static void Validate(PlinkData data)
    {
      Assert.AreEqual(2, data.Locus.Count);
      Assert.AreEqual(7, data.Individual.Count);

      Assert.AreEqual("GCCCGC0", data.LocusAllele1(0));
      Assert.AreEqual("GGGCGG0", data.LocusAllele2(0));

      Assert.AreEqual("ATTTA0T", data.LocusAllele1(1));
      Assert.AreEqual("ATAAA0A", data.LocusAllele2(1));

      Assert.AreEqual("2,1,1,0,2,1,3", data.LocusGenoType(0, ","));
      Assert.AreEqual("2,0,1,1,2,3,1", data.LocusGenoType(1, ","));
    }
  }
}
