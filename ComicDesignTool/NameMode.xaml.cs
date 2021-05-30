using System.Windows.Controls;

namespace ComicDesignTool
{
    /// <summary>
    /// NameMode.xaml の相互作用ロジック
    /// </summary>
    public partial class NameMode:Page
    {
        //-----------------------------------------------------------------------------------------
        private MainWindow mMainWindow = null;
        //-----------------------------------------------------------------------------------------
        public NameMode( MainWindow main_window )
        {
            mMainWindow = main_window;
            InitializeComponent();
        }
        //-----------------------------------------------------------------------------------------
    }
}
