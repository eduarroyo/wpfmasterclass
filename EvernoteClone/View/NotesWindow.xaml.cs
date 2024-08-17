using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;

namespace EvernoteClone.View;

/// <summary>
/// Interaction logic for NotesWindow.xaml
/// </summary>
public partial class NotesWindow : Window
{
    public NotesWindow()
    {
        InitializeComponent();
    }

    private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void SpeechButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void contentRichTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        TextRange tr = new(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd);
        int ammountOfCharacters = tr.Text.Length;
        statusTextBlock.Text = $"Document length: {ammountOfCharacters} characters";
    }

    private void boldButton_Click(object sender, RoutedEventArgs e)
    {
        bool isButtonChecked = (sender as ToggleButton)?.IsChecked ?? false;
        if (isButtonChecked)
        {
            contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
        }
        else
        {
            contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);
        }
    }

    private void contentRichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
    {
        var selectedWeigth = contentRichTextBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
        boldButton.IsChecked = selectedWeigth.Equals(FontWeights.Bold);
    }
}
