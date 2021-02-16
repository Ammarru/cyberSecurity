using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace cyberTask2
{
	public partial class Form3 : Form
	{
		public Form3()
		{
			InitializeComponent();
		}
		string keyPath = "D:\\Projects\\cyberTask2\\key.txt";
		string cypherTextPath = "D:\\Projects\\cyberTask2\\cyphertext.txt";
		byte[] key;
		byte[] cipherbytes;

		private void button1_Click(object sender, EventArgs e)
		{
			key = File.ReadAllBytes(keyPath);
			cipherbytes = File.ReadAllBytes(cypherTextPath);
			SymmetricAlgorithm sa = TripleDES.Create();
			sa.Key = key;
			sa.Mode = CipherMode.ECB;
			sa.Padding = PaddingMode.PKCS7;
			MemoryStream ms = new MemoryStream(cipherbytes);
			CryptoStream cs = new CryptoStream(ms, sa.CreateDecryptor(), CryptoStreamMode.Read);
			byte[] plainbytes = new Byte[cipherbytes.Length];
			cs.Read(plainbytes, 0, cipherbytes.Length);
			cs.Close();
			ms.Close();
			textBox1.Text = Encoding.Default.GetString(plainbytes);
		}
	}
}
