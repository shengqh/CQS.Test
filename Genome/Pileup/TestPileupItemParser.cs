using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Pileup
{
  [TestFixture]
  public class TestPileupItemParser
  {
    private static string line = "seq2\t156\tA\t7\t.$.,.^7.,+2AG-2tc+2AG-2tcG\t<975;:<\t4\t.<,>..\t<<<<<<";

    [Test]
    public void TestParseNoInsertionDeletion()
    {
      var item = new PileupItemParser(0, 0, true, false, false, 3).GetValue(line);
      Assert.IsNotNull(item);
      Assert.AreEqual(7, item.Samples[0].Count);
      
      Assert.AreEqual("seq2", item.SequenceIdentifier);
      Assert.AreEqual(156, item.Position);
      Assert.AreEqual('A', item.Nucleotide);
      Assert.AreEqual(2, item.Samples.Count);
      Assert.AreEqual(7, item.Samples[0].Count);
      Assert.AreEqual(4, item.Samples[1].Count);

      //The matched base from end of read
      Assert.AreEqual(StrandType.FORWARD, item.Samples[0][0].Strand);
      Assert.AreEqual(AlignedEventType.MATCH, item.Samples[0][0].EventType);
      Assert.AreEqual(PositionType.END, item.Samples[0][0].Position);
      Assert.AreEqual("A", item.Samples[0][0].Event);
      Assert.AreEqual('<' - 33, item.Samples[0][0].Score);
      Assert.AreEqual(0, item.Samples[0][0].ReadMappingQuality);

      //The matched bases from forward strand read
      foreach (int i in new int[] { 1, 3 })
      {
        Assert.AreEqual(StrandType.FORWARD, item.Samples[0][i].Strand);
        Assert.AreEqual(AlignedEventType.MATCH, item.Samples[0][i].EventType);
        Assert.AreEqual(PositionType.MIDDLE, item.Samples[0][i].Position);
        Assert.AreEqual("A", item.Samples[0][i].Event);
        Assert.AreEqual(0, item.Samples[0][i].ReadMappingQuality);
      }
      Assert.AreEqual('9' - 33, item.Samples[0][1].Score);
      Assert.AreEqual('5' - 33, item.Samples[0][3].Score);

      //The matched bases from reverse strand read
      foreach (int i in new int[] { 2, 5 })
      {
        Assert.AreEqual(StrandType.REVERSE, item.Samples[0][i].Strand);
        Assert.AreEqual(AlignedEventType.MATCH, item.Samples[0][i].EventType);
        Assert.AreEqual(PositionType.MIDDLE, item.Samples[0][i].Position);
        Assert.AreEqual("A", item.Samples[0][i].Event);
        Assert.AreEqual(0, item.Samples[0][i].ReadMappingQuality);
      }
      Assert.AreEqual('7' - 33, item.Samples[0][2].Score);
      Assert.AreEqual(':' - 33, item.Samples[0][5].Score);

      //The matched base from start of read
      Assert.AreEqual(StrandType.FORWARD, item.Samples[0][4].Strand);
      Assert.AreEqual(AlignedEventType.MATCH, item.Samples[0][4].EventType);
      Assert.AreEqual(PositionType.START, item.Samples[0][4].Position);
      Assert.AreEqual("A", item.Samples[0][4].Event);
      Assert.AreEqual(';' - 33, item.Samples[0][4].Score);
      Assert.AreEqual('7' - 33, item.Samples[0][4].ReadMappingQuality);

      //The insertions and deletions had been ignored
      //The mismatched base
      Assert.AreEqual(StrandType.FORWARD, item.Samples[0][6].Strand);
      Assert.AreEqual(AlignedEventType.MISMATCH, item.Samples[0][6].EventType);
      Assert.AreEqual(PositionType.MIDDLE, item.Samples[0][6].Position);
      Assert.AreEqual("G", item.Samples[0][6].Event);
      Assert.AreEqual('<' - 33, item.Samples[0][6].Score);
      Assert.AreEqual(0, item.Samples[0][6].ReadMappingQuality);


      //The matched bases from forward strand read
      foreach (int i in new int[] { 0, 1, 2, 3 })
      {
        Assert.AreEqual(AlignedEventType.MATCH, item.Samples[1][i].EventType);
        Assert.AreEqual(PositionType.MIDDLE, item.Samples[1][i].Position);
        Assert.AreEqual("A", item.Samples[1][i].Event);
        Assert.AreEqual(0, item.Samples[1][i].ReadMappingQuality);
        Assert.AreEqual('<' - 33, item.Samples[1][i].Score);
      }
      Assert.AreEqual(StrandType.FORWARD, item.Samples[1][0].Strand);
      Assert.AreEqual(StrandType.REVERSE, item.Samples[1][1].Strand);
      Assert.AreEqual(StrandType.FORWARD, item.Samples[1][2].Strand);
      Assert.AreEqual(StrandType.FORWARD, item.Samples[1][3].Strand);

      //foreach (var ss in item.Samples[0])
      //{
      //  Console.WriteLine("{0}\t{1}", ss.Base, ss.Score);
      //}
    }

    [Test]
    public void TestParseInsertionDeletion()
    {
      var item = new PileupItemParser(0, 0, false, false, false, 3).GetValue(line);
      Assert.IsNotNull(item);
      Assert.AreEqual(11, item.Samples[0].Count);

      //other base are equals to the TestParseNoInsertionDeletion

      //The base from insertion
      foreach (int i in new int[] { 6, 8 })
      {
        Assert.AreEqual(StrandType.FORWARD, item.Samples[0][i].Strand);
        Assert.AreEqual(AlignedEventType.INSERTION, item.Samples[0][i].EventType);
        Assert.AreEqual(PositionType.MIDDLE, item.Samples[0][i].Position);
        Assert.AreEqual("+2AG", item.Samples[0][i].Event);
        Assert.AreEqual(0, item.Samples[0][i].Score);
        Assert.AreEqual(0, item.Samples[0][i].ReadMappingQuality);
      }

      //The base from deletion
      foreach (int i in new int[] { 7, 9 })
      {
        Assert.AreEqual(StrandType.REVERSE, item.Samples[0][i].Strand);
        Assert.AreEqual(AlignedEventType.DELETION, item.Samples[0][i].EventType);
        Assert.AreEqual(PositionType.MIDDLE, item.Samples[0][i].Position);
        Assert.AreEqual("-2TC", item.Samples[0][i].Event);
        Assert.AreEqual(0, item.Samples[0][i].Score);
        Assert.AreEqual(0, item.Samples[0][i].ReadMappingQuality);
      }
    }

    [Test]
    public void TestParseFilterByCount()
    {
      var item = new PileupItemParser(5, 0, false, false, false, 3).GetValue(line);
      Assert.IsNull(item);
    }

    [Test]
    public void TestParseFilterByBaseMappingQuality()
    {
      var item = new PileupItemParser(0, 25, true, true, false, 3).GetValue(line);
      Assert.IsNotNull(item);
      Assert.AreEqual(4, item.Samples[0].Count);
      Assert.AreEqual(27, item.Samples[0][0].Score);
      Assert.AreEqual("A", item.Samples[0][0].Event);
      Assert.AreEqual(26, item.Samples[0][1].Score);
      Assert.AreEqual("A", item.Samples[0][1].Event);
      Assert.AreEqual(25, item.Samples[0][2].Score);
      Assert.AreEqual("A", item.Samples[0][2].Event);
      Assert.AreEqual(27, item.Samples[0][3].Score);
      Assert.AreEqual("G", item.Samples[0][3].Event);
    }

    [Test]
    public void TestErrorLine()
    {
      var parser = new PileupItemParser(0, 0, true, true, false, 3);

      var errorline = "3\t383725\tT\t27\t....,.,..,.,..,,,........^S,^S,\tIFJI<EHGIHF>GIIHGEIIGH=D@GA\t0\t\t";
      var item = parser.GetValue(errorline);
      Assert.AreEqual(2, item.Samples.Count);

      errorline = "2\t43639\tT\t0\t\t\t37\t<<<<<>><<<<<<><<<<<><<<<<<<<>,,..,,.,\tHHGHHGGDHHFEHEGC9HHBFEBCFHHHEHHHD6HHD";
      item = parser.GetValue(errorline);
      Assert.AreEqual(2, item.Samples.Count);
    }

    [Test]
    public void TestErrorLine2()
    {
      var parser = new PileupItemParser(0, 0, true, true, false, 3);

      var errorline = "4\t86101\tG\t47\t,+1c,+1c,+1c.+1C.+1C,+1c..+1C.+1C.+1C,+1c.+1C,+1c.+1C.+1C$.+1C.+1C,+1c.+1C.+1C.+1C,+1c.+1C.+1C.+1C.+1C.+1C.+1C.+1C.+1C.+1C.+1C,+1c.+1C.+1C.+1C.+1C,+1c,+1c,+1c.+1C,+1c,+1c,+1c.+1C.+1C^H,+1c\tBCDCDBDEECBCB?CCEDCECCC>?CA@3CCDACCC>>DBDAA?>@.\t37\t,+1c.+1C,+1c.+1C,+1c.+1C,+1c.+1C.+1C.+1C.+1C.+1C$,,.+1C.+1C.+1C.+1C.+1C.+1C.+1C.+1C.+1C,+1c.+1C,+1c,+1c,+1c,+1c,+1c,+1c.+1C,+1c,+1c,+1c,+1c.+1C\tDCC;>DDC?CD3DD<D5DA=;?DF??BCB<6E=546>";
      var item = parser.GetValue(errorline);
      Assert.AreEqual(2, item.Samples.Count);
    }
  }
}
