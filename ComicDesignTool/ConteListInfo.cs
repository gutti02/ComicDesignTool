using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicDesignTool
{
    public class ConteListInfo
    {
        //-----------------------------------------------------------------------------------------
        private string mInfoName;
        private SortedSet<int> mCutList;
        //-----------------------------------------------------------------------------------------
        public string InfoName { get { return mInfoName; } set { mInfoName = value; } }
        public SortedSet<int> CutList { get { return mCutList; } set { mCutList = value; } }
        //-----------------------------------------------------------------------------------------
        public ConteListInfo( string info_name )
        {
            mInfoName = info_name;
        }
        //-----------------------------------------------------------------------------------------
    }
}
