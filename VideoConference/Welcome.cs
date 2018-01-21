using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoConference
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nickField.TextLength > 1 && roomNameField.TextLength > 1)
            {
                Conference conference = new Conference(this);
                conference.joinRoom(nickField.Text, roomNameField.Text);
                conference.Show();
                Hide();
            }
        }
    }
}
