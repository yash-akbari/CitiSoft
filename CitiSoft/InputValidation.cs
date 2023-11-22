using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public static void IsOnlyAlphanumericWithDashAt(TextBox textBox, int length, string name)
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
                        if (!char.IsLetterOrDigit(c) && c != ' ' && c != '-' && c != '@') // Allow letters, spaces, numbers, dash and at(@)
                        {
                            // Show a message or handle the invalid character
                            MessageBox.Show("Only letters, spaces, numbers,  dash and at(@) are allowed.");
                            AutoCorrection(textBox, input);

                            break;
                        }
                    }
                }
            }
        }

        public static void IsOnlyAlphanumericWithDash(TextBox textBox, int length, string name)
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
                        if (!char.IsLetterOrDigit(c) && c != ' ' && c != '-') // Allow letters, spaces, numbers and dash
                        {
                            // Show a message or handle the invalid character
                            MessageBox.Show("Only letters, spaces, numbers and dash are allowed.");
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


        public static void IsValid(TextBox textBox, int length, String message, String pattern = @"^[a-zA-Z\s]+$") // by default it will accept a-z,A-Z and spaces
        {
            if (textBox.Text.Length > 0)
            {
                string input = textBox.Text;
                Regex regex = new Regex(pattern);
                // checks for length
                if (!regex.IsMatch(input))
                {
                    MessageBox.Show( $"{message} are allowed.");
                    AutoCorrection(textBox, input);
                }
                else if (input.Length > length)
                {
                    MessageBox.Show( "Too Long");
                    AutoCorrection(textBox, input);
                }
            }
        }


                public static void IsOnlyAlphanumericWithSpaceDashComma(TextBox textBox, int length, string name)
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
                        if (!char.IsLetterOrDigit(c) && c != ' ' && c != '.' && c != ',' && c != '-' ) // Allow letters, spaces, numbers,commas, dots and dash                        {
                        {    // Show a message or handle the invalid character
                            MessageBox.Show("Only letters, spaces, numbers,commas, dots and dash are allowed.");
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
            if (textBox.Text.Length >0)
            {
                textBox.Text = input.Substring(0, input.Length - 1);

                // Set the cursor position to the end of the text
                textBox.SelectionStart = textBox.Text.Length;
                textBox.SelectionLength = 0;
            }
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


        // the following two functions were generated by ChatGPT 4 and adapted by author, http://chat.openai.com
        public static bool CheckValueExists(string connectionString, string tableName, string columnName, string value)
        {
            // Sanitize the input for table and column names to prevent SQL injection
            // This is a rudimentary check; you should ideally check against known good values or use metadata
            if (!IsSafeSqlLiteral(tableName) || !IsSafeSqlLiteral(columnName))
            {
                throw new ArgumentException("Invalid table or column name.");
            }

            // Construct the SQL query
            string query = $"SELECT COUNT(1) FROM [{tableName}] WHERE [{columnName}] = @value";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Use a parameter for the value to protect against SQL injection
                    command.Parameters.AddWithValue("@value", value);

                    try
                    {
                        connection.Open();
                        int exists = (int)command.ExecuteScalar();
                        return exists > 0;
                    }
                    catch (SqlException)
                    {
                        // Handle exceptions as appropriate for your application
                        MessageBox.Show("An error occurred accessing the database");
                        return false;
                    }
                }
            }
        }

        // Helper method to check if the table or column name is a safe SQL literal
        // This method should be tailored to meet the security requirements of your application
        private static bool IsSafeSqlLiteral(string input)
        {
            // Perform checks against known good values, patterns, or metadata
            // For the sake of this example, we only allow alphanumeric characters and underscores
            return Regex.IsMatch(input, @"^\w+$");
        }
    }
}
