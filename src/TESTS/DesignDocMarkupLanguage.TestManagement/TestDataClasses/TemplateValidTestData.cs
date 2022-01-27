using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DesignDocMarkupLanguage.TestManagement;

public class TemplateValidTestData : IEnumerable<object[]>
{
    public static string Empty_String_Is_Valid = string.Empty;
    public static string Extra_Not_Tag_Content_After = @"::Header::SomeUnrelatedStuff";
    public static string Single_Line_Regular_Is_Valid = @"::Header::";
    public static string Single_Line_Collapse_Is_Valid = @"[::Header::]";
    public static string Multi_Line_Regular_Is_Valid = @"
::Header::
    ::Subject::
        ::Topic::";
    public static string Multi_Line_Collapse_Is_Valid = @"
[::Header::]
    [::Subject::]
        [::Topic::]";

    public static string Multi_Line_Mixed_Is_Valid = @"
::Header::
    [::Subject::]
        ::Topic::
            [::SupTopic::]";

    public static string Complex_Template_Is_Valid = @"
[::Header 1::]
    [::Subject 1::]
        ::Topic 1::
            [::SubTopic 1::]
            ::SubTopic 2::
                [::Detail 1::]
                [::Detail 2::]
                ::Detail 3::
        [::Topic 2::]
    ::Subject 2::
::Header 2::
    ::Subject 1::
        ::SubTopic 1::
        [::SubTopic 2::]
                ::Detail 3::
    [::Subject 2::]
[::Header 3::]
    ::Subject 1::
::Header 4::";
    

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