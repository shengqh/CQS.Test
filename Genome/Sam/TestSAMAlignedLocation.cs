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

      Assert.IsNull(locNoMutation.GetNotGsnapMismatch(qry));

      var locPositive = new SamAlignedLocation(null)
      {
        Strand = '+',
        NumberOfMismatch = 1,
        MismatchPositions = "22C0"
      };

      var retPositive = locPositive.GetNotGsnapMismatch(qry);
      Assert.IsNotNull(retPositive);
      Assert.AreEqual('C', retPositive.RefAllele);
      Assert.AreEqual('A', retPositive.SampleAllele);

      var locNegative = new SamAlignedLocation(null)
      {
        Strand = '-',
        NumberOfMismatch = 1,
        MismatchPositions = "0C22"
      };

      var retNegative = locNegative.GetNotGsnapMismatch(qry);
      Assert.IsNotNull(retNegative);
      Assert.AreEqual('G', retNegative.RefAllele);
      Assert.AreEqual('A', retNegative.SampleAllele);
    }

    [Test]
    public void TestGetGsnapMismatches()
    {
      var qry = "GTTTCTGTAGTGTAGTGGTTATCACGTTCGCCT";

      var sloc = new SamAlignedLocation(new SAMAlignedItem()
      {
        Sequence = qry
      })
      {
        Strand = '+',
        NumberOfMismatch = 1,
        NumberOfNoPenaltyMutation = 2,
        Cigar = "GTTTCc.TAGTGTAGTGGTTATCAC.TTCGCCT",
        MismatchPositions = "5CA18A7"
      };

      var polys = sloc.GetGsnapMismatches();
      Assert.AreEqual(5, polys[0].Position);
      Assert.AreEqual('C', polys[0].RefAllele);
      Assert.AreEqual('T', polys[0].SampleAllele);

      Assert.AreEqual(6, polys[1].Position);
      Assert.AreEqual('A', polys[1].RefAllele);
      Assert.AreEqual('G', polys[1].SampleAllele);

      Assert.AreEqual(25, polys[2].Position);
      Assert.AreEqual('A', polys[2].RefAllele);
      Assert.AreEqual('G', polys[2].SampleAllele);
    }
  }
}
