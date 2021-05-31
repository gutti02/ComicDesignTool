using System.Collections.Generic;
using System.Windows;

namespace ComicDesignTool
{
    public enum LogLevel
    {
        Log = 0,
        Warning = 1,
        Error = 2
    };

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window
    {
        //-----------------------------------------------------------------------------------------
        public class EditiongCutArg
        {
            public string mThemeKey = "";
            public string mThemeOutLine = "";

            public string mContentOutLineKey = "";
            public string mContentOutLineOutLine = "";

            public string mSequenceKey = "";
            public string mSequenceOutLine = "";

            public string mSceneKey = "";
            public string mSceneOutLine = "";

            public int? mConteIndex;
            public int? mConteRange;

            public int? mNamePage;
            public int? mNameIndex;
        }
        //-----------------------------------------------------------------------------------------
        private const string cIndifineStr = "Indifine";
        //-----------------------------------------------------------------------------------------
        private IdeaInfoList mThemeList = null;             // テーマ
        private IdeaInfoList mContentOutLineList = null;    // 話の大まかな流れ（起承転結）
        private IdeaInfoList mSequenceList = null;          // シーケンス
        private IdeaInfoList mSceneList = null;             // シーン
        private List<Cut> mCutList = null;                  // カット

        private PlotMode mPlotMode = null;
        private ConteMode mConteMode = null;
        private NameMode mNameMode = null;
        private PageView mPageView = null;
        //-----------------------------------------------------------------------------------------
        public IdeaInfoList ThemeList { get { return mThemeList; } }
        public IdeaInfoList ContentOutLineList { get { return mContentOutLineList; } }
        public IdeaInfoList SequenceList { get { return mSequenceList; } }
        public IdeaInfoList SceneList { get { return mSceneList; } }
        public List<Cut> CutList { get { return mCutList; } }
        //-----------------------------------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
            init_();
        }
        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// 初期化
        /// </summary>
        private void init_()
        {
            mThemeList = new IdeaInfoList();
            mThemeList.Add( cIndifineStr, new IdeaInfo() );
            mContentOutLineList = new IdeaInfoList();
            mContentOutLineList.Add( cIndifineStr, new IdeaInfo() );
            mSequenceList = new IdeaInfoList();
            mSequenceList.Add( cIndifineStr, new IdeaInfo() );
            mSceneList = new IdeaInfoList();
            mSceneList.Add( cIndifineStr, new IdeaInfo() );
            mCutList = new List<Cut>();

            mPlotMode = new PlotMode( this );
            mConteMode = new ConteMode( this );
            mNameMode = new NameMode( this );
            mPageView = new PageView( this );

            if( mConteMode == null )
            {
                throw new System.NullReferenceException( "mConteModeがNull" );
            }
            Frame_Main.Navigate( mPlotMode );
        }
        //-----------------------------------------------------------------------------------------
        private void Button_PlotMode_Click( object sender, RoutedEventArgs e )
        {
            if(mPlotMode == null)
            {
                throw new System.NullReferenceException( "mPlotModeがNull" );
            }
            Frame_Main.Navigate( mPlotMode );
        }
        //-----------------------------------------------------------------------------------------
        private void Button_ConteMode_Click( object sender, RoutedEventArgs e )
        {
            if( mConteMode == null )
            {
                throw new System.NullReferenceException( "mConteModeがNull" );
            }
            Frame_Main.Navigate( mConteMode );
        }
        //-----------------------------------------------------------------------------------------
        private void Button_NameMode_Click( object sender, RoutedEventArgs e )
        {
            if( mNameMode == null )
            {
                throw new System.NullReferenceException( "mNameModeがNull" );
            }
            Frame_Main.Navigate( mNameMode );
        }
        //-----------------------------------------------------------------------------------------
        private void Button_PageView_Click( object sender, RoutedEventArgs e )
        {
            if( mPageView == null )
            {
                throw new System.NullReferenceException( "mPageViewがNull" );
            }
            Frame_Main.Navigate( mPageView );
        }
        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// カットの追加。
        /// ThemeやSceneなどないものが指定されていたら新しく追加してカットを追加する。
        /// </summary>
        /// <param name="arg"></param>
        /// <returns>追加したカット</returns>
        public Cut addCut( EditiongCutArg arg )
        {
            var new_cut = new Cut()
            {
                ConteIndex = arg.mConteIndex ?? -1,
                ConteRange = arg.mConteRange ?? 1,
                NamePage = arg.mNamePage ?? -1 ,
                NameIndex = arg.mNameIndex ?? -1
            };
            mCutList.Add( new_cut );
            var cut_list_index = mCutList.Count - 1;

            System.Action<string, IdeaInfoList> add_conte_list_info = ( key, list ) => {
                if( string.IsNullOrEmpty( key ) || string.IsNullOrWhiteSpace( key ) )
                {
                    list[cIndifineStr].AffiliationCutList.Add( cut_list_index );
                }
                else if( !list.ContainsKey( key ) )
                {
                    var cut_list = new IdeaInfo();
                    cut_list.AffiliationCutList.Add( cut_list_index ); // 一番最後の要素が追加したカット
                    list.Add( key, cut_list );
                }
                else
                {
                    list[key].AffiliationCutList.Add( cut_list_index );
                }
            };

            add_conte_list_info( arg.mThemeKey, mThemeList );
            add_conte_list_info( arg.mContentOutLineKey, mContentOutLineList );
            add_conte_list_info( arg.mSequenceKey, mSequenceList );
            add_conte_list_info( arg.mSceneKey, mSceneList );

            if( string.IsNullOrEmpty( arg.mThemeKey ) || string.IsNullOrWhiteSpace( arg.mThemeKey ) )
            {
                new_cut.ThemeKey = cIndifineStr;
            }
            else
            {
                new_cut.ThemeKey = arg.mThemeKey;
            }
            if( string.IsNullOrEmpty( arg.mContentOutLineKey ) || string.IsNullOrWhiteSpace( arg.mContentOutLineKey ) )
            {
                new_cut.ContentOutLineKey = cIndifineStr;
            }
            else
            {
                new_cut.ContentOutLineKey = arg.mContentOutLineKey;
            }
            if( string.IsNullOrEmpty( arg.mSequenceKey ) || string.IsNullOrWhiteSpace( arg.mSequenceKey ) )
            {
                new_cut.SequenceKey = cIndifineStr;
            }
            else
            {
                new_cut.SequenceKey = arg.mSequenceKey;
            }
            if( string.IsNullOrEmpty( arg.mSceneKey ) || string.IsNullOrWhiteSpace( arg.mSceneKey ) )
            {
                new_cut.SceneKey = cIndifineStr;
            }
            else
            {
                new_cut.SceneKey = arg.mSceneKey;
            }

            return new_cut;
        }
        //-----------------------------------------------------------------------------------------
        public void editCut( Cut cut, EditiongCutArg arg )
        {
            var cut_list_index = mCutList.IndexOf( cut );
            if( cut_list_index < 0 )
            {
                throw new System.Exception( "指定されたCutがｍCutListから見つからなかった。" );
            }

            System.Func<string, IdeaInfoList, string, bool> edit_content_list_info = ( new_key, list, prev_key ) =>
            {
                // 新しいキーが指定されてなかったら特に何もしない
                if( !string.IsNullOrEmpty( new_key ) && !string.IsNullOrWhiteSpace( new_key ) )
                {
                    list.Remove( prev_key, cut_list_index );

                    if( list.ContainsKey( new_key ) )
                    {
                        list[new_key].AffiliationCutList.Add( cut_list_index );
                    }
                    else
                    {
                        var new_list = new IdeaInfo();
                        new_list.AffiliationCutList.Add( cut_list_index );
                        list.Add( new_key, new_list );
                    }
                    return true;
                }

                return false;
            };

            if( edit_content_list_info( arg.mThemeKey, mThemeList, cut.ThemeKey ) )
            {
                cut.ThemeKey = arg.mThemeKey;
            }
            if( edit_content_list_info( arg.mContentOutLineKey, mContentOutLineList, cut.ContentOutLineKey ) )
            {
                cut.ContentOutLineKey = arg.mContentOutLineKey;
            }
            if( edit_content_list_info( arg.mSequenceKey, mSequenceList, cut.SequenceKey ) )
            {
                cut.SequenceKey = arg.mSequenceKey;
            }
            if( edit_content_list_info( arg.mSceneKey, mSceneList, cut.SceneKey ) )
            {
                cut.SceneKey = arg.mSceneKey;
            }

            if( arg.mConteIndex.HasValue )
            {
                cut.ConteIndex = arg.mConteIndex.Value;
            }
            if( arg.mConteRange.HasValue )
            {
                cut.ConteRange = arg.mConteRange.Value;
            }
            if( arg.mNamePage.HasValue )
            {
                cut.NamePage = arg.mNamePage.Value;
            }
            if( arg.mNameIndex.HasValue )
            {
                cut.NameIndex = arg.mNameIndex.Value;
            }
        }
        public void editCut( int cut_index, EditiongCutArg arg )
        {
            if( cut_index < 0 || mCutList.Count <= cut_index )
            {
                throw new System.IndexOutOfRangeException( $"指定されたcut_index[ {cut_index} ]が負数かmCutListの要素より多いです。" );
            }

            var cut = mCutList[cut_index];
            editCut( cut, arg );
        }
        //-----------------------------------------------------------------------------------------
    }
}
