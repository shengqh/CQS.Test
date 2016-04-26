using NUnit.Framework;

namespace CQS.Genome.SomaticMutation
{
  [TestFixture]
  public class TestMpileupFisherResultFileFormat
  {
    [Test]
    public void TestReadFromFileWithoutFilter()
    {
      var data = new MpileupFisherResultFileFormat().ReadFromFile(@"../../../data/TCGA-BH-A0E0-DNA-TP-NB.candidates");
      Assert.AreEqual(850, data.Count);

      var res = data[0];
      Assert.AreEqual("1", res.Item.SequenceIdentifier);
      Assert.AreEqual(5732744, res.Item.Position);
      Assert.AreEqual('G', res.Item.Nucleotide);
      Assert.AreEqual("G", res.Group.SucceedName);
      Assert.AreEqual("T", res.Group.FailedName);
      Assert.AreEqual(44, res.Group.Sample1.Succeed);
      Assert.AreEqual(1, res.Group.Sample1.Failed);
      Assert.AreEqual(11, res.Group.Sample2.Succeed);
      Assert.AreEqual(3, res.Group.Sample2.Failed);
      Assert.AreEqual(3.8E-02, res.Group.PValue, 0.01);
    }

    [Test]
    public void TestReadFromFileWithFilter()
    {
      var data = new MpileupFisherResultFileFormat().ReadFromFile(@"../../../data/glmvc.candidates");
      Assert.AreEqual(24, data.Count);

      var res = data[3];
      Assert.AreEqual("2", res.Item.SequenceIdentifier);
      Assert.AreEqual(110301779, res.Item.Position);
      Assert.AreEqual('A', res.Item.Nucleotide);
      Assert.AreEqual("A", res.Group.SucceedName);
      Assert.AreEqual("", res.Group.FailedName);
      Assert.AreEqual(23, res.Group.Sample1.Succeed);
      Assert.AreEqual(0, res.Group.Sample1.Failed);
      Assert.AreEqual(9, res.Group.Sample2.Succeed);
      Assert.AreEqual(0, res.Group.Sample2.Failed);
      Assert.AreEqual(1.0E00, res.Group.PValue, 0.01);
      Assert.AreEqual("Read depth < 10", res.FailedReason);
    }

    [Test]
    public void TestParseStringWithoutFailedReason()
    {
      var filename = "4_JH584292_random_13694_T_T_G_49_0_37_6_8.5E-03";
      var res = MpileupFisherResultFileFormat.ParseString(filename);
      Assert.AreEqual("4_JH584292_random", res.Item.SequenceIdentifier);
      Assert.AreEqual(13694, res.Item.Position);
      Assert.AreEqual('T', res.Item.Nucleotide);
      Assert.AreEqual("T", res.Group.SucceedName);
      Assert.AreEqual("G", res.Group.FailedName);
      Assert.AreEqual(49, res.Group.Sample1.Succeed);
      Assert.AreEqual(0, res.Group.Sample1.Failed);
      Assert.AreEqual(37, res.Group.Sample2.Succeed);
      Assert.AreEqual(6, res.Group.Sample2.Failed);
      Assert.AreEqual(8.5E-03, res.Group.PValue, 0.01);
      Assert.AreEqual(string.Empty, res.FailedReason);
    }

    [Test]
    public void TestParseStringWithoutFailedReason2()
    {
      var filename = "chrUn_gl000219_78804_C_C_T_73_0_15_6_6.7E-05";
      var res = MpileupFisherResultFileFormat.ParseString(filename);
      Assert.AreEqual("chrUn_gl000219", res.Item.SequenceIdentifier);
      Assert.AreEqual(78804, res.Item.Position);
      Assert.AreEqual('C', res.Item.Nucleotide);
      Assert.AreEqual("C", res.Group.SucceedName);
      Assert.AreEqual("T", res.Group.FailedName);
      Assert.AreEqual(73, res.Group.Sample1.Succeed);
      Assert.AreEqual(0, res.Group.Sample1.Failed);
      Assert.AreEqual(15, res.Group.Sample2.Succeed);
      Assert.AreEqual(6, res.Group.Sample2.Failed);
      Assert.AreEqual(6.7E-5, res.Group.PValue, 0.01);
      Assert.AreEqual(string.Empty, res.FailedReason);
    }

    public void TestParseStringWithFailedReason()
    {
      var filename = "4_JH584292_random_13694_T_T_G_49_0_37_6_8.5E-03_FailedReason";
      var res = MpileupFisherResultFileFormat.ParseString(filename);
      Assert.AreEqual("4_JH584292_random", res.Item.SequenceIdentifier);
      Assert.AreEqual(13694, res.Item.Position);
      Assert.AreEqual('T', res.Item.Nucleotide);
      Assert.AreEqual("T", res.Group.SucceedName);
      Assert.AreEqual("G", res.Group.FailedName);
      Assert.AreEqual(49, res.Group.Sample1.Succeed);
      Assert.AreEqual(0, res.Group.Sample1.Failed);
      Assert.AreEqual(37, res.Group.Sample2.Succeed);
      Assert.AreEqual(6, res.Group.Sample2.Failed);
      Assert.AreEqual(8.5E-03, res.Group.PValue, 0.01);
      Assert.AreEqual("FailedReason", res.FailedReason);
    }
  }
}
