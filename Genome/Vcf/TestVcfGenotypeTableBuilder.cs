using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Genome.Vcf
{
  [TestFixture]
  public class TestVcfGenotypeTableBuilder
  {
    [Test]
    public void Test()
    {
      new VcfGenotypeTableBuilder(new VcfGenotypeTableBuilderOptions()
      {
        InputFile = "../../../data/P1886_snp_filtered.pass.vcf",
        MinimumDepth = 5,
        OutputFile = "../../../data/P1886_snp_filtered.pass.vcf.tsv"
      }).Process();
    }
  }
}
