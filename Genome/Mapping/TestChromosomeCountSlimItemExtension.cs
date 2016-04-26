using NUnit.Framework;

namespace CQS.Genome.Mapping
{
  [TestFixture]
  public class TestChromosomeCountSlimItemExtension
  {
    [Test]
    public void Test()
    {
      var items = new ChromosomeCountSlimItemXmlFormat().ReadFromFile(@"../../../data/CMS-306.bam.count.mapped.xml");
      var queries = items.GetQueries();

      Assert.AreEqual("NB501087:31:HTGWLBGXX:1:21112:13668:5159", queries[1].Qname);
      Assert.AreEqual(3, queries[1].Chromosomes.Count);

      items.MergeCalculateSortByEstimatedCount();

      Assert.AreEqual(1, items.Count);
      Assert.AreEqual(2, items[0].Queries.Count);
      Assert.AreEqual(2, items[0].Names.Count);
      Assert.IsTrue(items[0].Names.Contains("gma-miR166k"));
      Assert.IsTrue(items[0].Names.Contains("gma-miR166h-3p"));

      Assert.AreEqual(2, queries[1].Chromosomes.Count);
      Assert.AreEqual(28, items[0].EstimatedCount);
    }
  }
}
