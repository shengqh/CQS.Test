﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace CQS.Genome.SomaticMutation
{
  [TestFixture]
  public class TestMpileupParser
  {
    [Test]
    public void Test()
    {
      var result = new MpileupResult("test", "c:/temp");
      var parser = new MpileupParser(new PileupProcessorOptions(), result);
      var line = new Regex("\\s+").Replace("3       102196287       G       354     .$.$.$.$.$.$...,....,...,..,.....,,...........,....,,,.......,.,,..,......,..,.,,,.....,,.....,....,,,,...,...,,.,..........,.................,..................,,...,,.,..,,,,..,,....,,,.......,,..,,............,.........,....,,,.,,...,.....,.,,.,,,,..,.....,,.,........,,,,.,...,,.......,,,..,,,,,.,,.......,,.,.,.,,...,...,,...,,,,,..,.,,,,,,,.,.,,..,,,.,,^],  BfBBBBIlpIGdqIIIIIII;Ih:IIqIIFHhIECFHIIIIHI<GIHIDIdFIIIGIIIHHIEIDIIIIFGIIIIIEIIIIIII9IIIIIIF<IIGIHhIIFIGIIIIDIIImHIIIHIIIBIHFIHIHGIG?IIDIHIBIIIIDIGIoIBIIIIIIIGIIIHIIGIIHIGIIIIDIIHIHIIHIIIIIIIHHIqHIIHII@IIIHBIGIII=HIIHIIIIIHHICHIGIGIIIGIHIHEIIBHIIIGIIIIIHGHIIIIIIIHIIIHHIBIII?H=IICEIIIHIGIHBIGGD=HGEIIIIIEGBBHBEDIFIIGHII?GIIGGDFEBIIHIGAHE@D>IEIEEIIGGHEEEE 100,100,100,100,100,100,99,99,98,98,98,97,97,97,97,96,96,96,96,96,96,96,95,94,94,93,93,93,93,92,92,92,91,91,91,90,90,90,90,89,89,88,88,88,88,88,88,88,87,87,87,86,86,86,86,86,85,85,85,84,84,84,83,82,82,82,82,82,82,81,81,81,80,80,79,79,78,78,77,77,76,76,76,75,75,75,74,74,73,72,72,71,69,69,69,69,69,68,68,68,68,67,65,65,65,65,64,64,63,62,61,61,61,61,61,61,61,61,61,60,60,60,60,60,60,60,59,59,59,59,59,59,59,59,59,59,59,58,58,58,58,58,58,58,58,58,57,57,57,56,55,55,55,55,54,54,54,53,53,52,52,52,51,51,50,50,50,50,50,49,48,48,63,48,47,47,47,46,46,46,46,46,45,45,45,45,45,44,44,44,44,43,43,43,43,42,42,42,42,42,42,41,41,41,41,41,41,41,40,40,40,40,40,38,39,39,39,39,39,38,38,37,37,37,37,37,36,44,36,35,34,34,34,33,33,32,32,32,32,32,31,31,31,30,30,29,28,28,27,27,27,26,26,26,26,26,26,29,26,25,28,25,24,24,24,24,23,23,23,23,23,23,23,23,22,22,21,21,21,21,21,20,20,20,20,20,20,20,20,20,20,19,19,19,19,19,19,19,18,47,18,17,17,17,17,16,16,16,16,16,15,15,15,14,14,13,13,13,13,12,12,12,11,10,10,10,10,10,9,9,9,9,9,9,9,9,9,8,8,7,7,7,7,6,6,6,6,6,6,6,6,6,5,5,4,4,4,4,3,3,3,3,3,2,2,2,1,1  406     .$......A.AAA...,a,AAa.,a.....aAA..a..A..A.A.A.A.A.A,aA,a,.,,..,,,.AAaaa.AA.,.A.A.,a,aA..AAa...,..,..Aa....A..AAA,..A,..A.a.....A..,......,a.A....AAA..A......,...,..AA..,,,,.....Aaa..A.AA,AAaAA.,a....A.,a,.....,,A.A..A..A..AA.a,...,..,a.A..AAaA.,,aa,,....,a,aa..A.AAaA.A,.a....A...aaA..A..,....A.A..,AA..,,a..A..AAA.a,AT.,.A.a,,,..A,...AA.,a,a.A.A.a,,,,a,.AA.,,a,.A.A..,a.A.AAAAA,,a,Aa,A,..A,,aA,a,,,a.,,,^].^]. BIGBEGI8I8EH:piI>IIEIIIIIHqHDIBBHFIIEIIIIo>pji@IIIHIIIIIIIIIIFIIIIpp:IIHHHDIFIIFHGHIGI>IIGIIFIIIIIGIGIGBDIIHIIIHIEIIIHIIIFGHIIIIIIIGIGIIIGIIHIEHIIHHmGIIIIGDIFIIIIHIDFIIIIIHIGHGInCIHIIG=GEFIIDIIIIIIIIIBIHIIIIIIIGIIGIIIGIIIbHIIIIIIIHHIIIIIIIIIHIIIAEIGIIBIIIIHGHDHHIHIHGHI@IHIIHIIIIIHHIGGIIIHIIIHIIIIIHGIIIHIHIIIIIIHIIHGI@I8IIIIEIFIIIHIIIIIIGH=GFGIIIHHBHGI8IDIIGGHBIGII:IBHIIIIIIGIED7EIH?GAGIGHEE<G9IGG>EEEEEE   100,100,99,99,99,99,99,99,99,98,98,98,98,98,97,97,96,96,96,96,96,96,95,95,95,94,94,94,93,93,93,93,93,93,92,92,92,92,92,91,91,90,90,90,89,89,89,89,87,87,87,87,87,86,85,85,85,84,84,84,84,82,82,82,81,81,80,80,80,79,79,79,79,79,79,78,78,78,78,78,77,77,76,76,76,76,76,76,76,75,75,75,75,75,75,74,74,74,73,71,71,71,71,70,69,69,68,68,67,67,67,66,65,65,65,65,65,64,64,64,64,63,63,63,63,63,62,62,61,61,61,60,60,60,60,59,59,59,59,59,59,59,59,58,58,58,58,58,58,58,58,57,57,57,56,56,56,56,56,56,56,56,55,55,54,54,53,53,53,53,53,53,52,52,52,52,51,51,51,51,51,51,51,51,50,49,49,49,49,49,49,48,47,47,46,46,46,46,46,45,45,45,44,44,44,44,44,44,44,43,43,43,43,43,43,43,42,42,42,42,41,41,41,41,41,41,41,40,40,40,40,40,39,39,39,39,38,38,38,38,38,37,37,36,36,36,36,36,36,35,35,35,35,35,35,35,34,34,34,34,34,34,34,34,34,33,33,33,33,33,32,32,31,31,31,31,31,30,30,29,29,29,29,28,28,28,28,28,28,27,27,27,27,27,27,27,27,26,26,26,26,25,25,24,24,24,24,24,23,23,23,23,23,23,23,23,22,22,22,21,21,21,21,21,21,21,21,20,20,47,27,19,19,19,19,19,19,19,18,18,18,18,17,16,16,16,16,16,16,16,16,16,15,15,15,15,15,15,15,15,15,29,15,15,15,15,14,14,14,14,14,13,13,13,13,13,12,12,12,12,12,12,12,12,11,11,11,10,10,9,9,9,8,8,8,8,7,7,7,6,6,6,6,5,5,4,4,4,4,4,4,3,3,3,3,3,3,3,2,2,2,2,2,1,1,1", "\t");
      //File.WriteAllText(@"../../../data/glmvc_mpileup.txt", line);

      var fr = parser.Parse(line, false);

      Assert.IsNotNull(fr);

      Assert.AreEqual(354, fr.Item.Samples[0].Count);
      Assert.AreEqual(406, fr.Item.Samples[1].Count);

      Assert.AreEqual("G", fr.Group.SucceedName);
      Assert.AreEqual("A", fr.Group.FailedName);

      Assert.AreEqual(354, fr.Group.Sample1.Succeed);
      Assert.AreEqual(0, fr.Group.Sample1.Failed);

      Assert.AreEqual(262, fr.Group.Sample2.Succeed);
      Assert.AreEqual(143, fr.Group.Sample2.Failed);
    }

    [Test]
    public void TestParse()
    {
      var result = new MpileupResult("test", "c:/temp");
      var parser = new MpileupParser(new PileupProcessorOptions(), result);
      var line = File.ReadAllLines(@"../../../data/glmvc_mpileup.txt").First();
      var fr = parser.Parse(line, false);

      Assert.IsNotNull(fr);

      Assert.AreEqual(354, fr.Item.Samples[0].Count);
      Assert.AreEqual(406, fr.Item.Samples[1].Count);

      Assert.AreEqual("G", fr.Group.SucceedName);
      Assert.AreEqual("A", fr.Group.FailedName);

      Assert.AreEqual(354, fr.Group.Sample1.Succeed);
      Assert.AreEqual(0, fr.Group.Sample1.Failed);

      Assert.AreEqual(262, fr.Group.Sample2.Succeed);
      Assert.AreEqual(143, fr.Group.Sample2.Failed);
    }
  }
}
