using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LottoAdmin
{
    public partial class UserControlBet : UserControl
    {
        public UserControlBet()
        {
            InitializeComponent();
        }
        public string TName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }
        public string TAmount
        {
            get { return lblAmount.Text; }
            set { lblAmount.Text = value; }
        }
    }
}
