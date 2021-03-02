using System;
using Assignment2.ExtensionMethods;
using Xunit;

namespace Assignment2.Tests
{
    public class StringOperationsTest
    {
        [Theory]
        [InlineData("JoHn", "jOhN")]
        [InlineData("QuiCk FOx", "qUIcK foX")]
        [InlineData("Doe", "dOE")]
        [InlineData("SoME TeXt Bla bLA", "sOme tExT bLA Bla")]
        [InlineData("He11o", "hE11O")]
        public void ChangeCase_ReturnsLowerCaseCharConvertedToUpperCaseAndViceVersa(string input, string expOutput)
        {
            // Arrange
            // Nothing to do here

            // Act
            var output = input.ChangeCase();

            // Assert
            Assert.Equal(expOutput, output);
        }

        [Fact]
        public void ChangeCase_ThrowsArgumentNullExceptionWhenNullStringIsPassed()
        {
            // Arrange
            // Nothing to do here

            // Act
            try
            {
                ((string)null).ChangeCase();
            }
            catch (Exception e)
            {
                // Assert
                 var argNullException = Assert.IsType<ArgumentNullException>(e);
                Assert.Equal("input", argNullException.ParamName);
            }
        }

        [Fact]
        public void ChangeCase_ThrowsArgumentExceptionWhenEmptyStringIsPassed()
        {
            // Arrange
            // Nothing to do here

            // Act
            try
            {
                "".ChangeCase();
            }
            catch (Exception e)
            {
                // Assert
                Assert.IsType<ArgumentException>(e);
                Assert.Equal("input cannot be empty (Parameter 'input')", e.Message);
            }
        }



        [Theory]
        [InlineData("JOhn dOe", "John Doe")]
        [InlineData("The quick bROWn fOx jumps OVer the laZY dog", "The Quick Brown Fox Jumps Over The Lazy Dog")]
        [InlineData("WAR AND PEACE", "WAR AND PEACE")]
        [InlineData("hello123 4ere", "Hello123 4Ere")]
        [InlineData("1234", "1234")]
        public void ToTitleCase_ReturnsInputStringConvertedToTitleCase(string input, string expOutput)
        {
            // Arrange
            // Nothing to do here

            // Act
            var output = input.ToTitleCase();

            // Assert
            Assert.Equal(expOutput, output);
        }


        [Theory]
        [InlineData("JOhn dOe", false)]
        [InlineData("the quick brown fox", true)]
        [InlineData("WAR AND PEACE", false)]
        [InlineData("hello there", true)]
        [InlineData("1234 hello", false)]
        public void IsLowerCaseString_ReturnsWeatherInputStringIsLowerCaseOrNot(string input, bool expOutput)
        {
            // Arrange
            // Nothing to do here

            // Act
            var output = input.IsLowerCase();

            // Assert
            Assert.Equal(expOutput, output);
        }


        [Theory]
        [InlineData("JOHN DOE", true)]
        [InlineData("the QUICK brown FOX", false)]
        [InlineData("WAR AND PEACE", true)]
        [InlineData("hello there", false)]
        [InlineData("1234 hello", false)]
        public void IsUpperCaseString_ReturnsWeatherInputStringIsUpperCaseOrNot(string input, bool expOutput)
        {
            // Arrange
            // Nothing to do here

            // Act
            var output = input.IsUpperCase();

            // Assert
            Assert.Equal(expOutput, output);
        }


        [Theory]
        [InlineData("JOhn dOe", "John doe")]
        [InlineData("The quick bROWn fOx jumps OVer the laZY dog", "The quick brown fox jumps over the lazy dog")]
        [InlineData("WAR AND PEACE", "War and peace")]
        [InlineData("hello123 4ere", "Hello123 4ere")]
        [InlineData("1234", "1234")]
        public void Capitalize_ReturnsInputStringWithFirstCharUpperCaseAndAllRemainingLowerCase(string input, string expOutput)
        {
            // Arrange
            // Nothing to do here

            // Act
            var output = input.Capitalize();

            // Assert
            Assert.Equal(expOutput, output);
        }


        [Theory]
        [InlineData("97", true)]
        [InlineData("1095", true)]
        [InlineData("1C2", false)]
        [InlineData("176494992", true)]
        [InlineData("s1234", false)]
        public void IsValidNumericValue_ReturnsWeatherInputStringIsValidNumericValue(string input, bool expOutput)
        {
            // Arrange
            // Nothing to do here

            // Act
            var output = input.IsValidNumericValue();

            // Assert
            Assert.Equal(expOutput, output);
        }


        [Theory]
        [InlineData("JoHn", "JoH")]
        [InlineData("QuiCk FOx", "QuiCk FO")]
        [InlineData("Doe", "Do")]
        [InlineData("SoME TeXt Bla bLA", "SoME TeXt Bla bL")]
        [InlineData("He111", "He11")]
        public void RemoveLastCharacter_ReturnsInputStringWithLastCharRemoved(string input, string expOutput)
        {
            // Arrange
            // Nothing to do here

            // Act
            var output = input.RemoveLastCharacter();

            // Assert
            Assert.Equal(expOutput, output);
        }


        [Theory]
        [InlineData("JOhn dOe", 2)]
        [InlineData("The quick bROWn fOx jumps OVer the laZY dog", 9)]
        [InlineData("WAR AND PEACE", 3)]
        [InlineData("hello123 4ere 902L", 3)]
        [InlineData("1234 4567", 2)]
        public void WordCount_ReturnsWordCountFromInputString(string input, int expCount)
        {
            // Arrange
            // Nothing to do here

            // Act
            var output = input.WordCount();

            // Assert
            Assert.Equal(expCount, output);
        }

        [Theory]
        [InlineData("97", 97)]
        [InlineData("1095", 1095)]
        [InlineData("342340", 342340)]
        [InlineData("17649", 17649)]
        [InlineData("1", 1)]
        public void ToInteger_ReturnsIntegerParsedFromInputString(string input, int expOutput)
        {
            // Arrange
            // Nothing to do here

            // Act
            var output = input.ToInteger();

            // Assert
            Assert.Equal(expOutput, output);
        }
    }
}
