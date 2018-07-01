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
            accountsturned = new List<string>();
            accounts = new List<List<string>>();
            Initialize();
		}
		public void Initialize()
		{
            getAllAccounts();
			for(int i = 0; i < accounts.Count; i++)
			{
				ConvertToNumbers(accounts[i].ToArray());
			}
		}
        public void getAllAccounts()
        {
            int y = 0;
            for (int i = 0; i < file.Length; i += 4)
            {
                accounts.Add(new List<string>());
                getAccount(y, i);
                y++;
            }
        }

        public void getAccount(int accountsCount, int currentAccount)
        {
            for (int j = 0; j < 3; j++)
            {
                accounts[accountsCount].Add(file[currentAccount + j]);
            }
        }
		public void ConvertToNumbers(string[] account)
		{
			string[] toconvert = new string[9];

			for (int j = 0; j < 9; j++)
			{
                toconvert[j] = fillAllLines(account, j);
			}
			ArrayToNumber(toconvert);
		}

        public string fillAllLines(string[] account, int j)
        {
            string fullLine = "";
            if (j != 0) j = (j * 3);
            fullLine += account[0].Substring(j, 3);
            fullLine += account[1].Substring(j, 3);
            fullLine += account[2].Substring(j, 3);
            return fullLine;
        }

		public void ArrayToNumber(string[] account)
		{
			string finalNumber = "";

            finalNumber = addNumbers(account, finalNumber);
			finalNumber = ValidateAccount(finalNumber);
			accountsturned.Add(finalNumber);
		}

        public string addNumbers(string[] account, string finalNumber)
        {
            for (int i = 0; i < account.Length; i++)
            {

                finalNumber = addQuestionMarkToAccount(account[i], finalNumber);
            }
            return finalNumber;
        }

        public string addQuestionMarkToAccount(string acc, string finalNumber)
        {
            if (numbers.ContainsKey(acc))
            {
                finalNumber += numbers[acc];
            }
            else
            {
                finalNumber += '?';
            }
            return finalNumber;
        }

		public string ValidateAccount(string number)
		{
			string n = number;
			int output = 0;
			if(int.TryParse(n,out output))
			{
                n = calcValidatedAccount(n);
			}
			else
			{
				n += " ILL";
			}
			return n;
		}

        public string calcValidatedAccount(string number)
        {
            string n = number;

            if (calculateIfIsValid(n))
            {
                n += " ERR";
            }
            return n;
        }

        public bool calculateIfIsValid(string n)
        {
            int calc = 0;
            calc = multiplyAllNumbers(n);
            return calc % 11 == 0;
        }

        public int multiplyAllNumbers(string n)
        {
            int calc = 0;
            for (int i = 0; i < 9; i++)
            {
                calc += multiplyByPosition(n[i] + "", n.Length, i);
            }
            return calc;
        }

        public int multiplyByPosition(string n, int length, int position)
        {
            return Convert.ToInt32(n) * (length - position);
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
