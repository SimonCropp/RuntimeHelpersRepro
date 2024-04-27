public class Usage
{
    void Foo()
    {
        var array = new[]
        {
            "value1",
            "value2"
        };
        var subArray = array[..1];
    }
}