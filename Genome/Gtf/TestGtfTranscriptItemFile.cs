using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Gtf
{
  [TestFixture]
  public class TestGtfTranscriptItemFile
  {
    [Test]
    public void TestNextTranscriptItem()
    {
      GtfTranscriptItemFile file = new GtfTranscriptItemFile();
      file.Open(TestGtfItemFile.filename);
      GtfTranscriptItem tr = file.Next(false);
      Assert.AreEqual(1, tr.Count);
      Assert.AreEqual("ENST00000578976", tr[0].TranscriptId);

      tr = file.Next();
      Assert.AreEqual(11, tr.Count);
      foreach (var tritem in tr)
      {
        Assert.AreEqual("ENST00000327822", tritem.TranscriptId);
      }

      var item = (tr)[10];
      Assert.AreEqual("GL000213.1", item.Seqname);
      Assert.AreEqual("protein_coding", item.Source);
      Assert.AreEqual("exon", item.Feature);
      Assert.AreEqual(138767, item.Start);
      Assert.AreEqual(139339, item.End);
      Assert.AreEqual(".", item.Score);
      Assert.AreEqual('-', item.Strand);
      Assert.AreEqual('.', item.Frame);
      Assert.AreEqual(" gene_id \"ENSG00000237375\"; transcript_id \"ENST00000327822\"; exon_number \"1\"; gene_name \"BX072566.1\"; gene_biotype \"protein_coding\"; transcript_name \"BX072566.1-201\";", item.Attributes);

      GtfTranscriptItem item2 = file.Next();
      Assert.AreEqual("ENST00000459553", item2[0].TranscriptId);
    }

    [Test]
    public void TestNextTranscriptExonItem()
    {
      GtfTranscriptItemFile file = new GtfTranscriptItemFile();
      file.Open(TestGtfItemFile.filename);
      GtfTranscriptItem tr = file.Next(true);
      Assert.AreEqual(11, tr.Count);
      foreach (var tritem in tr)
      {
        Assert.AreEqual("ENST00000327822", tritem.TranscriptId);
      }

      var item = (tr)[10];
      Assert.AreEqual("GL000213.1", item.Seqname);
      Assert.AreEqual("protein_coding", item.Source);
      Assert.AreEqual("exon", item.Feature);
      Assert.AreEqual(138767, item.Start);
      Assert.AreEqual(139339, item.End);
      Assert.AreEqual(".", item.Score);
      Assert.AreEqual('-', item.Strand);
      Assert.AreEqual('.', item.Frame);
      Assert.AreEqual(" gene_id \"ENSG00000237375\"; transcript_id \"ENST00000327822\"; exon_number \"1\"; gene_name \"BX072566.1\"; gene_biotype \"protein_coding\"; transcript_name \"BX072566.1-201\";", item.Attributes);
    }
  }
}
