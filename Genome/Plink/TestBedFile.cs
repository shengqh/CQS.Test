using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Genome.Plink
{
  [TestFixture]
  public class TestBedFile
  {
    [Test]
    public void TestMethod()
    {
      var fileName = @"H:\shengquanhu\projects\genetics_data_import\plink\Kasasbeh_PAR1_704_postQC_rm7030.bed";
      using (var reader = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
      {
        var magic = reader.ReadBytes(3);
        Assert.AreEqual(108, magic[0]);
        Assert.AreEqual(27, magic[1]);
        var isSNPMajor = 1 == magic[2];


      }

    }
  }
}
