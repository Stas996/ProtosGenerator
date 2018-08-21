using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProtosGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSetDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                lblProtocDirectory.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CreateAndExecuteBat()
        {
            var currentFiles = Directory.GetFiles(lblProtocDirectory.Text);
            var outputDirectory = $"{Directory.GetCurrentDirectory()}\\ProtosContent";
            Directory.CreateDirectory(outputDirectory);

            var commands = currentFiles.Select(f => 
                BatCommands.GetProtocCommand(
                    lblProtocDirectory.Text,
                    outputDirectory,
                    f));
            var commandsContent = string.Join("\r\n", commands);

            string batContent = string.Empty;
            using (var sr = new StreamReader("Template/bat_template.tpl"))
            {
                batContent = sr.ReadToEnd();
            }

            BatCreator.CreateAndExecute("protoc_generator.bat", string.Format(batContent, commandsContent));
            Process.Start(outputDirectory);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            CreateAndExecuteBat();
        }
    }
}
