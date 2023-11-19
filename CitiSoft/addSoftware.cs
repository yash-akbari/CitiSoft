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
        public addSoftware() { }

        Label softwareNameLabel = new Label();
        TextBox softwareNameTextBox = new TextBox();

        Label companyWebsiteLabel = new Label();
        TextBox companyWebsiteTextBox = new TextBox();

        Label descriptionLabel = new Label();
        RichTextBox descriptionRichTextBox = new RichTextBox();

        Label typeOfSoftwareLabel = new Label();
        TextBox typeOfSoftwareTextBox = new TextBox();
        ListBox typeOfSoftwareListBox = new ListBox();
        Button typeOfSoftwareButton = new Button();

        Label businessAreasLabel = new Label();
        TextBox businessAreasTextBox = new TextBox();
        ListBox businessAreasListBox = new ListBox();
        Button businessAreasButton = new Button();

        Label modulesLabel = new Label();
        TextBox modulesTextBox = new TextBox();
        ListBox modulesListBox = new ListBox();
        Button modulesButton = new Button();

        Label financialServicesLabel = new Label();
        TextBox financialServicesTextBox = new TextBox();
        ListBox financialServicesListBox = new ListBox();
        Button financialServicesButton = new Button();

        Label cloudLabel = new Label();
        ComboBox cloudComboBox = new ComboBox();

        Label additionalInfoLabel = new Label();
        RichTextBox additionalInfoRichTextBox = new RichTextBox();

        private void InitializeComponents()
        {
            Controls.AddRange(new Control[] {
                softwareNameLabel, softwareNameTextBox,
                companyWebsiteLabel, companyWebsiteTextBox,
                typeOfSoftwareLabel, typeOfSoftwareTextBox, typeOfSoftwareListBox, typeOfSoftwareButton,
                descriptionLabel, descriptionRichTextBox,
                businessAreasLabel, businessAreasTextBox, businessAreasListBox, businessAreasButton,
                modulesLabel, modulesTextBox, modulesListBox,modulesButton,
                financialServicesLabel, financialServicesTextBox, financialServicesListBox, financialServicesButton,
                cloudLabel, cloudComboBox,
                additionalInfoLabel, additionalInfoRichTextBox,
                });
            string[] softControlVarName = new string[] {
                "softwareNameLabel", "softwareNameTextBox",
                "companyWebsiteLabel", "companyWebsiteTextBox",
                "typeOfSoftwareLabel", "typeOfSoftwareTextBox", "typeOfSoftwareListBox", "typeOfSoftwareButton",
                "descriptionLabel", "descriptionRichTextBox",
                "businessAreasLabel", "businessAreasTextBox", "businessAreasListBox", "businessAreasButton",
                "modulesLabel", "modulesTextBox", "modulesListBox", "modulesButton",
                "financialServicesLabel", "financialServicesTextBox", "financialServicesListBox", "financialServicesButton",
                "cloudLabel", "cloudComboBox",
                "additionalInfoLabel", "additionalInfoRichTextBox",
            };
            string[] softControlText = new string[]
            {
                "Software Name:",
                "Company Website:",
                "Type of Software:", "Add Type",
                "Description:",
                "Business Areas:", "Add Areas",
                "Modules:", "Add Modules",
                "Financial Services Client Types:", "Add Type",
                "Cloud (Enabled/Native/Based):",
                "Additional Information:",

            };
            int softAddxLoc = 10;
            int softAddyLoc = 11;
            int softAddHeight = 21;
            int softAddWidth = 200;
            int i = 0, j = 0;
            foreach (Control con in Controls)
            {
                con.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
                    con.Height = softAddHeight + 80;

                    con.Left = softAddxLoc + 210;
                    con.Top = softAddyLoc;
                    softAddyLoc = softAddyLoc + 120;
                }
                else if (con is ListBox)
                {
                    con.Width = softAddWidth;
                    con.Height = softAddHeight + 80;

                    con.Left = softAddxLoc + 210 + 100 + 210;
                    con.Top = softAddyLoc + 80;

                }
                else if (con is Button)
                {
                    con.Text = softControlText[j++];

                    con.Width = softAddWidth-150;
                    con.Height = softAddHeight;

                    con.Left = softAddxLoc + 210 + 100 + 210+ 180;
                    con.Top = softAddyLoc;
                }
                else
                {
                    con.Width = softAddWidth + 100;
                    con.Height = softAddHeight;

                    con.Left = softAddxLoc + 210;
                    con.Top = softAddyLoc;
                    softAddyLoc = softAddyLoc + 30;
                }

            }

        }
    }
}
