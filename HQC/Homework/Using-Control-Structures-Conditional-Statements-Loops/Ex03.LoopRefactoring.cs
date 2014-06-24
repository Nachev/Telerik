int arrLength = array.Length;
bool foundExpectedValue = false;

for (int i = 0; i < arrLength; i++) 
{
    if ((i % 10 == 0) && ( array[i] == expectedValue ))
    {
        foundExpectedValue = true;
    }
	
    Console.WriteLine(array[i]);
}

// More code here

if (foundExpectedValue)
{
    Console.WriteLine("Value Found");
}