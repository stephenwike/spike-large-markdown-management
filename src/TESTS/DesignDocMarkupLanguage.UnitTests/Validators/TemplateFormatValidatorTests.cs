using System;
using DesignDocMarkupLanguage.TestManagement;
using DesignDocMarkupLanguage.Validators;
using FluentAssertions;
using Xunit;

namespace DesignDocMarkupLanguage.UnitTests.Validators;

public class TemplateFormatValidatorTests
{
    [Theory]
    [ClassData(typeof(TemplateValidTestData))]
    public void Validate_ValidTemplate_ShouldNotThrowException(string[] template)
    {
        // Arrange
        var validator = new TemplateFormatValidator();
        
        // Act
        var act = () => validator.Validate(template);
        
        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [ClassData(typeof(TemplateInvalidTestData))]
    public void Validate_InvalidTemplate_ShouldThrowException(string[] template)
    {
        // Arrange
        var validator = new TemplateFormatValidator();
        
        // Act
        var act = () => validator.Validate(template);
        
        // Assert
        act.Should().Throw<Exception>();
    }
}