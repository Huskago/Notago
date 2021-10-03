using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notago.Controls
{
    class RichTextBoxContextMenuStrip : ContextMenuStrip
    {
        private RichTextBox _richTextBox;
        private const string NAME = "RtbContextMenuStrip";

        public RichTextBoxContextMenuStrip(RichTextBox richTextBox)
        {
            _richTextBox = richTextBox;

            Name = NAME;

            var cut = new ToolStripMenuItem("Couper");
            var copy = new ToolStripMenuItem("Copier");
            var paste = new ToolStripMenuItem("Coller");
            var selectAll = new ToolStripMenuItem("Tout sélectionner");

            cut.Click += (s, e) => _richTextBox.Cut();
            copy.Click += (s, e) => _richTextBox.Copy();
            paste.Click += (s, e) => _richTextBox.Paste();
            selectAll.Click += (s, e) => _richTextBox.SelectAll();

            Items.AddRange(new ToolStripItem[] { cut, copy, paste, selectAll });
        }
    }
}
