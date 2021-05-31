namespace ComicDesignTool
{
    public class Cut
    {
        //-----------------------------------------------------------------------------------------
        private string mThemeKey;             // テーマ
        private string mContentOutLineKey;    // 話の大まかな流れ（起承転結）
        private string mSequenceKey;          // シーケンス
        private string mSceneKey;             // シーン

        // コンテ用
        private int mConteIndex;        // 何番目か
        private int mConteRange;    // コンテで使う列の長さ（最小1）

        // ネーム用
        private int mNamePage;     // 何ページ目か
        private int mNameIndex;    // 何コマ目か

        // 絵
        // private __ mPicture_;         // 描いた絵の情報（ラスター情報）
        // private __ mPictureImage_;   // 描いた絵を画像化したもの（サムネとかアプリで実際に表示するのはこっち）
        //-----------------------------------------------------------------------------------------
        public string ThemeKey { get { return mThemeKey; } set { mThemeKey = value; } }                             // テーマ
        public string ContentOutLineKey { get { return mContentOutLineKey; } set { mContentOutLineKey = value; } }  // 話の大まかな流れ（起承転結）
        public string SequenceKey { get { return mSequenceKey; } set { mSequenceKey = value; } }                    // シーケンス
        public string SceneKey { get { return mSceneKey; } set { mSceneKey = value; } }                             // シーン

        // コンテ用
        public int ConteIndex { get { return mConteIndex; } set { mConteIndex = value; } }    // 何番目か
        public int ConteRange   // コンテで使う列の長さ（最小1）
        {
            get { return mConteRange; }
            set
            {
                if( value < 1 )
                {
                    mConteRange = 1;
                    System.Diagnostics.Debugger.Log( ( int )LogLevel.Warning, "Warning", "ConteRangeに1以下を設定しようしました。1を強制的に設定します。" );
                }
                else
                {
                    mConteRange = value;
                }
            }
        }

        // ネーム用
        public int NamePage { get { return mNamePage; } set { mNamePage = value; } }      // 何ページ目か
        public int NameIndex { get { return mNameIndex; } set { mNameIndex = value; } }   // 何コマ目か

        // 絵
        //

        //-----------------------------------------------------------------------------------------
        public Cut()
        {
            mThemeKey = "";
            mContentOutLineKey = "";
            mSequenceKey = "";
            mSceneKey = "";

            mConteIndex = -1;
            mConteRange = 1;

            mNamePage = -1;
            mNameIndex = -1;
        }
        //-----------------------------------------------------------------------------------------
    }
}
