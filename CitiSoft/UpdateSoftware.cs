using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    internal class UpdateSoftware: Form
    {
        public UpdateSoftware()
        {
            InitializeComponents();
        }

        public Controller Controller
        {
            get => default;
            set
            {
            }
        }

        internal InputValidation InputValidation
        {
            get => default;
            set
            {
            }
        }

        public CustomListBox CustomListBox
        {
            get => default;
            set
            {
            }
        }

        Label compNameLabel = new Label();
        ComboBox compNameComboBox = new ComboBox();

        Label softwareNameLabel = new Label();
        ComboBox softwareNameComboBox = new ComboBox();

        Label softwareWebsiteLabel = new Label();
        TextBox softwareWebsiteTextBox = new TextBox();


        Label typeOfSoftwareLabel = new Label();
        TextBox typeOfSoftwareTextBox = new TextBox();
        CustomListBox typeOfSoftwareCustomListBox;

        Label businessAreasLabel = new Label();
        TextBox businessAreasTextBox = new TextBox();
        CustomListBox buisenessAreasCustomListBox;


        Label modulesLabel = new Label();
        TextBox modulesTextBox = new TextBox();
        CustomListBox modulesCustomListBox;


        Label financialServicesLabel = new Label();
        TextBox financialServicesTextBox = new TextBox();
        CustomListBox financialServicesCustomListBox;


        Label cloudLabel = new Label();
        ComboBox cloudComboBox = new ComboBox();

        Button submitButton = new Button();


        int vid = 0;
        int sid = 0;

        private void InitializeComponents()
        {
            typeOfSoftwareCustomListBox = new CustomListBox(typeOfSoftwareTextBox);
            buisenessAreasCustomListBox = new CustomListBox(businessAreasTextBox);
            modulesCustomListBox = new CustomListBox(modulesTextBox);
            financialServicesCustomListBox = new CustomListBox(financialServicesTextBox);
            AutoScroll = true;
            Controls.AddRange(new Control[] {
                compNameLabel, compNameComboBox,
                softwareNameLabel, softwareNameComboBox,
                softwareWebsiteLabel, softwareWebsiteTextBox,
                typeOfSoftwareLabel, typeOfSoftwareTextBox, typeOfSoftwareCustomListBox,
                businessAreasLabel, businessAreasTextBox, buisenessAreasCustomListBox,
                modulesLabel, modulesTextBox, modulesCustomListBox,
                financialServicesLabel, financialServicesTextBox, financialServicesCustomListBox,
                cloudLabel, cloudComboBox,
                submitButton
                });
            string[] softControlVarName = new string[] {
                "compNameLabel","compNameComboBox",
                "softwareNameLabel", "softwareNameComboBox",
                "softwareWebsiteLabel", "softwareWebsiteTextBox",
                "typeOfSoftwareLabel", "typeOfSoftwareTextBox", "typeOfSoftwareCustomListBox",
                "businessAreasLabel", "businessAreasTextBox", "buisenessAreasCustomListBox",
                "modulesLabel", "modulesTextBox", "modulesCustomListBox",
                "financialServicesLabel", "financialServicesTextBox", "financialServicesCustomListBox",
                "cloudLabel", "cloudComboBox",
                "submitButton"
            };
            string[] softControlText = new string[]
            {
                "Comapany Name:",
                "Software Name:",
                "Company Website:",
                "Type of Software:",
                "Business Areas:",
                "Modules:",
                "Financial Services Client Types:",
                "Cloud (Enabled/Native/Based):",
                "Submit",
            };

            int softAddxLoc = 10;
            int softAddyLoc = 11;
            int softAddHeight = 30;
            int softAddWidth = 200;
            int i = 0, j = 0;
            foreach (Control con in Controls)
            {
                con.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                con.Name = softControlVarName.ElementAt(i++);
                if (con is Label)
                {
                    con.Width = softAddWidth;
                    con.Height = softAddHeight;
                    con.Text = softControlText[j++];
                    con.Left = softAddxLoc;
                    con.Top = softAddyLoc;
                }
                else if (con is CustomListBox)
                {
                    //con.Width = softAddWidth;
                    //con.Height = softAddHeight + 60;

                    con.Left = softAddxLoc + 530;
                    con.Top = softAddyLoc - 50;
                    softAddyLoc = softAddyLoc + 60;
                }

                else if (con is TextBox || con is ComboBox)
                {
                    con.Width = softAddWidth + 100;
                    con.Height = softAddHeight;

                    con.Left = softAddxLoc + 210;
                    con.Top = softAddyLoc;
                    softAddyLoc = softAddyLoc + 50;
                }
                else if (con is Button)
                {

                    con.Width = softAddWidth - 100;
                    con.Height = softAddHeight;
                    con.Left = softAddxLoc + 100;
                    con.Top = softAddyLoc;
                    con.Text = softControlText[j++];
                    softAddxLoc = softAddxLoc + 110;
                }

            }

            softwareWebsiteTextBox.TextChanged += CompanyWebsiteTextBox_TextChanged;
            typeOfSoftwareTextBox.TextChanged += TypeOfSoftwareTextBox_TextChanged;
            businessAreasTextBox.TextChanged += BusinessAreasTextBox_TextChanged;
            modulesTextBox.TextChanged += ModulesTextBox_TextChanged;
            financialServicesTextBox.TextChanged += FinancialServicesTextBox_TextChanged;
            submitButton.Click += SubmitButton_Click;

            cloudComboBox.Items.Add("None");
            cloudComboBox.Items.Add("Cloud Native");
            cloudComboBox.Items.Add("Cloud Based");
            cloudComboBox.Items.Add("Cloud Enabled");
            cloudComboBox.SelectedIndex = 0;



            compNameComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            compNameComboBox.DataSource = Controller.vendorModelList.Select(vendor => vendor.CompanyName).ToList();
            compNameComboBox.SelectedIndex = -1;
            compNameComboBox.Leave += CompNameComboBox_Leave;
            compNameComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            compNameComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            compNameComboBox.SelectedIndexChanged += CompNameComboBox_SelectedIndexChanged;


            softwareNameComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            //softwareNameComboBox.DataSource = Controller..Select(software => software.SoftwareName).ToList();
            softwareNameComboBox.SelectedIndex = -1;
            softwareNameComboBox.Leave += SoftwareNameComboBox_Leave;
            softwareNameComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            softwareNameComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            softwareNameComboBox.SelectedIndexChanged += SoftwareNameComboBox_SelectedIndexChanged;
        }

        private void CompNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (compNameComboBox.SelectedIndex >= -1)
            {
                vid =    Controller.vendorModelList.Where(vendor => vendor.CompanyName.Equals(compNameComboBox.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase)).Select(vendor => vendor.Vid).FirstOrDefault();

                if (vid != 0)
                {
                    softwareNameComboBox.DataSource= Controller.softwareModelList.Where(software => software.Vid == vid).Select(software => software.SoftwareName).ToList();
                }
            }
        }

        private void SoftwareNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SoftwareModel softwareModel = Controller.softwareModelList.FirstOrDefault(software => software.SoftwareName.Equals(softwareNameComboBox.SelectedItem.ToString()));
            sid = softwareModel.SoftwareId;
            softwareWebsiteTextBox.Text = softwareModel.SoftwareWebsite;
            if (softwareModel.Cloud == "Cloud Native")
                cloudComboBox.SelectedIndex = 1;
            else if (softwareModel.Cloud == "Cloud Based")
                cloudComboBox.SelectedIndex = 2;
            else if (softwareModel.Cloud == "Cloud Enabled")
                cloudComboBox.SelectedIndex = 3;
            else
                cloudComboBox.SelectedIndex = 0;
            List<String> typeOf = Controller.typeOfSoftwareModelList.Where(software => software.Sid == sid).Select(software => software.TypeOfSoftware).ToList();
            List<String> businessarea = Controller.businessAreasModelList.Where(business => business.Sid == sid).Select(business => business.BusinessAreas).ToList();
            List<String> module = Controller.modulesModelList.Where(modules => modules.Sid == sid).Select(modules => modules.Modules).ToList();
            List<String> finance = Controller.financialServicesModelList.Where(client => client.Sid == sid).Select(client => client.FinancialService).ToList();
            foreach (var val in typeOf)
            {
                typeOfSoftwareCustomListBox.listBox.Items.Add(val);
            }
            foreach (var val in businessarea)
            {
                buisenessAreasCustomListBox.listBox.Items.Add(val);
            }
            foreach (var val in module)
            {
                modulesCustomListBox.listBox.Items.Add(val);
            }
            foreach (var val in finance)
            {
                financialServicesCustomListBox.listBox.Items.Add(val);
            }
        }
    

        private void SoftwareNameComboBox_Leave(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {

                if (!Controller.getDeliverSoftware(vid).Any(vendor => vendor.SoftwareName.Equals(comboBox.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    comboBox.Text = string.Empty;
                }
            }
        }

        private static void CompNameComboBox_Leave(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {

                if (!Controller.getDeliverVendor().Any(vendor => vendor.CompanyName.Equals(comboBox.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    comboBox.Text = string.Empty;
                }
            }
        }


        private void ClearButton_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int random = rand.Next(int.MinValue, 0);
            if (!(InputValidation.GetStringValueOrNoneOrWhitespace(softwareNameComboBox.Text)).Equals("None"))
            {
                try
                {
                    Controller.softwareModelList.Add(new SoftwareModel
                    {
                        Vid = Controller.vendorModelList.Where(v => v.CompanyName.ToLowerInvariant().Equals(compNameComboBox.SelectedItem.ToString().ToLowerInvariant(), StringComparison.OrdinalIgnoreCase)).Select(v => v.Vid).FirstOrDefault(),
                        SoftwareId = random,
                        SoftwareName = InputValidation.GetStringValueOrNoneOrWhitespace(softwareNameComboBox.Text),
                        SoftwareWebsite = InputValidation.GetStringValueOrNoneOrWhitespace(softwareWebsiteTextBox.Text),
                        Cloud = cloudComboBox.SelectedItem.ToString(),
                    });
                    foreach (var type in typeOfSoftwareCustomListBox.listBox.Items)
                    {
                        Controller.typeOfSoftwareModelList.Add(new TypeOfSoftwareModel
                        {
                            id = random,
                            TypeOfSoftware = type.ToString()
                        });
                    }
                    foreach (var business in buisenessAreasCustomListBox.listBox.Items)
                    {
                        Controller.businessAreasModelList.Add(new BusinessAreasModel
                        {
                            id = random,
                            BusinessAreas = business.ToString()
                        });
                    }
                    foreach (var modules in modulesCustomListBox.listBox.Items)
                    {
                        Controller.modulesModelList.Add(new ModulesModel
                        {
                            id = random,
                            Modules = modules.ToString()
                        });
                    }
                    foreach (var finance in financialServicesCustomListBox.listBox.Items)
                    {
                        Controller.financialServicesModelList.Add(new FinancialServicesModel
                        {
                            id = random,
                            FinancialService = finance.ToString()
                        });
                    }
                    clearAll();
                    MessageBox.Show("Software Successfully added.");
                    //Controller.sendSoftwareUpdate(Controller.softwareModelList);

                }
                catch (FormatException fe)
                {
                    MessageBox.Show(fe.Message);
                }
            }
            else
            {
                MessageBox.Show("Software Name is Empty");
            }
        }

        void clearAll()
        {

            foreach (Control con in Controls)
            {
                if (con is TextBox)
                    con.Text = "";
                else if (con is RichTextBox)
                    con.Text = "";
                else if (con is CustomListBox)
                {
                    foreach (Control conCom in typeOfSoftwareCustomListBox.Controls)
                    {
                        if (conCom is TextBox)
                            conCom.Text = "";
                    }
                    foreach (Control conCom in buisenessAreasCustomListBox.Controls)
                    {
                        if (conCom is TextBox)
                            conCom.Text = "";
                    }
                    foreach (Control conCom in modulesCustomListBox.Controls)
                    {
                        if (conCom is TextBox)
                            conCom.Text = "";
                    }
                    foreach (Control conCom in financialServicesCustomListBox.Controls)
                    {
                        if (conCom is TextBox)
                            conCom.Text = "";
                    }
                }
            }
            typeOfSoftwareCustomListBox.listBox.Items.Clear();
            buisenessAreasCustomListBox.listBox.Items.Clear();
            modulesCustomListBox.listBox.Items.Clear();
            financialServicesCustomListBox.listBox.Items.Clear();
        }

        private void CompanyWebsiteTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 40, "Only Text, Numbers and Special Characters like these  /&?=:%$-_.+!*'(),", @"^[ a-zA-Z0-9/&?=:%$-_.+!*'(),]+$");
        }

        private void TypeOfSoftwareTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 30, "Only Text and Space", @"^[a-zA-Z ]+$");
        }

 


        private void BusinessAreasTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 30, "Only Text and Space", @"^[a-zA-Z ]+$");
        }

        private void ModulesTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 30, "Only Text and Space", @"^[a-zA-Z ]+$");
        }

        private void FinancialServicesTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 30, "Only Text and Space", @"^[a-zA-Z ]+$");
        }



    }
}

