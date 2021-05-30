using System.Windows.Controls;

namespace ComicDesignTool
{
    /// <summary>
    /// PlotMode.xaml の相互作用ロジック
    /// </summary>
    public partial class PlotMode:Page
    {
        //-----------------------------------------------------------------------------------------
        private MainWindow mMainWindow = null;
        //-----------------------------------------------------------------------------------------
        public PlotMode( MainWindow main_window )
        {
            mMainWindow = main_window;

            InitializeComponent();
        }
        //-----------------------------------------------------------------------------------------
    }
}
