using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CQS.Genome.Feature;

namespace CQS.Genome.SmallRNA
{
  [TestFixture]
  public class TestSmallRNACountProcessorOptions
  {
    [Test]
    public void Test()
    {
      var features = new SmallRNACountProcessorOptions()
      {
        CoordinateFile = "../../../data/hg19_smallrna_test.bed",
        FastaFile = "../../../data/hg19_smallrna_test.bed.fa"
      }.GetSequenceRegions();

      Assert.AreEqual(3, features.Count);
      var lst = features.GroupByName();
      Assert.AreEqual(3, lst.Count);
      var group = lst.GroupBySequence();
      Assert.AreEqual(3, group.Count);
    }
  }
}
