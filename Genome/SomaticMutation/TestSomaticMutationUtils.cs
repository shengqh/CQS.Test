using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CQS.Genome.SomaticMutation
{
  [TestFixture]
  public class TestSomaticMutationUtils
  {
    [Test]
    public void TestParseGlmvcFile()
    {
      var items =  SomaticMutationUtils.ParseGlmvcFile(@"../../../data/glmvc.tsv", m => true);
      Assert.AreEqual(6, items.Count);
      var  item = items.First();
      Assert.AreEqual("10", item.Chrom);
      Assert.AreEqual(10689871, item.StartPosition);
      Assert.AreEqual("G", item.RefAllele);
      Assert.AreEqual("T", item.AltAllele);
      Assert.AreEqual(80, item.NormalMajorCount);
      Assert.AreEqual(0, item.NormalMinorCount);
      Assert.AreEqual(23, item.TumorMajorCount);
      Assert.AreEqual(12, item.TumorMinorCount);
      Assert.AreEqual("0.869220015293937", item.LogisticScore);
      Assert.AreEqual("0.527922388896575", item.LogisticStrand);
      Assert.AreEqual("0.417003497870188", item.LogisticPosition);
      Assert.AreEqual(-Math.Log(0.00451949830920884), item.Score);
      Assert.AreEqual("exonic", item.RefGeneFunc);
      Assert.AreEqual("Grm1", item.RefGeneName);
      Assert.AreEqual("nonsynonymous SNV", item.RefGeneExonicFunc);
    }

    [Test]
    public void TestParseAnnovarMutectFile()
    {
      var items = SomaticMutationUtils.ParseAnnovarMutectFile(@"../../../data/annovar_mutect.tsv", m => true);
      Assert.AreEqual(6, items.Count);
      var item = items.First();
      Assert.AreEqual("1", item.Chrom);
      Assert.AreEqual(1670432, item.StartPosition);
      Assert.AreEqual("T", item.RefAllele);
      Assert.AreEqual("C", item.AltAllele);
      Assert.AreEqual(37, item.NormalMajorCount);
      Assert.AreEqual(0, item.NormalMinorCount);
      Assert.AreEqual(23, item.TumorMajorCount);
      Assert.AreEqual(3, item.TumorMinorCount);
      Assert.AreEqual(7.59487, item.Score);
      Assert.AreEqual("exonic", item.RefGeneFunc);
      Assert.AreEqual("SLC35E2", item.RefGeneName);
      Assert.AreEqual("synonymous SNV", item.RefGeneExonicFunc);
    }

    [Test]
    public void TestParseAnnovarVarscan2File()
    {
      var items = SomaticMutationUtils.ParseAnnovarVarscan2File(@"../../../data/annovar_varscan2.tsv", m => true);
      Assert.AreEqual(6, items.Count);
      var item = items.First();
      Assert.AreEqual("1", item.Chrom);
      Assert.AreEqual(16950261, item.StartPosition);
      Assert.AreEqual("G", item.RefAllele);
      Assert.AreEqual("C", item.AltAllele);
      Assert.AreEqual(13, item.NormalMajorCount);
      Assert.AreEqual(0, item.NormalMinorCount);
      Assert.AreEqual(7, item.TumorMajorCount);
      Assert.AreEqual(4, item.TumorMinorCount);
      Assert.AreEqual(-Math.Log(3.1056E-2), item.Score);
      Assert.AreEqual("ncRNA_intronic", item.RefGeneFunc);
      Assert.AreEqual("CROCCP2", item.RefGeneName);
      Assert.AreEqual("", item.RefGeneExonicFunc);
    }
  }
}
