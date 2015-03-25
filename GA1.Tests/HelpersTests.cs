using System.Linq;
using NUnit.Framework;

namespace GA1.Tests
{
    [TestFixture]
    public class HelpersTests
    {
        [Test]
        public void CanGenerate64BitBinaryString()
        {
            var result = Helpers.Generate64BitBinaryString();

            Assert.That(result.Length, Is.EqualTo(64));
        }

        [Test]
        public void CanGenerate64BitBinaryStringContainsOnlyBinaryValues()
        {
            var result = Helpers.Generate64BitBinaryString();

            var zeroCount = result.ToCharArray().Count(x => x == '0');
            var oneCount = result.ToCharArray().Count(x => x == '1');

            Assert.That(zeroCount + oneCount, Is.EqualTo(64));
        }

        [Test]
        public void CanGenerate64BitBinaryStringGeneratesRandomValues()
        {
            var resultOne = Helpers.Generate64BitBinaryString();
            var resultTwo = Helpers.Generate64BitBinaryString();

            Assert.That(resultOne, Is.Not.EqualTo(resultTwo));
        }

        [Test]
        public void CanGenerateRandomBit()
        {
            var randomBit = Helpers.GenerateRandomBit();

            var result = (randomBit == 0 || randomBit == 1);
            Assert.That(result);
        }

        [Test]
        public void CanGenerateRandomNumberBetweenValues()
        {
            var randomNumber = Helpers.GenerateRandomNumber(0, 100);

            for (var i = 0; i < 200; i++)
            {
                Assert.That(randomNumber, Is.InRange(0, 99));
            }
            
        }
    }
}
