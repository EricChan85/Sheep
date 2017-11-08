using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using OrderSheep.Dao;
using OrderSheep.Entity;
using OrderSheep.Common;

namespace OrderSheep
{
    public partial class Rooms : Form
    {
        RoomStateDao rsDao = new RoomStateDao();
        RoomDao rDao = new RoomDao();
        int _id = -1;

        public Rooms(int id)
        {
            InitializeComponent();
            _id = id;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            DataTable dt = rsDao.GetAllRoomStates();
            cbState.DataSource = dt.DefaultView;
            cbState.ValueMember = "Id";
            cbState.DisplayMember = "StateName";
            if (_id > 0)
            {
                RoomEntity entity = rDao.GetRoomById(_id);
                txtName.Text = entity.Name;
                txtDescription.Text = entity.Description;
                cbState.SelectedIndex = entity.State - 1;
                if (!string.IsNullOrEmpty(entity.PicExtension))
                {
                    string path = FileUtil.GetPicLocationById("room", entity.Id, entity.PicExtension);
                    txtPicLocation.Text = path;
                    pbPicture.Image = Image.FromFile(path);
                }

            }
            else {
                cbState.SelectedIndex = 0;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!FileUtil.IsValidImage(openFileDialog1.FileName)) {
                    MessageBox.Show("请选择正确的图片！");
                    return;
                }
                txtPicLocation.Text = openFileDialog1.FileName;
                pbPicture.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ext = "";
            if (txtPicLocation.Text.Trim() != "")
            {
                ext = Path.GetExtension(txtPicLocation.Text);
            }
            RoomEntity rEntity = new RoomEntity();
            rEntity.Name = txtName.Text;
            rEntity.Description = txtDescription.Text;
            rEntity.State = (int)cbState.SelectedValue;
            rEntity.PicExtension = ext;
            if (_id == -1)
            {
                rEntity.CreateTime = DateTime.Now;
                _id = rDao.AddRoom(rEntity);
            }
            else {
                rEntity.Id = _id;
                rDao.UpdateRoom(rEntity);
            }
            
            if (txtPicLocation.Text.Trim() != "") {
                string newFileName = FileUtil.GetPicLocationById("room", _id, ext);
                if (File.Exists(newFileName)) {
                    File.Delete(newFileName);
                }
                File.Copy(txtPicLocation.Text, newFileName);
            }
            MessageBox.Show("保存成功！");
            this.Close();
        }

    }
}
