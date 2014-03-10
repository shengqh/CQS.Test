using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome
{
  [TestFixture]
  public class TestSequenceRegionUtils
  {
    private string namelocations = "(mmu-let-7a-1-5p:TGAGGTAGTAGGTTGTATAGTT)13:48633608-48633629:-,(mmu-let-7a-2-5p:TGAGGTAGTAGGTTGTATAGTT)9:41344815-41344836:+";
    private string location = "13:48633608-48633629:-";

    [Test]
    public void TestNameLocations()
    {
      var locs = SequenceRegionUtils.ParseNameLocations<SequenceRegion>(namelocations);
      Assert.AreEqual(2, locs.Count);
      
      Assert.AreEqual("mmu-let-7a-1-5p:TGAGGTAGTAGGTTGTATAGTT", locs[0].Name);
      Assert.AreEqual("13", locs[0].Seqname);
      Assert.AreEqual(48633608, locs[0].Start);
      Assert.AreEqual(48633629, locs[0].End);
      Assert.AreEqual('-', locs[0].Strand);

      Assert.AreEqual("mmu-let-7a-2-5p:TGAGGTAGTAGGTTGTATAGTT", locs[1].Name);
      Assert.AreEqual("9", locs[1].Seqname);
      Assert.AreEqual(41344815, locs[1].Start);
      Assert.AreEqual(41344836, locs[1].End);
      Assert.AreEqual('+', locs[1].Strand);

      Assert.AreEqual(namelocations, SequenceRegionUtils.GetNameLocations(locs));
    }

    [Test]
    public void TestLocation()
    {
      var loc = SequenceRegionUtils.ParseLocation<SequenceRegion>(location);
      Assert.AreEqual("13", loc.Seqname);
      Assert.AreEqual(48633608, loc.Start);
      Assert.AreEqual(48633629, loc.End);
      Assert.AreEqual('-', loc.Strand);

      Assert.AreEqual(location, SequenceRegionUtils.GetLocation(loc));
    }
  }
}
