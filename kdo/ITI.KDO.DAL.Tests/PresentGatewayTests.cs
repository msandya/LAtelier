using ITI.KDO.DAL;
using NUnit.Framework;

namespace ITI.KDO.DAL.Tests
{
    [TestFixture]
    public class PresentGatewayTests
    {
        [Test]
        public void can_create_find_update_and_delete_Present()
        {
            PresentGateway sut = new PresentGateway(TestHelpers.ConnectionString);
            string presentName = TestHelpers.RandomPresentName();
            float price = TestHelpers.RandomPrice();
            string linkPresent = TestHelpers.RandomLink();
            int userId = TestHelpers.RandomUserId();
            int categoryPresent = TestHelpers.RandomUserId();

            sut.AddUserPresent(presentName, price, linkPresent, categoryPresent, userId);
            Present present = sut.FindById(userId);

            {
                Assert.That(present.PresentName, Is.EqualTo(presentName));
                Assert.That(present.CategoryPresentId, Is.EqualTo(categoryPresent));
                Assert.That(present.Price, Is.EqualTo(price));
                Assert.That(present.LinkPresent, Is.EqualTo(linkPresent));
            }

            {
                Present p = sut.FindById(present.UserId);
                Assert.That(p.UserId, Is.EqualTo(userId));
            }

        }

    }
}
