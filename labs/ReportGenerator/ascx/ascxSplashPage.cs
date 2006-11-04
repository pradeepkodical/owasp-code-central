using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Security.Principal;
using System.Security;
using System.IO;
using System.Configuration;
using System.Xml;

namespace Owasp.VulnReport.ascx
{
	/// <summary>
	/// Summary description for ascxSplashPage.
	/// </summary>
	public class ascxSplashPage : System.Windows.Forms.UserControl
	{
		private WindowsIdentity wiCurrentWindowsIdentity;
		private WindowsPrincipal wpCurrentWindowsPrincipal; 
		private string strCurrentLoggedInUsername;
        private UserProfile up = UserProfile.GetUserProfile();

        #region Form Objects
        private System.Windows.Forms.PictureBox pbOwaspLogo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tcSplashPage;
		private System.Windows.Forms.TabPage tpUserConfiguration;
		private System.Windows.Forms.TabPage tcReleaseNotes;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbCurrentVersion;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button btStartPenTestReporter;
		private System.Windows.Forms.TextBox txtReleaseNotes;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbUserProfile;
		private System.Windows.Forms.ComboBox cbTempDirectory;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lbCurrentLoggedInUser;
		private System.Windows.Forms.Label lbCurrentUserIsAnAdministrator;
		private System.Windows.Forms.Label lbVulnReportTempReport_alert;
		private System.Windows.Forms.Label lbSelectBaseDirectory;
		private System.Windows.Forms.Label lbSelectTempDirectory;
		private System.Windows.Forms.Label lbSaveChangesAlert;
		private System.Windows.Forms.TabPage tbAppConfigFile;
		private ICSharpCode.TextEditor.TextEditorControl tedAppConfigFile;
		private System.Windows.Forms.ComboBox cbBaseDirectory;
		private System.Windows.Forms.Button btCreateProfile;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtNewProfileName;
        #endregion

        /// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ascxSplashPage()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

