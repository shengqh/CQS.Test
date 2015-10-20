using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Genome.Gwas
{
  [TestFixture]
  public class TestSNPItemUtils
  {
    [Test]
    public void TestFillDbsnpIdByPositionWithDifferentType()
    {
      var snps = new[]{new SNPItem(){
        Name = "exm249481",
        Chrom = 2,
        Position = 179658175
      }};

      var map = SNPItemUtils.FillDbsnpIdByPosition(snps, "../../../data/dbsnp_samelocus_differenttype.vcf");
      Assert.AreEqual(1, map.Count);
      Assert.AreEqual("exm249481", map.First().Value);
      Assert.AreEqual("rs72647851", map.First().Key);
    }

    [Test]
    public void TestFillDbsnpIdByPositionWithSameType()
    {
      var snps = new[]{new SNPItem(){
        Name = "exm249481",
        Chrom = 6,
        Position = 29688099
      }};

      var map = SNPItemUtils.FillDbsnpIdByPosition(snps, "../../../data/dbsnp_samelocus_sametype.vcf");
      Assert.AreEqual(1, map.Count);
      Assert.AreEqual("exm249481", map.First().Value);
      Assert.AreEqual("rs9258157", map.First().Key);
    }
  }
}
