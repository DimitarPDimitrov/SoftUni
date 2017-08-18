using NUnit.Framework;

namespace SeleniumDesignPatternsDemo.Pages.RegistrationPage
{
    public static class RegistrationPageAsserter
    {
        public static void AssertRegistrationPageIsOpen(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.Header.Text);
        }

        public static void AssertSuccessMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.SuccessMessage.Displayed);
            Assert.AreEqual(text, page.SuccessMessage.Text);
        }

        public static void AssertErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorRegistrationMessage.Displayed);
            StringAssert.Contains(text, page.ErrorRegistrationMessage.Text);
        }

        public static void AssertNamesErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorForNames.Displayed);
            StringAssert.Contains(text, page.ErrorForNames.Text);
        }
        
        public static void AssertHobbyErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorForHobbyes.Displayed);
            StringAssert.Contains(text, page.ErrorForHobbyes.Text);
        }

        public static void AssertPhoneErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorForPhone.Displayed);
            StringAssert.Contains(text, page.ErrorForPhone.Text);
        }

        public static void AssertUsernameErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorForUsername.Displayed);
            StringAssert.Contains(text, page.ErrorForUsername.Text);
        }

        public static void AssertEmailErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorForEmail.Displayed);
            StringAssert.Contains(text, page.ErrorForEmail.Text);
        }

        public static void AssertProfilePictureErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorForProfilePicture.Displayed);
            StringAssert.Contains(text, page.ErrorForProfilePicture.Text);
        }

        public static void AssertPasswordError(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorForPassword.Displayed);
            StringAssert.Contains(text, page.ErrorForPassword.Text);
        }

        public static void AssertConfirmPasswordError(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorForConfirmPassword.Displayed);
            StringAssert.Contains(text, page.ErrorForConfirmPassword.Text);
        }

        public static void AssertPasswordStrength(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorForStrengthIndicator.Displayed);
            StringAssert.Contains(text, page.ErrorForStrengthIndicator.Text);
        }

    }
}
