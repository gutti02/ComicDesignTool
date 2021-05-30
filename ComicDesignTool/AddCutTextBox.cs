using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ComicDesignTool
{
    class AddCutTextBox: TextBox
    {
        //-----------------------------------------------------------------------------------------
        private bool mIsOnceChanged = false;
        private Cut mAddCut = null;
        //-----------------------------------------------------------------------------------------
        public bool IsOneceChanged { get { return mIsOnceChanged; } }
        public Cut AddCut { get { return mAddCut; } set { mAddCut = value; } }
        //-----------------------------------------------------------------------------------------
        public void OnceChange()
        {
            mIsOnceChanged = true;
        }
        //-----------------------------------------------------------------------------------------
    }
}
