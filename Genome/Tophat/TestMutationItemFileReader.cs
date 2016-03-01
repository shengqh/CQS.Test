using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CQS.Genome.Tophat;

namespace CQS.Genome.Tophat
{
  [TestFixture]
  public class TestMutationItemFileReader
  {
    [Test]
    public void TestRead()
    {
      var lst = new MutationItemFileReader().ReadFromFile(@"../../../data/mutation.txt");
      Assert.AreEqual(4, lst.Count);
      Assert.AreEqual("19", lst[0].Chr);
      Assert.AreEqual("MED26", lst[0].Gene);
      Assert.AreEqual("line17970	stopgain SNV	\"MED26:NM_004831:exon3:c.C1442A:p.S481X,\"	19	16687199	16687199	G	T	GT:AD:DP:GQ:PL	\"0/0:104,0:104:99:0,292,3001\"	\"0/1:98,27:126:99:419,0,2535\"	Gain_0	PASS", lst[0].Line);
      Assert.AreEqual(16687199, lst[0].Position);
    }
  }
}
