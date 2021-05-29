namespace ComicDesignTool
{
    public class Cut
    {
        //-----------------------------------------------------------------------------------------
        private int mTheme;             // テーマ
        private int mContentOutLine;    // 話の大まかな流れ（起承転結）
        private int mSequence;          // シーケンス
        private int mScene;             // シーン

        // コンテ用
        private int mConteIndex;   // 何番目か

        // ネーム用
        private int mNamePage;     // 何ページ目か
        private int mNameIndex;    // 何コマ目か

        // 絵
        // private __ mPicture_;         // 描いた絵の情報（ラスター情報）
        // private __ mPictureImage_;   // 描いた絵を画像化したもの（サムネとかアプリで実際に表示するのはこっち）
        //-----------------------------------------------------------------------------------------
        public int Theme { get { return mTheme; } set { mTheme = value; } }                             // テーマ
        public int ContentOutLine { get { return mContentOutLine; } set { mContentOutLine = value; } }  // 話の大まかな流れ（起承転結）
        public int Sequence { get { return mSequence; } set { mSequence = value; } }                    // シーケンス
        public int Scene { get { return mScene; } set { mScene = value; } }                             // シーン

        // コンテ用
        public int ConteIndex { get { return mConteIndex; } set { mConteIndex = value; } }    // 何番目か

        // ネーム用
        public int NamePage { get { return mNamePage; } set { mNamePage = value; } }      // 何ページ目か
        public int NameIndex { get { return mNameIndex; } set { mNameIndex = value; } }   // 何コマ目か

        // 絵
        //
        //-----------------------------------------------------------------------------------------
    }
}
