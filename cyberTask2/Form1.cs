using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cyberTask2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		string keyPath = "D:\\Projects\\cyberTask2\\key.txt";
		byte[] key;
		private void button1_Click(object sender, EventArgs e)
		{
			SymmetricAlgorithm sa = TripleDES.Create();
			sa.GenerateKey();
			key = sa.Key;
			File.WriteAllBytes(keyPath, key);
			Form2 form2 = new Form2();
			form2.Show();
		}
	}
}
