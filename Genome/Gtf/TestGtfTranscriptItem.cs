using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Gtf
{
  [TestFixture]
  public class TestGtfTranscriptItem
  {
    [Test]
    public void TestSameTranscript()
    {
      GtfTranscriptItemFile file = new GtfTranscriptItemFile();
      file.Open(TestGtfItemFile.filename);
      GtfTranscriptItem item = file.Next();
      GtfTranscriptItem next = file.Next();

      for (int i = 1; i < 11; i++)
      {
        Assert.IsTrue(item.IsSameTranscript(item[i]));
        Assert.IsFalse(next.IsSameTranscript(item[i]));
      }
    }

    [Test]
    public void TestFindItemIndex()
    {
      GtfTranscriptItemFile file = new GtfTranscriptItemFile();
      file.Open(TestGtfItemFile.filename);
      GtfTranscriptItem item = file.Next();
      GtfTranscriptItem next = file.Next();

      int index = item.FindItemIndex(134290, 134380);
      Assert.IsTrue(index >= 0);
      GtfItem find = item[index];
      Assert.AreEqual(2, find.ExonNumber);

      Assert.AreEqual(-1, item.FindItemIndex(1342900, 1343800));
      Assert.AreEqual(-1, item.FindItemIndex(134, 1343));
    }
  }
}
