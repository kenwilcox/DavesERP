using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DavesInterfaces
{
    public interface IModule
    {
        string DisplayName { get; }
        Form MainForm { get; }
        Type MainFormType { get; }
        Image Image { get; }
    }
}
