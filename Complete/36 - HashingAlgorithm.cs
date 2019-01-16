using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace _01_Complete
{
    class myHashingAlgorithm
    {
        public static void Main()
        {
            myHashingAlgorithm mha = new myHashingAlgorithm();
            var hashingcode = mha.GetHash("02-Decisions.cs", "SHA-512");
            Console.WriteLine(Encoding.UTF8.GetString(hashingcode));
            Console.ReadLine();
        }
        public byte[] GetHash(string filename, string algorithmType)
        {
            var hasher = HashAlgorithm.Create(algorithmType);
            var filesBytes = File.ReadAllBytes(filename);
            //1 ==
            //var outputBuffer = new byte[filesBytes.Length];
            //hasher.TransformBlock(filesBytes, 0, filesBytes.Length, outputBuffer, 0);
            //hasher.TransformFinalBlock(filesBytes,filesBytes.Length - 1, filesBytes.Length);
            //System.ArgumentException: Offset and length were out of bounds for 
            //       the array or count is greater than the number of elements from 
            //       index to the end of the source collection.
            //return outputBuffer;
            //2 ==
            //hasher.ComputeHash(filesBytes);
            //return hasher.GetHashCode(); // Cannot implicitly convert type 'int' to 'byte[]'
            //3 ==
            //var outputBuffer = new byte[filesBytes.Length];
            //hasher.TransformBlock(filesBytes, 0, filesBytes.Length, outputBuffer, 0);
            //return outputBuffer; // Return file content
            //4 ==
            hasher.ComputeHash(filesBytes);
            return hasher.Hash; //???|?g)?R?yh???M??>rCU???>?ud?[?U?  '??N?y????LoM???-;!
        }

    }
}
