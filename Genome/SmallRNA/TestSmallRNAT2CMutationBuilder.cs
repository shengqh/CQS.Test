using Meta.Numerics.Statistics;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Genome.SmallRNA
{
  [TestFixture]
  public class TestSmallRNAT2CMutationBuilder
  {
    [Test]
    public void Test()
    {
      Assert.Greater(SmallRNAT2CMutationBuilder.CalculateT2CPvalue(4734, 3, 0.014), 0.05);
      Assert.Less(SmallRNAT2CMutationBuilder.CalculateT2CPvalue(4734, 4731, 0.014), 0.05);

      Assert.Less(SmallRNAT2CMutationBuilder.CalculateT2CPvalue(4734, 200, 0.014), 0.05);
      Assert.Less(SmallRNAT2CMutationBuilder.CalculateT2CPvalue(4734, 4531, 0.014), 0.05);
    }
  }
}
