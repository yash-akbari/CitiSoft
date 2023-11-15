using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    internal class InputValidation
    {
        public static void IsOnlyNumbers(TextBox textBox)
        {
            if (textBox != null)
            {
                string input = textBox.Text;
                foreach (char c in input)
                {
                    if (!char.IsDigit(c)) // Allow numbers
                    {
                        // Show a message or handle the invalid character
                        MessageBox.Show("Only numbers are allowed.");
                        AutoCorrection(textBox, input);

                        break;
                    }
                }
            }
        }

        public static void IsOnlyLettersAndSpaces(TextBox textBox, int length, string name)
        {
            if (textBox != null)
            {
                string input = textBox.Text;
                // checks for length
                if (textBox.Text.Length > length)
                {
                    MessageBox.Show($"{name} name is too long");
                    AutoCorrection(textBox, input);
                }
                else
                {
                    foreach (char c in input)
                    {
                        if (!char.IsLetter(c) && c != ' ') // Allow letters and spaces
                        {
                            // Show a message or handle the invalid character
                            MessageBox.Show("Only letters and spaces are allowed.");
                            AutoCorrection(textBox, input);

                            break;
                        }
                    }
                }
            }
        }

        public static void IsOnlyLetters(TextBox textBox, int length, string name)
        {
            if (textBox != null)
            {
                string input = textBox.Text;
                // checks for length
                if (input.Length > length)
                {
                    MessageBox.Show($"{name} name is too long");
                    AutoCorrection(textBox, input);
                }
                else
                {
                    foreach (char c in input)
                    {
                        if (!char.IsLetter(c)) // Allow letters
                        {
                            // Show a message or handle the invalid character
                            MessageBox.Show("Only letters are allowed.");
                            AutoCorrection(textBox, input);

                            break;
                        }
                    }
                }
            }
        }

        public static void IsOnlyAlphanumericOrWithDots(TextBox textBox, int length, string name)
        {
            if (textBox != null)
            {
                string input = textBox.Text;
                // checks for length
                if (input.Length > length)
                {
                    MessageBox.Show($"{name} address is too long");
                    AutoCorrection(textBox, input);
                }
                else
                {
                    foreach (char c in input)
                    {
                        if (!char.IsLetterOrDigit(c) && c != ' ' && c != '.') // Allow letters, spaces, numbers and dots
                        {
                            // Show a message or handle the invalid character
                            MessageBox.Show("Only letters, spaces and numbers are allowed.");
                            AutoCorrection(textBox, input);

                            break;
                        }
                    }
                }
            }
        }

        // checks if the text is email structured
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    var idn = new System.Globalization.IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }

                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public static void IsPhoneNumberStructured(TextBox textBox, int length, string name)
        {
            if (textBox != null)
            {
                string input = textBox.Text;

                // checks for length
                if (input.Length > length)
                {
                    MessageBox.Show($"{name} is too long");
                    AutoCorrection(textBox, input);
                }
                else
                {
                    foreach (char c in input)
                    {
                        if (!char.IsDigit(c) && c != ' ' && c != '+') // Allow letters spaces and numbers
                        {
                            // Show a message or handle the invalid character
                            MessageBox.Show("Please don't inlcude any letters.");
                            AutoCorrection(textBox, input);

                            break;
                        }
                    }
                }
            }
        }

        private static void AutoCorrection(TextBox textBox, string input)
        {
            // Remove the last character
            textBox.Text = input.Substring(0, input.Length - 1);

            // Set the cursor position to the end of the text
            textBox.SelectionStart = textBox.Text.Length;
            textBox.SelectionLength = 0;
        }

        public static void LimitLength(TextBox textBox, int length, string name)
        {
            if (textBox != null)
            {
                string input = textBox.Text;
                // checks for length
                if (input.Length > length)
                {
                    MessageBox.Show($"{name} is too long, should be less than {length} characters");
                    AutoCorrection(textBox, input);
                }
            }
        }
    }
}
