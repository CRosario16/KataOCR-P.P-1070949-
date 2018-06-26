using Microsoft.VisualStudio.TestTools.UnitTesting;
using BANKOCR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKOCR.Tests
{
	[TestClass()]
	public class BANKOCRTests
	{
		[TestMethod()]
		public void AllZeroesShouldReturnZeroes()
		{
			List<String> expected = new List<string>() {
				{"000000000"} 
			};
			BANKOCR b = new BANKOCR("D:/Users/franc/Documents/Visual Studio 2017/Projects/BANKOCR/BANKOCR/bin/inputZeroes.txt");
			CollectionAssert.AreEqual(expected, b.accountsturned);
		}

		[TestMethod()]
		public void TwoNumbersShouldWorkAsWell()
		{
			List<String> expected = new List<string>() {
				{ "457508000"},
				{ "345882865"}
			};
			BANKOCR b = new BANKOCR("D:/Users/franc/Documents/Visual Studio 2017/Projects/BANKOCR/BANKOCR/bin/inputTwoNumbers.txt");
			CollectionAssert.AreEqual(expected, b.accountsturned);
		}
		[TestMethod()]
		public void ThreeNumbersShouldWorkAsWell()
		{
			List<String> expected = new List<string>() {
				{ "457508000"},
				{ "345882865"},
				{"457508043" }
			};
			BANKOCR b = new BANKOCR("D:/Users/franc/Documents/Visual Studio 2017/Projects/BANKOCR/BANKOCR/bin/inputThreeNumbers.txt");
			CollectionAssert.AreEqual(expected, b.accountsturned);
		}
		[TestMethod()]
		public void ShouldReturnQuestionMark()
		{
			List<String> expected = new List<string>() {
				{ "345882?65"},
			};
			BANKOCR b = new BANKOCR("D:/Users/franc/Documents/Visual Studio 2017/Projects/BANKOCR/BANKOCR/bin/DamagedAccount.txt");
			CollectionAssert.AreEqual(expected, b.accountsturned);
		}
		[TestMethod()]
		public void ShouldReturnQuestionMarkAndTag()
		{
			List<String> expected = new List<string>() {
				{ "345882?65 ILL"},
			};
			BANKOCR b = new BANKOCR("D:/Users/franc/Documents/Visual Studio 2017/Projects/BANKOCR/BANKOCR/bin/DamagedAccount.txt");
			CollectionAssert.AreEqual(expected, b.accountsturned);
		}
		[TestMethod()]
		public void ShouldReturnAllQuestionMarkWithTag()
		{
			List<String> expected = new List<string>() {
				{ "????????? ILL"},
			};
			BANKOCR b = new BANKOCR("D:/Users/franc/Documents/Visual Studio 2017/Projects/BANKOCR/BANKOCR/bin/AllQuestionMark.txt");
			CollectionAssert.AreEqual(expected, b.accountsturned);
		}
		[TestMethod()]
		public void ShouldReturnInvalidAccountTag()
		{
			List<String> expected = new List<string>() {
				{ "111111111 ERR"},
			};
			BANKOCR b = new BANKOCR("D:/Users/franc/Documents/Visual Studio 2017/Projects/BANKOCR/BANKOCR/bin/inputInValid.txt");
			CollectionAssert.AreEqual(expected, b.accountsturned);
		}
		[TestMethod()]
		public void MixedAccounts()
		{
			List<String> expected = new List<string>() {
				{ "111111111 ERR"},
				{ "457508000"},
				{ "345882?65 ILL"}
			};
			BANKOCR b = new BANKOCR("D:/Users/franc/Documents/Visual Studio 2017/Projects/BANKOCR/BANKOCR/bin/inputInvalidAndValid.txt");
			CollectionAssert.AreEqual(expected, b.accountsturned);
		}
		[TestMethod()]
		public void EmptyAccountsShouldReturnAllQuestionMarks()
		{
			List<String> expected = new List<string>() {
				{ "????????? ILL"},
			};
			BANKOCR b = new BANKOCR("D:/Users/franc/Documents/Visual Studio 2017/Projects/BANKOCR/BANKOCR/bin/EmptyAccount.txt");
			CollectionAssert.AreEqual(expected, b.accountsturned);
		}

	}
}