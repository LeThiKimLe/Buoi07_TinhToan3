using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        private bool hasError1 = false;
        private bool hasError2 = false;
        private int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;             //đầu tiên chọn phép cộng
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                                 "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            //lấy giá trị của 2 ô số
            double so1, so2, kq = 0;
            so1 = double.Parse(txtSo1.Text);
            so2 = double.Parse(txtSo2.Text);

            //Thực hiện phép tính dựa vào phép toán được chọn
            if (radCong.Checked) kq = so1 + so2;
            else if (radTru.Checked) kq = so1 - so2;
            else if (radNhan.Checked) kq = so1 * so2;
            else if (radChia.Checked) { 
                if (so2 == 0)    { 
                    MessageBox.Show("Không thể chia 0", "Thông báo", MessageBoxButtons.OK); 
                    txtSo2.Focus(); 
                    txtSo2.SelectAll(); }
                else             
                    kq = so1 / so2; }
            //Hiển thị kết quả lên trên ô kết quả
            txtKq.Text = kq.ToString();
        }

        private void txtSo2_Click(object sender, EventArgs e)
        {
            txtSo2.Focus();
            txtSo2.SelectAll();
        }

        private void txtSo1_Click(object sender, EventArgs e)
        {
            txtSo1.Focus();
            txtSo1.SelectAll();
        }

        private void txtSo1_Leave(object sender, EventArgs e)
        {
           
            string input = txtSo1.Text;

            // Kiểm tra xem chuỗi nhập vào có phải là số hay không
            if (!double.TryParse(input, out _))
            {
                hasError1 = true;
                count = 0;
            }
            else
            {
                hasError1 = false;
            }    
        }
       

        private void txtSo2_Leave_1(object sender, EventArgs e)
        {
            string input = txtSo2.Text;

            // Kiểm tra xem chuỗi nhập vào có phải là số hay không
            if (!double.TryParse(input, out _))
            {
                hasError2 = true;
                count = 0;
            }
            else {
                hasError2 = false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count == 0)
            {
                if (this.Focused == true)
                {
                    checkError();
                }

                foreach(Control ctrl in this.Controls)
                {
                    if (ctrl.Focused == true && ctrl.Name != "btnThoat")
                    {
                        checkError();
                    }
                }
                
                foreach(Control ctrl in groupBox1.Controls)
                {
                    if (ctrl.Focused == true)
                    {
                        checkError();
                    }
                }    
            }
        }

        private void checkError()
        {
            if (hasError1 && txtSo1.Focused == false)
            {
                count = count + 1;
                MessageBox.Show("Lỗi: Vui lòng chỉ nhập số! Số không quá lớn.");
                txtSo1.Focus();
                txtSo1.SelectAll();
            }

            if (hasError2 && txtSo2.Focused == false)
            {
                count = count + 1;
                MessageBox.Show("Lỗi: Vui lòng chỉ nhập số! Số không quá lớn.");
                txtSo2.Focus();
                txtSo2.SelectAll();
            }
        }
    }
}
