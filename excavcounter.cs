using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace WindowsFormsApp1
{
    public partial class excavcounter : Form
    {
        excav standart;
        short rows = 5;
        short columns = 2;
        int excavatorsNeeded = 0;
        public excavcounter(excav pass)
        {
            InitializeComponent();
            standart = pass;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            excavatorsNeeded = (int)Math.Ceiling(int.Parse(textBox1.Text) / standart.performanceExcav);
            textBox2.Text = excavatorsNeeded.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Document doc = word.Documents.Add();
            Paragraph titlecard = doc.Content.Paragraphs.Add();
            titlecard.Range.Text = $"Количество экскаваторов {standart.name} предоставлено в таблице 1.";
            titlecard.Range.InsertParagraphAfter();

            Paragraph tableName = doc.Content.Paragraphs.Add();
            tableName.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            tableName.Range.Font.Italic = 1;
            tableName.Range.Text = "Таблица 1";
            tableName.Range.InsertParagraphAfter();

            Table table = doc.Tables.Add(doc.Content.Paragraphs.Last.Range, rows, columns);
            table.Cell(1, 1).Range.Text = "Наименование показателя";
            table.Cell(1, 2).Range.Text = "Значение";

            table.Cell(2, 1).Range.Text = "Модель экскаватора";
            table.Cell(2, 2).Range.Text = $"{standart.name}";

            table.Cell(3, 1).Range.Text = "Производительность, тыс. м^3/год";
            table.Cell(3, 2).Range.Text = standart.performanceExcav.ToString();

            table.Cell(4, 1).Range.Text = "Объём работ, тыс. м^3";
            table.Cell(4, 2).Range.Text = $"{textBox1.Text}";

            table.Cell(5, 1).Range.Text = "Количество, шт";
            table.Cell(5, 2).Range.Text = excavatorsNeeded.ToString();

            try
            {
                doc.Save();
                doc.Close();
                word.Quit();
                textBox2.Text = excavatorsNeeded.ToString();
            }
            catch (System.Runtime.InteropServices.COMException) { }

            System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(word);
        }
    }
}
