using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Genome.CNV
{
  [TestFixture]
  public class TestCnMOPSCallProcessor
  {
    [Test]
    public void Test()
    {
      var data = new CnMOPsItemReader().ReadFromFile("../../../data/cnmops.txt");
      var focus_before = data.Where(l => l.Start > 3000000 && l.End < 9000000).ToList();
      var ranges = CnMOPSCallProcessor.MergeRange(focus_before);

      var focus = ranges["5"];

      Assert.AreEqual(1, focus.Count);
      Assert.AreEqual(3000100, focus[0].Start);
      Assert.AreEqual(8494963, focus[0].End);
      //focus.ForEach(l =>
      //{
      //  Console.WriteLine("{0}-{1}", l.Start, l.End);
      //  l.Items.ForEach(m =>
      //  {
      //    Console.WriteLine("\t{0}-{1}\t{2}\t{3}", m.Start, m.End, m.FileName, m.CN);
      //  });
      //});

    }
  }
}
