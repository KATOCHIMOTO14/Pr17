namespace MusicCollectionApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tracksListView = new System.Windows.Forms.ListView();
            this.columnHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAlbom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDateVipusk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addTrackButton = new System.Windows.Forms.Button();
            this.editTrackButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tracksListView
            // 
            this.tracksListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTitle,
            this.columnHeaderAuthor,
            this.columnHeaderAlbom,
            this.columnHeaderDateVipusk});
            this.tracksListView.HideSelection = false;
            this.tracksListView.Location = new System.Drawing.Point(29, 31);
            this.tracksListView.Name = "tracksListView";
            this.tracksListView.Size = new System.Drawing.Size(330, 191);
            this.tracksListView.TabIndex = 0;
            this.tracksListView.UseCompatibleStateImageBehavior = false;
            this.tracksListView.View = System.Windows.Forms.View.Details;
            this.tracksListView.DoubleClick += new System.EventHandler(this.tracksListView_DoubleClick_1);
            // 
            // columnHeaderTitle
            // 
            this.columnHeaderTitle.Text = "Название трека";
            this.columnHeaderTitle.Width = 98;
            // 
            // columnHeaderAuthor
            // 
            this.columnHeaderAuthor.Text = "Исполнитель";
            this.columnHeaderAuthor.Width = 83;
            // 
            // columnHeaderAlbom
            // 
            this.columnHeaderAlbom.Text = "Альбом";
            // 
            // columnHeaderDateVipusk
            // 
            this.columnHeaderDateVipusk.Text = "Год выпуска";
            this.columnHeaderDateVipusk.Width = 80;
            // 
            // addTrackButton
            // 
            this.addTrackButton.Location = new System.Drawing.Point(29, 250);
            this.addTrackButton.Name = "addTrackButton";
            this.addTrackButton.Size = new System.Drawing.Size(86, 43);
            this.addTrackButton.TabIndex = 1;
            this.addTrackButton.Text = "Добавить трек";
            this.addTrackButton.UseVisualStyleBackColor = true;
            this.addTrackButton.Click += new System.EventHandler(this.addTrackButton_Click_1);
            // 
            // editTrackButton
            // 
            this.editTrackButton.Location = new System.Drawing.Point(147, 250);
            this.editTrackButton.Name = "editTrackButton";
            this.editTrackButton.Size = new System.Drawing.Size(95, 43);
            this.editTrackButton.TabIndex = 2;
            this.editTrackButton.Text = "Редактировать трек";
            this.editTrackButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(271, 250);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(93, 43);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 313);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.editTrackButton);
            this.Controls.Add(this.addTrackButton);
            this.Controls.Add(this.tracksListView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView tracksListView;
        private System.Windows.Forms.ColumnHeader columnHeaderTitle;
        private System.Windows.Forms.ColumnHeader columnHeaderAuthor;
        private System.Windows.Forms.ColumnHeader columnHeaderAlbom;
        private System.Windows.Forms.ColumnHeader columnHeaderDateVipusk;
        private System.Windows.Forms.Button addTrackButton;
        private System.Windows.Forms.Button editTrackButton;
        private System.Windows.Forms.Button saveButton;
    }
}

