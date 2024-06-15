using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    public static void Main()
    {
        // Mensagem criptografada fornecida
        string ciphertext = @"
            10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 
            00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";

        // Remove espaços em branco e quebras de linha extras
        ciphertext = ciphertext.Replace("\n", "").Replace("\r", "").Replace(" ", "");

        // Descriptografa a mensagem
        string plaintext = DecryptMessage(ciphertext);

        Console.WriteLine("Mensagem descriptografada:");
        Console.WriteLine(plaintext);
    }

    public static string DecryptMessage(string ciphertext)
    {
        // Divide a mensagem criptografada em bytes
        List<string> encryptedBytes = SplitByLength(ciphertext, 8);

        List<byte> decryptedBytes = new List<byte>();
        foreach (string byteStr in encryptedBytes)
        {
            byte b = Convert.ToByte(byteStr, 2);
            // Aplicar a inversão dos últimos 2 bits
            b = InvertLastTwoBits(b);
            // Aplicar a troca dos nibbles
            b = SwapNibbles(b);
            decryptedBytes.Add(b);
        }

        // Converte os bytes para caracteres ASCII
        string decryptedMessage = Encoding.ASCII.GetString(decryptedBytes.ToArray());
        return decryptedMessage;
    }

    public static byte InvertLastTwoBits(byte b)
    {
        // Inverter os dois últimos bits de um byte
        return (byte)(b ^ 0b11);
    }

    public static byte SwapNibbles(byte b)
    {
        // Trocar os nibbles (os 4 bits mais significativos com os 4 bits menos significativos)
        return (byte)(((b & 0x0F) << 4) | ((b & 0xF0) >> 4));
    }

    public static List<string> SplitByLength(string str, int length)
    {
        // Divide a string em partes de comprimento especificado
        List<string> parts = new List<string>();
        for (int i = 0; i < str.Length; i += length)
        {
            parts.Add(str.Substring(i, Math.Min(length, str.Length - i)));
        }
        return parts;
    }
}
