using System.Collections;
using System.Collections.Generic;
using DesignDocMarkupLanguage.Constants;
using DesignDocMarkupLanguage.DataStructs;
using DesignDocMarkupLanguage.Models;
using DesignDocMarkupLanguage.TestManagement.Generators;
// ReSharper disable InconsistentNaming

namespace DesignDocMarkupLanguage.TestManagement.TestDataClasses;

public class RegexHelperMapTemplateStepValidTestData : IEnumerable<object[]>
{
    // Templates
    private const string TemplateRegularTag = "::Heading 1::";
    private const string TemplateCollapseTag = "[:Heading 1:]";
    
    // Expected Results
    private readonly TemplateStep ExpectedRegularTagTemplateStep = new TemplateStep
        { Depth = 1, Action = TemplateAction.Regular, Id = "heading-1", Index = 0, Line = 1, Label = "Heading 1"};
    private readonly TemplateStep ExpectedCollapseTagTemplateStep = new TemplateStep
        { Depth = 1, Action = TemplateAction.Collapse, Id = "heading-1", Index = 0, Line = 1, Label = "Heading 1"};

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { TemplateRegularTag , ExpectedRegularTagTemplateStep };
        yield return new object[] { TemplateCollapseTag , ExpectedCollapseTagTemplateStep };
        // TODO: Add more tests ???
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}