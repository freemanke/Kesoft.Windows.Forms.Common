using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Kesoft.Windows.Forms.Common
{
    /// <summary>
    ///   DES加密解密类，
    ///   提供一种对称式加解密方法。
    /// </summary>
    public class DESEncrypt
    {
        private readonly string initialVector = "InitializationVector";
        private readonly string secretKey = "12345678";

        /// <summary>
        ///   构造方法。
        /// </summary>
        /// <param name="initialVector"> 初始化向量。 </param>
        /// <param name="secretKey"> 密钥，8位字符串。 </param>
        public DESEncrypt(string initialVector, string secretKey)
        {
            if (!string.IsNullOrEmpty(initialVector))
            {
                this.initialVector = initialVector;
            }

            if (!string.IsNullOrEmpty(secretKey)
                && secretKey.Length == 8)
            {
                this.secretKey = secretKey;
            }
        }

        /// <summary>
        ///   获取或设置密钥，
        ///   密钥字符串长度必须为8。
        /// </summary>
        public string SecretKey
        {
            get { return secretKey; }
        }

        /// <summary>
        ///   获取或设置初始化向量字符串，
        ///   字符串不能为空。
        /// </summary>
        public string InitialVector
        {
            get { return initialVector; }
        }

        /// <summary>
        ///   获取密钥字节数组。
        /// </summary>
        private byte[] SecretKeyBytes
        {
            get { return Encoding.Default.GetBytes(secretKey); }
        }

        /// <summary>
        ///   获取初始化向量字节数组。
        /// </summary>
        private byte[] InitialVectorBytes
        {
            get { return Encoding.Default.GetBytes(initialVector); }
        }

        /// <summary>
        ///   加密字符串，
        ///   如果输入为空，则返回“Empty”。
        /// </summary>
        /// <param name="text"> 原始字符串。 </param>
        /// <returns> 加密后的字符串。 </returns>
        public string Encrypt(string text)
        {
            var result = string.Empty;
            if (!string.IsNullOrEmpty(text))
            {
                var textBuffer = Encoding.Default.GetBytes(text);
                var provider = new DESCryptoServiceProvider();

                MemoryStream ms = null;
                CryptoStream cs = null;
                try
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, provider.CreateEncryptor(SecretKeyBytes, InitialVectorBytes), CryptoStreamMode.Write);
                    cs.Write(textBuffer, 0, textBuffer.Length);
                    cs.FlushFinalBlock();
                    result = Convert.ToBase64String(ms.ToArray());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (ms != null)
                    {
                        ms.Close();
                    }

                    if (cs != null)
                    {
                        cs.Close();
                    }
                }
            }

            return result;
        }

        /// <summary>
        ///   解密字符串，
        ///   如果输入为空或非加密字符串，返回“Empty”。
        /// </summary>
        /// <param name="encryptedText"> 加密字符串。 </param>
        /// <returns> 解密后的字符串。 </returns>
        public string Decrypt(string encryptedText)
        {
            var result = string.Empty;
            if (!string.IsNullOrEmpty(encryptedText))
            {
                var textBuffer = Convert.FromBase64String(encryptedText);
                var provider = new DESCryptoServiceProvider();

                MemoryStream ms = null;
                CryptoStream cs = null;
                try
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, provider.CreateDecryptor(SecretKeyBytes, InitialVectorBytes), CryptoStreamMode.Write);
                    cs.Write(textBuffer, 0, textBuffer.Length);
                    cs.FlushFinalBlock();
                    result = Encoding.Default.GetString(ms.ToArray());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (ms != null)
                    {
                        ms.Close();
                    }

                    if (cs != null)
                    {
                        cs.Close();
                    }
                }
            }

            return result;
        }

        /// <summary>
        ///   加密文件。
        /// </summary>
        /// <param name="from"> 待加密文件名。 </param>
        /// <param name="to"> 加密后存储的目的文件名。 </param>
        /// <exception cref="ArgumentNullException">“from”为空。</exception>
        /// <exception cref="ArgumentNullException">“to”参数为空。</exception>
        /// <exception cref="FileNotFoundException">“from”文件不存在。</exception>
        /// <exception cref="DirectoryNotFoundException">“to”文件名中的文件夹无法创建。</exception>
        public void EncryptFile(string from, string to)
        {
            if (string.IsNullOrEmpty(from))
            {
                throw new ArgumentNullException("from");
            }
            if (string.IsNullOrEmpty(to))
            {
                throw new ArgumentNullException("to");
            }
            if (!File.Exists(from))
            {
                throw new FileNotFoundException("Source file not found", from);
            }

            var provider = new DESCryptoServiceProvider();
            var fileBuffer = File.ReadAllBytes(from);

            FileStream fs = null;
            CryptoStream cs = null;
            try
            {
                var dir = Path.GetDirectoryName(to);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                {
                    try
                    {
                        Directory.CreateDirectory(dir);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }

                fs = new FileStream(to, FileMode.Create, FileAccess.Write);
                cs = new CryptoStream(fs, provider.CreateEncryptor(SecretKeyBytes, InitialVectorBytes), CryptoStreamMode.Write);
                cs.Write(fileBuffer, 0, fileBuffer.Length);
                cs.FlushFinalBlock();
            }
            catch (Exception e2)
            {
                throw e2;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }

                if (cs != null)
                {
                    cs.Close();
                }
            }
        }

        /// <summary>
        ///   加密文件，
        ///   加密后的文件将覆盖原始文件。
        /// </summary>
        /// <param name="fileName"> 原始文件名。 </param>
        public void EncryptFile(string fileName)
        {
            EncryptFile(fileName, fileName);
        }

        /// <summary>
        ///   解密文件，
        ///   解密后的文件将存储到目的文件。
        /// </summary>
        /// <param name="from"> 原始文件名。 </param>
        /// <param name="to"> 解密后存储目的文件名。 </param>
        public void DecryptFile(string from, string to)
        {
            if (string.IsNullOrEmpty(from))
            {
                throw new ArgumentNullException("from");
            }
            if (string.IsNullOrEmpty(to))
            {
                throw new ArgumentNullException("to");
            }
            if (!File.Exists(from))
            {
                throw new FileNotFoundException("File not found", from);
            }

            var provider = new DESCryptoServiceProvider();
            var fileBuffer = File.ReadAllBytes(from);

            FileStream fs = null;
            CryptoStream cs = null;
            try
            {
                fs = new FileStream(to, FileMode.Create, FileAccess.Write);
                cs = new CryptoStream(fs, provider.CreateDecryptor(SecretKeyBytes, InitialVectorBytes), CryptoStreamMode.Write);
                cs.Write(fileBuffer, 0, fileBuffer.Length);
                cs.FlushFinalBlock();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }

                if (cs != null)
                {
                    cs.Close();
                }
            }
        }

        /// <summary>
        ///   解密文件，
        ///   将解密后的文件覆盖原始文件。
        /// </summary>
        /// <param name="fileName"> 原始文件名。 </param>
        public void DecryptFile(string fileName)
        {
            DecryptFile(fileName, fileName);
        }
    }
}