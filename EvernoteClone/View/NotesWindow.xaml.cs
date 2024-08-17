using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;

namespace EvernoteClone.View;

/// <summary>
/// Interaction logic for NotesWindow.xaml
/// </summary>
public partial class NotesWindow : Window
{
    public NotesWindow()
    {
        InitializeComponent();

        IOrderedEnumerable<FontFamily> fontFamilies = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
        fontFamilyCombo.ItemsSource = fontFamilies;
        List<double> fontSizes = new List<double> { 8, 9, 10 , 11, 12, 14, 16, 28, 48, 72 };
        fontSizeCombo.ItemsSource = fontSizes;
    }

    private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
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

        var selectedFontFamily = selection.GetPropertyValue(Inline.FontFamilyProperty);
        fontFamilyCombo.SelectedValue = selectedFontFamily;

        var selectedFontSize = selection.GetPropertyValue(Inline.FontSizeProperty);
        fontSizeCombo.Text = selectedFontSize.ToString();
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

    private void fontFamilyCombo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (fontFamilyCombo.SelectedItem != null)
        {
            contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, fontFamilyCombo.SelectedValue);
        }
    }

    private void fontSizeCombo_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        if (fontFamilyCombo.SelectedItem != null)
        {
            contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, fontSizeCombo.Text);
        }
    }
}
