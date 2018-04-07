using DavesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DavesSales
{
    public class ModuleInterface: IModule
    {
        private Form _mainForm;

        public ModuleInterface()
        {
            _mainForm = new FormSales();
        }
        public string DisplayName => "Sales";
        public Form MainForm => _mainForm;
        public Type MainFormType => typeof(FormSales);
        public Image Image => Properties.Resources.newdocument32;
    }
}
