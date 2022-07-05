using MessagePack;

var convertAndWriteLine = (MyClass mc) =>
{
    try
    {
        var _mc = mc as MyClass;
        byte[] bytes = MessagePackSerializer.Serialize(_mc);
        MyClass __mc = MessagePackSerializer.Deserialize<MyClass>(bytes);

        // See https://aka.ms/new-console-template for more information
        Console.WriteLine(__mc.FirstName);

        var mc2 = __mc as MyClass2;
        if (mc2 != null) { Console.WriteLine(mc2.XYZ); }

        var mc3 = __mc as MyClass3;
        if (mc3 != null) { Console.WriteLine(mc3.ABC); }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
};

convertAndWriteLine(new MyClass2
{
    Age = 99,
    FirstName = "myclass 2",
    LastName = "huga",
    XYZ = "xyz",
});

// Union したクラスをさらに継承して、MessagePackで扱えるかのテスト
// Keyの重複に気をつければ通る
convertAndWriteLine(new MyClass3
{
    Age = 99,
    FirstName = "myclass 3",
    LastName = "",
    XYZ = "xyz 2",
    ABC = "abc"
});

Console.WriteLine("end");
