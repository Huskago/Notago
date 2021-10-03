using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notago.Controls
{
    public class MainMenuStrip : MenuStrip
    {
        private const string NAME = "MainMenuStrip";

        private FontDialog _fontDialog;

        public MainMenuStrip()
        {
            Name = NAME;
            Dock = DockStyle.Top;

            _fontDialog = new FontDialog();

            FileDropDownMenu();
            EditDropDownMenu();
            FormatDropDownMenu();
            ViewDropDownMenu();
        }

        public void FileDropDownMenu()
        {
            var fileDropDownMenu = new ToolStripMenuItem("Fichier");

            var newFile = new ToolStripMenuItem("Nouveau", null, null, Keys.Control | Keys.N);
            var openFile = new ToolStripMenuItem("Ouvrir...", null, null, Keys.Control | Keys.O);
            var saveFile = new ToolStripMenuItem("Enregistrer", null, null, Keys.Control | Keys.S);
            var saveAsFile = new ToolStripMenuItem("Enregistrer sous...", null, null, Keys.Control | Keys.Shift | Keys.S);
            var quitApplication = new ToolStripMenuItem("Quitter", null, null, Keys.Alt | Keys.F4);

            fileDropDownMenu.DropDownItems.AddRange(new ToolStripItem[] { newFile, openFile, saveFile, saveAsFile, quitApplication });

            Items.Add(fileDropDownMenu);
        }

        public void EditDropDownMenu()
        {
            var editDropDown = new ToolStripMenuItem("Edition");

            var cancel = new ToolStripMenuItem("Annuler", null, null, Keys.Control | Keys.Z);
            var restore = new ToolStripMenuItem("Restaurer", null, null, Keys.Control | Keys.Y);

            cancel.Click += (s, e) => { if(MainForm.RichTextBox.CanUndo) MainForm.RichTextBox.Undo(); };
            restore.Click += (s, e) => { if (MainForm.RichTextBox.CanRedo) MainForm.RichTextBox.Redo(); };

            editDropDown.DropDownItems.AddRange(new ToolStripItem[] { cancel, restore });

            Items.Add(editDropDown);
        }

        public void FormatDropDownMenu()
        {
            var formatDropDown = new ToolStripMenuItem("Affichage");

            var font = new ToolStripMenuItem("Police...");

            font.Click += (s, e) =>
            {
                _fontDialog.Font = MainForm.RichTextBox.Font;
                _fontDialog.ShowDialog();

                MainForm.RichTextBox.Font = _fontDialog.Font;
            };

            formatDropDown.DropDownItems.AddRange(new ToolStripItem[] { font });

            Items.Add(formatDropDown);
        }

        public void ViewDropDownMenu()
        {
            var viewDropDown = new ToolStripMenuItem("Affichage");
            var alwaysOnTop = new ToolStripMenuItem("Toujours devant");

            var zoomDropDown = new ToolStripMenuItem("Zoom");
            var zoomIn = new ToolStripMenuItem("Zoom avant", null, null, Keys.Control | Keys.Add);
            var zoomOut = new ToolStripMenuItem("Zoom arrière" ,null, null, Keys.Control | Keys.Subtract);
            var restoreZoom = new ToolStripMenuItem("Restaurer le zoom par défaut", null, null, Keys.Control | Keys.Divide);

            zoomIn.ShortcutKeyDisplayString = "Ctrl+Num +";
            zoomOut.ShortcutKeyDisplayString = "Ctrl+Num -";
            restoreZoom.ShortcutKeyDisplayString = "Ctrl+Num /";

            alwaysOnTop.Click += (s, e) =>
            {
                if (alwaysOnTop.Checked)
                {
                    alwaysOnTop.Checked = false;
                    Program.MainForm.TopMost = false;
                }
                else
                {
                    alwaysOnTop.Checked = true;
                    Program.MainForm.TopMost = true;
                }
            };

            zoomIn.Click += (s, e) =>
            {
                if (MainForm.RichTextBox.ZoomFactor < 5F)
                {
                    MainForm.RichTextBox.ZoomFactor += 0.3F;
                }
            };

            zoomOut.Click += (s, e) =>
            {
                if (MainForm.RichTextBox.ZoomFactor > 0.3F)
                {
                    MainForm.RichTextBox.ZoomFactor -= 0.3F;
                }
            };

            restoreZoom.Click += (s, e) => { MainForm.RichTextBox.ZoomFactor = 1F; };

            zoomDropDown.DropDownItems.AddRange(new ToolStripItem[] { zoomIn, zoomOut, restoreZoom });

            viewDropDown.DropDownItems.AddRange(new ToolStripItem[] { alwaysOnTop, zoomDropDown });

            Items.Add(viewDropDown);
        }
    }
}
