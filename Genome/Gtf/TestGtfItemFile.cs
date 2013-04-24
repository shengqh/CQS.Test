using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Gtf
{
  [TestFixture]
  public class TestGtfItemFile
  {
    public static string filename = "../../data/Homo_sapiens.GRCh37.68.slim.gtf";

    [Test]
    public void TestNext()
    {
      using (GtfItemFile file = new GtfItemFile(filename))
      {
        GtfItem item = file.Next();
        Assert.AreEqual("GL000213.1", item.Seqname);
        Assert.AreEqual("miRNA", item.Source);
        Assert.AreEqual("CDS", item.Feature);
        Assert.AreEqual(104742, item.Start);
        Assert.AreEqual(104817, item.End);
        Assert.AreEqual(".", item.Score);
        Assert.AreEqual('+', item.Strand);
        Assert.AreEqual('.', item.Frame);
        Assert.AreEqual(" gene_id \"ENSG00000265283\"; transcript_id \"ENST00000578976\"; exon_number \"1\"; gene_name \"MIR3118-5\"; gene_biotype \"miRNA\"; transcript_name \"MIR3118-5-201\";", item.Attributes);
      }
    }

    [Test]
    public void TestNextExon()
    {
      using (GtfItemFile file = new GtfItemFile(filename))
      {
        GtfItem item = file.NextExon();
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
}
