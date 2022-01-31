using System;
using System.IO;
using DesignDocMarkupLanguage.CLI;
using DesignDocMarkupLanguage.TestManagement;
using DesignDocMarkupLanguage.Validators;
using FluentAssertions;
using Xunit;

namespace DesignDocMarkupLanguage.UnitTests.Validators;

public class OptionsValidatorTests : IClassFixture<TestFilesFixture>
{
    private TestFilesFixture _fixture;
    private Uri _testDir;

    public OptionsValidatorTests(TestFilesFixture fixture)
    {
        _testDir = new Uri(Path.Combine(fixture.GetBaseDirectory(2), "TestFiles/"));
    }
    
    [Fact]
    public void Validate_GivenValidPaths_ShouldNotThrowException()
    {
        // Arrange
        var validator = new OptionsValidator();
        var docsFolder = "ValidPath";
        var templateFile = "ValidTemplate.md";
        
        var options = new Options()
        {
            DocsFolder = docsFolder,
            TemplateFile = templateFile,
        };
        
        // Act
        var act = () => validator.Validate(options);
        
        // Assert
        act.Should().NotThrow();
    }
}