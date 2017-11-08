namespace OrderSheep
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabRoom = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSearchFood = new System.Windows.Forms.Button();
            this.btnDeleteFood = new System.Windows.Forms.Button();
            this.btnEditFood = new System.Windows.Forms.Button();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.gvFoodItems = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FICategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIRetailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gvRoom = new System.Windows.Forms.DataGridView();
            this.RId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnSearchRoom = new System.Windows.Forms.Button();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabRoom.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFoodItems)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRoom);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(863, 425);
            this.tabControl1.TabIndex = 0;
            // 
            // tabRoom
            // 
            this.tabRoom.Controls.Add(this.label1);
            this.tabRoom.Controls.Add(this.flowLayoutPanel1);
            this.tabRoom.Location = new System.Drawing.Point(4, 22);
            this.tabRoom.Name = "tabRoom";
            this.tabRoom.Padding = new System.Windows.Forms.Padding(3);
            this.tabRoom.Size = new System.Drawing.Size(855, 399);
            this.tabRoom.TabIndex = 3;
            this.tabRoom.Text = "房间";
            this.tabRoom.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "绿色表示空闲，红色表示使用中，蓝色表示不能使用";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 37);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(842, 356);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSearchFood);
            this.tabPage2.Controls.Add(this.btnDeleteFood);
            this.tabPage2.Controls.Add(this.btnEditFood);
            this.tabPage2.Controls.Add(this.btnAddFood);
            this.tabPage2.Controls.Add(this.gvFoodItems);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(855, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "菜单管理";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSearchFood
            // 
            this.btnSearchFood.Location = new System.Drawing.Point(27, 7);
            this.btnSearchFood.Name = "btnSearchFood";
            this.btnSearchFood.Size = new System.Drawing.Size(100, 25);
            this.btnSearchFood.TabIndex = 4;
            this.btnSearchFood.Text = "查询";
            this.btnSearchFood.UseVisualStyleBackColor = true;
            this.btnSearchFood.Click += new System.EventHandler(this.btnSearchFood_Click);
            // 
            // btnDeleteFood
            // 
            this.btnDeleteFood.Location = new System.Drawing.Point(386, 8);
            this.btnDeleteFood.Name = "btnDeleteFood";
            this.btnDeleteFood.Size = new System.Drawing.Size(100, 25);
            this.btnDeleteFood.TabIndex = 3;
            this.btnDeleteFood.Text = "删除";
            this.btnDeleteFood.UseVisualStyleBackColor = true;
            this.btnDeleteFood.Click += new System.EventHandler(this.btnDeleteFood_Click);
            // 
            // btnEditFood
            // 
            this.btnEditFood.Location = new System.Drawing.Point(267, 8);
            this.btnEditFood.Name = "btnEditFood";
            this.btnEditFood.Size = new System.Drawing.Size(100, 25);
            this.btnEditFood.TabIndex = 2;
            this.btnEditFood.Text = "修改";
            this.btnEditFood.UseVisualStyleBackColor = true;
            this.btnEditFood.Click += new System.EventHandler(this.btnEditFood_Click);
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(148, 7);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(100, 25);
            this.btnAddFood.TabIndex = 1;
            this.btnAddFood.Text = "新建";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // gvFoodItems
            // 
            this.gvFoodItems.AllowUserToAddRows = false;
            this.gvFoodItems.AllowUserToDeleteRows = false;
            this.gvFoodItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFoodItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.FIName,
            this.FIDescription,
            this.FICategory,
            this.FIRetailPrice});
            this.gvFoodItems.Location = new System.Drawing.Point(7, 39);
            this.gvFoodItems.Name = "gvFoodItems";
            this.gvFoodItems.ReadOnly = true;
            this.gvFoodItems.RowTemplate.Height = 23;
            this.gvFoodItems.Size = new System.Drawing.Size(842, 354);
            this.gvFoodItems.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // FIName
            // 
            this.FIName.DataPropertyName = "Name";
            this.FIName.HeaderText = "菜名";
            this.FIName.Name = "FIName";
            this.FIName.ReadOnly = true;
            this.FIName.Width = 160;
            // 
            // FIDescription
            // 
            this.FIDescription.DataPropertyName = "Description";
            this.FIDescription.HeaderText = "描述";
            this.FIDescription.Name = "FIDescription";
            this.FIDescription.ReadOnly = true;
            this.FIDescription.Width = 300;
            // 
            // FICategory
            // 
            this.FICategory.DataPropertyName = "Category";
            this.FICategory.HeaderText = "类型";
            this.FICategory.Name = "FICategory";
            this.FICategory.ReadOnly = true;
            this.FICategory.Width = 200;
            // 
            // FIRetailPrice
            // 
            this.FIRetailPrice.DataPropertyName = "RetailPrice";
            this.FIRetailPrice.HeaderText = "单价";
            this.FIRetailPrice.Name = "FIRetailPrice";
            this.FIRetailPrice.ReadOnly = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.gvRoom);
            this.tabPage4.Controls.Add(this.btnDelete);
            this.tabPage4.Controls.Add(this.btnModify);
            this.tabPage4.Controls.Add(this.btnSearchRoom);
            this.tabPage4.Controls.Add(this.btnAddRoom);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(855, 399);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "房间管理";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // gvRoom
            // 
            this.gvRoom.AllowUserToAddRows = false;
            this.gvRoom.AllowUserToDeleteRows = false;
            this.gvRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RId,
            this.RName,
            this.RDescription,
            this.RState});
            this.gvRoom.Location = new System.Drawing.Point(6, 36);
            this.gvRoom.Name = "gvRoom";
            this.gvRoom.RowTemplate.Height = 23;
            this.gvRoom.Size = new System.Drawing.Size(843, 357);
            this.gvRoom.TabIndex = 4;
            // 
            // RId
            // 
            this.RId.DataPropertyName = "Id";
            this.RId.HeaderText = "Id";
            this.RId.Name = "RId";
            this.RId.ReadOnly = true;
            this.RId.Visible = false;
            // 
            // RName
            // 
            this.RName.DataPropertyName = "RoomName";
            this.RName.HeaderText = "房间名";
            this.RName.Name = "RName";
            this.RName.ReadOnly = true;
            this.RName.Width = 150;
            // 
            // RDescription
            // 
            this.RDescription.DataPropertyName = "Description";
            this.RDescription.HeaderText = "详情";
            this.RDescription.Name = "RDescription";
            this.RDescription.ReadOnly = true;
            this.RDescription.Width = 200;
            // 
            // RState
            // 
            this.RState.DataPropertyName = "StateName";
            this.RState.HeaderText = "状态";
            this.RState.Name = "RState";
            this.RState.ReadOnly = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(307, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(215, 7);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 2;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnSearchRoom
            // 
            this.btnSearchRoom.Location = new System.Drawing.Point(25, 7);
            this.btnSearchRoom.Name = "btnSearchRoom";
            this.btnSearchRoom.Size = new System.Drawing.Size(75, 23);
            this.btnSearchRoom.TabIndex = 1;
            this.btnSearchRoom.Text = "查询";
            this.btnSearchRoom.UseVisualStyleBackColor = true;
            this.btnSearchRoom.Click += new System.EventHandler(this.btnSearchRoom_Click);
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Location = new System.Drawing.Point(118, 7);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(75, 23);
            this.btnAddRoom.TabIndex = 0;
            this.btnAddRoom.Text = "新增";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(855, 399);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "查看报表";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 449);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "点餐页面";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabRoom.ResumeLayout(false);
            this.tabRoom.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvFoodItems)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvRoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gvFoodItems;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabRoom;
        private System.Windows.Forms.Button btnDeleteFood;
        private System.Windows.Forms.Button btnEditFood;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.Button btnSearchFood;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button btnSearchRoom;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.DataGridView gvRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn FICategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIRetailPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn RId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn RState;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
    }
}

