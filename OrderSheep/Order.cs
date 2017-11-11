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
using OrderSheep.Common;

namespace OrderSheep
{
    public partial class Order : Form
    {
        FoodCategoryDao fcDao = new FoodCategoryDao();
        FoodItemDao fiDao = new FoodItemDao();
        FOrderDao oDao = new FOrderDao();
        SOrderDao soDao = new SOrderDao();
        TextBox textBoxDgv1 = new TextBox();
        Label labelDgv1 = new Label();
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
                gb.Height = 210;
                gb.Tag = dr["Id"];
                PictureBox pb = new PictureBox();
                pb.Tag = dr["Name"].ToString();
                pb.Width = 150;
                pb.Height = 150;
                //string picLocation = "f:\\mj_121427056_20171007_112145.bmp";
                if (!string.IsNullOrEmpty(dr["PicExtension"].ToString()))
                {
                    string picLocation = FileUtil.GetPicLocationById("food", (int)dr["Id"], dr["PicExtension"].ToString());
                    pb.Image = FileUtil.OpenImage(picLocation);
                }                
                pb.Paint += new PaintEventHandler(PictureBox_Paint);
                gb.Controls.Add(pb);
                Button minus = new Button();
                minus.Width = 30;
                minus.Height = 22;
                minus.Text = "-";
                minus.Location = new Point(30, 155);
                minus.Click += new EventHandler(Button_Minus_Click);
                gb.Controls.Add(minus);
                TextBox tx = new TextBox();
                tx.Text = "0";
                tx.Width = 20;
                tx.Location = new Point(70, 155);
                tx.MaxLength = 2;
                gb.Controls.Add(tx);

                Button plus = new Button();
                plus.Width = 30;
                plus.Height = 22;
                plus.Text = "+";
                plus.Location = new Point(100, 155);
                plus.Click += new EventHandler(Button_Plus_Click);
                gb.Controls.Add(plus);

                Button add = new Button();
                add.Width = 100;
                add.Text = "添加";
                add.Location = new Point(30, 180);
                add.Tag = dr["RetailPrice"];
                add.Click += new EventHandler(Button_Add_Click);
                gb.Controls.Add(add);
                
                flowLayoutPanel1.Controls.Add(gb);
            }
            gvFoodList.AutoGenerateColumns = false;
            DataTable orders = oDao.GetOrderByRoomId(_roomId);
            gvFoodList.DataSource = orders.DefaultView;

            //load 
            labelDgv1.Text = "总和";
            labelDgv1.Height = 21;
            labelDgv1.AutoSize = false;
            labelDgv1.BorderStyle = BorderStyle.FixedSingle;
            labelDgv1.TextAlign = ContentAlignment.MiddleCenter;
            int Xdgv1 = this.gvFoodList.GetCellDisplayRectangle(3, -1, true).Location.X;
            labelDgv1.Width = this.gvFoodList.Columns[2].Width + Xdgv1;
            labelDgv1.Location = new Point(0, this.gvFoodList.Height - textBoxDgv1.Height);
            this.gvFoodList.Controls.Add(labelDgv1);
            textBoxDgv1.Width = this.gvFoodList.Columns[3].Width;
            //Xdgvx = this.gvFoodList.GetCellDisplayRectangle(3, -1, true).Location.X;
            textBoxDgv1.Location = new Point(labelDgv1.Width, this.gvFoodList.Height - textBoxDgv1.Height);
            this.gvFoodList.Controls.Add(textBoxDgv1);
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

        private void PictureBox_Paint(Object sender, PaintEventArgs e) {
            PictureBox pb = (PictureBox)sender;
            using (Font myFont = new Font("Arial", 20))
            {
                e.Graphics.DrawString(pb.Tag.ToString(), myFont, Brushes.Green, new Point(2, 2));
            }
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

        private void gvFoodList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            float sum = 0;
            for (int i = 0; i < this.gvFoodList.Rows.Count; i++)
            {
                //if (gvFoodList.Rows[i].Cells[4].Value.ToString() != string.Empty)
                //{
                //    sum += Convert.ToSingle(this.gvFoodList[4, i].Value);
                //}
                sum += Convert.ToSingle(this.gvFoodList[4, i].Value);
            }
            textBoxDgv1.Text = sum.ToString();
        }
    }
}
