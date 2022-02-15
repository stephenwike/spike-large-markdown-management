using System.Collections;
using System.Collections.Generic;
using DesignDocMarkupLanguage.DataStructs;
using DesignDocMarkupLanguage.TestManagement.Generators;

namespace DesignDocMarkupLanguage.TestManagement.TestDataClasses;

public class DocumentBuilderParseInvalidTestData : IEnumerable<object[]>
{
    // Templates
    private readonly string[] Template_Queue_Is_Empty = { "::Header 1::" };
    
    // Template Queues
    private readonly TemplateQueue Queue_Is_Empty = new TemplateQueueGenerator().GenerateQueue().Build();

    // Expected Results
    private readonly string[] Expected_Queue_Is_Empty = { "::Header 1::" };

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { Template_Queue_Is_Empty , Queue_Is_Empty, Expected_Queue_Is_Empty };
        // TODO: Come up with more tests for when invalid data is given.
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}