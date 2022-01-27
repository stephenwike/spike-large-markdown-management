using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DesignDocMarkupLanguage.TestManagement;

public class TemplateInvalidTestData : IEnumerable<object[]>
{
    public static string Missing_Char_Regular_Closing_Tag = @"::Header:";
    public static string Missing_Char_Regular_Opening_Tag = @":Header::";
    public static string Missing_Char_Collapse_Closing_Tag = @"[::Header:]";
    public static string Missing_CharCollapse_Opening_Tag = @"[:Header::]";
    public static string Mismatch_Tags_Regular_Then_Collapsed = @"::Header::]";
    public static string Mismatch_Tags_Collapse_Then_Regular = @"[::Header::";
    public static string Reversed_Collapse_Tags = @"::]Header[::";
    public static string Missing_Regular_Opening_Tag = @"Header::";
    public static string Missing_Regular_Closing_Tag = @"::Header";
    public static string Missing_Collapse_Opening_Tag = @"Header::]";
    public static string Missing_Collapse_Closing_Tag = @"[::Header";
    public static string Extra_Regular_Tag = @"::Header:: ::";
    public static string Extra_Collapse_Tag = @"[::Header::] ::]";
    public static string Extra_Regular_Char_Collapse_Tag = @"[::Header:::]";
    public static string Missing_Char_In_Middle = @"
::Header 1::
    ::Topic 1: // Missing a ':'
        ::SubTopic 1::";

    public static string Duplicate_Label_In_Middle = @"
::Header::
    ::Topic:: ::Topic::
";

    public IEnumerator<object[]> GetEnumerator()
    {
        var fields = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Static).ToList();
        for (int i = 0; i < fields.Count; ++i)
        {
            yield return new object[] { fields[i].GetValue(this) };
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}