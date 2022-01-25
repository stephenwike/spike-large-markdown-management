using Xunit;
using FluentAssertions;

namespace DesignDoc.Markup.Parser.UnitTests;

public class TemplateParserTests
{
    [Theory]
    [ClassData(typeof(TemplateValidTestData))]
    public void Parse_GivenValidTemplate_ShouldReturnMatchingGraph(string validTemplate)
    {
        // Arrange
        var parser = new TemplateParser();

        // Act
        var result = parser.Parse(validTemplate);
        
        // Assert
        result.Should().BeTrue();
    }
    
    [Theory]
    [ClassData(typeof(TemplateInvalidTestData))]
    public void Validate_GivenInvalidTags_ShouldGiveReturnFalse(string invalidTemplate)
    {
        // Arrange
        var parser = new TemplateParser();

        // Act
        var result = parser.Parse(invalidTemplate);
        
        // Assert
        result.Should().BeFalse();
    }
}