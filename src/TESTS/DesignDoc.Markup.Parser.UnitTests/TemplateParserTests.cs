using DesignDoc.Markup.TestManagement;
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
        var parser = new TemplateParser(new MarkupSettings());

        // Act
        var result = parser.Parse(validTemplate);
        
        // Assert
        result.Should().NotBeNull();
    }
    
    [Theory]
    [ClassData(typeof(TemplateInvalidTestData))]
    public void Validate_GivenInvalidTags_ShouldGiveReturnNull(string invalidTemplate)
    {
        // Arrange
        var parser = new TemplateParser(new MarkupSettings());

        // Act
        var result = parser.Parse(invalidTemplate);
        
        // Assert
        result.Should().BeNull();
    }
}