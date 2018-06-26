using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKOCR
{
	public class BANKOCR{
		string[] file;
		List<List<string>> accounts;
		public List<String> accountsturned;
		Dictionary<string, char> numbers = new Dictionary<string, char>()
		{
			{ " _ "+ "| |"+ "|_|", '0'},
			{ "   "+ " | "+ " | ", '1'},
			{ " _ "+ " _|"+ "|_ ", '2'},
			{ " _ "+ " _|"+ " _|", '3'},
			{ "   "+ "|_|"+ "  |", '4'},
			{ " _ "+ "|_ "+ " _|", '5'},
			{ " _ "+ "|_ "+ "|_|", '6'},
			{ " _ "+ "  |"+ "  |", '7'},
			{ " _ "+ "|_|"+ "|_|", '8'},
			{ " _ "+ "|_|"+ " _|", '9'}
		};

		public BANKOCR(string path)
		{
		file =	System.IO.File.ReadAllLines(path);
			Initialize();
		}
		public void Initialize()
		{
			accounts = new List<List<string>>();
			accountsturned = new List<string>();
			int y = -1;
			for (int i = 0; i < file.Length; i+=4)
			{

				y++;
				accounts.Add(new List<string>());
				for (int j = 0; j < 3; j++)
				{
					accounts[y].Add(file[i + j]);
				}
			}
			for(int i = 0; i < accounts.Count; i++)
			{
				ConvertToNumbers(accounts[i].ToArray());
			}
		}
		public void ConvertToNumbers(string[] account)
		{
			string[] toconvert = new string[9];
			
			int addee = 0;
			for (int j = 0; j < 9; j++)
			{
				if (j != 0) addee = (j * 3); 
				toconvert[j] += account[0].Substring(addee, 3);
				toconvert[j] += account[1].Substring(addee, 3);
				toconvert[j] += account[2].Substring(addee, 3);
			}
			ArrayToNumber(toconvert);
		}

		public void ArrayToNumber(string[] account)
		{
			string finalNumber = "";
			
			for (int i = 0; i < account.Length; i++)
			{
				finalNumber += numbers.ContainsKey(account[i]) ? numbers[account[i]] : '?';
			}
			finalNumber = ValidateAccount(finalNumber);
			accountsturned.Add(finalNumber);
		}

		public string ValidateAccount(string number)
		{
			string n = number;
			int output = 0;
			int calc = 0;
			if(int.TryParse(n,out output))
			{
				for (int i = 0; i < 9; i++)
				{
					calc += Convert.ToInt32(n[i] + "")*(n.Length-i);
				}
				if(calc % 11 != 0)
				{
					n += " ERR";
				}
			}
			else
			{
				n += " ILL";
			}
			return n;
		}
		

}
	class Program
	{
		static void Main(string[] args)
		{
			BANKOCR FirstTry = new BANKOCR("D:/Users/franc/Documents/Visual Studio 2017/Projects/BANKOCR/BANKOCR/bin/DamagedAccount.txt");
			Console.ReadLine();
		}
	}
}
