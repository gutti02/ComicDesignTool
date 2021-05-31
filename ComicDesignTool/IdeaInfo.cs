using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicDesignTool
{
    //-----------------------------------------------------------------------------------------
    public class IdeaInfo
    {
        //-----------------------------------------------------------------------------------------
        private string mOutline = "";
        private List<int> mAffiliationCutList = null;
        //-----------------------------------------------------------------------------------------
        public string OutLine { get { return mOutline; } set { mOutline = value; } }
        public List<int> AffiliationCutList { get { return mAffiliationCutList; } set { mAffiliationCutList = value; } }
        //-----------------------------------------------------------------------------------------
        public IdeaInfo()
        {
            mAffiliationCutList = new List<int>();
        }
        //-----------------------------------------------------------------------------------------
    }
    //-----------------------------------------------------------------------------------------
    public class IdeaInfoList:Dictionary<string, IdeaInfo>
    {
        //-----------------------------------------------------------------------------------------
        public bool Remove( string key, int index )
        {
            var result = false;

            result = this[key].AffiliationCutList.Remove( index );
            if( this[key].AffiliationCutList.Count == 0 )
            {
                result = this.Remove( key );
            }

            return result;
        }
        //-----------------------------------------------------------------------------------------
    }
    //-----------------------------------------------------------------------------------------
}
