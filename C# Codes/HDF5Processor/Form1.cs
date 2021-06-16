using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using HDF.PInvoke;

namespace HDF5Processor
{
    public partial class MainForm : Form
    {
        private FileDialog openFileDialog;
        private string fileName;
        public MainForm()
        {
            InitializeComponent();
            this.fileName = string.Empty;
            mainFolderTextBox.ReadOnly = true;
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            GetFilename();
            mainFolderTextBox.Text = this.fileName;
            resultLabel.Text = GetModelConfig();
            resultLabel.Update();
        }

        private void GetFilename() 
        {
            using (this.openFileDialog = new OpenFileDialog())
            {
                this.openFileDialog.Filter = "H5 files (*.h5)|*.h5|HDF5 files (*.hdf5)|*.hdf5";
                this.openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.fileName = openFileDialog.FileName;
                }
            }

        }

        private string GetModelConfig() 
        {
            long fileId = H5F.open(this.fileName,H5F.ACC_RDONLY);
            long attrId = H5A.open(fileId, @"model_config");
            long typeId = H5A.get_type(attrId);
            long spaceId = H5A.get_space(attrId);
            long count = H5S.get_simple_extent_npoints(spaceId);
            H5S.close(spaceId);
            IntPtr[] dest = new IntPtr[count];
            GCHandle handle = GCHandle.Alloc(dest, GCHandleType.Pinned);
            
            H5A.read(attrId, typeId, handle.AddrOfPinnedObject());

            var attrStrings = new List<string>();
            for (int i = 0; i < dest.Length; ++i)
            {
                int attrLength = 0;
                while (Marshal.ReadByte(dest[i], attrLength) != 0)
                {
                    ++attrLength;
                }

                byte[] buffer = new byte[attrLength];
                Marshal.Copy(dest[i], buffer, 0, buffer.Length);
                string stringPart = Encoding.UTF8.GetString(buffer);

                attrStrings.Add(stringPart);

                H5.free_memory(dest[i]);
            }

            handle.Free();
            return attrStrings.ToArray().ToString();
        }
    }
}
