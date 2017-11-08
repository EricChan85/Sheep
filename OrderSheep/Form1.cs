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
    public partial class MainForm : Form
    {
        FoodItemDao fiDao = new FoodItemDao();
        RoomDao rDao = new RoomDao();
        SOrderDao soDao = new SOrderDao();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DataTable dt = rDao.GetAllRooms();
            foreach (DataRow dr in dt.Rows) {
                GroupBox gb = new GroupBox();
                gb.Width = 160;
                gb.Height = 160;
                gb.Tag = dr["State"];
                Button b = new Button();
                b.Tag = dr["Id"];
                b.Text = dr["RoomName"].ToString();
                b.Width = 150;
                b.Height = 150;
                b.Location = new Point(5, 5);
                switch ((int)dr["State"]) { 
                    case 1:
                        b.BackColor = Color.Green;
                        break;
                    case 2:
                        b.BackColor = Color.Red;
                        break;
                    case 3:
                        b.BackColor = Color.Blue;
                        break;
                    default:
                        break;
                }
                b.Click += new EventHandler(btnRoom_click);
                gb.Controls.Add(b);
                flowLayoutPanel1.Controls.Add(gb);
            }
            
        }

        private void btnRoom_click(object sender, EventArgs e) {
            Button b = (Button)sender;
            int id = (int)b.Tag;
            int state = (int)b.Parent.Tag;
            switch (state) { 
                case 1:
                    //input username and mobile here
                    SOrderEntity soEntity = new SOrderEntity();
                    soEntity.RoomId = id;
                    soEntity.State = 1;
                    soEntity.StartTime = DateTime.Now;
                    soDao.StartOrder(soEntity);
                    b.BackColor = Color.Red;
                    break;
                case 2:
                    break;
                case 3:
                    MessageBox.Show("当前房间不能使用！");
                    return;
            }
            Order o = new Order(id);
            var result = o.ShowDialog();
            if (result == DialogResult.OK) {
                if (o.ReturnValue == "pay") {
                    b.BackColor = Color.Green;
                }   
            }
        }


        #region "菜单"
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            FoodItems fi = new FoodItems(-1);
            fi.ShowDialog();
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            if (gvFoodItems.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择要修改的行！");
                return;
            }
            int id = (int)gvFoodItems.SelectedRows[0].Cells[0].Value;
            FoodItems fi = new FoodItems(id);
            fi.ShowDialog();
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (gvFoodItems.SelectedRows.Count <= 0) {
                MessageBox.Show("请选择要删除的行！");
                return;
            }
            foreach (DataGridViewRow row in gvFoodItems.SelectedRows) {
                int id = (int)row.Cells[0].Value;
                gvFoodItems.Rows.Remove(row);
                fiDao.DeleteFoodItemsById(id);    
            }
            
            MessageBox.Show("删除成功！");
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            gvFoodItems.AutoGenerateColumns = false;
            DataTable dtFoodItems = fiDao.GetAllFoodItems();
            gvFoodItems.DataSource = dtFoodItems.DefaultView;
            
        }

        #endregion

        #region "room"


        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            Rooms room = new Rooms(-1);
            room.ShowDialog();
        }

        

        private void btnSearchRoom_Click(object sender, EventArgs e)
        {
            gvRoom.AutoGenerateColumns = false;
            DataTable dt = rDao.GetAllRooms();
            gvRoom.DataSource = dt.DefaultView;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (gvRoom.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择要修改的行！");
                return;
            }
            int id = (int)gvRoom.SelectedRows[0].Cells[0].Value;
            Rooms fi = new Rooms(id);
            fi.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvRoom.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择要删除的行！");
                return;
            }
            var result = MessageBox.Show("确定要删除选中的房间吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) {
                return;
            }
            foreach (DataGridViewRow row in gvRoom.SelectedRows)
            {
                int id = (int)row.Cells[0].Value;
                gvRoom.Rows.Remove(row);
                rDao.DeleteRoomById(id);
            }

            MessageBox.Show("删除成功！");
        }

        #endregion

        

        

        
    }
}
