using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ComicDesignTool
{
    /// <summary>
    /// ConteMode.xaml の相互作用ロジック
    /// </summary>
    public partial class ConteMode:Page
    {
        //-----------------------------------------------------------------------------------------
        private class TextBox_CheckFinishEdit:Behavior<TextBox>
        {
            //-----------------------------------------------------------------------------------------
            protected override void OnAttached()
            {
                base.OnAttached();
                this.AssociatedObject.KeyDown += OnPreviewKeyDown;
            }
            //-----------------------------------------------------------------------------------------
            protected override void OnDetaching()
            {
                base.OnDetaching();
                this.AssociatedObject.KeyDown -= OnPreviewKeyDown;
            }
            //-----------------------------------------------------------------------------------------
            private void OnPreviewKeyDown( object sender, KeyEventArgs e )
            {
                if( e.Key == Key.Enter )
                {
                    // エンターキーが押されたらFocusをはずして今までの入力を確定させる
                    var text_box = sender as TextBox;
                    if( text_box == null )
                    {
                        return;
                    }
                    Keyboard.ClearFocus();
                }
            }
            //-----------------------------------------------------------------------------------------
        }
        //-----------------------------------------------------------------------------------------
        private MainWindow mMainWindow = null;
        //-----------------------------------------------------------------------------------------
        public ConteMode( MainWindow main_window )
        {
            mMainWindow = main_window;

            InitializeComponent();
        }        
        //-----------------------------------------------------------------------------------------
        private void AddScene_Click( object sender, RoutedEventArgs e )
        {
            var new_scene = new AddCutTextBox();
            {
                new_scene.BorderBrush = null;

                // 何も入力されなかったりスペースしか入力されなかったらこの要素は消す
                new_scene.LostKeyboardFocus += ( sender, e ) =>
                {
                    if( string.IsNullOrEmpty( new_scene.Text ) || string.IsNullOrWhiteSpace( new_scene.Text ) )
                    {
                        SceneList.Children.Remove( new_scene );
                        return;
                    }

                    // 初回編集（つまり新規追加時）のみ新しいカットとして登録する
                    if( !new_scene.IsOneceChanged )
                    {
                        new_scene.AddCut = mMainWindow.addCut( "", "", "", new_scene.Text );
                        new_scene.OneceChange();
                    }
                    // 再編集時は情報更新
                    else
                    {
                        if( new_scene.AddCut == null )
                        {
                            throw new System.NullReferenceException( "CutがNullでした。Cutの追加に失敗してる？" );
                        }

                        mMainWindow.editCut( new_scene.AddCut, "", "", "", new_scene.Text );
                    }
                };

                // 再編集時にテキストを全選択する
                new_scene.GotFocus += ( sender, e ) =>
                {
                    var text_box = sender as TextBox;
                    if( text_box == null )
                    {
                        return;
                    }

                    if( text_box.IsFocused )
                    {
                        return;
                    }

                    text_box.Focus();
                    e.Handled = true;
                    text_box.SelectAll();
                };
                new_scene.PreviewMouseLeftButtonDown += ( sender, e ) =>
                {
                    var text_box = sender as TextBox;
                    if( text_box == null )
                    {
                        return;
                    }

                    if( text_box.IsFocused )
                    {
                        return;
                    }

                    text_box.Focus();
                    e.Handled = true;
                    text_box.SelectAll();
                };

                var behavior_collection = Interaction.GetBehaviors( new_scene );
                behavior_collection.Add( new TextBox_CheckFinishEdit() );
            }
            SceneList.Children.Add( new_scene );
            new_scene.Focus();
        }
        //-----------------------------------------------------------------------------------------
    }
}
