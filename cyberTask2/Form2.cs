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
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}
		string keyPath = "D:\\Projects\\cyberTask2\\key.txt";
		string cypherTextPath = "D:\\Projects\\cyberTask2\\cyphertext.txt";
		byte[] key;
		byte[] cipherbytes;
		string encodedtext;
		private void button1_Click(object sender, EventArgs e)
		{
			key = File.ReadAllBytes(keyPath);
			SymmetricAlgorithm sa = TripleDES.Create();
			sa.Key = key;
			sa.Mode = CipherMode.ECB;
			sa.Padding = PaddingMode.PKCS7;
			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, sa.CreateEncryptor(), CryptoStreamMode.Write);
			byte[] plainbytes = Encoding.Default.GetBytes(textBox1.Text);
			cs.Write(plainbytes, 0, plainbytes.Length);
			cs.Close();
			cipherbytes = ms.ToArray();
			ms.Close();
			File.WriteAllBytes(cypherTextPath, cipherbytes);
			Form3 form3 = new Form3();
			form3.Show();

		}
	}
}
