using System;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class DecimalValidation
	{
		public DecimalValidation()
		{
		}

		public bool checkString(TextBox text)
		{
			bool flag = true;
			int num = 0;
			if (!(text.Text != "."))
			{
				flag = false;
			}
			else
			{
				string str = text.Text;
				int num1 = 0;
				while (num1 < str.Length)
				{
					char chr = str[num1];
					if ((chr < '0' || chr > '9' ? chr != '.' : false))
					{
						flag = false;
						break;
					}
					else
					{
						if (chr == '.')
						{
							num++;
						}
						if (num <= 1)
						{
							num1++;
						}
						else
						{
							flag = false;
							break;
						}
					}
				}
			}
			return flag;
		}
	}
}