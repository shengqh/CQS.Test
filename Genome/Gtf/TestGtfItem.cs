using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Gtf
{
  [TestFixture]
  public class TestGtfItem
  {
    [Test]
    public void TestGetLength()
    {
      var item = new GtfItem();
      
      item.Start = -1;
      item.End = -1;
      Assert.AreEqual(0, item.Length);

      item.Start = 100;
      item.End = 200;
      Assert.AreEqual(101, item.Length);

      item.Start = 200;
      item.End = 100;
      Assert.AreEqual(101, item.Length);
    }

    [Test]
    public void TestSetAttribute()
    {
      GtfItem item = new GtfItem();
      item.Attributes = " gene_id \"ENSG00000237375\"; transcript_id \"ENST00000327822\"; exon_number \"2\"; gene_name \"BX072566.1\"; gene_biotype \"protein_coding\"; transcript_name \"BX072566.1-201\";";
      Assert.AreEqual("ENSG00000237375", item.GeneId);
      Assert.AreEqual("ENST00000327822", item.TranscriptId);
      Assert.AreEqual(2, item.ExonNumber);
    }

    [Test]
    public void TestIsSameTranscript()
    {
      GtfItem item = new GtfItem();
      GtfItem item2 = new GtfItem();

      item.Attributes = " gene_id \"ENSG00000237375\"; transcript_id \"ENST00000327822\"; exon_number \"2\"; gene_name \"BX072566.1\"; gene_biotype \"protein_coding\"; transcript_name \"BX072566.1-201\";";
      item2.Attributes = " gene_id \"ENSG00000237375\"; transcript_id \"ENST00000327822\"; exon_number \"3\"; gene_name \"BX072566.1\"; gene_biotype \"protein_coding\"; transcript_name \"BX072566.1-201\";";
      Assert.IsTrue(item.IsSameTranscript(item2));
      Assert.IsTrue(item2.IsSameTranscript(item));

      item2.Attributes = " gene_id \"ENSG00000237375\"; transcript_id \"ENST000003278XX\"; exon_number \"3\"; gene_name \"BX072566.1\"; gene_biotype \"protein_coding\"; transcript_name \"BX072566.1-201\";";
      Assert.IsFalse(item.IsSameTranscript(item2));
      Assert.IsFalse(item2.IsSameTranscript(item));
    }
  }
}
