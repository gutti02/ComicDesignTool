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
        private List<string> mThemeList = null;             // テーマ
        private List<string> mContentOutLineList = null;    // 話の大まかな流れ（起承転結）
        private List<string> mSequenceList = null;          // シーケンス
        private List<string> mSceneList = null;             // シーン
        private List<Cut> mCutList = null;                  // カット

        private PlotMode mPlotMode = null;
        private ConteMode mConteMode = null;
        private NameMode mNameMode = null;
        private PageView mPageView = null;
        //-----------------------------------------------------------------------------------------
        public List<string> ThemeList { get { return mThemeList; } }
        public List<string> ContentOutLineList { get { return mContentOutLineList; } }
        public List<string> SequenceList { get { return mSequenceList; } }
        public List<string> SceneList { get { return mSceneList; } }
        public List<Cut> CutList { get { return mCutList; } }
        //-----------------------------------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
            Init_();
        }
        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// 初期化
        /// </summary>
        private void Init_()
        {
            mThemeList = new List<string>();
            mContentOutLineList = new List<string>();
            mSequenceList = new List<string>();
            mSceneList = new List<string>();
            mCutList = new List<Cut>();

            mPlotMode = new PlotMode();
            mConteMode = new ConteMode();
            mNameMode = new NameMode();
            mPageView = new PageView();

            Frame_Main.Navigate( mConteMode );
        }

        private void Button_PlotMode_Click( object sender, RoutedEventArgs e )
        {
            Frame_Main.Navigate( mPlotMode );
        }

        private void Button_ConteMode_Click( object sender, RoutedEventArgs e )
        {
            Frame_Main.Navigate( mConteMode );
        }

        private void Button_NameMode_Click( object sender, RoutedEventArgs e )
        {
            Frame_Main.Navigate( mNameMode );
        }

        private void Button_PageView_Click( object sender, RoutedEventArgs e )
        {
            Frame_Main.Navigate( mPageView );
        }
    }
}
