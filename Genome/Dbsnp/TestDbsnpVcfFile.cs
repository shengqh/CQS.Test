using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Dbsnp
{
  [TestFixture]
  public class TestDbsnpVcfFile
  {
    string datafile = "../../../data/dbsnp.vcf";

    [Test]
    public void TestConstruction1()
    {
      var data = new DbsnpVcfFile(false).ReadFromFile(datafile);
      Assert.AreEqual(11, data.Count);
      Assert.AreEqual("1", data[0].Chrom);
      Assert.AreEqual(10144, data[0].Position);
      Assert.AreEqual("rs144773400", data[0].Id);
      Assert.AreEqual("TA", data[0].Reference);
      Assert.AreEqual("T", data[0].Alternative);
      Assert.AreEqual(".", data[0].Quality);
      Assert.AreEqual(".", data[0].Filter);
      Assert.AreEqual("DIV", data[0].VariationClass);
      Assert.AreEqual("RSPOS=10145;dbSNPBuildID=134;SSR=0;SAO=0;VP=050000000005000002000200;WGT=1;VC=DIV;ASP;OTHERKG", data[0].Information);
    }

    [Test]
    public void TestConstruction2()
    {
      var data = new DbsnpVcfFile(true).ReadFromFile(datafile);
      Assert.AreEqual(7, data.Count);
      Assert.AreEqual("1", data[0].Chrom);
      Assert.AreEqual(10177, data[0].Position);
      Assert.AreEqual("rs201752861", data[0].Id);
      Assert.AreEqual("A", data[0].Reference);
      Assert.AreEqual("C", data[0].Alternative);
      Assert.AreEqual(".", data[0].Quality);
      Assert.AreEqual(".", data[0].Filter);
      Assert.AreEqual("SNV", data[0].VariationClass);
      Assert.AreEqual("RSPOS=10177;dbSNPBuildID=137;SSR=0;SAO=0;VP=050000000005000002000100;WGT=1;VC=SNV;ASP;OTHERKG", data[0].Information);
    }
  }
}
