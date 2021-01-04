using System;
using System.Security.Cryptography;

namespace Hashing
{
    class MACHandler
    {
        private HMAC myMAC;
        public MACHandler(string name)
        {
            if (name.CompareTo("SHA1") == 0)
            {
                myMAC = new HMACSHA1();
            }
            if (name.CompareTo("MD5") == 0)
            {
                myMAC = new HMACMD5();
            }
            if (name.CompareTo("RIPEMD") == 0)
            {
                myMAC = new HMACRIPEMD160();
            }
            if (name.CompareTo("SHA256") == 0)
            {
                myMAC = new HMACSHA256();
            }
            if (name.CompareTo("SHA384") == 0)
            {
                myMAC = new HMACSHA384();
            }
            if (name.CompareTo("SHA512") == 0)
            {
                myMAC = new HMACSHA512();
            }
        }

        public byte[] ComputeMAC(byte[] mes, byte[] key)
        {
            myMAC.Key = key;
            return myMAC.ComputeHash(mes);
        }
        public bool CheckAuthenticity(byte[] mes, byte[] mac, byte[] key)
        {
            myMAC.Key = key;
            if (CompareByteArrays(myMAC.ComputeHash(mes), mac, myMAC.HashSize / 8) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CompareByteArrays(byte[] a, byte[] b, int len)
        {
            for (int i = 0; i < len; i++)
                if (a[i] != b[i]) return false;
            return true;
        }
    }
}
