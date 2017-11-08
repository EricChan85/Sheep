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
    public partial class FoodItems : Form
    {
        FoodCategoryDao fcDao = new FoodCategoryDao();
        FoodItemDao fiDao = new FoodItemDao();
        
        int _id = -1;

        public FoodItems(int id)
        {
            InitializeComponent();
            _id = id;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FoodItems_Load(object sender, EventArgs e)
        {
            DataTable dtCategory = fcDao.GetAllFoodCategory();
            cbCategory.DataSource = dtCategory.DefaultView;
            cbCategory.DisplayMember = "CatName";
            cbCategory.ValueMember = "Id";
            cbCategory.SelectedIndex = 0;
            if (_id > 0)
            {
                FoodItemsEntity entity = fiDao.GetFoodItemsById(_id);
                txtName.Text = entity.Name;
                txtDescription.Text = entity.Description;
                cbCategory.SelectedIndex = entity.Category - 1;
                txtRetailPrice.Text = entity.RetailPrice.ToString();
                
                if (entity.PicExtension != "") {
                    string path = FileUtil.GetPicLocationById("food", entity.Id, entity.PicExtension);
                    txtPicLocation.Text = path;
                    pbPicture.Image = Image.FromFile(path);
                }
                
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
            FoodItemsEntity fiEntity = new FoodItemsEntity();            
            fiEntity.Name = txtName.Text;
            fiEntity.Description = txtDescription.Text;
            fiEntity.Category = cbCategory.SelectedIndex + 1;
            fiEntity.RetailPrice = float.Parse(txtRetailPrice.Text);
            fiEntity.PicExtension = ext;
            if (_id == -1)
            {
                fiEntity.CreateTime = DateTime.Now;
                _id = fiDao.AddFoodItems(fiEntity);
            }
            else {
                fiEntity.Id = _id;
                fiDao.UpdateFoodItems(fiEntity);
            }
            
            if (txtPicLocation.Text.Trim() != "") {
                string newFileName = FileUtil.GetPicLocationById("food", _id, ext);
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
