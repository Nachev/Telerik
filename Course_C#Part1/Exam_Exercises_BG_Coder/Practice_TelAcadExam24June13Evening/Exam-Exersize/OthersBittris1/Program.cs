using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Bittris
{
    static uint GetScorePiece(byte numberPiece)
    {
        byte points = 0;
        for (int i = 0; i < 32; i++)
        {
            if (((oneCount[numberPiece] >> i) & 1) == 1)
            {
                points++;
            }
        }
        if (field[finalLine] == 255)
        {
            points = (byte)(points * 10);
            for (sbyte i = finalLine; i >= 1; i--)
            {
                field[i] = field[i - 1];
            }
            field[0] = 0;
            finalLine = -1;
        }
        return points;
    }

    static void MovePiece(char com, byte line, byte numberPiece)
    {
        byte pieceBefore = pieces[numberPiece];
        if (com == 'L')
        {
            if (((pieces[numberPiece] >> 7) & 1) != 1)
            {
                pieces[numberPiece] = (byte)(pieces[numberPiece] << 1);
                field[line] = (byte)(field[line] ^ pieceBefore);
                field[line] = (byte)(field[line] | pieces[numberPiece]);
                pieceBefore = pieces[numberPiece];
            }
        }
        else if (com == 'R')
        {
            if ((pieces[numberPiece] & 1) != 1)
            {
                pieces[numberPiece] = (byte)(pieces[numberPiece] >> 1);
                field[line] = (byte)(field[line] ^ pieceBefore);
                field[line] = (byte)(field[line] | pieces[numberPiece]);
                pieceBefore = pieces[numberPiece];
            }
        }
        if ((field[line + 1] & pieces[numberPiece]) == 0)
        {
            field[line + 1] = (byte)(field[line + 1] | pieces[numberPiece]);
            field[line] = (byte)(field[line] ^ pieceBefore);
        }
        else
        {
            isFinal = true;
            finalLine = (sbyte)line;
            score += GetScorePiece(numberPiece);
            return;
        }
        if (line + 1 == 3)
        {
            isFinal = true;
            finalLine = 3;
            score += GetScorePiece(numberPiece);
            return;
        }
    }

    static byte[] pieces;
    static int[] oneCount;
    static bool isFinal = false;
    static bool gameOver = false;
    static uint score = 0;
    static byte[] field;
    static sbyte finalLine = -1;

    static void Main()
    {
        field = new byte[4];
        int inputsCount = int.Parse(Console.ReadLine());
        inputsCount = inputsCount / 4;
        pieces = new byte[inputsCount];
        oneCount = new int[inputsCount];
        char[,] commands = new char[3, inputsCount];
        for (int i = 0; i < inputsCount; i++)
        {
            oneCount[i] = int.Parse(Console.ReadLine());
            pieces[i] = (byte)oneCount[i];
            commands[0, i] = char.Parse(Console.ReadLine());
            commands[1, i] = char.Parse(Console.ReadLine());
            commands[2, i] = char.Parse(Console.ReadLine());
        }
        for (int j = 0; j < inputsCount; j++)
        {
            field[0] = (byte)((pieces[j]) & (~(byte)0));
            isFinal = false;                //draw the piece;
            for (byte i = 0; i < 3; i++)
            {
                MovePiece(commands[i, j], (byte)i, (byte)j);
                if (isFinal)
                {
                    if (field[0] != 0)
                    {
                        gameOver = true;
                    }
                    break;
                }
            }
            if (gameOver)
            {
                break;
            }
        }
        Console.WriteLine(score);
    }
}