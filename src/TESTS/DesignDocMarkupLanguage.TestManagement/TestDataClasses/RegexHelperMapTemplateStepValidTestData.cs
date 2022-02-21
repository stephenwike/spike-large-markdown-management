using System.Collections;
using System.Collections.Generic;
using DesignDocMarkupLanguage.Constants;
using DesignDocMarkupLanguage.DataStructs;
using DesignDocMarkupLanguage.TestManagement.Generators;

namespace DesignDocMarkupLanguage.TestManagement.TestDataClasses;

public class DocumentBuilderParseValidTestData : IEnumerable<object[]>
{
    // Templates
    private readonly string[] Template_Queue_Is_Empty = {"Some unrelated content"};
    private readonly string[] Template_Regular_Tag = {"::Heading 1::"};
    private readonly string[] Template_Regular_With_Content = { "::Heading 1::" };
    private readonly string[] Template_Collapse_Tag = { "[:Heading 1:]" };

    // Template Queues
    private readonly TemplateQueue Queue_Is_Empty = new TemplateQueueGenerator().GenerateQueue().Build();
    private readonly TemplateQueue Queue_Regular_Tag = new TemplateQueueGenerator().GenerateQueue()
        .AddStep(1, TemplateAction.Regular, "Heading 1", 0).Build();
    private readonly TemplateQueue Queue_Regular_With_Content = new TemplateQueueGenerator().GenerateQueue()
        .AddStep(1, TemplateAction.Regular, "Heading 1", 0, new string[] 
            { "Some content." }).Build();
    private readonly TemplateQueue Queue_Collapse_Tag = new TemplateQueueGenerator().GenerateQueue()
        .AddStep(1, TemplateAction.Collapse, "Heading 1", 0, new string[]
            { "Some content." }).Build();
    
    // Expected Results
    private readonly string[] Expected_Queue_Is_Empty = { "Some unrelated content" };
    private readonly string[] Expected_Regular_Tag = { "# Heading 1", "" };
    private readonly string[] Expected_Regular_With_Content = { "# Heading 1", "", "Some content.", "" };
    private readonly string[] Expected_Collapse_Tag = { "<details id=\"TestId\">", 
        "<summary>Heading 1</summary>", "", "Some content.", "", "</details>", ""};

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { Template_Queue_Is_Empty , Queue_Is_Empty, Expected_Queue_Is_Empty };
        yield return new object[] { Template_Regular_Tag , Queue_Regular_Tag, Expected_Regular_Tag };
        yield return new object[] { Template_Regular_With_Content , Queue_Regular_With_Content, Expected_Regular_With_Content };
        yield return new object[] { Template_Collapse_Tag , Queue_Collapse_Tag, Expected_Collapse_Tag };
        // TODO: Add test for nested tags.
        // TODO: Add tests for different depths.
        // TODO: Add tests for various combinations of tags.
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}