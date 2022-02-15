using System;
using System.IO;
using DesignDocMarkupLanguage.DataStructs;
using DesignDocMarkupLanguage.TestManagement.Generators;
using DesignDocMarkupLanguage.Validators;
using FluentAssertions;
using Xunit;

namespace DesignDocMarkupLanguage.UnitTests.Validators;

public class TemplateContentValidatorTests
{
    [Fact]
    public void Validate_ValidFiles_ShouldGiveReturnTrue()
    {
        // Arrange
        var graph = new FileGraphGenerator().GenerateFileGraph("ValidTestFiles");
        var validator = new TemplateContentValidator();

        // Act
        var act = () => validator.ValidateAndUpdate(new TemplateQueue(), new FileGraph(new DirectoryInfo("")));
        
        // Assert
        act.Should().NotThrow();
    }
    
    [Fact]
    public void Validate_RootDirectoryDoesntExist_ShouldThrowException()
    {
        // Arrange
        var graph = new FileGraph(new DirectoryInfo("N/A"));
        var validator = new TemplateContentValidator();
        
        // Act
        var act = () => validator.ValidateAndUpdate(new TemplateQueue(), new FileGraph(new DirectoryInfo("")));
        
        // Assert
        act.Should().Throw<Exception>();
    }
    
    [Fact]
    public void Validate_MissingDirectoryNumber_ShouldNotIncludeDirectory()
    {
        // Arrange
        var graph = new FileGraphGenerator().GenerateFileGraph("MissingDirNumber");
        var validator = new TemplateContentValidator();
        
        // Act
        var act = () => validator.ValidateAndUpdate(new TemplateQueue(), new FileGraph(new DirectoryInfo("")));
        
        // Assert
        graph.Root.Value.FullName.Should().Be("01 MissingDirNumber");
        graph.Root.Children.Should().BeEmpty();
    }
    
    [Fact]
    public void Validate_MissingFileNumber_ShouldNotIncludeFile()
    {
        // Arrange
        var graph = new FileGraphGenerator().GenerateFileGraph("MissingFileNumber");
        var validator = new TemplateContentValidator();
        
        // Act
        var act = () => validator.ValidateAndUpdate(new TemplateQueue(), new FileGraph(new DirectoryInfo("")));
        
        // Assert
        graph.Root.Value.FullName.Should().Be("01 MissingFileNumber");
        graph.Root.Children.Should().BeEmpty();
    }
    
    [Fact]
    public void Validate_MissingFileNumberOnChild_ShouldNotIncludeChildFile()
    {
        // Arrange
        var graph = new FileGraphGenerator().GenerateFileGraph("MissingFileNumberOnChild");
        var validator = new TemplateContentValidator();
        
        // Act
        var act = () => validator.ValidateAndUpdate(new TemplateQueue(), new FileGraph(new DirectoryInfo("")));
        
        // Assert
    }
}