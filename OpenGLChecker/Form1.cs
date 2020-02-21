using System;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenGLChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtInfo.Font = new Font(SystemFonts.DefaultFont.FontFamily, 14);

            try
            {
                txtInfo.AppendText($"OpenGL Version: {QueryOpenGlVersion()}");
            }
            catch (Exception ex)
            {
                txtInfo.AppendText(ex.Message);
                txtInfo.AppendText(ex.StackTrace);
            }
        }

        public string QueryOpenGlVersion()
        {
            // glGetString does not work without an OpenGL context.
            using (var openGlControl = new GLControl())
            {
                openGlControl.MakeCurrent();
                return GL.GetString(StringName.Version);
            }
        }
    }
}