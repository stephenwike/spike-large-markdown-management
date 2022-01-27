using System.Collections.Generic;
using System.IO;
using DesignDocMarkupLanguage.DataStructs;
using DesignDocMarkupLanguage.Parsers;
using DesignDocMarkupLanguage.TestManagement;
using FluentAssertions;
using Moq;
using Xunit;

namespace DesignDocMarkupLanguage.UnitTests.Validators;

public class TemplateParserTests
{
    private Mock<FileGraph> mockGraph = new Mock<FileGraph>();
    
    
    [Theory]
    [ClassData(typeof(TemplateValidTestData))]
    public void Parse_GivenValidTemplate_ShouldReturnMatchingGraph(string validTemplate)
    {
        // Arrange
        var mockRoot = new Mock<FileGraphNode>();
        var mockHeader1 = new Mock<FileGraphNode>();
        mockHeader1.SetupGet(x => x.Parent).Returns(mockRoot.Object);
        mockHeader1.SetupGet(x => x.Value).Returns(new FileNodeInfo("01 Header"));
        mockRoot.SetupGet(x => x.Children).Returns(new List<FileGraphNode>() {mockHeader1.Object});
        
        var parser = new TemplateParser();
        mockGraph.SetupGet(x => x.Root).Returns(mockRoot.Object);

        // Act
        var result = parser.Parse(validTemplate, mockGraph.Object);
        
        // Assert
        result.Should().NotBeNull();
    }
    
    [Theory]
    [ClassData(typeof(TemplateInvalidTestData))]
    public void Validate_GivenInvalidTags_ShouldGiveReturnNull(string invalidTemplate)
    {
        // Arrange
        var parser = new TemplateParser();

        // Act
        var result = parser.Parse(invalidTemplate, new FileGraph(new DirectoryInfo("")));
        
        // Assert
        result.Should().BeNull();
    }
}