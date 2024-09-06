/*=====================================================================
  
  This file is part of the Autodesk Vault API Code Samples.

  Copyright (C) Autodesk Inc.  All rights reserved.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Autodesk.Connectivity.Extensibility.Framework;
using Autodesk.Connectivity.JobProcessor.Extensibility;

namespace TestLoader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            m_folderTextBox.Text = ExtensionLoader.DefaultExtensionsFolder;
        }

        private void m_folderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog()
            {
                SelectedPath = m_folderTextBox.Text,
            };

            DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                m_folderTextBox.Text = dialog.SelectedPath;
            }
        }

        private void m_loadButton_Click(object sender, EventArgs e)
        {
            m_outputTextBox.Clear();

            ExtensionLoader loader = new ExtensionLoader();
            //List<Extension> extensions = null;
            List<Extension<VcetExtension>> vcetExtensions = null;
            List<ExtensionException> exceptions = null;
            ICollection<Extension<IJobHandler>> extensions = null;

            try
            {
                // Loading extensions from the folder
                // Find IJobHandler extensions because those are the ones we care about
                extensions = loader.FindExtensions<IJobHandler>();
                //vcetExtensions = loader.FindExtensions<VcetExtension>().ToList();

                //extensions = loader.FindExtensions();

                //extensions = loader.FindExtensions<VcetExtension>().ToList();

                if (!extensions.Any())
                {
                    m_outputTextBox.Text = "No valid extensions found.";
                    return;
                }
            }
            catch (Exception ex)
            {
                m_outputTextBox.Text = "Error reading extensions: " + Environment.NewLine + ex.ToString();
                return;
            }

            //instead of firstordefault, we need to use the value from m_outputTextBox


            string selectedFolder = m_folderTextBox.Text;
            var extension = extensions.FirstOrDefault(ext => ext.ExtensionAssembly.Folder.Equals(selectedFolder, StringComparison.InvariantCultureIgnoreCase));

            if (extension == null)
            {
                m_outputTextBox.Text = "Null extension";
                return;
            }

            // Verifying the extension is in the correct folder
            string dflt = ExtensionLoader.DefaultExtensionsFolder;
            if (!extension.ExtensionAssembly.Folder.StartsWith(dflt, StringComparison.InvariantCultureIgnoreCase))
            {
                m_outputTextBox.Text = "Extension found, but not in the correct location." + Environment.NewLine +
                    "Only extensions under \"" + dflt + "\" can be loaded.";
                return;
            }

            // Add additional resolve folders if necessary, e.g., for external dependencies
            //extension.ResolveFolders.Add(@"path\to\log4net");

            // Loading the extension and checking for exceptions
            try
            {
                loader = new ExtensionLoader();
                loader.LoadExtension(extension);
                exceptions = loader.Exceptions.ToList();
            }
            catch (Exception ex)
            {
                m_outputTextBox.Text = "Error loading extension: " + Environment.NewLine + ex.ToString();
                return;
            }

            if (exceptions.Count > 0)
            {
                StringBuilder output = new StringBuilder();
                output.AppendLine("Exceptions found during load:");

                foreach (ExtensionException ee in exceptions)
                {
                    output.AppendLine("--------------------------------------");
                    if (ee.InnerException != null && ee.InnerException.GetType() == typeof(BadImageFormatException))
                    {
                        output.AppendLine("BadImageFormatException found, this is usually because the extension is .NET 4 or higher.");
                        output.AppendLine("To fix, make sure your extension is .NET 3.5 or lower.");
                    }

                    output.AppendLine(ee.ToString());
                }

                m_outputTextBox.Text = output.ToString();
            }
            else
            {
                m_outputTextBox.Text = "Extension loaded successfully.";
            }
        }

        /*private void m_loadButton_Click(object sender, EventArgs e)
        {
            m_outputTextBox.Clear();
            Extension extension = null;
            ExtensionLoader loader = new ExtensionLoader();

            try
            {
                var extensions = loader.FindExtensions<VcetExtension>() ;
                extension = extensions?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                m_outputTextBox.Text = "Error reading extension: " + Environment.NewLine + ex.ToString();
                return;
            }

            if (extension == null)
            {
                m_outputTextBox.Text = "Null extension";
                return;
            }

            string dflt = Autodesk.Connectivity.Extensibility.Framework.ExtensionLoader.DefaultExtensionsFolder;
            if (!extension.ExtensionAssembly.Description.StartsWith(dflt, StringComparison.InvariantCultureIgnoreCase))
            {
                m_outputTextBox.Text = "Extension found, but not in the correct location." + Environment.NewLine +
                    "Only extensions under \"" + dflt + "\" can be loaded.";
                return;
            }

            // Add external dependency folders (if any)
            extension.ResolveFolders.Add(@"path\to\log4net");  // Example: Add external library folder

            List<Extension> loadedExtensions = null;
            List<ExtensionException> exceptions = null;

            try
            {
                loader.LoadExtensions(new List<Extension> { extension });
                exceptions = loader.Exceptions.ToList();
            }
            catch (Exception ex)
            {
                m_outputTextBox.Text = "Error loading extension: " + Environment.NewLine + ex.ToString();
                return;
            }

            // Handle exceptions if any occurred during the loading process
            if (exceptions != null && exceptions.Count > 0)
            {
                StringBuilder output = new StringBuilder();
                output.AppendLine("Exceptions found during load:");

                foreach (var exception in exceptions)
                {
                    output.AppendLine(exception.ToString());
                }

                m_outputTextBox.Text = output.ToString();
            }
            else
            {
                m_outputTextBox.Text = "Extension loaded successfully.";
            }
        }*/



    }
}
