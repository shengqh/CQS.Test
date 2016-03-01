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
  public class TestPlinkBedRandomFile
  {
    [Test]
    public void TestMethod()
    {
      var file = new PlinkBedRandomFile();
      file.OpenBinaryFile("../../../data/plink/plink.bed");
      try
      {
        var data = file.Read("RS168753");

        Assert.IsTrue(data[0, 0]);
        Assert.IsFalse(data[0, 1]);
        Assert.IsFalse(data[0, 2]);
        Assert.IsFalse(data[0, 3]);
        Assert.IsTrue(data[0, 4]);

        Assert.IsTrue(data[1, 0]);
        Assert.IsFalse(data[1, 1]);
        Assert.IsTrue(data[1, 2]);
        Assert.IsTrue(data[1, 3]);
        Assert.IsTrue(data[1, 4]);

        data = file.Read("RS11267092");

        Assert.IsTrue(data[0, 0]);
        Assert.IsFalse(data[0, 1]);
        Assert.IsFalse(data[0, 2]);
        Assert.IsFalse(data[0, 3]);
        Assert.IsTrue(data[0, 4]);

        Assert.IsTrue(data[1, 0]);
        Assert.IsTrue(data[1, 1]);
        Assert.IsTrue(data[1, 2]);
        Assert.IsFalse(data[1, 3]);
        Assert.IsTrue(data[1, 4]);
      }
      finally
      {
        file.Close();
      }
    }
  }
}
