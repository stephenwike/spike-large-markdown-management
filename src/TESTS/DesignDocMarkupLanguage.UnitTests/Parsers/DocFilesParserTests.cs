using System;
using System.IO;
using DesignDocMarkupLanguage.Parsers;
using DesignDocMarkupLanguage.TestManagement;
using FluentAssertions;
using Xunit;

namespace DesignDocMarkupLanguage.UnitTests.Parsers;

public class DocFilesParserTests : IClassFixture<TestFilesFixture>
{
    private Uri _testDir;
    
    public DocFilesParserTests(TestFilesFixture fixture)
    {
        _testDir = new Uri(Path.Combine(fixture.GetBaseDirectory(2), "TestFiles"));
    }
    
    [Fact]
    public void Validate_MissingFileNumberInSequence_ShouldThrowException()
    {
        // Arrange
        var parser = new DocFilesParser();
        
        // Act
        var act = () => parser.Parse(new Uri(_testDir, "MissingFileNumberInSequence"));
        
        // Assert
        act.Should().Throw<Exception>();
    }
}