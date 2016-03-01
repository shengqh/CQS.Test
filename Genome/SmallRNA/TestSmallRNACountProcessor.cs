using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CQS.Genome.Feature;
using CQS.Genome.Sam;

namespace CQS.Genome.SmallRNA
{
  [TestFixture]
  public class TestSmallRNACountProcessor
  {
    [Test]
    public void Test()
    {
      var proc = new SmallRNACountProcessor(new SmallRNACountProcessorOptions() { });

      var floc = new FeatureLocation() { };
      var sloc = new SAMAlignedLocation(null) { };

      var actual = proc.CheckNoPenaltyMutation(floc, sloc, 1);
    }
  }
}
