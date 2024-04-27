using NUnit.Framework;
using NUnit.Framework.Legacy;

[TestFixture]
public class Usage
{
    [Test]
    public void Foo()
    {
        var array = new[]
        {
            "value1",
            "value2"
        };
        var subArray = array[..1];
        ClassicAssert.AreEqual("value1", subArray[0]);
    }
}