using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Rnaediting
{
  [TestFixture]
  public class TestDarnedReader
  {
    [Test]
    public void Test()
    {
      var datafile = "../../../data/darned_rnaediting.txt";
      var data = new DarnedReader().ReadFromFile(datafile);
      Assert.AreEqual(57, data.Count);
      Assert.AreEqual("4", data[0].Chrom);
      Assert.AreEqual(250721, data[0].Coordinate);
      Assert.AreEqual('-', data[0].Strand);
      Assert.AreEqual('A', data[0].NucleotideInChromosome);
      Assert.AreEqual('I', data[0].NucleotideInRNA);
      Assert.AreEqual("", data[0].Gene);
      Assert.AreEqual('O', data[0].SeqReg);
      Assert.AreEqual(' ', data[0].ExReg);
      Assert.AreEqual("DIENCEPHALON", data[0].Source);
      Assert.AreEqual("19478186", data[0].PubmedId);
    }
  }
}
