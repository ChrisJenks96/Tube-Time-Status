using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TubeProject;

namespace TubeAppWin
{
    public partial class MainForm : Form
    {
        TubeXMLParser tubeXML = new TubeXMLParser();
        //for the data grid view for the tube data
        DataTable dt = new DataTable();
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //add the 3 columns to our datagridview
            dt.Columns.AddRange(new DataColumn[3]{
                new DataColumn("Tube Line", typeof(string)),
                new DataColumn("Status", typeof(string)),
                new DataColumn("Message",typeof(string))
            });
        }

        private void UIUpdate()
        {
            //update data source, resize columns (account for long messages)
            dgvTubeLines.DataSource = dt;
            dgvTubeLines.AllowUserToAddRows = false;
            dgvTubeLines.AutoResizeColumns();
            lblXMLDataDate.Text = "Tube XML Data Date: " + tubeXML.GetTubeXMLDataDate();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TubeXMLPull tubeXMLPull = new TubeXMLPull();
            //private credentials, directory to save the xml file too, app id and app key can be requested from TFL
            bool xmlPullSuccess = tubeXMLPull.Get(TubeCredentials.app_dir, tbAppId.Text, tbAppKey.Text);
            if (xmlPullSuccess)
            {
                //parse and read the xml file
                if (tubeXML.Load(TubeCredentials.app_dir)){
                    tubeXML.Read(dt);
                    UIUpdate();
                }

                else
                {
                    MessageBox.Show("TubeXMLParser.Load: Failed to load " + TubeCredentials.app_dir);
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "xml files (*.xml)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //parse and read the xml file
                if (tubeXML.Load(openFileDialog.FileName)){
                    tubeXML.Read(dt);
                    UIUpdate();
                }

                else
                {
                    MessageBox.Show("TubeXMLParser.Load: Failed to load " + TubeCredentials.app_dir);
                }

            }
        }
    }
}
