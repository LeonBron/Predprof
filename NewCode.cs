using System;
using System.Security.Cryptography;

using System.IO;
using System.Text;

namespace ConsoleApp5
{
    class Program
    {


        static void Main(string[] args)
        {


            string someString = "asdfgasdfgasdfgasdfg";
            SHA256 sha256 = SHA256.Create();
            byte[] byteforencode = Encoding.ASCII.GetBytes(someString); // получаем массив данных
            byte[] hash = sha256.ComputeHash(byteforencode);                                                           // Console.Write(;
                                                                        /* for (int i = 0; i < byteforencode.Length; i++)
                                                                         {
                                                                             Console.Write(byteforencode[i] + " g ");
                                                                         }*/
            byte[] CodMess; // место для записи закодированного массива

            RSACryptoServiceProvider Keys = new RSACryptoServiceProvider(); // пара ключей
            RSAPKCS1SignatureFormatter Sign = new RSAPKCS1SignatureFormatter(Keys); // объект подпись

            byte[] publicKey = Keys.ExportCspBlob(false);
            for (int i = 0; i < publicKey.Length; i++)
            {
                Console.Write(publicKey[i] + " ");
            }

            CodMess = Sign.CreateSignature(hash);
            //Create an RSAPKCS1SignatureDeformatter object and pass it the  
            //RSACryptoServiceProvider to transfer the key information.
            RSAPKCS1SignatureDeformatter RSADeformatter = new RSAPKCS1SignatureDeformatter(Keys);
            RSADeformatter.SetHashAlgorithm("SHA256");
            //Verify the hash and display the results to the console. 
            if (RSADeformatter.VerifySignature(hash, CodMess))
            {
                Console.WriteLine("The signature was verified.");
            }
            else
            {
                Console.WriteLine("The signature was not verified.");
            }
        }
    }
}
        


//= { 59, 4, 248, 102, 77, 97, 142, 201, 210, 12, 224, 93, 25, 41, 100, 197, 213, 134, 130, 135 };
/*//RSAParameters RSAParams = Keys.ExportParameters(false);
            RSAParameters rsaKeyInfo = Keys.ExportParameters(false);
            rsaKeyInfo.Modulus = modulusData;
            rsaKeyInfo.Exponent = exponentData;
            
            bool dataOK = Keys.VerifyData(CodMess, CryptoConfig.MapNameToOID("SHA1"), Sign);
            Console.ReadLine();*/
