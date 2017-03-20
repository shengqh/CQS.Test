﻿using CQS.Genome.Feature;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Genome.SmallRNA
{
  [TestFixture]
  public class TestSmallRNAUtils
  {
    [Test]
    public void TestGroupByTRNACode()
    {
      var fileDic = PrepareDictionary();

      var actual = SmallRNAUtils.GroupByTRNACode(fileDic, true);
      Assert.AreEqual(2, actual.Count);

      //tRNA1 and tRNA2 should be combined as one group
      Assert.AreEqual(2, actual["Sample1"].Count);
      Assert.True(actual["Sample1"].ContainsKey("GlyGCC"));

      Assert.AreEqual(2, actual["Sample1"]["GlyGCC"].Count);
      Assert.True(null != actual["Sample1"]["GlyGCC"].Where(l => l.Name.Equals("tRNA:chr1.tRNA35-GlyGCC")).FirstOrDefault());
      Assert.True(null != actual["Sample1"]["GlyGCC"].Where(l => l.Name.Equals("tRNA:chr2.tRNA36-GlyGCC")).FirstOrDefault());

      Assert.True(actual["Sample1"].ContainsKey("HisGTG"));
      Assert.AreEqual(1, actual["Sample1"]["HisGTG"].Count);
      Assert.True(null != actual["Sample1"]["HisGTG"].Where(l => l.Name.Equals("tRNA:chr1.tRNA111-HisGTG")).FirstOrDefault());

      //same as original one except the key
      Assert.AreEqual(2, actual["Sample2"].Count);
      Assert.True(actual["Sample2"].ContainsKey("GlyGCC"));
      Assert.AreEqual(2, actual["Sample2"]["GlyGCC"].Count);
      Assert.True(actual["Sample2"].ContainsKey("HisGTG"));
      Assert.AreEqual(1, actual["Sample2"]["HisGTG"].Count);
    }

    [Test]
    public void TestGroupByIdenticalQuery()
    {
      Dictionary<string, Dictionary<string, FeatureItemGroup>> fileDic = PrepareDictionary();

      var actual = SmallRNAUtils.GroupByIdenticalQuery(fileDic);
      Assert.AreEqual(2, actual.Count);

      Assert.AreEqual(3, actual["Sample1"].Count);
      Assert.True(actual["Sample1"].ContainsKey("tRNA:chr1.tRNA35-GlyGCC"));
      Assert.True(actual["Sample1"].ContainsKey("tRNA:chr2.tRNA36-GlyGCC"));
      Assert.True(actual["Sample1"].ContainsKey("tRNA:chr1.tRNA111-HisGTG"));

      Assert.AreEqual(3, actual["Sample2"].Count);
      Assert.True(actual["Sample2"].ContainsKey("tRNA:chr1.tRNA35-GlyGCC"));
      Assert.True(actual["Sample2"].ContainsKey("tRNA:chr2.tRNA36-GlyGCC"));
      Assert.True(actual["Sample2"].ContainsKey("tRNA:chr1.tRNA111-HisGTG"));
    }

    private static Dictionary<string, Dictionary<string, FeatureItemGroup>> PrepareDictionary()
    {
      var fileDic = new Dictionary<string, Dictionary<string, FeatureItemGroup>>();

      // in sample 1, three groups were mapped with three different queries
      fileDic["Sample1"] = new Dictionary<string, FeatureItemGroup>();
      fileDic["Sample1"]["tRNA1"] = new FeatureItemGroup(new FeatureItem() { Name = "tRNA:chr1.tRNA35-GlyGCC" });
      fileDic["Sample1"]["tRNA1"][0].Locations.Add(new FeatureLocation());
      fileDic["Sample1"]["tRNA1"][0].Locations[0].SamLocations.Add(new FeatureSamLocation(fileDic["Sample1"]["tRNA1"][0].Locations[0]) { SamLocation = new Sam.SAMAlignedLocation(new Sam.SAMAlignedItem() { Qname = "Query1" }) });

      fileDic["Sample1"]["tRNA2"] = new FeatureItemGroup(new FeatureItem() { Name = "tRNA:chr2.tRNA36-GlyGCC" });
      fileDic["Sample1"]["tRNA2"][0].Locations.Add(new FeatureLocation());
      fileDic["Sample1"]["tRNA2"][0].Locations[0].SamLocations.Add(new FeatureSamLocation(fileDic["Sample1"]["tRNA2"][0].Locations[0]) { SamLocation = new Sam.SAMAlignedLocation(new Sam.SAMAlignedItem() { Qname = "Query2" }) });

      fileDic["Sample1"]["tRNA3"] = new FeatureItemGroup(new FeatureItem() { Name = "tRNA:chr1.tRNA111-HisGTG" });
      fileDic["Sample1"]["tRNA3"][0].Locations.Add(new FeatureLocation());
      fileDic["Sample1"]["tRNA3"][0].Locations[0].SamLocations.Add(new FeatureSamLocation(fileDic["Sample1"]["tRNA3"][0].Locations[0]) { SamLocation = new Sam.SAMAlignedLocation(new Sam.SAMAlignedItem() { Qname = "Query3" }) });

      // in sample 2, two groups were mapped with two different queries. The first group contains two tRNA with same code.
      fileDic["Sample2"] = new Dictionary<string, FeatureItemGroup>();
      fileDic["Sample2"]["tRNA1"] = new FeatureItemGroup(new FeatureItem() { Name = "tRNA:chr1.tRNA35-GlyGCC" });
      fileDic["Sample2"]["tRNA1"][0].Locations.Add(new FeatureLocation());
      fileDic["Sample2"]["tRNA1"][0].Locations[0].SamLocations.Add(new FeatureSamLocation(fileDic["Sample2"]["tRNA1"][0].Locations[0]) { SamLocation = new Sam.SAMAlignedLocation(new Sam.SAMAlignedItem() { Qname = "Query4" }) });

      fileDic["Sample2"]["tRNA1"].Add(new FeatureItem() { Name = "tRNA:chr2.tRNA36-GlyGCC" });
      fileDic["Sample2"]["tRNA1"][1].Locations.Add(new FeatureLocation());
      fileDic["Sample2"]["tRNA1"][1].Locations[0].SamLocations.Add(new FeatureSamLocation(fileDic["Sample2"]["tRNA1"][1].Locations[0]) { SamLocation = new Sam.SAMAlignedLocation(new Sam.SAMAlignedItem() { Qname = "Query4" }) });

      fileDic["Sample2"]["tRNA3"] = new FeatureItemGroup(new FeatureItem() { Name = "tRNA:chr1.tRNA111-HisGTG" });
      fileDic["Sample2"]["tRNA3"][0].Locations.Add(new FeatureLocation());
      fileDic["Sample2"]["tRNA3"][0].Locations[0].SamLocations.Add(new FeatureSamLocation(fileDic["Sample2"]["tRNA3"][0].Locations[0]) { SamLocation = new Sam.SAMAlignedLocation(new Sam.SAMAlignedItem() { Qname = "Query5" }) });
      return fileDic;
    }

    [Test]
    public void TestGetTrnaAnticodon()
    {
      Assert.AreEqual("AlaAGC", SmallRNAUtils.GetTrnaAnticodon("tRNA:tRNA-Ala-AGC-12-3"));
      Assert.AreEqual("GlyGCC", SmallRNAUtils.GetTrnaAnticodon("tRNA:chr2.tRNA36-GlyGCC"));
      Assert.AreEqual("iMetCAT", SmallRNAUtils.GetTrnaAnticodon("tRNA:tRNA-iMet-CAT-1-1"));
      Assert.AreEqual("TV", SmallRNAUtils.GetTrnaAnticodon("tRNA:chrMT.tRNA2-TV"));
      Assert.AreEqual("PseudoTTA", SmallRNAUtils.GetTrnaAnticodon("tRNA:chr4.tRNA5-PseudoTTA"));
      Assert.AreEqual("Pseudo???", SmallRNAUtils.GetTrnaAnticodon("tRNA:chr1.tRNA126-Pseudo???"));
      Assert.AreEqual("SeC(e)TCA", SmallRNAUtils.GetTrnaAnticodon("tRNA:chr19.tRNA8-SeC(e)TCA"));
      Assert.AreEqual("GlyCCC", SmallRNAUtils.GetTrnaAnticodon("tRNA:tRNA-Gly-CCC-chr1-16"));
      Assert.AreEqual("GlnCTG", SmallRNAUtils.GetTrnaAnticodon("tRNA:nmt-tRNA-Gln-CTG-1-1"));
    }

    [Test]
    public void TestGetTrnaAminoacid()
    {
      Assert.AreEqual("Ala", SmallRNAUtils.GetTrnaAminoacid("tRNA:tRNA-Ala-AGC-12-3"));
      Assert.AreEqual("Gla", SmallRNAUtils.GetTrnaAminoacid("tRNA:chr2.tRNA36-GlaGCC"));
      Assert.AreEqual("iMet", SmallRNAUtils.GetTrnaAminoacid("tRNA:tRNA-iMet-CAT-1-1"));
      Assert.AreEqual("TV", SmallRNAUtils.GetTrnaAminoacid("tRNA:chrMT.tRNA2-TV"));
      Assert.AreEqual("Pseudo", SmallRNAUtils.GetTrnaAminoacid("tRNA:chr4.tRNA5-PseudoTTA"));
      Assert.AreEqual("Pseudo", SmallRNAUtils.GetTrnaAminoacid("tRNA:chr1.tRNA126-Pseudo???"));
      Assert.AreEqual("SeC(e)", SmallRNAUtils.GetTrnaAminoacid("tRNA:chr19.tRNA8-SeC(e)TCA"));
      Assert.AreEqual("Gly", SmallRNAUtils.GetTrnaAminoacid("tRNA:tRNA-Gly-CCC-chr1-16"));
      Assert.AreEqual("Gln", SmallRNAUtils.GetTrnaAminoacid("tRNA:nmt-tRNA-Gln-CTG-1-1"));
    }
  }
}
