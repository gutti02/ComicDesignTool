using System.Collections.Generic;
using System.Windows;

namespace ComicDesignTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window
    {
        //-----------------------------------------------------------------------------------------
        private const string cIndifineStr = "Indifine";
        //-----------------------------------------------------------------------------------------
        private Dictionary<string, List<int>> mThemeList = null;             // テーマ
        private Dictionary<string, List<int>> mContentOutLineList = null;    // 話の大まかな流れ（起承転結）
        private Dictionary<string, List<int>> mSequenceList = null;          // シーケンス
        private Dictionary<string, List<int>> mSceneList = null;             // シーン
        private List<Cut> mCutList = null;                  // カット

        private PlotMode mPlotMode = null;
        private ConteMode mConteMode = null;
        private NameMode mNameMode = null;
        private PageView mPageView = null;
        //-----------------------------------------------------------------------------------------
        public Dictionary<string, List<int>> ThemeList { get { return mThemeList; } }
        public Dictionary<string, List<int>> ContentOutLineList { get { return mContentOutLineList; } }
        public Dictionary<string, List<int>> SequenceList { get { return mSequenceList; } }
        public Dictionary<string, List<int>> SceneList { get { return mSceneList; } }
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
            mThemeList = new Dictionary<string, List<int>>();
            mThemeList.Add( cIndifineStr, new List<int>() );
            mContentOutLineList = new Dictionary<string, List<int>>();
            mContentOutLineList.Add( cIndifineStr, new List<int>() );
            mSequenceList = new Dictionary<string, List<int>>();
            mSequenceList.Add( cIndifineStr, new List<int>() );
            mSceneList = new Dictionary<string, List<int>>();
            mSceneList.Add( cIndifineStr, new List<int>() );
            mCutList = new List<Cut>();

            mPlotMode = new PlotMode( this );
            mConteMode = new ConteMode( this );
            mNameMode = new NameMode( this );
            mPageView = new PageView( this );

            if( mConteMode == null )
            {
                throw new System.NullReferenceException( "mConteModeがNull" );
            }
            Frame_Main.Navigate( mConteMode );
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
        /// <param name="theme_key"></param>
        /// <param name="content_outline_key"></param>
        /// <param name="sequence_key"></param>
        /// <param name="scene_key"></param>
        /// <param name="conte_index"></param>
        /// <param name="name_page"></param>
        /// <param name="name_page_index"></param>
        /// <returns>追加したCut</returns>
        public Cut addCut( 
            string theme_key = "",
            string content_outline_key = "",
            string sequence_key = "",
            string scene_key = "",
            int conte_index = -1,
            int name_page = -1,
            int name_page_index = -1
        )
        {
            var new_cut = new Cut();
            mCutList.Add( new_cut );
            var cut_list_index = mCutList.Count - 1;

            System.Action<string, Dictionary<string, List<int>>> add_conte_list_info = ( key, list ) => {
                if( string.IsNullOrEmpty( key ) || string.IsNullOrWhiteSpace( key ) )
                {
                    list[cIndifineStr].Add( cut_list_index );
                }
                else if( !list.ContainsKey( key ) )
                {
                    var cut_list = new List<int>();
                    cut_list.Add( cut_list_index ); // 一番最後の要素が追加したカット
                    list.Add( key, cut_list );
                }
                else
                {
                    list[key].Add( cut_list_index );
                }
            };

            add_conte_list_info( theme_key, mThemeList );
            add_conte_list_info( content_outline_key, mContentOutLineList );
            add_conte_list_info( sequence_key, mSequenceList );
            add_conte_list_info( scene_key, mSceneList );

            if( string.IsNullOrEmpty( theme_key ) || string.IsNullOrWhiteSpace( theme_key ) )
            {
                new_cut.ThemeKey = cIndifineStr;
            }
            else
            {
                new_cut.ThemeKey = theme_key;
            }
            if( string.IsNullOrEmpty( content_outline_key ) || string.IsNullOrWhiteSpace( content_outline_key ) )
            {
                new_cut.ContentOutLineKey = cIndifineStr;
            }
            else
            {
                new_cut.ContentOutLineKey = content_outline_key;
            }
            if( string.IsNullOrEmpty( sequence_key ) || string.IsNullOrWhiteSpace( sequence_key ) )
            {
                new_cut.SequenceKey = cIndifineStr;
            }
            else
            {
                new_cut.SequenceKey = sequence_key;
            }
            if( string.IsNullOrEmpty( scene_key ) || string.IsNullOrWhiteSpace( scene_key ) )
            {
                new_cut.SceneKey = cIndifineStr;
            }
            else
            {
                new_cut.SceneKey = scene_key;
            }

            return new_cut;
        }
        //-----------------------------------------------------------------------------------------
        public void editCut(
            Cut cut,
            string new_theme_key = "",
            string new_content_outline_key = "",
            string new_sequence_key = "",
            string new_scene_key = "",
            int new_conte_index = -1,
            int new_name_page = -1,
            int new_name_index = -1
        )
        {
            var cut_list_index = mCutList.IndexOf( cut );
            if( cut_list_index < 0 )
            {
                throw new System.Exception( "指定されたCutがｍCutListから見つからなかった。" );
            }

            System.Func<string, Dictionary<string, List<int>>, string, bool> edit_content_list_info = ( new_key, list, prev_key ) =>
            {
                // 新しいキーが指定されてなかったら特に何もしない
                if( !string.IsNullOrEmpty( new_key ) && !string.IsNullOrWhiteSpace( new_key ) )
                {   
                    list[prev_key].Remove( cut_list_index );
                    if( list[prev_key].Count == 0 )
                    {
                        list.Remove( prev_key );
                    }

                    if( list.ContainsKey( new_key ) )
                    {
                        list[new_key].Add( cut_list_index );
                    }
                    else
                    {
                        var new_list = new List<int>();
                        new_list.Add( cut_list_index );
                        list.Add( new_key, new_list );
                    }
                    return true;
                }

                return false;
            };

            if( edit_content_list_info( new_theme_key, mThemeList, cut.ThemeKey ) )
            {
                cut.ThemeKey = new_theme_key;
            }
            if( edit_content_list_info( new_content_outline_key, mContentOutLineList, cut.ContentOutLineKey ) )
            {
                cut.ContentOutLineKey = new_content_outline_key;
            }
            if( edit_content_list_info( new_sequence_key, mSequenceList, cut.SequenceKey ) )
            {
                cut.SequenceKey = new_sequence_key;
            }
            if( edit_content_list_info( new_scene_key, mSceneList, cut.SceneKey ) )
            {
                cut.SceneKey = new_scene_key;
            }

            if( 0 <= new_conte_index )
            {
                cut.ConteIndex = new_conte_index;
            }
            if( 0 <= new_name_page )
            {
                cut.NamePage = new_name_page;
            }
            if( 0 <= new_name_index )
            {
                cut.NameIndex = new_name_index;
            }
        }
        public void editCut(
            int cut_index,
            string new_theme_key = "",
            string new_content_outline_key = "",
            string new_sequence_key = "",
            string new_scene_key = "",
            int new_conte_index = -1,
            int new_name_page = -1,
            int new_name_index = -1
        )
        {
            if( cut_index < 0 || mCutList.Count <= cut_index )
            {
                throw new System.IndexOutOfRangeException( $"指定されたcut_index[ {cut_index} ]が負数かmCutListの要素より多いです。" );
            }

            var cut = mCutList[cut_index];
            editCut( cut, new_theme_key, new_content_outline_key, new_sequence_key, new_scene_key, new_conte_index, new_name_page, new_name_index );
        }
        //-----------------------------------------------------------------------------------------
    }
}
