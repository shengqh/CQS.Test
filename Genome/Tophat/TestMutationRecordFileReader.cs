using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CQS.Genome.Tophat;

namespace CQS.Genome.Tophat
{
  [TestFixture]
  public class TestMutationRecordFileReader
  {
    [Test]
    public void TestRead()
    {
      var lst = new MutationRecordFileReader().ReadFromFile(@"../../data/LB_122210_CDJ_snp.record");
      Assert.AreEqual(641, lst.Count);
      Assert.AreEqual("10", lst[0].Chr);
      Assert.AreEqual(102295836, lst[0].Position);
      Assert.AreEqual("X", lst.Last().Chr);
      Assert.AreEqual(48418659, lst.Last().Position);
    }
  }
}
