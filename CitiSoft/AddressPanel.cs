using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CitiSoft
{

    public partial class AddressPanel : Panel
    {
        public Label addressLine1Label = new Label();
        public TextBox addressLine1TextBox = new TextBox();

        public Label addressLine2Label = new Label();
        public TextBox addressLine2TextBox = new TextBox();

        public Label cityLabel = new Label();
        public TextBox cityTextBox = new TextBox();

        public Label countryLabel = new Label();
        public TextBox countryTextBox = new TextBox();

        public Label postCodeLabel = new Label();
        public TextBox postCodeTextBox = new TextBox();

        public Label emailLabel = new Label();
        public TextBox emailTextBox = new TextBox();

        public Label telephoneLabel = new Label();
        public TextBox telephoneTextBox = new TextBox();

        public CustomListBox addressCustomListBox = new CustomListBox();

        public List<AddressModel> addressList = new List<AddressModel>();

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
                    con.TabStop = false;
                    addressCustomListBox.setHeightWidth(600, 325);
                    con.Left = addxLoc + 210 + 100 + 210;
                    con.Top = addyLoc- 50;
                }
                else
                {
                    con.TabStop = false;
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
            addressCustomListBox.update.Click += Update_Click;
            addressCustomListBox.edit.Click += Edit_Click;
        }

        

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (addressCustomListBox.listBox.SelectedItem != null)
            {
                index= addressCustomListBox.listBox.SelectedIndex;
                AddressModel instance = addressList[index] as AddressModel;
                addressLine1TextBox.Text = instance.AddressLine1;
                addressLine2TextBox.Text = instance.AddressLine2;
                cityTextBox.Text = instance.City;
                countryTextBox.Text = instance.Country;
                postCodeTextBox.Text = instance.PostCode;
                emailTextBox .Text = instance.Email;
                telephoneTextBox.Text = instance.Telephone;
                addressCustomListBox.add.Visible = false;
                addressCustomListBox.edit.Visible = true;
                addressCustomListBox.update.Visible = false;
                
            }

        }

        public void Add_Click(object sender, EventArgs e)
        {
            if (addressLine1TextBox.Text.Trim() != "" || addressLine2TextBox.Text.Trim() != "" || cityTextBox.Text.Trim() != "" || countryTextBox.Text.Trim() != "" || postCodeTextBox.Text.Trim() != "" || emailTextBox.Text.Trim() != "" || telephoneTextBox.Text.Trim() != "")
            {
                
                addressList.Add(new AddressModel
                {
                    AddressLine1 = addressLine1TextBox.Text,
                    AddressLine2 = addressLine2TextBox.Text,
                    City = cityTextBox.Text,
                    Country = countryTextBox.Text,
                    PostCode = postCodeTextBox.Text,
                    Email = emailTextBox.Text,
                    Telephone = telephoneTextBox.Text
                });
                foreach (Control con in Controls)
                {
                    if (con is TextBox)
                    {
                        con.Text = "";
                    }
                }
                AddressModel instance = addressList[addressList.Count - 1] as AddressModel;
                addressCustomListBox.listBox.Items.Add(instance.AddressLine1 + " " + instance.AddressLine2 + " " + instance.City + " " + instance.Country + " " + instance.PostCode + " " + instance.Email + " " + instance.Telephone);
            }
            else
            {
                MessageBox.Show("Empty Textboxes.");
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            index = addressCustomListBox.listBox.SelectedIndex;
            if (index > -1 )
            {
                AddressModel instance = addressList[index] as AddressModel;
                addressLine1TextBox.Text = instance.AddressLine1;
                addressLine2TextBox.Text = instance.AddressLine2;
                cityTextBox.Text = instance.City;
                countryTextBox.Text = instance.Country;
                postCodeTextBox.Text = instance.PostCode;
                emailTextBox.Text = instance.Email;
                telephoneTextBox.Text = instance.Telephone;
                addressCustomListBox.add.Visible = false;
                addressCustomListBox.edit.Visible = false;
                addressCustomListBox.update.Visible = true;
                addressCustomListBox.remove.Visible = false;
            }
            else
            {
                MessageBox.Show("No Entries Found Or Please Select the Entry.");
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            index = addressCustomListBox.listBox.SelectedIndex;
            if (index > -1)
            {
                addressCustomListBox.listBox.Items.RemoveAt(index);
                addressList.RemoveAt(index);
                foreach (Control con in Controls)
                {
                    if (con is TextBox)
                    {
                        con.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("No Element Selected");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (addressLine1TextBox.Text.Trim() != "" || addressLine2TextBox.Text.Trim() != "" || cityTextBox.Text.Trim() != "" || countryTextBox.Text.Trim() != "" || postCodeTextBox.Text.Trim() != "" || emailTextBox.Text.Trim() != "" || telephoneTextBox.Text.Trim() != "")
            {
                addressList[index]=(new AddressModel
                {
                    AddressLine1 = addressLine1TextBox.Text,
                    AddressLine2 = addressLine2TextBox.Text,
                    City = cityTextBox.Text,
                    Country = countryTextBox.Text,
                    PostCode = postCodeTextBox.Text,
                    Email = emailTextBox.Text,
                    Telephone = telephoneTextBox.Text
                });
                foreach (Control con in Controls)
                {
                    if (con is TextBox)
                    {
                        con.Text = "";
                    }
                }
                AddressModel instance = addressList[index] as AddressModel;
                addressCustomListBox.listBox.Items.RemoveAt(index);
                addressCustomListBox.listBox.Items.Insert(index,(instance.AddressLine1 + " " + instance.AddressLine2 + " " + instance.City + " " + instance.Country + " " + instance.PostCode + " " + instance.Email + " " + instance.Telephone));
                addressCustomListBox.add.Visible = true;
                addressCustomListBox.edit.Visible = true;
                addressCustomListBox.remove.Visible = true;
                addressCustomListBox.update.Visible = false;   
            }
            else
            {
                MessageBox.Show("Empty Textboxes.");
            }
        }


        private void AddressLine1TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 30, "Only Text,Numbers, Space, Hyphen(-) and Comma(,)", @"^[a-zA-Z0-9 ,-]+$"); ;
        }

        private void AddressLine2TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 30, "Only Text,Numbers, Space, Hyphen(-) and Comma(,)", @"^[a-zA-Z0-9 ,-]+$"); ;
        }

        private void CityTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 60, "Only Text", @"^[a-zA-Z]+$");
        }

        private void CountryTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 45, "Only Text", @"^[a-zA-Z]+$");
        }

        private void PostCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 12, "Only Text, Numbers and space", @"^[a-zA-Z0-9 ]+$");
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
            InputValidation.IsValid(textBox, 14, "Only Numbers and Plus(+) ", @"^[0-9 +]+$");
        }
    }
}
