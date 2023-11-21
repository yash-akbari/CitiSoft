using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CitiSoft
{

    public class AddressList {

        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        public String PostCode { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
    }

    public partial class AddressPanel : Panel
    {
        Label addressLine1Label = new Label();
        TextBox addressLine1TextBox = new TextBox();

        Label addressLine2Label = new Label();
        TextBox addressLine2TextBox = new TextBox();

        Label cityLabel = new Label();
        TextBox cityTextBox = new TextBox();

        Label countryLabel = new Label();
        TextBox countryTextBox = new TextBox();

        Label postCodeLabel = new Label();
        TextBox postCodeTextBox = new TextBox();

        Label emailLabel = new Label();
        TextBox emailTextBox = new TextBox();

        Label telephoneLabel = new Label();
        TextBox telephoneTextBox = new TextBox();

        CustomListBox addressCustomListBox = new CustomListBox();

        List<AddressList> addressList = new List<AddressList>();

        int index = 0;



        public AddressPanel() 
        { 
            InitializeComponent();
        }


        public void InitializeComponent() 
        {
            Controls.AddRange(new Control[]
            {
                addressLine1Label,addressLine1TextBox,addressCustomListBox,
                addressLine2Label,addressLine2TextBox,
                cityLabel, cityTextBox,
                countryLabel, countryTextBox,
                postCodeLabel, postCodeTextBox,
                emailLabel, emailTextBox,
                telephoneLabel, telephoneTextBox
            });
            string[] addControlVarName = new string[]
            {
                "addressLine1Label","addressLine1TextBox","addressCustomListBox",
                "addressLine2Label","addressLine2TextBox",
                "cityLabel", "cityTextBox",
                "countryLabel", "countryTextBox",
                "postCodeLabel", "postCodeTextBox",
                "emailLabel", "emailTextBox",
                "telephoneLabel", "telephoneTextBox"
            };
            string[] addControlText = new string[]
            {
                "Address Line 1:",
                "Address Line 2:",
                "City:",
                "Country:",
                "PostCode:",
                "Email Address:",
                "Phone:"
            };

            int addxLoc = 0;
            int addyLoc = 0;
            int addHeight = 30;
            int addWidth = 200;
            int i = 0, j = 0;
            Size= new System.Drawing.Size(1100, 350);
            foreach (Control con in Controls)
            {
                con.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                con.Name = addControlVarName.ElementAt(i++);
                if (con is Label)
                {
                    con.Width = addWidth;
                    con.Height = addHeight;
                    con.Text = addControlText[j++];
                    con.Left = addxLoc;
                    con.Top = addyLoc;
                }
                else if (con is CustomListBox)
                {
                    addressCustomListBox.setHeightWidth(600, 325);
                    con.Left = addxLoc + 210 + 100 + 210;
                    con.Top = addyLoc- 50;
                }
                else
                {
                    con.Width = addWidth + 100;
                    con.Height = addHeight;

                    con.Left = addxLoc + 210;
                    con.Top = addyLoc;
                    addyLoc = addyLoc + 50;
                }
            }
            addressLine1TextBox.TextChanged += AddressLine1TextBox_TextChanged;
            addressLine2TextBox.TextChanged += AddressLine2TextBox_TextChanged;
            cityTextBox.TextChanged += CityTextBox_TextChanged;
            countryTextBox.TextChanged += CountryTextBox_TextChanged;
            postCodeTextBox.TextChanged += PostCodeTextBox_TextChanged;
            emailTextBox.Leave += EmailTextBox_Leave;
            telephoneTextBox.TextChanged += TelephoneTextBox_TextChanged;
            addressCustomListBox.add.Click += Add_Click;
            addressCustomListBox.remove.Click += Remove_Click;
            addressCustomListBox.reset.Click += Reset_Click;
            addressCustomListBox.update.Click += Update_Click;
            addressCustomListBox.listBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;

        }

        

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (addressCustomListBox.listBox.SelectedItem != null)
            {
                index= addressCustomListBox.listBox.SelectedIndex;
                AddressList instance = addressList[index] as AddressList;
                addressLine1TextBox.Text = instance.AddressLine1;
                addressLine2TextBox.Text = instance.AddressLine2;
                cityTextBox.Text = instance.City;
                countryTextBox.Text = instance.Country;
                postCodeTextBox.Text = instance.PostCode;
                emailTextBox .Text = instance.Email;
                telephoneTextBox.Text = instance.Phone;
                addressCustomListBox.add.Visible = false;
                addressCustomListBox.update.Visible = true;
                addressCustomListBox.reset.Visible = false;
                
            }

        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (addressLine1TextBox.Text.Trim() != "" || addressLine2TextBox.Text.Trim() != "" || cityTextBox.Text.Trim() != "" || countryTextBox.Text.Trim() != "" || postCodeTextBox.Text.Trim() != "" || emailTextBox.Text.Trim() != "" || telephoneTextBox.Text.Trim() != "")
            {
                addressList.Add(new AddressList
                {
                    AddressLine1 = addressLine1TextBox.Text,
                    AddressLine2 = addressLine2TextBox.Text,
                    City = cityTextBox.Text,
                    Country = countryTextBox.Text,
                    PostCode = postCodeTextBox.Text,
                    Email = emailTextBox.Text,
                    Phone = telephoneTextBox.Text
                });
                foreach (Control con in Controls)
                {
                    if (con is TextBox)
                    {
                        con.Text = "";
                    }
                }
                AddressList instance = addressList[addressList.Count - 1] as AddressList;
                addressCustomListBox.listBox.Items.Add(instance.AddressLine1 + " " + instance.AddressLine2 + " " + instance.City + " " + instance.Country + " " + instance.PostCode + " " + instance.Email + " " + instance.Phone);
            }
            else
            {
                MessageBox.Show("Empty Textboxes.");
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            foreach (Control con in Controls)
            {
                if (con is TextBox)
                {
                    con.Text = "";
                }
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            addressCustomListBox.listBox.Items.RemoveAt(index);
            addressList.RemoveAt(index);
            addressCustomListBox.add.Visible = true;
            addressCustomListBox.update.Visible = false;
            addressCustomListBox.reset.Visible = true;
            foreach (Control con in Controls)
            {
                if (con is TextBox)
                {
                    con.Text = "";
                }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (addressLine1TextBox.Text.Trim() != "" || addressLine2TextBox.Text.Trim() != "" || cityTextBox.Text.Trim() != "" || countryTextBox.Text.Trim() != "" || postCodeTextBox.Text.Trim() != "" || emailTextBox.Text.Trim() != "" || telephoneTextBox.Text.Trim() != "")
            {
                addressList[index]=(new AddressList
                {
                    AddressLine1 = addressLine1TextBox.Text,
                    AddressLine2 = addressLine2TextBox.Text,
                    City = cityTextBox.Text,
                    Country = countryTextBox.Text,
                    PostCode = postCodeTextBox.Text,
                    Email = emailTextBox.Text,
                    Phone = telephoneTextBox.Text
                });
                foreach (Control con in Controls)
                {
                    if (con is TextBox)
                    {
                        con.Text = "";
                    }
                }
                AddressList instance = addressList[index] as AddressList;
                addressCustomListBox.listBox.Items.RemoveAt(index);
                addressCustomListBox.listBox.Items.Insert(index,(instance.AddressLine1 + " " + instance.AddressLine2 + " " + instance.City + " " + instance.Country + " " + instance.PostCode + " " + instance.Email + " " + instance.Phone));
                addressCustomListBox.add.Visible = true;
                addressCustomListBox.update.Visible = false;
                addressCustomListBox.reset.Visible = true;
                
            }
            else
            {
                MessageBox.Show("Empty Textboxes.");
            }
        }


        private void AddressLine1TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyAlphanumericWithSpaceDashComma(textBox,30,"Address Line 1");
        }

        private void AddressLine2TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyAlphanumericWithSpaceDashComma(textBox, 30, "Address Line 2");
        }

        private void CityTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyLetters(textBox, 20, "City");
        }

        private void CountryTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyLetters(textBox, 20, "Country");
        }

        private void PostCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyAlphanumericOrWithDots(textBox, 12, "PostCode");
        }

        private void EmailTextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text != " " && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                // checks for length
                if (textBox.Text.Length > 30)
                {
                    MessageBox.Show("Email is too long.");
                    textBox.Focus();
                }
                if (textBox != null && !InputValidation.IsValidEmail(textBox.Text))
                {
                    MessageBox.Show("Invalid email format.");
                    textBox.Focus();
                }
            }
        }

        private void TelephoneTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsPhoneNumberStructured(textBox,14,"Phone Number");
        }
    }
}
