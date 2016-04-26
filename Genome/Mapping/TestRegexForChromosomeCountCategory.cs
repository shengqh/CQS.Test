using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CQS.Genome.Mapping
{
  [TestFixture]
  public class TestRegexForChromosomeCountCategory
  {
    [Test]
    public void Test()
    {
      Regex myreg = new Regex("_(.+?);");
      Assert.AreEqual("Bacteria", myreg.Match("CP003909.1943765.1946655_Bacteria;Proteobacteria;").Groups[1].Value);
    }
  }
}
