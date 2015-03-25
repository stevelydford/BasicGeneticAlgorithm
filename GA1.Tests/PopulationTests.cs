using NUnit.Framework;

namespace GA1.Tests
{
    [TestFixture]
    public class PopulationTests
    {
        [Test]
        public void CanCreateAPopulationPassingInAPopulationSize()
        {
            var population = new Population(10);

            Assert.That(population.Members.Count, Is.EqualTo(10));
        }

        [Test]
        public void PopulationMembersAreCreatedWith64CharacterStringValues()
        {
            var population = new Population();
            population.SeedPopulation(2);

            Assert.That(population.Members[0].Value.Length, Is.EqualTo(64));
            Assert.That(population.Members[1].Value.Length, Is.EqualTo(64));
        }

        [Test]
        public void CanEvaluatePopulation()
        {
            var population = new Population(10);
            var desiredResult = Helpers.Generate64BitBinaryString();

            var result = population.Evaluate(desiredResult);
        }

        [Test]
        public void EvaluationOfPopulationReturnsFittestMember()
        {
            var population = new Population();
            population.Members.Add(new Member { Value = "1000" });
            population.Members.Add(new Member { Value = "1100" });
            population.Members.Add(new Member { Value = "1110" });

            var result = population.Evaluate("1111");

            Assert.That(result.Value, Is.EqualTo("1110"));
        }

        [Test]
        public void PopulationCanBreed()
        {
            const string initialValue = "0000000000000000000000000000000000000000000000000000000000000000";
            var population = new Population(2000);
            population.Members.Add(new Member { Value = initialValue });
            population.Breed();

            Assert.That(population.Members[0].Value, Is.Not.EqualTo(initialValue));
        }
    }
}
