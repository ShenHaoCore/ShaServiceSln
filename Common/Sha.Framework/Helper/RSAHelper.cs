using System.Security.Cryptography;
using System.Text;

namespace Sha.Framework.Common
{
    /// <summary>
    /// RSA 帮助类
    /// </summary>
    public class RSAHelper
    {
        public readonly RSA privateRsa;
        public readonly RSA publicRsa;
        private readonly Encoding encoding;
        private readonly HashAlgorithmName hashname;

        /// <summary>
        /// RSA 帮助类
        /// </summary>
        /// <param name="hashname"></param>
        /// <param name="encoding"></param>
        /// <param name="privateKey"></param>
        /// <param name="publicKey"></param>
        public RSAHelper(HashAlgorithmName hashname, Encoding encoding, string privateKey, string publicKey)
        {
            this.hashname = hashname;
            this.encoding = encoding ?? Encoding.UTF8;
            privateRsa = CreateRsaProviderFromPrivateKey(privateKey);
            publicRsa = CreateRsaProviderFromPublicKey(publicKey);
        }

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string RSAEncrypt(string text)
        {
            var size = publicRsa.KeySize / 8 - 11;
            byte[] buffer = new byte[size];
            using (MemoryStream msInput = new MemoryStream(encoding.GetBytes(text)))
            {
                using (MemoryStream msOutput = new MemoryStream())
                {
                    int length; while ((length = msInput.Read(buffer, 0, size)) > 0)
                    {
                        byte[] dataToEnc = new byte[length];
                        Array.Copy(buffer, 0, dataToEnc, 0, length); 
                        byte[] encData = publicRsa.Encrypt(dataToEnc, RSAEncryptionPadding.Pkcs1);
                        msOutput.Write(encData, 0, encData.Length);
                    }
                    byte[] result = msOutput.ToArray();
                    return Convert.ToBase64String(result);
                }
            }
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <returns></returns>
        public string RSADecrypt(string text)
        {
            var size = privateRsa.KeySize / 8;
            byte[] buffer = new byte[size];//待解密块  
            using (MemoryStream msInput = new MemoryStream(Convert.FromBase64String(text)))
            {
                using (MemoryStream msOutput = new MemoryStream())
                {
                    int length; while ((length = msInput.Read(buffer, 0, size)) > 0)
                    {
                        byte[] dataToEnc = new byte[length];
                        Array.Copy(buffer, 0, dataToEnc, 0, length); 
                        byte[] encData = privateRsa.Decrypt(dataToEnc, RSAEncryptionPadding.Pkcs1);
                        msOutput.Write(encData, 0, encData.Length);
                    }
                    byte[] result = msOutput.ToArray();
                    return encoding.GetString(result);
                }
            }
        }

        #region 私有
        /// <summary>
        /// 
        /// </summary>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static RSA CreateRsaProviderFromPublicKey(string publicKey)
        {
            byte[] SeqOID = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
            var x509key = Convert.FromBase64String(publicKey);

            using (var mem = new MemoryStream(x509key))
            {
                using (var binr = new BinaryReader(mem))
                {
                    byte bt = 0;
                    ushort twobytes = 0;

                    twobytes = binr.ReadUInt16();
                    switch (twobytes)
                    {
                        case 0x8130:
                            binr.ReadByte();
                            break;
                        case 0x8230:
                            binr.ReadInt16();
                            break;
                        default:
                            throw new Exception("Unexpected Value");
                    }

                    var seq = binr.ReadBytes(15);
                    if (!CompareBytearrays(seq, SeqOID)) { throw new Exception("Unexpected Value"); }


                    twobytes = binr.ReadUInt16();
                    switch (twobytes)
                    {
                        case 0x8103:
                            binr.ReadByte();
                            break;
                        case 0x8203:
                            binr.ReadInt16();
                            break;
                        default:
                            throw new Exception("Unexpected Value");
                    }

                    bt = binr.ReadByte();
                    if (bt != 0x00) { throw new Exception("Unexpected Value"); }

                    twobytes = binr.ReadUInt16();
                    switch (twobytes)
                    {
                        case 0x8130:
                            binr.ReadByte();
                            break;
                        case 0x8230:
                            binr.ReadInt16();
                            break;
                        default:
                            throw new Exception("Unexpected Value");
                    }

                    twobytes = binr.ReadUInt16();

                    byte lowbyte;
                    byte highbyte = 0x00;

                    switch (twobytes)
                    {
                        case 0x8102:
                            lowbyte = binr.ReadByte();
                            break;
                        case 0x8202:
                            highbyte = binr.ReadByte();
                            lowbyte = binr.ReadByte();
                            break;
                        default:
                            throw new Exception("Unexpected Value");
                    }
                    byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                    var modsize = BitConverter.ToInt32(modint, 0);

                    var firstbyte = binr.PeekChar();
                    if (firstbyte == 0x00)
                    {
                        binr.ReadByte();
                        modsize -= 1;
                    }

                    var modulus = binr.ReadBytes(modsize);
                    if (binr.ReadByte() != 0x02) { throw new Exception("Unexpected Value"); }
                    var expbytes = (int)binr.ReadByte();
                    var exponent = binr.ReadBytes(expbytes);

                    RSA rsa = RSA.Create();
                    RSAParameters rsaParams = new RSAParameters { Modulus = modulus, Exponent = exponent };
                    rsa.ImportParameters(rsaParams);
                    return rsa;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static bool CompareBytearrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) { return false; }
            var i = 0;
            foreach (var c in a)
            {
                if (c != b[i]) { return false; }
                i++;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private RSA CreateRsaProviderFromPrivateKey(string privateKey)
        {
            var privateKeyBits = Convert.FromBase64String(privateKey);

            RSA rsa = RSA.Create();
            RSAParameters rsaParams = new RSAParameters();
            using (BinaryReader binr = new BinaryReader(new MemoryStream(privateKeyBits)))
            {
                byte bt = 0;
                ushort twobytes = binr.ReadUInt16();
                switch (twobytes)
                {
                    case 0x8130:
                        binr.ReadByte();
                        break;
                    case 0x8230:
                        binr.ReadInt16();
                        break;
                    default:
                        throw new Exception("Unexpected Value ");
                }

                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102) { throw new Exception("Unexpected Value"); }

                bt = binr.ReadByte();
                if (bt != 0x00) { throw new Exception("Unexpected Value"); }

                rsaParams.Modulus = binr.ReadBytes(GetIntegerSize(binr));
                rsaParams.Exponent = binr.ReadBytes(GetIntegerSize(binr));
                rsaParams.D = binr.ReadBytes(GetIntegerSize(binr));
                rsaParams.P = binr.ReadBytes(GetIntegerSize(binr));
                rsaParams.Q = binr.ReadBytes(GetIntegerSize(binr));
                rsaParams.DP = binr.ReadBytes(GetIntegerSize(binr));
                rsaParams.DQ = binr.ReadBytes(GetIntegerSize(binr));
                rsaParams.InverseQ = binr.ReadBytes(GetIntegerSize(binr));
            }

            rsa.ImportParameters(rsaParams);
            return rsa;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binr"></param>
        /// <returns></returns>
        private int GetIntegerSize(BinaryReader binr)
        {
            byte bt = binr.ReadByte();
            if (bt != 0x02) { return 0; }
            bt = binr.ReadByte();
            int count = 0;
            switch (bt)
            {
                case 0x81:
                    count = binr.ReadByte();
                    break;
                case 0x82:
                    var highbyte = binr.ReadByte();
                    var lowbyte = binr.ReadByte();
                    byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                    count = BitConverter.ToInt32(modint, 0);
                    break;
                default:
                    count = bt;
                    break;

            }
            while (binr.ReadByte() == 0x00) { count -= 1; }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);
            return 0;
        }
        #endregion
    }
}
