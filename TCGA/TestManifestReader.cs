using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.TCGA
{
  [TestFixture]
  public class TestManifestReader
  {
    [Test]
    public void TestRead()
    {
      var map = ManifestReader.ReadFromFile("../../../data/snp_MANIFEST.txt");
      Assert.AreEqual(774, map.Count);
      Assert.AreEqual("4c242b6fee76f26f44c7b9a8f01a3bf0", map["changes_dcc.txt"]);
    }
  }
}
