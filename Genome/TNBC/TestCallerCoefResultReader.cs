using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CQS.Genome.TNBC
{
  [TestFixture]
  public class TestCallerCoefResultReader
  {
    [Test]
    public void TestRead()
    {
      var ccrs = new CallerResultReader().ReadFromFile(@"../../../data/tnbc_call_coef.csv");
      Assert.AreEqual(19, ccrs.Count);
      Assert.AreEqual(0.17, ccrs[0].Items[TNBCSubtype.IM].Coef, 0.01);
      Assert.AreEqual(-0.49, ccrs[0].Items[TNBCSubtype.BL1].Coef, 0.01);
    }
  }
}
