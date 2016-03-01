using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.CNV
{
  [TestFixture]
  public class TestCnvnatorItemExtension
  {
    [Test]
    public void TestFilter()
    {
      var file = "../../../data/2110.call";
      var items = new CnvnatorReader().ReadFromFile(file);
      items.FilterByPvalue(0.01);
      Assert.AreEqual(7, items.Count);
    }
  }
}
