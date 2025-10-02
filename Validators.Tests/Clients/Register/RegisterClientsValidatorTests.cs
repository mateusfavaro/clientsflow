using ClientsFlow.Application.UseCases.Clients.Register;
using ClientsFlow.Communication.Enums;
using ClientsFlow.Exception.ExceptionBase;
using CommonTestUtilities;

namespace Validators.Tests.Clients.Register
{
    public class RegisterClientsValidatorTests
    {
        [Fact]
        public void Sucess()
        {
            //Arrange
            var validator = new RegisterClientsValidator();
            var request = RequestRegisterClientJsonBuilder.Build();

            //Act
            var result = validator.Validator(request);

            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        public void Error_Name_Empty(string name)
        {
            //Arrange
            var validator = new RegisterClientsValidator();
            var request = RequestRegisterClientJsonBuilder.Build();
            request.ClientName = name;

            //Act
            var exception = Assert.Throws<ErrorOnValidationException>(() => validator.Validator(request));

            //Assert
            Assert.Contains(ResourceErrorMessages.REQUIRED_NAME, exception.GetErrors());
        }

        [Fact]
        public void Area_Of_Activity_Invalid()
        {
            //Arrange
            var validator = new RegisterClientsValidator();
            var request = RequestRegisterClientJsonBuilder.Build();
            request.AreaOfActivity = (AreaOfActivity)40;

            //Act
            var exception = Assert.Throws<ErrorOnValidationException>(() => validator.Validator(request));

            //Assert
            Assert.Contains(ResourceErrorMessages.AREA_OF_ACTIVITY, exception.GetErrors());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-5)]
        [InlineData(-7)]
        public void Error_Amount_Charged(decimal amount)
        {
            //Arrange
            var validator = new RegisterClientsValidator();
            var request = RequestRegisterClientJsonBuilder.Build();
            request.AmountCharged = amount;

            //Act
            var exception = Assert.Throws<ErrorOnValidationException>(() => validator.Validator(request));

            //Assert
            Assert.Contains(ResourceErrorMessages.AMOUNT_CHARGED, exception.GetErrors());

        }

        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        public void Description_Error(string description)
        {
            // Arrange
            var validator = new RegisterClientsValidator();
            var request = RequestRegisterClientJsonBuilder.Build();
            request.ServiceDescription = description;

            //Act
            var exception = Assert.Throws<ErrorOnValidationException>(() => validator.Validator(request));

            //Assert
            Assert.Contains(ResourceErrorMessages.SERVICE_DESCRIPTION, exception.GetErrors());
        }

    }
}
