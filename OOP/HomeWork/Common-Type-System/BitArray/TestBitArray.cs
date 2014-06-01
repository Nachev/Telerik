namespace BitArray
{
    using System;

    /*Define a class BitArray64 to hold 64 bit values inside an ulong value. 
    * Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.*/

    public class TestBitArray
    {
        private const ulong AllOnes = 18446744073709551615;

        private static void Main()
        {
            var bitArr = new BitArray64(12436744071709501615);
            var bitArr2 = new BitArray64(AllOnes);
            byte line = new byte();
            foreach (var bit in bitArr)
            {
                Console.Write("bit {0,2} : ", line++);
                Console.WriteLine(bit);
            }

            Console.WriteLine("Hash codes:");
            Console.WriteLine(bitArr.GetHashCode());
            Console.WriteLine(bitArr2.GetHashCode());

            Console.WriteLine(bitArr[32]);
            bitArr[32] = 0;
            Console.WriteLine(bitArr[32]);
            bitArr[32] = 1;
            Console.WriteLine(bitArr[32]);
            Console.WriteLine(bitArr == bitArr2);
        }
    }
}