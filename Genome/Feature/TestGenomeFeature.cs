using CQS.Genome.Bed;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Genome.Feature
{
  [TestFixture]
  public class TestGenomeFeature
  {
    [Test]
    public void TestGetGenomeLocusFromInternalLocus()
    {
      var gf = new GenomeFeature();
      gf.Name = "Test";

      /**********0123456789**********0123456789**********/
      gf.Blocks.Add(new BedItem() { Start = 10, End = 20, Strand = '+' });
      gf.Blocks.Add(new BedItem() { Start = 30, End = 40, Strand = '+' });
      gf.InitializePositions();

      /**********0aaaa56789**********0123456789**********/
      var loc = gf.GetGenomeLocusFromInternalLocus(1, 5);
      Assert.IsNotNull(loc);
      Assert.AreEqual(11, loc.Start);
      Assert.AreEqual(15, loc.End);

      /**********0123456789**********0aaaa56789**********/
      loc = gf.GetGenomeLocusFromInternalLocus(11, 15);
      Assert.IsNotNull(loc);
      Assert.AreEqual(31, loc.Start);
      Assert.AreEqual(35, loc.End);

      /**********0123456789**********0aaaa56789**********/
      Assert.IsNull(gf.GetGenomeLocusFromInternalLocus(22, 26));


      /**********9876543210**********9876543210**********/
      gf.Blocks.ForEach(m => m.Strand = '-');
      gf.InitializePositions();

      /**********9876543210**********98765aaaa0**********/
      loc = gf.GetGenomeLocusFromInternalLocus(1, 5);
      Assert.IsNotNull(loc);
      Assert.AreEqual(35, loc.Start);
      Assert.AreEqual(39, loc.End);

      /**********98765aaaa0**********9876543210**********/
      loc = gf.GetGenomeLocusFromInternalLocus(11, 15);
      Assert.IsNotNull(loc);
      Assert.AreEqual(15, loc.Start);
      Assert.AreEqual(19, loc.End);

      /**********9876543aaa**********aa76543210**********/
      loc = gf.GetGenomeLocusFromInternalLocus(8, 13);
      Assert.IsNull(loc);
 
    }
  }
}
