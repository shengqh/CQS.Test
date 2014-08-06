using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Genome.SomaticMutation
{
  [TestFixture]
  public class TestMpileupFisherResultFileFormat
  {
    [Test]
    public void TestMethod()
    {
      var data = new MpileupFisherResultFileFormat().ReadFromFile(@"../../data/TCGA-BH-A0E0-DNA-TP-NB.candidates");
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
  }
}
