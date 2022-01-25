using DesignDoc.Markup.TestManagement;
using Xunit;
using FluentAssertions;

namespace DesignDoc.Markup.Parser.UnitTests;

public class MarkupValidatorTests
{
    [Theory]
    [ClassData(typeof(TemplateValidTestData))]
    public void Validate_GivenValidTags_ShouldGiveReturnTrue(string validTemplate)
    {
        // Arrange
        var validator = new MarkupValidator();

        // Act
        var result = validator.Validate(validTemplate);
        
        // Assert
        result.Should().BeTrue();
    }
    
    [Theory]
    [ClassData(typeof(TemplateInvalidTestData))]
    public void Validate_GivenInvalidTags_ShouldGiveReturnFalse(string invalidTemplate)
    {
        // Arrange
        var validator = new MarkupValidator();

        // Act
        var result = validator.Validate(invalidTemplate);
        
        // Assert
        result.Should().BeFalse();
    }
}