            if (!this.DesignMode)
            {
                up.ProfileFolder = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory,
                                                                 ConfigurationManager.AppSettings["pathToUserProfileDir"]));
            }
            
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(null != components )
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );	
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ascxSplashPage));
            this.pbOwaspLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tcSplashPage = new System.Windows.Forms.TabControl();
            this.tpUserConfiguration = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNewProfileName = new System.Windows.Forms.TextBox();
            this.btCreateProfile = new System.Windows.Forms.Button();
            this.cbTempDirectory = new System.Windows.Forms.ComboBox();
            this.cbBaseDirectory = new System.Windows.Forms.ComboBox();
            this.cbUserProfile = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSelectBaseDirectory = new System.Windows.Forms.Label();
            this.lbSelectTempDirectory = new System.Windows.Forms.Label();
            this.lbVulnReportTempReport_alert = new System.Windows.Forms.Label();
            this.tcReleaseNotes = new System.Windows.Forms.TabPage();
            this.txtReleaseNotes = new System.Windows.Forms.TextBox();
            this.tbAppConfigFile = new System.Windows.Forms.TabPage();
            this.tedAppConfigFile = new ICSharpCode.TextEditor.TextEditorControl();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCurrentVersion = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btStartPenTestReporter = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lbCurrentLoggedInUser = new System.Windows.Forms.Label();
            this.lbCurrentUserIsAnAdministrator = new System.Windows.Forms.Label();
            this.lbSaveChangesAlert = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbOwaspLogo)).BeginInit();
            this.tcSplashPage.SuspendLayout();
            this.tpUserConfiguration.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tcReleaseNotes.SuspendLayout();
            this.tbAppConfigFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbOwaspLogo
            // 
            this.pbOwaspLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbOwaspLogo.Image")));
            this.pbOwaspLogo.Location = new System.Drawing.Point(0, 0);
            this.pbOwaspLogo.Name = "pbOwaspLogo";
            this.pbOwaspLogo.Size = new System.Drawing.Size(325, 60);
            this.pbOwaspLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOwaspLogo.TabIndex = 0;
            this.pbOwaspLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(320, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 60);
            this.label1.TabIndex = 1;
            this.label1.Text = "PenTest Reporter";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tcSplashPage
            // 
            this.tcSplashPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcSplashPage.Controls.Add(this.tpUserConfiguration);
            this.tcSplashPage.Controls.Add(this.tcReleaseNotes);
            this.tcSplashPage.Controls.Add(this.tbAppConfigFile);
            this.tcSplashPage.Location = new System.Drawing.Point(8, 144);
            this.tcSplashPage.Name = "tcSplashPage";
            this.tcSplashPage.SelectedIndex = 0;
            this.tcSplashPage.Size = new System.Drawing.Size(632, 176);
            this.tcSplashPage.TabIndex = 2;
            // 
            // tpUserConfiguration
            // 
            this.tpUserConfiguration.Controls.Add(this.groupBox1);
            this.tpUserConfiguration.Controls.Add(this.cbTempDirectory);
            this.tpUserConfiguration.Controls.Add(this.cbBaseDirectory);
            this.tpUserConfiguration.Controls.Add(this.cbUserProfile);
            this.tpUserConfiguration.Controls.Add(this.label3);
            this.tpUserConfiguration.Controls.Add(this.lbSelectBaseDirectory);
            this.tpUserConfiguration.Controls.Add(this.lbSelectTempDirectory);
            this.tpUserConfiguration.Controls.Add(this.lbVulnReportTempReport_alert);
            this.tpUserConfiguration.Location = new System.Drawing.Point(4, 22);
            this.tpUserConfiguration.Name = "tpUserConfiguration";
            this.tpUserConfiguration.Size = new System.Drawing.Size(624, 150);
            this.tpUserConfiguration.TabIndex = 0;
            this.tpUserConfiguration.Text = "User Configuration";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNewProfileName);
            this.groupBox1.Controls.Add(this.btCreateProfile);
            this.groupBox1.Location = new System.Drawing.Point(496, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 96);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create New Profile";
            // 
            // txtNewProfileName
            // 
            this.txtNewProfileName.Location = new System.Drawing.Point(8, 24);
            this.txtNewProfileName.Name = "txtNewProfileName";
            this.txtNewProfileName.Size = new System.Drawing.Size(100, 20);
            this.txtNewProfileName.TabIndex = 6;
            // 
            // btCreateProfile
            // 
            this.btCreateProfile.Location = new System.Drawing.Point(8, 64);
            this.btCreateProfile.Name = "btCreateProfile";
            this.btCreateProfile.Size = new System.Drawing.Size(104, 24);
            this.btCreateProfile.TabIndex = 5;
            this.btCreateProfile.Text = "Create Profile ";
            this.btCreateProfile.Click += new System.EventHandler(this.btCreateProfileFor_Click);
            // 
            // cbTempDirectory
            // 
            this.cbTempDirectory.Location = new System.Drawing.Point(152, 88);
            this.cbTempDirectory.Name = "cbTempDirectory";
            this.cbTempDirectory.Size = new System.Drawing.Size(176, 21);
            this.cbTempDirectory.TabIndex = 6;
            this.cbTempDirectory.Visible = false;
            // 
            // cbBaseDirectory
            // 
            this.cbBaseDirectory.Location = new System.Drawing.Point(152, 56);
            this.cbBaseDirectory.Name = "cbBaseDirectory";
            this.cbBaseDirectory.Size = new System.Drawing.Size(176, 21);
            this.cbBaseDirectory.TabIndex = 6;
            this.cbBaseDirectory.Visible = false;
            // 
            // cbUserProfile
            // 
            this.cbUserProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserProfile.Location = new System.Drawing.Point(152, 24);
            this.cbUserProfile.Name = "cbUserProfile";
            this.cbUserProfile.Size = new System.Drawing.Size(176, 21);
            this.cbUserProfile.TabIndex = 0;
            this.cbUserProfile.SelectedIndexChanged += new System.EventHandler(this.cbUserProfile_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Select User Profile";
            // 
            // lbSelectBaseDirectory
            // 
            this.lbSelectBaseDirectory.Location = new System.Drawing.Point(8, 56);
            this.lbSelectBaseDirectory.Name = "lbSelectBaseDirectory";
            this.lbSelectBaseDirectory.Size = new System.Drawing.Size(160, 24);
            this.lbSelectBaseDirectory.TabIndex = 0;
            this.lbSelectBaseDirectory.Text = "Select Base Directory";
            this.lbSelectBaseDirectory.Visible = false;
            // 
            // lbSelectTempDirectory
            // 
            this.lbSelectTempDirectory.Location = new System.Drawing.Point(8, 88);
            this.lbSelectTempDirectory.Name = "lbSelectTempDirectory";
            this.lbSelectTempDirectory.Size = new System.Drawing.Size(160, 24);
            this.lbSelectTempDirectory.TabIndex = 0;
            this.lbSelectTempDirectory.Text = "Select Temp Directory";
            this.lbSelectTempDirectory.Visible = false;
            // 
            // lbVulnReportTempReport_alert
            // 
            this.lbVulnReportTempReport_alert.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVulnReportTempReport_alert.ForeColor = System.Drawing.Color.Black;
            this.lbVulnReportTempReport_alert.Location = new System.Drawing.Point(152, 120);
            this.lbVulnReportTempReport_alert.Name = "lbVulnReportTempReport_alert";
            this.lbVulnReportTempReport_alert.Size = new System.Drawing.Size(160, 24);
            this.lbVulnReportTempReport_alert.TabIndex = 1;
            this.lbVulnReportTempReport_alert.Text = "Note: all files will be placed in the \'_VulnReport_tempFiles\' folder";
            this.lbVulnReportTempReport_alert.Visible = false;
            // 
            // tcReleaseNotes
            // 
            this.tcReleaseNotes.Controls.Add(this.txtReleaseNotes);
            this.tcReleaseNotes.Location = new System.Drawing.Point(4, 22);
            this.tcReleaseNotes.Name = "tcReleaseNotes";
            this.tcReleaseNotes.Size = new System.Drawing.Size(624, 150);
            this.tcReleaseNotes.TabIndex = 1;
            this.tcReleaseNotes.Text = "Release Notes";
            // 
            // txtReleaseNotes
            // 
            this.txtReleaseNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReleaseNotes.Location = new System.Drawing.Point(8, 8);
            this.txtReleaseNotes.Multiline = true;
            this.txtReleaseNotes.Name = "txtReleaseNotes";
            this.txtReleaseNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReleaseNotes.Size = new System.Drawing.Size(608, 136);
            this.txtReleaseNotes.TabIndex = 0;
            // 
            // tbAppConfigFile
            // 
            this.tbAppConfigFile.Controls.Add(this.tedAppConfigFile);
            this.tbAppConfigFile.Location = new System.Drawing.Point(4, 22);
            this.tbAppConfigFile.Name = "tbAppConfigFile";
            this.tbAppConfigFile.Size = new System.Drawing.Size(624, 150);
            this.tbAppConfigFile.TabIndex = 2;
            this.tbAppConfigFile.Text = "App.Config File";
            // 
            // tedAppConfigFile
            // 
            this.tedAppConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tedAppConfigFile.LineViewerStyle = ICSharpCode.TextEditor.Document.LineViewerStyle.FullRow;
            this.tedAppConfigFile.Location = new System.Drawing.Point(8, 8);
            this.tedAppConfigFile.Name = "tedAppConfigFile";
            this.tedAppConfigFile.ShowEOLMarkers = true;
            this.tedAppConfigFile.ShowSpaces = true;
            this.tedAppConfigFile.ShowTabs = true;
            this.tedAppConfigFile.ShowVRuler = true;
            this.tedAppConfigFile.Size = new System.Drawing.Size(608, 136);
            this.tedAppConfigFile.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current Version:";
            // 
            // lbCurrentVersion
            // 
            this.lbCurrentVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentVersion.Location = new System.Drawing.Point(120, 72);
            this.lbCurrentVersion.Name = "lbCurrentVersion";
            this.lbCurrentVersion.Size = new System.Drawing.Size(326, 15);
            this.lbCurrentVersion.TabIndex = 4;
            this.lbCurrentVersion.Text = "...";
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(8, 336);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(152, 32);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Cancel";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btStartPenTestReporter
            // 
            this.btStartPenTestReporter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStartPenTestReporter.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btStartPenTestReporter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStartPenTestReporter.Location = new System.Drawing.Point(488, 336);
            this.btStartPenTestReporter.Name = "btStartPenTestReporter";
            this.btStartPenTestReporter.Size = new System.Drawing.Size(152, 32);
            this.btStartPenTestReporter.TabIndex = 1;
            this.btStartPenTestReporter.Text = "Start PenTest Reporter";
            this.btStartPenTestReporter.Click += new System.EventHandler(this.btStartPenTestReporter_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "You are logged in as:";
            // 
            // lbCurrentLoggedInUser
            // 
            this.lbCurrentLoggedInUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentLoggedInUser.Location = new System.Drawing.Point(120, 96);
            this.lbCurrentLoggedInUser.Name = "lbCurrentLoggedInUser";
            this.lbCurrentLoggedInUser.Size = new System.Drawing.Size(312, 15);
            this.lbCurrentLoggedInUser.TabIndex = 4;
            this.lbCurrentLoggedInUser.Text = "...";
            // 
            // lbCurrentUserIsAnAdministrator
            // 
            this.lbCurrentUserIsAnAdministrator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentUserIsAnAdministrator.ForeColor = System.Drawing.Color.Red;
            this.lbCurrentUserIsAnAdministrator.Location = new System.Drawing.Point(120, 112);
            this.lbCurrentUserIsAnAdministrator.Name = "lbCurrentUserIsAnAdministrator";
            this.lbCurrentUserIsAnAdministrator.Size = new System.Drawing.Size(384, 24);
            this.lbCurrentUserIsAnAdministrator.TabIndex = 4;
            this.lbCurrentUserIsAnAdministrator.Text = "This account is member of the BUILTIN\\Administrators security groups";
            this.lbCurrentUserIsAnAdministrator.Visible = false;
            // 
            // lbSaveChangesAlert
            // 
            this.lbSaveChangesAlert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSaveChangesAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSaveChangesAlert.ForeColor = System.Drawing.Color.Black;
            this.lbSaveChangesAlert.Location = new System.Drawing.Point(488, 376);
            this.lbSaveChangesAlert.Name = "lbSaveChangesAlert";
            this.lbSaveChangesAlert.Size = new System.Drawing.Size(152, 17);
            this.lbSaveChangesAlert.TabIndex = 1;
            this.lbSaveChangesAlert.Text = "Note: This will save your changes";
            // 
            // ascxSplashPage
            // 
            this.Controls.Add(this.lbCurrentVersion);
            this.Controls.Add(this.lbCurrentLoggedInUser);
            this.Controls.Add(this.lbCurrentUserIsAnAdministrator);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tcSplashPage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbOwaspLogo);
            this.Controls.Add(this.btStartPenTestReporter);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbSaveChangesAlert);
            this.Name = "ascxSplashPage";
            this.Size = new System.Drawing.Size(648, 408);
            this.Load += new System.EventHandler(this.ascxSplashPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbOwaspLogo)).EndInit();
            this.tcSplashPage.ResumeLayout(false);
            this.tpUserConfiguration.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tcReleaseNotes.ResumeLayout(false);
            this.tcReleaseNotes.PerformLayout();
            this.tbAppConfigFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void ascxSplashPage_Load(object sender, System.EventArgs e)
		{
            if (!this.DesignMode)
            {
                loadVersionInfoAndReleaseNotes();
                populateCurrentWindowsIdentityAndPrincipalVars();
                loadCurrentProfilesListBox();
                LoadAppConfigFile();
            }
		}

		public void byPassSplashPage()
		{
            up.CreateUserProfile("splashBypassed");
			saveSelectedUserProfileSettings();
		}

		private void loadVersionInfoAndReleaseNotes()
		{
            lbCurrentVersion.Text = ConfigurationManager.AppSettings["currentVersion"];
            txtReleaseNotes.Text = utils.files.GetFileContents(ConfigurationManager.AppSettings["releaseNotesFile"], false);
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
            // Check: I don't think we need to clean up the temp files since they are only created after this menu
			//GlobalVariables.deleteTempFilesAndTerminateProcess();
            GlobalVariables.terminateProcess();
		}

		private void btStartPenTestReporter_Click(object sender, System.EventArgs e)
		{
			saveSelectedUserProfileSettings();
		}

		private void btCreateProfileFor_Click(object sender, System.EventArgs e)
		{
            up.CreateUserProfile(txtNewProfileName.Text);
			enableAllUserProfileControls();
			loadCurrentProfilesListBox();
		}

		private void populateCurrentWindowsIdentityAndPrincipalVars()
		{
			wiCurrentWindowsIdentity = WindowsIdentity.GetCurrent();
			lbCurrentLoggedInUser.Text = wiCurrentWindowsIdentity.Name;
			strCurrentLoggedInUsername= lbCurrentLoggedInUser.Text.Replace(@"\","_");
			wpCurrentWindowsPrincipal = new WindowsPrincipal(wiCurrentWindowsIdentity);
			if (wpCurrentWindowsPrincipal.IsInRole(@"BUILTIN\Administrators"))
				lbCurrentUserIsAnAdministrator.Visible = true;
			txtNewProfileName.Text = strCurrentLoggedInUsername;
			if (cbUserProfile.Items.Count>0)
				cbUserProfile.SelectedIndex = 0;
		}

		private void cbUserProfile_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cbUserProfile.SelectedIndex > -1 && cbUserProfile.SelectedItem.ToString() != "")
			{
                up.LoadUserProfile(cbUserProfile.SelectedItem.ToString());
				enableAllUserProfileControls();
			}
		}
	
		private void enableAllUserProfileControls()
		{
            cbBaseDirectory.Text = up.BaseDirectory;
            cbTempDirectory.Text = up.TempDirectory;
			cbBaseDirectory.Visible = true;
			cbTempDirectory.Visible = true;			
			btStartPenTestReporter.Visible = true;
			lbVulnReportTempReport_alert.Visible = true;
			lbSelectBaseDirectory.Visible = true;
			lbSelectTempDirectory.Visible = true;
			lbSaveChangesAlert.Visible = true;
		}

		private void loadCurrentProfilesListBox()
		{
			utils.windowsForms.loadFilesIntoComboBox(cbUserProfile,up.ProfileFolder,"*.xml"); 
		}

		private void LoadAppConfigFile()
		{
			string strAppConfigFileName = Path.GetFileName(Application.ExecutablePath) + ".config";	
		    if (System.IO.File.Exists(strAppConfigFileName)) {
			    tedAppConfigFile.LoadFile(strAppConfigFileName );
            }

		}

		private void saveSelectedUserProfileSettings()
		{
            // Precondition: User profile is already loaded.
            up.BaseDirectory = cbBaseDirectory.Text;
            up.TempDirectory = cbTempDirectory.Text;
            up.Save();
		}
	}
}

