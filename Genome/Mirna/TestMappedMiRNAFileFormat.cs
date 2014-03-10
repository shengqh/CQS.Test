using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace CQS.Genome.Mirna
{
  [TestFixture]
  public class TestMappedMiRNAFileFormat
  {
  //  private MappedMiRNAFileFormat format = new MappedMiRNAFileFormat(new int[] { 0, 1, 2 });

  //  [Test]
  //  public void TestReadWrite()
  //  {
  //    var oldfile = @"../../data/mirna.mapped";

  //    var mirnas = format.ReadFromFile(oldfile);
  //    Assert.AreEqual(2, mirnas.Count);
  //    Assert.AreEqual("mmu-let-7a-1-3p:CTATACAATCTACTGTCTTTCC", mirnas[0].Name);
  //    Assert.AreEqual(1, mirnas[0].Count);
  //    Assert.AreEqual(3, mirnas[0][0].Mapped[0].Count);
  //    Assert.AreEqual(0, mirnas[0][0].Mapped[1].Count);
  //    Assert.AreEqual(0, mirnas[0][0].Mapped[2].Count);

  //    Assert.AreEqual("mmu-let-7a-1-5p:TGAGGTAGTAGGTTGTATAGTT", mirnas[1].Name);
  //    Assert.AreEqual(1, mirnas[1].Count);
  //    Assert.AreEqual(2, mirnas[1][0].Mapped[0].Count);
  //    Assert.AreEqual(1, mirnas[1][0].Mapped[1].Count);
  //    Assert.AreEqual(0, mirnas[1][0].Mapped[2].Count);

  //    var qm = mirnas[1][0].Mapped[1][0];
  //    Assert.AreEqual("HWI-ST508:275:D2A2JACXX:3:2201:8264:53077", qm.Qname);
  //    Assert.AreEqual("AAACTATACAACCTACTACCTC", qm.Sequence);
  //    Assert.AreEqual(1, qm.QueryCount);
  //    Assert.AreEqual(0, qm.AlignmentScore);

  //    Assert.AreEqual(2, qm.Locations.Count);
  //    Assert.AreEqual("mmu-let-7a-1-5p:TGAGGTAGTAGGTTGTATAGTT", qm.Locations[0].Name);
  //    Assert.AreEqual("13", qm.Locations[0].Seqname);
  //    Assert.AreEqual(48633608, qm.Locations[0].Start);
  //    Assert.AreEqual(48633629, qm.Locations[0].End);
  //    Assert.AreEqual('-', qm.Locations[0].Strand);

  //    Assert.AreEqual("mmu-let-7a-2-5p:TGAGGTAGTAGGTTGTATAGTT", qm.Locations[1].Name);
  //    Assert.AreEqual("9", qm.Locations[1].Seqname);
  //    Assert.AreEqual(41344815, qm.Locations[1].Start);
  //    Assert.AreEqual(41344836, qm.Locations[1].End);
  //    Assert.AreEqual('+', qm.Locations[1].Strand);

  //    var newfile = oldfile + ".temp";
  //    format.WriteToFile(newfile, mirnas);
  //    FileAssert.AreEqual(oldfile, newfile);
  //    File.Delete(newfile);
  //  }
  }
}
