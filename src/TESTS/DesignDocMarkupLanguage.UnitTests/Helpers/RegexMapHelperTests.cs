using System;
using System.Text.RegularExpressions;
using DesignDocMarkupLanguage.CLI;
using DesignDocMarkupLanguage.Constants;
using DesignDocMarkupLanguage.Helpers;
using DesignDocMarkupLanguage.Models;
using DesignDocMarkupLanguage.TestManagement.TestDataClasses;
using FluentAssertions;
using Xunit;

namespace DesignDocMarkupLanguage.UnitTests.Helpers;

public class RegexMapHelperTests
{
    [Theory]
    [ClassData(typeof(RegexHelperMapTemplateStepValidTestData))]
    public void MapTemplateStep_GivenValidMatch_ReturnsValidTemplateStep(string validInput, TemplateStep? validTemplateStep)
    {
        // Arrange
        Settings.IndentType = IndentTypes.FourSpaces; 
        var match = new Regex(Patterns.TemplatePattern).Match(validInput);
        
        // Act
        var templateStep = RegexMapHelper.MapTemplateStep(match, 0);
        
        // Assert
        templateStep.Should().BeEquivalentTo(validTemplateStep);
    }
    
    [Fact]
    public void MapTemplateStep_GivenMatchNotSuccessful_ShouldThrowException()
    {
        // Arrange
        Settings.IndentType = IndentTypes.FourSpaces;
        var match = new Regex(Patterns.TemplatePattern).Match("invalid-input");
        
        // Act
        var act = () => RegexMapHelper.MapTemplateStep(match, 0);
        
        // Assert
        act.Should().Throw<Exception>();
    }
}