using NUnit.Framework;

namespace GA1.Tests
{
    [TestFixture]
    public class MemberTests
    {
        [Test]
        public void CanInstantiateMember()
        {
            var member = new Member();

            Assert.IsNotNull(member);
        }

        [Test]
        public void CanSetAndRetrieveMemberValue()
        {
            var member = new Member {Value = "101"};

            Assert.That(member.Value, Is.EqualTo("101"));
        }
    }
}
