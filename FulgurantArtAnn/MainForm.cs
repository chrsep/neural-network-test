﻿using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.IO.Directory;

namespace FulgurantArtAnn
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            
        }

        private void buttonAddArt_Click(object sender, EventArgs e)
        {
            var form = new AddArtForm(this);
            form.Show();
            Hide();
        }

        private void buttonCheckCategory_Click(object sender, EventArgs e)
        {
            var form = new CheckCategoryForm(this);
            form.Show();
            Hide();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            var form = new BrowseForm(this);
            form.Show();
            Hide();
        }

        private void linkExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (NeuralEngine.IsExist())
                NeuralEngine.Instance.Save();
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                GetDirectories("pictures");
            }
            catch (Exception)
            {
                CreateDirectory("pictures");
            }
        }
    }
}