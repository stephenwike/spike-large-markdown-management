using System;
using DesignDocMarkupLanguage.Helpers;
using FluentAssertions;
using Xunit;

namespace DesignDocMarkupLanguage.UnitTests.Helpers;

public class ContentHelperTests
{
    // TODO: Make some happy path tests.
    
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void GetContent_PathIsEmptyOrWhiteSpace_ShouldThrowException(string path)
    {
        // Act
        var act = () => ContentHelper.GetContent(path);
        
        // Assert
        act.Should().Throw<Exception>();
    }
}