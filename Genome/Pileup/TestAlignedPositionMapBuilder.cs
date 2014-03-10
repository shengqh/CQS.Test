using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Pileup
{
  [TestFixture]
  public class TestAlignedPositionMapBuilder
  {
    [Test]
    public void TestMappingQuality()
    {
      var options = new AlignedPositionMapBuilderOptions();
      options.MinimumReadQuality = 255;
      var builder = new AlignedPositionMapBuilder(options, "../../data/small_2.sam");
      var item = builder.Next();
      //the maximum MapQ is 50, so no reads passed the criteria
      Assert.IsNull(item);

      options.MinimumReadQuality = 5;
      builder = new AlignedPositionMapBuilder(options, "../../data/small_2.sam");
      item = builder.Next();
      Assert.IsNotNull(item);
    }

    [Test]
    public void TestPileup()
    {
      var options = new AlignedPositionMapBuilderOptions();
      options.MinimumReadQuality = 5;
      var builder = new AlignedPositionMapBuilder(options, "../../data/small_2.sam");

      AlignedPositionMap item;
      while ((item = builder.Next()) != null)
      {
        if (3589590 == item.Position)
        {
          Assert.IsTrue(item.ContainsKey("T"));
          Assert.AreEqual(2, item["T"].Count);
          Assert.AreEqual(40, (int)item["T"][0].Score - 33);
          Assert.AreEqual(39, item["T"][0].Distance);
          Assert.AreEqual(41, (int)item["T"][1].Score - 33);
          Assert.AreEqual(22, item["T"][1].Distance);

          Assert.IsTrue(item.ContainsKey("INSERTION_T"));
          Assert.AreEqual(1, item["INSERTION_T"].Count);
          Assert.AreEqual(41, (int)item["INSERTION_T"][0].Score - 33);
          Assert.AreEqual(21, item["INSERTION_T"][0].Distance);
        }

        if (3589733 == item.Position)
        {
          Assert.IsTrue(item.ContainsKey("A"));
          Assert.AreEqual(2, item["A"].Count);
          Assert.AreEqual(41, (int)item["A"][0].Score - 33);
          Assert.AreEqual(71, item["A"][0].Distance);
          Assert.AreEqual(36, (int)item["A"][1].Score - 33);
          Assert.AreEqual(12, item["A"][1].Distance);

          Assert.IsTrue(item.ContainsKey("C"));
          Assert.AreEqual(1, item["C"].Count);
          Assert.AreEqual(9, (int)item["C"][0].Score - 33);
          Assert.AreEqual(48, item["C"][0].Distance);
        }

        //Console.WriteLine(item.Position);
        //foreach (var eve in item)
        //{
        //  foreach (var p in eve.Value)
        //  {
        //    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}", eve.Key, (int)p.Score - 33, p.Distance, p.EventLength);
        //  }
        //}
      }
    }
  }
}
