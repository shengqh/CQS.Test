﻿using System;
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

    [Test]
    public void TestOverlap()
    {
      var loc1 = new SequenceRegion()
      {
        Seqname = "2",
        Start = 12227067,
        End = 12227087
      };

      var loc2 = new SequenceRegion()
      {
        Seqname = "1",
        Start = 12227065,
        End = 12227076
      };

      //different chromosomes
      Assert.IsFalse(loc1.Overlap(loc2, 0.0));

      loc1.Seqname = "1";
      Assert.IsTrue(loc1.Overlap(loc2, 0.0));

      loc1.Start = loc2.End + 1;
      Assert.IsFalse(loc1.Overlap(loc2, 0.0));
    }

    SequenceRegion loc1, loc2;

    public void TestCombineDifferntChromosome()
    {
      var locs = InitLocs();
      SequenceRegionUtils.Combine(locs);
      Assert.AreEqual(2, locs.Count);
    }

    [Test]
    public void TestCombineOverlap()
    {
      var locs = InitLocs();
      loc1.Seqname = "1";
      SequenceRegionUtils.Combine(locs);
      Assert.AreEqual(1, locs.Count);
      Assert.AreEqual(12227065, locs[0].Start);
      Assert.AreEqual(12227087, locs[0].End);
    }

    [Test]
    public void TestCombineContain()
    {
      var locs = InitLocs();
      loc1.Seqname = "1";
      loc1.End = 12227075;
      SequenceRegionUtils.Combine(locs);
      Assert.AreEqual(1, locs.Count);
      Assert.AreSame(loc2, locs[0]);
      Assert.AreEqual(12227065, locs[0].Start);
      Assert.AreEqual(12227076, locs[0].End);
    }

    private List<SequenceRegion> InitLocs()
    {
      loc1 = new SequenceRegion()
      {
        Seqname = "2",
        Start = 12227067,
        End = 12227087
      };

      loc2 = new SequenceRegion()
      {
        Seqname = "1",
        Start = 12227065,
        End = 12227076
      };

      var locs = new List<SequenceRegion>(new[] { loc1, loc2 });
      return locs;
    }
  }
}
