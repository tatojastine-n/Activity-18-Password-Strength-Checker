using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Strength_Checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] passwords = new string[5];
            string[] specialChars = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "+", "=" };

            Console.WriteLine("Enter 5 passwords for validation:");

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Password {i + 1}: ");
                passwords[i] = Console.ReadLine();
            }

            Console.WriteLine("\nPassword Validation Results:");
            Console.WriteLine("Password     | Strength");

            foreach (string password in passwords)
            {
                bool valid = true;
                int requirementsMet = 0;

                bool hasUpper = false;
                bool hasDigit = false;
                bool hasSpecial = false;

                if (password.Length < 8)
                {
                    valid = false;
                }
                foreach (char c in password)
                {
                    if (char.IsUpper(c)) hasUpper = true;
                    if (char.IsDigit(c)) hasDigit = true;
                    foreach (string sc in specialChars)
                    {
                        if (password.Contains(sc))
                        {
                            hasSpecial = true;
                            break;
                        }
                    }
                }
                requirementsMet += hasUpper ? 1 : 0;
                requirementsMet += hasDigit ? 1 : 0;
                requirementsMet += hasSpecial ? 1 : 0;

                string strength;
                if (!valid)
                {
                    strength = "Invalid (Too short)";
                }
                else if (requirementsMet == 3)
                {
                    strength = "Strong";
                }
                else if (requirementsMet >= 1)
                {
                    strength = "Weak";
                }
                else
                {
                    strength = "Invalid (Missing all special requirements)";
                }

                Console.WriteLine($"{password,-12} | {strength}");
            }
        }
    }
}
