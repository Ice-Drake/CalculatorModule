using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DDay.iCal;

namespace MultiDesktop
{
    /// <summary>
    /// Interaction logic for JournalUserControl.xaml
    /// </summary>
    public partial class JournalUserControl : UserControl
    {
        public static CalendarManager CalendarController { private get; set; }

        public JournalBook JournalBook { get; private set; }
        private int index;
        
        public JournalUserControl(JournalBook journalBook)
        {
            InitializeComponent();
            JournalBook = journalBook;
            index = 0;

            openJournalEntry(index + 1);
        }

        public void saveJournalEntry()
        {
            if ((index + 1) >= JournalBook.getEntrySize()) // New Entry
            {
                IJournal newEntry = CalendarController.CalendarList[JournalBook.CalendarID].IICalendar.Create<Journal>();
                newEntry.Created = new iCalDateTime(DateLabel.Content.ToString());
                newEntry.Description = new TextRange(DescTextBox.Document.ContentStart, DescTextBox.Document.ContentEnd).Text;
                JournalBook.addEntry(newEntry);
            }
            else // Existing Entry
            {
                IJournal existingEntry = JournalBook.getEntry(index);
                existingEntry.Created = new iCalDateTime(DateLabel.Content.ToString());
                existingEntry.Description = new TextRange(DescTextBox.Document.ContentStart, DescTextBox.Document.ContentEnd).Text;
                JournalBook.save();
            }
        }

        public void removeJournalEntry()
        {
            if ((index + 1) >= JournalBook.getEntrySize()) // New Entry
            {
                DescTextBox.Document = new FlowDocument();
            }
            else // Existing Entry
            {
                JournalBook.removeEntry(index);
                if (index < JournalBook.getEntrySize())  // Existing Next Entry
                    openJournalEntry(index + 1);
                else // Blank Next Entry
                {
                    DateLabel.Content = DateTime.Today.ToShortDateString();
                    DescTextBox.Document = new FlowDocument();
                }
            }
        }

        private void openJournalEntry(int pageNum)
        {
            index = pageNum - 1;

            if (index < JournalBook.getEntrySize()) // Existing Entry
            {
                IJournal journal = JournalBook.getEntry(index);
                
                DateLabel.Content = journal.Created.Date.ToShortDateString();
                
                FlowDocument flowDoc = new FlowDocument();
                flowDoc.Blocks.Add(new Paragraph(new Run(journal.Description)));
                DescTextBox.Document = flowDoc;
            }
            else // Blank Entry
            {
                DateLabel.Content = DateTime.Today.ToShortDateString();
                DescTextBox.Document = new FlowDocument();
            }

            if (pageNum == 1)
                PrevButton.IsEnabled = false;
            else
                PrevButton.IsEnabled = true;

            PageNumField.Text = pageNum.ToString();

            if (pageNum <= JournalBook.getEntrySize())
                NextButton.IsEnabled = true;
            else
                NextButton.IsEnabled = false;
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            openJournalEntry(index);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            openJournalEntry(index + 2);
        }
    }
}
