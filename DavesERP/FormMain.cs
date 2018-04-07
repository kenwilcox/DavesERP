using DavesInterfaces;
using DavesSales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DavesERP
{
    public partial class FormMain : RibbonForm
    {
        private DavesSales.ModuleInterface _salesInterface = new DavesSales.ModuleInterface();

        public FormMain()
        {
            InitializeComponent();
        }
        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //}

        private void FormMain_Load(object sender, EventArgs e)
        {
            Theme.StandardThemeIsGlobal = false;
            Text += $@" v{Assembly.GetExecutingAssembly().GetName().Version}";

            var ribbonButton = new RibbonButton();
            ribbonButton.Name = _salesInterface.DisplayName;
            ribbonButton.Tag = _salesInterface;
            ribbonButton.LargeImage = _salesInterface.Image;
            ribbonButton.Text = "Button: " + _salesInterface.DisplayName;
            ribbonButton.Click += new EventHandler(RibbonButtonClick);

            var ribbonPanel = new RibbonPanel(_salesInterface.DisplayName);
            ribbonPanel.Items.Add(ribbonButton);

            var ribbonTab = new RibbonTab();
            ribbonTab.Text = _salesInterface.DisplayName;
            ribbonTab.Panels.Add(ribbonPanel);

            ribbon.Tabs.Add(ribbonTab);
            this.Controls.Add(ribbon);
        }

        private void RibbonButtonClick(object sender, EventArgs e)
        {
            if (sender is RibbonButton)
            {
                if (((RibbonButton)sender).Tag is IModule)
                {
                    var moduleInterface = (IModule)((RibbonButton)sender).Tag;

                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.GetType() == moduleInterface.MainFormType)
                        {
                            f.Activate();
                            return;
                        }
                    }
                    Form form = moduleInterface.MainForm;
                    //form.FormBorderStyle = FormBorderStyle.None;
                    form.WindowState = FormWindowState.Maximized;
                    form.ControlBox = false;
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }
    }
}
