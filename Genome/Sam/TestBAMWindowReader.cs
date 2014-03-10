using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Sam
{
  [TestFixture]
  public class TestBAMWindowReader
  {
    [Test]
    public void Test()
    {
      var bamfile = "../../data/small.bam";
      Assert.IsTrue(SAMUtils.IsSortedByCoordinate(bamfile));

      var reader = new BAMWindowReader(bamfile);
      var lines = reader.ReadHeaders();
      Assert.IsTrue(lines.First().StartsWith("@HD"));
      Assert.IsTrue(lines.Last().StartsWith("@PG"));

      var sam = reader.ReadSAMAlignedSequence();
      Assert.IsNotNull(sam);
      Assert.AreEqual("HWI-ST829:174:C1A0GACXX:5:1108:12447:66009", sam.QName);
      Assert.AreEqual("HWI-ST829:174:C1A0GACXX:5:1108:12447:66009	256	chr1	3020293	0	101M	*	0	0	GTCTACCTTTTCAGGTGTGTTAGGGTGCCCTGGACTGGGCGAAGTGGGTGTTCTGGGTTCTGATGATGGTGAGTGGTCCTGGTTTCTGTTAGTAGGATTCT	CCCFFFFFHHHHDGI?ECFEHIGIJFEHIGEHHEGIIIGDHFFGFGIGHIHGJJJJH=CEFFCFFDFEECCCEDDBCCDDCCACDDDDDDCDCDDDCCDCC	AS:i:0	XN:i:0	XM:i:0	XO:i:0	XG:i:0	NM:i:0	MD:Z:101	YT:Z:UU	NH:i:10	CC:Z:=	CP:i:86775490	HI:i:0", reader.SAMToString(sam));
    }
  }
}
