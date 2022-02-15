using DesignDocMarkupLanguage.DataStructs;
using DesignDocMarkupLanguage.Parsers;
using DesignDocMarkupLanguage.TestManagement.TestDataClasses;
using FluentAssertions;
using Moq;
using Xunit;

namespace DesignDocMarkupLanguage.UnitTests.Validators;

public class DocumentBuilderTests
{
    private readonly Mock<FileGraph> _mockGraph = new Mock<FileGraph>();
    
    [Theory]
    [ClassData(typeof(DocumentBuilderParseValidTestData))]
    public void Parse_GivenValidTemplateAndQueue_ShouldReturnTemplateWithCorrectContent(string[] validTemplate, TemplateQueue queue, string[] expectedResult)
    {
        // Arrange
        var builder = new DocumentBuilder();

        // Act
        var result = builder.Parse(validTemplate, queue);
        
        // Assert
        result.Should().Equal(expectedResult);
    }
    
    [Theory]
    [ClassData(typeof(DocumentBuilderParseInvalidTestData))]
    public void Validate_GivenInvalidTags_ShouldGiveReturnNull(string[] inValidTemplate, TemplateQueue queue, string[] expectedResult)
    {
        // Arrange
        var parser = new DocumentBuilder();

        // Act
        var result = parser.Parse(inValidTemplate, queue);
        
        // Assert
        result.Should().Equal(expectedResult);
    }
}