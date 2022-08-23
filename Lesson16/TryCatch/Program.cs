Show(3);

/*
int[] arr = new int[] { 1, 2, 3, 4, 5 };
var el = GetElementByIndex(1);
Console.WriteLine(el);

int GetElementByIndex(int index)
{
    return arr[index];
}
*/


void Show(object obj)
{
    int son = 0;
    try
    {
        Console.WriteLine("try : ");
        son = (int)obj;

        int[] arr = new int[1];

        Console.WriteLine(arr[2]);
    }
    catch (InvalidCastException ex)
    {
        Console.WriteLine(" Cast :  " + ex.Message);
        //
    }
    catch (NullReferenceException ex)
    {
        Console.WriteLine(" NullRef :  " + ex.Message);
        //
    }
    catch (IndexOutOfRangeException ex)
    {
        //
    }
    catch (Exception ex)
    {
        //error
        Console.Write("catch: ");

        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine("finally");
        Console.WriteLine(son);
    }
}