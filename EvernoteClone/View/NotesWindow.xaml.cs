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

    private void contentRichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
    {
        TextSelection selection = contentRichTextBox.Selection;
        var selectedWeigth = selection.GetPropertyValue(Inline.FontWeightProperty);
        boldButton.IsChecked = selectedWeigth.Equals(FontWeights.Bold);

        var selectedItalic = selection.GetPropertyValue(Inline.FontStyleProperty);
        italicButton.IsChecked = selectedItalic.Equals(FontStyles.Italic);

        var selectedDecoration = selection.GetPropertyValue(Inline.TextDecorationsProperty);
        underlineButton.IsChecked = selectedDecoration.Equals(TextDecorations.Underline);
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

    private void italicButton_Click(object sender, RoutedEventArgs e)
    {
        bool isButtonChecked = (sender as ToggleButton)?.IsChecked ?? false;
        if (isButtonChecked)
        {
            contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Italic);
        }
        else
        {
            contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal);
        }
    }

    private void underlineButton_Click(object sender, RoutedEventArgs e)
    {
        bool isButtonChecked = (sender as ToggleButton)?.IsChecked ?? false;
        if (isButtonChecked)
        {
            contentRichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
        }
        else
        {
            TextDecorationCollection textDecorations;
            (contentRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection)
                .TryRemove(TextDecorations.Underline, out textDecorations);
            contentRichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, textDecorations);
        }
    }
}
