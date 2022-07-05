using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Union(0, typeof(MyClass2))]
[Union(1, typeof(MyClass3))]
[MessagePackObject]
public abstract class MyClass
{
    // Key attributes take a serialization index (or string name)
    // The values must be unique and versioning has to be considered as well.
    // Keys are described in later sections in more detail.
    [Key(0)]
    public int Age { get; set; }

    [Key(1)]
    public string FirstName { get; set; }

    [Key(2)]
    public string LastName { get; set; }

    // All fields or properties that should not be serialized must be annotated with [IgnoreMember].
    [IgnoreMember]
    public string FullName { get { return FirstName + LastName; } }
}

[MessagePackObject]
public class MyClass2 : MyClass
{
    [Key(10)]
    public string XYZ { get; set; }
}

[MessagePackObject]
public class MyClass3 : MyClass2
{
    [Key(11)]
    public string ABC { get; set; }
}

