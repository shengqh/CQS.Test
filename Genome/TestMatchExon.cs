using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome
{
  [TestFixture]
  public class TestMatchExon
  {
    [Test]
    public void TestEqualLocations()
    {
      MatchExon e1 = new MatchExon();
      e1.Add(new Location(1, 10));
      e1.Add(new Location(30, 40));

      MatchExon e2 = new MatchExon();
      e2.Add(new Location(1, 10));
      e2.Add(new Location(30, 40));

      MatchExon e3 = new MatchExon();
      e3.Add(new Location(1, 11));
      e3.Add(new Location(30, 40));

      Assert.IsTrue(e1.EqualLocations(e2));
      Assert.IsFalse(e1.EqualLocations(e3));
    }

    [Test]
    public void TestContainLocation()
    {
      MatchExon e1 = new MatchExon();
      e1.Add(new Location(1, 10));
      e1.Add(new Location(30, 40));

      Location l1 = new Location(3, 6);
      Assert.IsTrue(e1.ContainLocation(l1));

      Location l2 = new Location(3, 11);
      Assert.IsFalse(e1.ContainLocation(l2));

      Location l3 = new Location(25, 35);
      Assert.IsFalse(e1.ContainLocation(l3));
    }

    [Test]
    public void TestContainLocations()
    {
      MatchExon e1 = new MatchExon();
      e1.Add(new Location(1, 10));
      e1.Add(new Location(30, 40));

      var e2 = new[] { new Location(1, 10), new Location(30, 40) };
      var e3 = new[] { new Location(1, 11), new Location(30, 40) };

      Assert.IsTrue(e1.EqualLocations(e2));
      Assert.IsFalse(e1.EqualLocations(e3));
    }

  }
}
