using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderSheep.Dao;
using OrderSheep.Entity;

namespace OrderSheep
{
    public partial class Order : Form
    {
        FoodCategoryDao fcDao = new FoodCategoryDao();
        FoodItemDao fiDao = new FoodItemDao();
        FOrderDao oDao = new FOrderDao();
        SOrderDao soDao = new SOrderDao();
        int _roomId = 0;

        public string ReturnValue { get; set; }

        public Order(int id)
        {
            InitializeComponent();
            _roomId = id;
        }

        private void Order_Load(object sender, EventArgs e)
        {
            DataTable dt = fiDao.GetAllFoodItems();
            foreach (DataRow dr in dt.Rows)
            {
                GroupBox gb = new GroupBox();
                gb.Width = 160;
                gb.Height = 220;
                gb.Tag = dr["Id"];
                PictureBox pb = new PictureBox();
                pb.Text = dr["Name"].ToString();
                pb.Width = 150;
                pb.Height = 150;
                pb.Image = Image.FromFile("f:\\mj_121427056_20171007_112145.bmp");
                gb.Controls.Add(pb);
                Button minus = new Button();
                minus.Width = 30;
                minus.Height = 22;
                minus.Text = "-";
                minus.Location = new Point(30, 160);
                minus.Click += new EventHandler(Button_Minus_Click);
                gb.Controls.Add(minus);
                TextBox tx = new TextBox();
                tx.Text = "0";
                tx.Width = 20;
                tx.Location = new Point(70, 160);
                tx.MaxLength = 2;
                gb.Controls.Add(tx);

                Button plus = new Button();
                plus.Width = 30;
                plus.Height = 22;
                plus.Text = "+";
                plus.Location = new Point(100, 160);
                plus.Click += new EventHandler(Button_Plus_Click);
                gb.Controls.Add(plus);

                Button add = new Button();
                add.Width = 100;
                add.Text = "添加";
                add.Location = new Point(30, 190);
                add.Tag = dr["RetailPrice"];
                add.Click += new EventHandler(Button_Add_Click);
                gb.Controls.Add(add);
                
                flowLayoutPanel1.Controls.Add(gb);
            }
            gvFoodList.AutoGenerateColumns = false;
            DataTable orders = oDao.GetOrderByRoomId(_roomId);
            gvFoodList.DataSource = orders.DefaultView;
        }

        private void Button_Minus_Click(Object sender, EventArgs e) {
            Button b = (Button)sender;
            foreach (Control c in b.Parent.Controls) {
                TextBox tb = c as TextBox;
                if (tb != null) {
                    int value = 0;
                    int.TryParse(tb.Text, out value);
                    if (value > 0)
                    {
                        value = value - 1;
                    }
                    else {
                        value = 0;
                    }
                    tb.Text = value.ToString();
                    break;
                }
            }
        }

        private void Button_Plus_Click(Object sender, EventArgs e) {
            Button b = (Button)sender;
            foreach (Control c in b.Parent.Controls)
            {
                TextBox tb = c as TextBox;
                if (tb != null)
                {
                    int value = 0;
                    int.TryParse(tb.Text, out value);
                    value++;
                    tb.Text = value.ToString();
                    break;
                }
            }
        }

        private void Button_Add_Click(Object sender, EventArgs e) {
            Button b = (Button)sender;
            int count = 0;
            foreach (Control c in b.Parent.Controls)
            {
                TextBox tb = c as TextBox;
                if (tb != null)
                {
                    int.TryParse(tb.Text, out count);
                    break;
                }
            }
            if (count <= 0) {
                return;
            }
            int foodId = (int)b.Parent.Tag;
            float price = (float)b.Tag;
            FOrderEntity entity = oDao.GetOpenFOrder(_roomId, foodId);
            if (entity == null)
            {
                entity = new FOrderEntity();
                entity.RoomId = _roomId;
                entity.FoodId = foodId;
                entity.Quantity = count;
                entity.Price = price;
                entity.Amount = price * count;
                entity.StartTime = DateTime.Now;
                oDao.AddFOrder(entity);
            }
            else {
                entity.Quantity += count;
                entity.Amount += count * price;
                oDao.ResetFOrderQuantity(entity);
            }
            DataTable orders = oDao.GetOrderByRoomId(_roomId);
            gvFoodList.DataSource = orders.DefaultView;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvFoodList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择要删除的行！");
                return;
            }
            var result = MessageBox.Show("确定要删除吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            foreach (DataGridViewRow row in gvFoodList.SelectedRows)
            {
                int id = (int)row.Cells[0].Value;
                gvFoodList.Rows.Remove(row);
                oDao.DeleteFOrderById(id);
            }

            MessageBox.Show("删除成功！");
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            soDao.PayOrder(_roomId);
            this.ReturnValue = "pay";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("确定要取消这个订单吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            soDao.QuitOrder(_roomId);
            this.ReturnValue = "quit";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
