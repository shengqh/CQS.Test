using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Genome.Bacteria
{
  [TestFixture]
  public class TestGffToBedConverter
  {
    [Test]
    public void TestConvert()
    {
      var options = new GffToBedConverterOptions()
      {
        InputFile = @"H:\shengquanhu\database\bacteria\NC_012803.gff",
        OutputFile = @"H:\shengquanhu\database\bacteria\NC_012803.bed"
      };

      new GffToBedConverter(options).Process();
    }
  }
}
