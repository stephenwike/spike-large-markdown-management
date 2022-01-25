using System.Collections;
using System.Collections.Generic;

namespace DesignDoc.Markup.TestManagement;

public class TemplateInvalidTestData : IEnumerable<object[]>
{
    private readonly string _template1 = @"
::Header 1::
    ::Topic 1: // Missing a ':'
        ::SubTopic 1::";

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { _template1 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}