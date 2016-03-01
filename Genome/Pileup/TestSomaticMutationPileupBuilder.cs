using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Pileup
{
  [TestFixture]
  public class TestSomaticMutationPileupBuilder
  {
    [Test]
    public void Test()
    {
      SomaticMutationPileupBuilderOptions options = new SomaticMutationPileupBuilderOptions ();
      options.NormalFile = "../../../data/small.bam";
      options.TumorFile = "../../../data/small.bam";

      SomaticMutationPileupBuilder pib = new SomaticMutationPileupBuilder(options);

      //Assert.IsNotNull(pib.Chromosomes);

      //Assert.AreEqual(66, pib.Chromosomes.Count);
      //Assert.AreEqual("chr1", pib.Chromosomes.First());
      //Assert.AreEqual("chrY_JH584303_random", pib.Chromosomes.Last());
    }
  }
}
