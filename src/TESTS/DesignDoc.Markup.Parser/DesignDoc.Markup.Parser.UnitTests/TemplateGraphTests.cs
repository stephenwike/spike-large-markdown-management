using Xunit;
using FluentAssertions;

namespace DesignDoc.Markup.Parser.UnitTests;

public class DesignDocMarkupParserTests
{
    [Theory]
    [ClassData(typeof(TemplateValidTestData))]
    public void Validate_GivenValidTags_ShouldGiveReturnTrue(string validTemplate)
    {
        // Act
        var result = DesignDocMarkupParser.Validate(validTemplate);
        
        // Assert
        result.Should().BeTrue();
    }
    
    [Theory]
    [ClassData(typeof(TemplateInvalidTestData))]
    public void Validate_GivenInvalidTags_ShouldGiveReturnFalse(string invalidTemplate)
    {
        // Act
        var result = DesignDocMarkupParser.Validate(invalidTemplate);
        
        // Assert
        result.Should().BeFalse();
    }
}