using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Converter
{
  [TestFixture]
  public class TestConverterUtils
  {
    class TestClass
    {
      public string String1 { get; set; }
      public int Int1 { get; set; }
      public double Double1 { get; set; }
    }

    [Test]
    public void TestGetConverters()
    {
      var converters = ConverterUtils.GetPropertConverters<TestClass>();
      var map = converters.ToDictionary(m => m.Name);
      Assert.IsTrue(map.ContainsKey("String1"));
      Assert.IsTrue(map.ContainsKey("Int1"));
      Assert.IsTrue(map.ContainsKey("Double1"));

      TestClass obj = new TestClass();
      obj.String1 = "TestString";
      obj.Int1 = 1;
      obj.Double1 = 2.0;

      Assert.AreEqual(obj.String1, map["String1"].GetProperty(obj));
      Assert.AreEqual(obj.Int1, int.Parse(map["Int1"].GetProperty(obj)));
      Assert.AreEqual(obj.Double1, double.Parse(map["Double1"].GetProperty(obj)));

      map["String1"].SetProperty(obj, "ChangedTestString");
      map["Int1"].SetProperty(obj, "2");
      map["Double1"].SetProperty(obj, "-2.0");
      Assert.AreEqual(obj.String1, "ChangedTestString");
      Assert.AreEqual(obj.Int1, 2);
      Assert.AreEqual(obj.Double1, -2.0);
    }
  }
}
