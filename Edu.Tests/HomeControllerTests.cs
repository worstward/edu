using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Edu.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        Mock<Helpers.ICaptchaHelper> _captchaHelper;
        Models.Enrollee _enrollee;
        Edu.Controllers.HomeController _home;

        [TestInitialize]
        public void InitTestContext()
        {
            _captchaHelper = new Mock<Helpers.ICaptchaHelper>();

            
            _enrollee = Mock.Of<Models.Enrollee>(e => 
                
                    e.Email == "email" &&
                    e.Name == "name" &&
                    e.Surname == "surname" && 
                    e.Phone == "81234567890"
                );
        }


        [TestMethod]
        public void CanValidateOkCaptchaAnswer()
        {
            _captchaHelper.Setup(x => x.ValidateCaptcha(It.IsAny<string>())).Returns(true);

            _home = new Controllers.HomeController(_captchaHelper.Object);
            
            var view = _home.SignUpForm(_enrollee);
            var enrollee = view.Model as Models.Enrollee;
            
            Assert.AreEqual(view.ViewName, "SignUpOk");
            Assert.AreEqual(enrollee.Name, "name");
            Assert.AreEqual(enrollee.Surname, "surname");
            Assert.AreEqual(enrollee.Email, "email");
            Assert.AreEqual(enrollee.Phone, "81234567890");
        }

        [TestMethod]
        public void CanRejectBadCaptchaAnswer()
        {
            _captchaHelper.Setup(x => x.ValidateCaptcha(It.IsAny<string>())).Returns(false);

            _home = new Controllers.HomeController(_captchaHelper.Object);

            var view = _home.SignUpForm(_enrollee);
            Assert.AreEqual(view.ViewName, "SignUpForm");            
        }
    }
}
