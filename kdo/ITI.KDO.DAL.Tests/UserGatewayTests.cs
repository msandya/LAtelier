using NUnit.Framework;
using System;
using ITI.KDO.DAL;

namespace ITI.KDO.DAL.Tests
{
    [TestFixture]
    public class UserGatewayTests
    {
        readonly Random _random = new Random();

        [Test]
        public void can_create_find_update_and_delete_user()
        {
            UserGateway sut = new UserGateway(TestHelpers.ConnectionString);

            string firstName = TestHelpers.RandomTestName();
            string lastName = TestHelpers.RandomTestName();
            string email = TestHelpers.RandomEmail();
            byte[] password = Guid.NewGuid().ToByteArray();

            sut.CreateUserWithPassword(email, firstName, lastName, password);
            User user = sut.FindByEmail(email);

            {
                Assert.That(user.Email, Is.EqualTo(email));
                Assert.That(user.Password, Is.EqualTo(password));
            }

            {
                User u = sut.FindById(user.UserId);
                Assert.That(u.Email, Is.EqualTo(email));
                Assert.That(u.Password, Is.EqualTo(password));
            }

            {
                DateTime birthDate = TestHelpers.RandomBirthDate(_random.Next(5, 10));
                email = TestHelpers.RandomEmail();
                sut.Update(user.UserId, firstName, lastName, birthDate, email, user.Phone, user.Photo);
            }

            {
                User u = sut.FindById(user.UserId);
                Assert.That(u.Email, Is.EqualTo(email));
                Assert.That(u.Password, Is.EqualTo(password));
            }

            {
                sut.Delete(user.UserId);
                Assert.That(sut.FindById(user.UserId), Is.Null);
            }
        }

        [Test]
        public void can_create_google_user()
        {
            DAL.UserGateway sut = new DAL.UserGateway(TestHelpers.ConnectionString);
            string email = string.Format("user{0}@test.com", Guid.NewGuid());
            string firstName = TestHelpers.RandomTestName();
            string lastName = TestHelpers.RandomTestName();
            string googleId = "azertyuiop";
            string refreshToken = "azertyuiop";

            sut.CreateGoogleUser(email, googleId, refreshToken);
            User user = sut.FindByEmail(email);

            Assert.That(user.GoogleRefreshToken, Is.EqualTo(refreshToken));

            refreshToken = Guid.NewGuid().ToString().Replace("-", string.Empty);
            sut.UpdateGoogleToken(user.UserId, googleId, refreshToken);

            user = sut.FindById(user.UserId);
            Assert.That(user.GoogleRefreshToken, Is.EqualTo(refreshToken));

            sut.Delete(user.UserId);
        }

        [Test]
        public void can_create_facebook_user()
        {
            DAL.UserGateway sut = new DAL.UserGateway(TestHelpers.ConnectionString);
            string email = string.Format("user{0}@test.com", Guid.NewGuid());
            string firstName = TestHelpers.RandomTestName();
            string lastName = TestHelpers.RandomTestName();
            string facebookId = "azertyuiop";
            string refreshToken = "azertyuiop";

            sut.CreateFacebookUser(email, facebookId, refreshToken, firstName, lastName);
            User user = sut.FindByEmail(email);

            Assert.That(user.FacebookAccessToken, Is.EqualTo(refreshToken));

            refreshToken = Guid.NewGuid().ToString().Replace("-", string.Empty);
            sut.UpdateFacebookToken(user.UserId, facebookId, refreshToken);

            user = sut.FindById(user.UserId);
            Assert.That(user.FacebookAccessToken, Is.EqualTo(refreshToken));

            sut.Delete(user.UserId);
        }
    }
}
