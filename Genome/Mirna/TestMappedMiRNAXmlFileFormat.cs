using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace CQS.Genome.Mirna
{
  [TestFixture]
  public class TestMappedMiRNAXmlFileFormat
  {
    private MappedMirnaGroupXmlFileFormat format = new MappedMirnaGroupXmlFileFormat();

    [Test]
    public void TestReadWrite()
    {
      var oldfile = @"../../../data/2570-KCV-01-19.bam.count.mapped.xml";

      var mirnas = format.ReadFromFile(oldfile);
      Assert.AreEqual(347, mirnas.Count);
      Assert.AreEqual(2, mirnas[0].Count);
      Assert.AreEqual("mmu-let-7a-1-3p", mirnas[0][0].Name);
      Assert.AreEqual("mmu-let-7c-2-3p", mirnas[0][1].Name);
      var mirna = mirnas[0][0];
      Assert.AreEqual("CTATACAATCTACTGTCTTTCC", mirna.Sequence);
      Assert.AreEqual(1, mirna.MappedRegions.Count);
      Assert.AreEqual(4, mirna.MappedRegions[0].Mapped[0].AlignedLocations.Count);

      var newfile = Path.ChangeExtension(oldfile, ".temp.xml");
      format.WriteToFile(newfile, mirnas);
      FileAssert.AreEqual(oldfile, newfile);
      File.Delete(newfile);
    }
  }
}
