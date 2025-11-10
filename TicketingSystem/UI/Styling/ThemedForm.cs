using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    // Provides a centralized modern look & feel for every WinForms screen.
    public class ThemedForm: Form
    {
        private static readonly Color WindowBackColor = Color.FromArgb(244, 247, 252);
        private static readonly Color PrimaryAccentColor = Color.FromArgb(0, 120, 215);
        private static readonly Color AccentHoverColor = Color.FromArgb(0, 102, 183);
        private static readonly Color AccentDangerColor = Color.FromArgb(230, 68, 89);
        private static readonly Color PrimaryTextColor = Color.FromArgb(30, 30, 30);
        private static readonly Font BodyFont = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        private static readonly Font HeadingFont = new Font("Segoe UI Semibold", 14F, FontStyle.Regular, GraphicsUnit.Point);

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyTheme(this);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            ApplyTheme(e.Control);
        }

        private void ApplyTheme(Control control)
        {
            if (control == null)
            {
                return;
            }

            if (control is Form form)
            {
                form.BackColor = WindowBackColor;
                form.ForeColor = PrimaryTextColor;
                form.Font = BodyFont;
            }

            switch (control)
            {
                case Label label:
                    label.Font = label.Font.Size > 12 ? HeadingFont : BodyFont;
                    label.ForeColor = PrimaryTextColor;
                    break;
                case Button button:
                    string text = button.Text?.ToLowerInvariant() ?? string.Empty;
                    bool isDanger = text.Contains("cancel") || text.Contains("hủy") || text.Contains("huỷ") || text.Contains("ပယ်") || text.Contains("thoát");
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor = AccentHoverColor;
                    button.FlatAppearance.MouseDownBackColor = AccentHoverColor;
                    button.BackColor = isDanger ? AccentDangerColor : PrimaryAccentColor;
                    button.ForeColor = Color.White;
                    button.Font = BodyFont;
                    button.Padding = new Padding(8, 4, 8, 4);
                    break;
                case Panel panel:
                case GroupBox groupBox:
                    control.BackColor = Color.FromArgb(255, 255, 255);
                    break;
                case PictureBox pictureBox:
                    pictureBox.BackColor = Color.Transparent;
                    break;
                case TextBox textBox:
                case ComboBox comboBox:
                    control.BackColor = Color.White;
                    control.ForeColor = PrimaryTextColor;
                    control.Font = BodyFont;
                    break;
            }

            foreach (Control child in control.Controls)
            {
                ApplyTheme(child);
            }
        }
    }
}
