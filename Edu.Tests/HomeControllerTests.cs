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

                    e.Email == "email@mail.com" &&
                    e.Name == "name" &&
                    e.Surname == "surname" &&
                    e.Phone == "81234567890"
                );
        }


        [TestMethod]
        public void CanValidateAndRestoreStateAfterInvalidInput()
        {
            _captchaHelper.Setup(x => x.ValidateCaptcha(It.IsAny<string>())).Returns(false);
            _home = new Controllers.HomeController(_captchaHelper.Object);
            var view = _home.SignUpForm(_enrollee);

            Assert.AreEqual(view.ViewName, "SignUpForm");
            _captchaHelper.Setup(x => x.ValidateCaptcha(It.IsAny<string>())).Returns(true);
         
            view = _home.SignUpForm(_enrollee);
            Assert.AreEqual(view.ViewName, "SignUpOk");


            var enrollee = view.Model as Models.Enrollee;
            Assert.AreEqual(enrollee, _enrollee);
        }


        [TestMethod]
        public void CanValidateModelErrorsExpected()
        {
            var enrollee = new Models.Enrollee()
            {
                Email = "badEmail",
                Name = "bad111Name",
                Surname = "Goodsurname",
                Phone = "notValidPhoneNumber"
            };

            var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(enrollee);
            System.ComponentModel.DataAnnotations.Validator.TryValidateObject(enrollee, validationContext, results, true);

                        
            Assert.AreEqual(results.Count, 3);
        }


        [TestMethod]
        public void CanValidateOkModel()
        {
            var enrollee = new Models.Enrollee()
            {
                Email = "enrollee@gmail.com",
                Name = "Enrolleename",
                Surname = "Enrolleesurname",
                Phone = "12345678900"
            };

            var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(enrollee);
            System.ComponentModel.DataAnnotations.Validator.TryValidateObject(enrollee, validationContext, results, true);

            Assert.AreEqual(results.Count, 0);
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
