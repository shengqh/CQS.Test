using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Meta.Numerics.Statistics;

namespace CQS.Statistics
{
  [TestFixture]
  public class TestMyFisherExactTest
  {
    [Test]
    public void Test()
    {
      Assert.AreEqual(0.00008, MyFisherExactTest.TwoTailPValue(34, 153, 41, 62), 0.00001);

      Assert.AreEqual(1, MyFisherExactTest.TwoTailPValue(515, 0, 514, 1), 0.0001);
      Assert.AreEqual(1, MyFisherExactTest.TwoTailPValue(515, 0, 515, 0), 0.0001);

      Assert.AreEqual(0.04899, MyFisherExactTest.TwoTailPValue(14, 10, 21, 3), 0.0001);
      Assert.AreEqual(0.04899, MyFisherExactTest.TwoTailPValue(10, 14, 3, 21), 0.0001);
      Assert.AreEqual(0.04899, MyFisherExactTest.TwoTailPValue(21, 3, 14, 10), 0.0001);
      Assert.AreEqual(0.04899, MyFisherExactTest.TwoTailPValue(3, 21, 10, 14), 0.0001);

      Assert.AreEqual(0.6069, MyFisherExactTest.TwoTailPValue(1, 21, 3, 19), 0.0001);
      Assert.AreEqual(0.0606, MyFisherExactTest.TwoTailPValue(0, 6, 4, 2), 0.0001);
      Assert.AreEqual(0.4958, MyFisherExactTest.TwoTailPValue(0, 60, 2, 58), 0.0001);

      Assert.AreEqual(1, MyFisherExactTest.TwoTailPValue(1, 210, 1, 190), 0.0001);
    }

    [Test]
    public void TestGreater()
    {
      var mat = new[,] { { 14, 0 }, { 14, 5 } };

      Assert.AreEqual(0.0574, new BinaryContingencyTable(mat).FisherExactTest().Statistic, 0.0001);
    }

  }
}
