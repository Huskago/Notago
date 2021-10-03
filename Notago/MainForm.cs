using Notago.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notago
{
    public partial class MainForm : Form
    {
        public static RichTextBox RichTextBox;

        public MainForm()
        {
            InitializeComponent();
            
            var mainTabControl = new MainTabControl();
            var menuStrip = new MainMenuStrip();
            RichTextBox = new CustomRichTextBox();

            mainTabControl.TabPages.Add("Onglet 1");
            mainTabControl.TabPages[0].Controls.Add(RichTextBox);

            Controls.AddRange(new Control[] { mainTabControl, menuStrip });
        }
    }
}
