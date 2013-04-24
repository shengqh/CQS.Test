﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS
{
  [TestFixture]
  public class TestLocation
  {
    [Test]
    public void TestConstruction1()
    {
      var loc = new Location("1");
      Assert.AreEqual(1, loc.Start);
      Assert.AreEqual(1, loc.End);
    }

    [Test]
    public void TestConstruction2()
    {
      var loc = new Location("1-5");
      Assert.AreEqual(1, loc.Start);
      Assert.AreEqual(5, loc.End);
    }

    [Test]
    [ExpectedException("System.ArgumentException")]
    public void TestConstructionException1()
    {
      new Location(2, 1);
    }

    [Test]
    [ExpectedException("System.ArgumentException")]
    public void TestConstructionException2()
    {
      new Location("1-2-3");
    }

    [Test]
    [ExpectedException("System.ArgumentException")]
    public void TestConstructionException3()
    {
      new Location("a-b");
    }

    [Test]
    public void TestEquals()
    {
      var loc1 = new Location(1, 2);
      var loc2 = new Location(1, 2);
      var loc3 = new Location(1, 3);
      Assert.AreEqual(loc1, loc2);
      Assert.AreEqual(loc1.GetHashCode(), loc2.GetHashCode());
      Assert.AreNotEqual(loc1, loc3);
      Assert.AreNotEqual(loc1.GetHashCode(), loc3.GetHashCode());
    }
  }
}
