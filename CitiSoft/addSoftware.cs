using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    internal class addSoftware : Form
    {
        public addSoftware() 
        {
            InitializeComponents();
        }

        

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

            

        }

    }

}
