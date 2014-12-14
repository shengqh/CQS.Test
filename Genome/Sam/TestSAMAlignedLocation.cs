using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Genome.Sam
{
  [TestFixture]
  public class TestSAMAlignedLocation
  {
    [Test]
    public void TestMethod()
    {
      var qry = "TCCTGTACTGAGCTGCCCCGAGA";

      var locNoMutation = new SamAlignedLocation(null)
      {
        Strand = '+',
        NumberOfMismatch = 0,
        MismatchPositions = "23"
      };

      Assert.IsNull(locNoMutation.GetMutation(qry));

      var locPositive = new SamAlignedLocation(null)
      {
        Strand = '+',
        NumberOfMismatch = 1,
        MismatchPositions = "22C0"
      };

      var retPositive = locPositive.GetMutation(qry);
      Assert.IsNotNull(retPositive);
      Assert.AreEqual('C', retPositive.RefAllele);
      Assert.AreEqual('A', retPositive.SampleAllele);

      var locNegative = new SamAlignedLocation(null)
      {
        Strand = '-',
        NumberOfMismatch = 1,
        MismatchPositions = "0C22"
      };

      var retNegative = locNegative.GetMutation(qry);
      Assert.IsNotNull(retNegative);
      Assert.AreEqual('G', retNegative.RefAllele);
      Assert.AreEqual('A', retNegative.SampleAllele);
    }
  }
}
