using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Genome.SomaticMutation
{
  [TestFixture]
  public class TestMpileupFisherResult
  {
    [Test]
    public void TestMethod()
    {
      var item = new MpileupFisherResult();
      item.ParseString("1_1594962_t_T_C_82_1_76_10_9.4E-03");
    }
  }
}
