using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    
    internal class AddSoftware : Form
    {
        public AddSoftware() 
        {
            InitializeComponents();
        }


        Label compNameLabel = new Label();
        ComboBox compNameComboBox = new ComboBox();

        Label softwareNameLabel = new Label();
        TextBox softwareNameTextBox = new TextBox();

        Label companyWebsiteLabel = new Label();
        TextBox companyWebsiteTextBox = new TextBox();

        Label descriptionLabel = new Label();
        RichTextBox descriptionRichTextBox = new RichTextBox();

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

        Label additionalInfoLabel = new Label();
        RichTextBox additionalInfoRichTextBox = new RichTextBox();



        private void InitializeComponents()
        {
            typeOfSoftwareCustomListBox = new CustomListBox(typeOfSoftwareTextBox);
            buisenessAreasCustomListBox = new CustomListBox(businessAreasTextBox);
            modulesCustomListBox = new CustomListBox(modulesTextBox);
            financialServicesCustomListBox = new CustomListBox(financialServicesTextBox);
            AutoScroll = true;
            Controls.AddRange(new Control[] {
                compNameLabel, compNameComboBox,
                softwareNameLabel, softwareNameTextBox,
                companyWebsiteLabel, companyWebsiteTextBox,
                typeOfSoftwareLabel, typeOfSoftwareTextBox, typeOfSoftwareCustomListBox,
                descriptionLabel, descriptionRichTextBox,
                businessAreasLabel, businessAreasTextBox, buisenessAreasCustomListBox,
                modulesLabel, modulesTextBox, modulesCustomListBox,
                financialServicesLabel, financialServicesTextBox, financialServicesCustomListBox,
                cloudLabel, cloudComboBox,
                additionalInfoLabel, additionalInfoRichTextBox,
                });
            string[] softControlVarName = new string[] {
                "compNameLabel","compNameComboBox",
                "softwareNameLabel", "softwareNameTextBox",
                "companyWebsiteLabel", "companyWebsiteTextBox",
                "typeOfSoftwareLabel", "typeOfSoftwareTextBox", "typeOfSoftwareCustomListBox",
                "descriptionLabel", "descriptionRichTextBox",
                "businessAreasLabel", "businessAreasTextBox", "buisenessAreasCustomListBox",
                "modulesLabel", "modulesTextBox", "modulesCustomListBox",
                "financialServicesLabel", "financialServicesTextBox", "financialServicesCustomListBox",
                "cloudLabel", "cloudComboBox",
                "additionalInfoLabel", "additionalInfoRichTextBox",
            };
            string[] softControlText = new string[]
            {
                "Comapany Name:",
                "Software Name:",
                "Company Website:",
                "Type of Software:",
                "Description:",
                "Business Areas:",
                "Modules:",
                "Financial Services Client Types:",
                "Cloud (Enabled/Native/Based):",
                "Additional Information:",
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
                else if (con is RichTextBox)
                {
                    con.Width = softAddWidth + 100;
                    con.Height = softAddHeight + 60;

                    con.Left = softAddxLoc + 210;
                    con.Top = softAddyLoc;
                    softAddyLoc = softAddyLoc + 100;
                }
                else if (con is CustomListBox)
                {
                    //con.Width = softAddWidth;
                    //con.Height = softAddHeight + 60;

                    con.Left = softAddxLoc + 530;
                    con.Top = softAddyLoc-50;
                    softAddyLoc = softAddyLoc + 60;
                }

                else
                {
                    con.Width = softAddWidth + 100;
                    con.Height = softAddHeight;

                    con.Left = softAddxLoc + 210;
                    con.Top = softAddyLoc;
                    softAddyLoc = softAddyLoc + 50;
                }

            }
            softwareNameTextBox.TextChanged += SoftwareNameTextBox_TextChanged;
            companyWebsiteTextBox.TextChanged += CompanyWebsiteTextBox_TextChanged;
            typeOfSoftwareTextBox.TextChanged += TypeOfSoftwareTextBox_TextChanged;
            descriptionRichTextBox.TextChanged += DescriptionRichTextBox_TextChanged;
            businessAreasTextBox.TextChanged += BusinessAreasTextBox_TextChanged;
            modulesTextBox.TextChanged += ModulesTextBox_TextChanged;
            financialServicesTextBox.TextChanged += FinancialServicesTextBox_TextChanged;
            additionalInfoRichTextBox.TextChanged += AdditionalInfoRichTextBox_TextChanged;

            

        }

        private void SoftwareNameTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox,30,"Only Text, Space and Hyphen(-)", @"^[a-zA-Z -]+$");
        }
        private void CompanyWebsiteTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 40, "Only Text, Numbers and Special Characters like these  /&?=:%$-_.+!*'(),", @"^[a-zA-Z0-9/&?=:%$-_.+!*'(),]+$");
        }

        private void TypeOfSoftwareTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 30, "Only Text and Space", @"^[a-zA-Z ]+$");
        }

        private void DescriptionRichTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 255, "Only Text, Numbers and Special Characters like these  /&?=:%$-_.+!*'(),", @"^[a-zA-Z0-9/&?=:%$£-_.+!*'(),]+$");
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

        private void AdditionalInfoRichTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 255, "Only Text, Numbers and Special Characters like these  /&?=:%$-_.+!*'(),", @"^[a-zA-Z0-9/&?=:%$£-_.+!*'(),]+$");
        }

    }

}