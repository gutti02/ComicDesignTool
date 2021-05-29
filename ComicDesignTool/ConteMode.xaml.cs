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
        private class TextBox_CheckFinishEdit:Behavior<TextBox>
        {
            protected override void OnAttached()
            {
                base.OnAttached();
                this.AssociatedObject.KeyDown += OnPreviewKeyDown;
            }

            protected override void OnDetaching()
            {
                base.OnDetaching();
                this.AssociatedObject.KeyDown -= OnPreviewKeyDown;
            }

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
        }

        public ConteMode()
        {
            InitializeComponent();
        }

        private void AddScene_Click( object sender, RoutedEventArgs e )
        {
            var new_scene = new TextBox();
            {
                new_scene.BorderBrush = null;

                // 何も入力されなかったりスペースしか入力されなかったらこの要素は消す
                new_scene.LostKeyboardFocus += ( sender, e ) =>
                {
                    if( string.IsNullOrEmpty( new_scene.Text ) || string.IsNullOrWhiteSpace( new_scene.Text ) )
                    {
                        SceneList.Children.Remove( new_scene );
                    }
                };

                var behavior_collection = Interaction.GetBehaviors( new_scene );
                behavior_collection.Add( new TextBox_CheckFinishEdit() );
            }
            SceneList.Children.Add( new_scene );
            new_scene.Focus();
        }
    }
}
