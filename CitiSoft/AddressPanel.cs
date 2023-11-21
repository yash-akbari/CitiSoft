using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
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
            emailTextBox.TextChanged += EmailTextBox_TextChanged;
            telephoneTextBox.TextChanged += TelephoneTextBox_TextChanged;
            addressCustomListBox.add.Click += Add_Click;
            addressCustomListBox.remove.Click += Remove_Click;
            addressCustomListBox.clear.Click += Clear_Click;

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            String address = "";
            String[] addressTobeSend = new String[20];
            foreach (TextBox tb in Controls)
            {
                address = address + tb.Text;
                //addressTobeSend = addressTobeSend
            }
            addressCustomListBox.listBox.Items.Add("");
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

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValidEmail(textBox.Text);
        }

        private void TelephoneTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsPhoneNumberStructured(textBox,14,"Phone Number");
        }



    }
}
