using System.Windows.Controls;

namespace ComicDesignTool
{
    /// <summary>
    /// PageView.xaml の相互作用ロジック
    /// </summary>
    public partial class PageView:Page
    {
        //-----------------------------------------------------------------------------------------
        private MainWindow mMainWindow = null;
        //-----------------------------------------------------------------------------------------
        public PageView( MainWindow main_window )
        {
            mMainWindow = main_window;

            InitializeComponent();
        }
        //-----------------------------------------------------------------------------------------
    }
}
