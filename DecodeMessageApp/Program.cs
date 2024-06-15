using System;
using System.Text;

class Program
{
    static void Main()
    {
        // Mensagem criptografada
        string encryptedMessage = "10000101 00110101 01100101 01100101 01110101 00100001 01011100 01111010 00101100 00110101 00100101 10000011";
        // Descriptografa a mensagem
        string decryptedMessage = DecryptMessage(encryptedMessage);
        // Imprime a mensagem descriptografada
        Console.WriteLine("Decrypted message: " + decryptedMessage);
    }

    static string DecryptMessage(string encryptedMessage)
    {
        // Divide a mensagem criptografada em bytes (cada byte tem 8 bits)
        string[] bytesArray = encryptedMessage.Split(' ');

        StringBuilder decryptedMessage = new StringBuilder();
        foreach (string byteStr in bytesArray)
        {
            // Inverte os dois últimos bits do byte
            string invertedByte = InvertLastTwoBits(byteStr);
            // Troca os nibbles (4 bits) do byte
            string swappedByte = SwapNibbles(invertedByte);
            // Converte o byte descriptografado em um caractere ASCII
            char character = (char)Convert.ToInt32(swappedByte, 2);
            // Adiciona o caractere à mensagem descriptografada
            decryptedMessage.Append(character);
        }

        return decryptedMessage.ToString();
    }

    static string InvertLastTwoBits(string byteStr)
    {
        // Converte o byte em um array de caracteres para manipulação
        char[] byteArray = byteStr.ToCharArray();
        // Inverte os dois últimos bits do byte
        char temp = byteArray[6];
        byteArray[6] = byteArray[7];
        byteArray[7] = temp;
        return new string(byteArray);
    }

    static string SwapNibbles(string byteStr)
    {
        // Troca os 4 primeiros bits com os 4 últimos bits do byte
        return byteStr.Substring(4, 4) + byteStr.Substring(0, 4);
    }
}
