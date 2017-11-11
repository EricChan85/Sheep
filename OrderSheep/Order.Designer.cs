namespace OrderSheep
{
    partial class Order
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
            this.gvFoodList = new System.Windows.Forms.DataGridView();
            this.OId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvFoodList)).BeginInit();
            this.SuspendLayout();
            // 
            // gvFoodList
            // 
            this.gvFoodList.AllowUserToAddRows = false;
            this.gvFoodList.AllowUserToDeleteRows = false;
            this.gvFoodList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFoodList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OId,
            this.FoodName,
            this.Quality,
            this.Rate,
            this.Amount});
            this.gvFoodList.Location = new System.Drawing.Point(12, 42);
            this.gvFoodList.Name = "gvFoodList";
            this.gvFoodList.ReadOnly = true;
            this.gvFoodList.RowTemplate.Height = 23;
            this.gvFoodList.Size = new System.Drawing.Size(347, 617);
            this.gvFoodList.TabIndex = 1;
            this.gvFoodList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gvFoodList_CellPainting);
            // 
            // OId
            // 
            this.OId.DataPropertyName = "Id";
            this.OId.HeaderText = "OId";
            this.OId.Name = "OId";
            this.OId.ReadOnly = true;
            this.OId.Visible = false;
            // 
            // FoodName
            // 
            this.FoodName.DataPropertyName = "Name";
            this.FoodName.HeaderText = "餐名";
            this.FoodName.Name = "FoodName";
            this.FoodName.ReadOnly = true;
            // 
            // Quality
            // 
            this.Quality.DataPropertyName = "Quantity";
            this.Quality.HeaderText = "数量";
            this.Quality.MaxInputLength = 100;
            this.Quality.Name = "Quality";
            this.Quality.ReadOnly = true;
            this.Quality.Width = 60;
            // 
            // Rate
            // 
            this.Rate.DataPropertyName = "Price";
            this.Rate.HeaderText = "单价";
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            this.Rate.Width = 60;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "总金额";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 80;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(365, 13);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(830, 646);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(13, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(111, 12);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(150, 23);
            this.btnPay.TabIndex = 4;
            this.btnPay.Text = "结账";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(279, 13);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(58, 23);
            this.btnQuit.TabIndex = 5;
            this.btnQuit.Text = "放弃";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 671);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gvFoodList);
            this.Name = "Order";
            this.ShowIcon = false;
            this.Text = "点餐页面";
            this.Load += new System.EventHandler(this.Order_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvFoodList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvFoodList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn OId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FoodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quality;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}