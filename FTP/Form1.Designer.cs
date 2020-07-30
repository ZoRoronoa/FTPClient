namespace FTP
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.renameText = new System.Windows.Forms.TextBox();
            this.ButtonRename = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.ButtonEnterUp = new System.Windows.Forms.Button();
            this.localListBox = new System.Windows.Forms.ListBox();
            this.hostNameBox = new System.Windows.Forms.TextBox();
            this.ButtonUpload = new System.Windows.Forms.Button();
            this.fileList = new System.Windows.Forms.ListBox();
            this.ButtonDisconnect = new System.Windows.Forms.Button();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.ButtonDownload = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonBackUp = new System.Windows.Forms.Button();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.ButtonBuildNew = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ButtonBackDown = new System.Windows.Forms.Button();
            this.ButtonEnterDown = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.ButtonHome = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.imageListFileFolder = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(743, 497);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 23);
            this.label4.TabIndex = 44;
            this.label4.Text = "修改文件名为：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(646, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 23);
            this.label3.TabIndex = 43;
            this.label3.Text = "密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(337, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 23);
            this.label2.TabIndex = 42;
            this.label2.Text = "用户名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 23);
            this.label1.TabIndex = 41;
            this.label1.Text = "主机：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // renameText
            // 
            this.renameText.Font = new System.Drawing.Font("宋体", 12F);
            this.renameText.Location = new System.Drawing.Point(907, 494);
            this.renameText.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.renameText.Name = "renameText";
            this.renameText.Size = new System.Drawing.Size(218, 30);
            this.renameText.TabIndex = 40;
            // 
            // ButtonRename
            // 
            this.ButtonRename.Image = ((System.Drawing.Image)(resources.GetObject("ButtonRename.Image")));
            this.ButtonRename.Location = new System.Drawing.Point(1140, 488);
            this.ButtonRename.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ButtonRename.Name = "ButtonRename";
            this.ButtonRename.Size = new System.Drawing.Size(47, 39);
            this.ButtonRename.TabIndex = 39;
            this.ButtonRename.UseVisualStyleBackColor = true;
            this.ButtonRename.Click += new System.EventHandler(this.ButtonRename_Click);
            // 
            // pathBox
            // 
            this.pathBox.Enabled = false;
            this.pathBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathBox.Location = new System.Drawing.Point(147, 124);
            this.pathBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(321, 31);
            this.pathBox.TabIndex = 38;
            // 
            // ButtonEnterUp
            // 
            this.ButtonEnterUp.Image = ((System.Drawing.Image)(resources.GetObject("ButtonEnterUp.Image")));
            this.ButtonEnterUp.Location = new System.Drawing.Point(537, 443);
            this.ButtonEnterUp.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ButtonEnterUp.Name = "ButtonEnterUp";
            this.ButtonEnterUp.Size = new System.Drawing.Size(47, 39);
            this.ButtonEnterUp.TabIndex = 36;
            this.ButtonEnterUp.UseVisualStyleBackColor = true;
            this.ButtonEnterUp.Click += new System.EventHandler(this.ButtonEnterUp_Click);
            // 
            // localListBox
            // 
            this.localListBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localListBox.FormattingEnabled = true;
            this.localListBox.ItemHeight = 23;
            this.localListBox.Location = new System.Drawing.Point(24, 171);
            this.localListBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.localListBox.Name = "localListBox";
            this.localListBox.Size = new System.Drawing.Size(560, 257);
            this.localListBox.TabIndex = 35;
            // 
            // hostNameBox
            // 
            this.hostNameBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostNameBox.Location = new System.Drawing.Point(119, 82);
            this.hostNameBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.hostNameBox.Name = "hostNameBox";
            this.hostNameBox.Size = new System.Drawing.Size(188, 31);
            this.hostNameBox.TabIndex = 34;
            this.hostNameBox.Text = "127.0.0.1";
            // 
            // ButtonUpload
            // 
            this.ButtonUpload.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonUpload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ButtonUpload.Image = ((System.Drawing.Image)(resources.GetObject("ButtonUpload.Image")));
            this.ButtonUpload.Location = new System.Drawing.Point(537, 124);
            this.ButtonUpload.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ButtonUpload.Name = "ButtonUpload";
            this.ButtonUpload.Size = new System.Drawing.Size(47, 39);
            this.ButtonUpload.TabIndex = 33;
            this.ButtonUpload.UseVisualStyleBackColor = false;
            this.ButtonUpload.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // fileList
            // 
            this.fileList.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileList.FormattingEnabled = true;
            this.fileList.ItemHeight = 23;
            this.fileList.Location = new System.Drawing.Point(617, 171);
            this.fileList.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(570, 257);
            this.fileList.TabIndex = 29;
            this.fileList.SelectedIndexChanged += new System.EventHandler(this.fileList_SelectedIndexChanged);
            // 
            // ButtonDisconnect
            // 
            this.ButtonDisconnect.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDisconnect.Location = new System.Drawing.Point(1076, 69);
            this.ButtonDisconnect.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ButtonDisconnect.Name = "ButtonDisconnect";
            this.ButtonDisconnect.Size = new System.Drawing.Size(127, 39);
            this.ButtonDisconnect.TabIndex = 28;
            this.ButtonDisconnect.Text = "断开连接";
            this.ButtonDisconnect.UseVisualStyleBackColor = true;
            this.ButtonDisconnect.Click += new System.EventHandler(this.ButtonDisconnect_Click);
            // 
            // passwordBox
            // 
            this.passwordBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordBox.Location = new System.Drawing.Point(732, 74);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(191, 31);
            this.passwordBox.TabIndex = 27;
            // 
            // usernameBox
            // 
            this.usernameBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameBox.Location = new System.Drawing.Point(445, 79);
            this.usernameBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(191, 31);
            this.usernameBox.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 131);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 47;
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // ButtonDownload
            // 
            this.ButtonDownload.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDownload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ButtonDownload.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDownload.Image")));
            this.ButtonDownload.Location = new System.Drawing.Point(1076, 121);
            this.ButtonDownload.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ButtonDownload.Name = "ButtonDownload";
            this.ButtonDownload.Size = new System.Drawing.Size(49, 39);
            this.ButtonDownload.TabIndex = 48;
            this.ButtonDownload.UseVisualStyleBackColor = false;
            this.ButtonDownload.Click += new System.EventHandler(this.ButtonDownload_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDelete.Image")));
            this.ButtonDelete.Location = new System.Drawing.Point(1138, 124);
            this.ButtonDelete.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(49, 39);
            this.ButtonDelete.TabIndex = 49;
            this.ButtonDelete.UseVisualStyleBackColor = false;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonBackUp
            // 
            this.ButtonBackUp.Image = ((System.Drawing.Image)(resources.GetObject("ButtonBackUp.Image")));
            this.ButtonBackUp.Location = new System.Drawing.Point(469, 443);
            this.ButtonBackUp.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ButtonBackUp.Name = "ButtonBackUp";
            this.ButtonBackUp.Size = new System.Drawing.Size(47, 39);
            this.ButtonBackUp.TabIndex = 52;
            this.ButtonBackUp.UseVisualStyleBackColor = true;
            this.ButtonBackUp.Click += new System.EventHandler(this.ButtonBackUp_Click);
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonConnect.Location = new System.Drawing.Point(939, 71);
            this.ButtonConnect.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(127, 39);
            this.ButtonConnect.TabIndex = 53;
            this.ButtonConnect.Text = "连接服务器";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // ButtonBuildNew
            // 
            this.ButtonBuildNew.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonBuildNew.ForeColor = System.Drawing.Color.White;
            this.ButtonBuildNew.Image = ((System.Drawing.Image)(resources.GetObject("ButtonBuildNew.Image")));
            this.ButtonBuildNew.Location = new System.Drawing.Point(1019, 121);
            this.ButtonBuildNew.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ButtonBuildNew.Name = "ButtonBuildNew";
            this.ButtonBuildNew.Size = new System.Drawing.Size(47, 39);
            this.ButtonBuildNew.TabIndex = 54;
            this.ButtonBuildNew.UseVisualStyleBackColor = false;
            this.ButtonBuildNew.Click += new System.EventHandler(this.ButtonBuildNew_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 130);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 23);
            this.label6.TabIndex = 55;
            this.label6.Text = "本地文件";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(613, 131);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 23);
            this.label7.TabIndex = 56;
            this.label7.Text = "服务器文件：";
            // 
            // ButtonBackDown
            // 
            this.ButtonBackDown.Image = ((System.Drawing.Image)(resources.GetObject("ButtonBackDown.Image")));
            this.ButtonBackDown.Location = new System.Drawing.Point(1078, 437);
            this.ButtonBackDown.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ButtonBackDown.Name = "ButtonBackDown";
            this.ButtonBackDown.Size = new System.Drawing.Size(47, 39);
            this.ButtonBackDown.TabIndex = 59;
            this.ButtonBackDown.UseVisualStyleBackColor = true;
            this.ButtonBackDown.Click += new System.EventHandler(this.ButtonBackDown_Click);
            // 
            // ButtonEnterDown
            // 
            this.ButtonEnterDown.Image = ((System.Drawing.Image)(resources.GetObject("ButtonEnterDown.Image")));
            this.ButtonEnterDown.Location = new System.Drawing.Point(1140, 437);
            this.ButtonEnterDown.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ButtonEnterDown.Name = "ButtonEnterDown";
            this.ButtonEnterDown.Size = new System.Drawing.Size(47, 39);
            this.ButtonEnterDown.TabIndex = 61;
            this.ButtonEnterDown.UseVisualStyleBackColor = true;
            this.ButtonEnterDown.Click += new System.EventHandler(this.ButtonEnterDown_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(847, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 23);
            this.label8.TabIndex = 62;
            this.label8.Text = "Status";
            // 
            // ButtonHome
            // 
            this.ButtonHome.Image = ((System.Drawing.Image)(resources.GetObject("ButtonHome.Image")));
            this.ButtonHome.Location = new System.Drawing.Point(401, 443);
            this.ButtonHome.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ButtonHome.Name = "ButtonHome";
            this.ButtonHome.Size = new System.Drawing.Size(47, 39);
            this.ButtonHome.TabIndex = 37;
            this.ButtonHome.UseVisualStyleBackColor = true;
            this.ButtonHome.Click += new System.EventHandler(this.ButtonHome_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(626, 451);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 23);
            this.label9.TabIndex = 63;
            this.label9.Text = "-";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // imageListFileFolder
            // 
            this.imageListFileFolder.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFileFolder.ImageStream")));
            this.imageListFileFolder.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFileFolder.Images.SetKeyName(0, "fileicon-directory.png");
            this.imageListFileFolder.Images.SetKeyName(1, "fileicon-others.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1208, 609);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ButtonEnterDown);
            this.Controls.Add(this.ButtonBackDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ButtonBuildNew);
            this.Controls.Add(this.ButtonConnect);
            this.Controls.Add(this.ButtonBackUp);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonDownload);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.renameText);
            this.Controls.Add(this.ButtonRename);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.ButtonHome);
            this.Controls.Add(this.ButtonEnterUp);
            this.Controls.Add(this.localListBox);
            this.Controls.Add(this.hostNameBox);
            this.Controls.Add(this.ButtonUpload);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.ButtonDisconnect);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "FTP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox renameText;
        private System.Windows.Forms.Button ButtonRename;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Button ButtonEnterUp;
        private System.Windows.Forms.ListBox localListBox;
        private System.Windows.Forms.TextBox hostNameBox;
        private System.Windows.Forms.Button ButtonUpload;
        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.Button ButtonDisconnect;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label label5;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.Button ButtonDownload;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonBackUp;
        private System.Windows.Forms.Button ButtonConnect;
        private System.Windows.Forms.Button ButtonBuildNew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ButtonBackDown;
        private System.Windows.Forms.Button ButtonEnterDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ButtonHome;
        public  System.Windows.Forms.Label label9;
        private System.Windows.Forms.ImageList imageListFileFolder;
    }
}

