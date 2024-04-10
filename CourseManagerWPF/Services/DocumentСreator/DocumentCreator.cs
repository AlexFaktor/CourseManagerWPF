using CourseManagerDatabase.Entity;
using Xceed.Words.NET;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace CourseManagerWPF.Services.DocumentСreator
{
    public class DocumentCreator
    {
        public static void CreateStudentTableDocx(List<StudentRecord> students, string courseName, string groupName, string filePath)
        {
            using var doc = DocX.Create(filePath);
            doc.SetDefaultFont(new Xceed.Document.NET.Font("Times New Roman"));

            doc.InsertParagraph(courseName).Bold().FontSize(16).Alignment = Xceed.Document.NET.Alignment.center;
            doc.InsertParagraph(groupName).FontSize(14).Alignment = Xceed.Document.NET.Alignment.center;

            var table = doc.AddTable(students.Count + 1, 3);

            table.Rows[0].Cells[0].Paragraphs.First().Append("Name").Bold();
            table.Rows[0].Cells[1].Paragraphs.First().Append("Surname").Bold();
            table.Rows[0].Cells[2].Paragraphs.First().Append("Patronymic").Bold();

            for (int i = 0; i < students.Count; i++)
            {
                table.Rows[i + 1].Cells[0].Paragraphs.First().Append(students[i].Name);
                table.Rows[i + 1].Cells[1].Paragraphs.First().Append(students[i].Surname);
                table.Rows[i + 1].Cells[2].Paragraphs.First().Append(students[i].Patronymic);
            }

            doc.InsertTable(table);

            doc.Save();
        }

        

public static void CreateStudentTablePdf(List<StudentRecord> students, string courseName, string groupName, string filePath)
    {
        using (PdfDocument document = new PdfDocument())
        {
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Arial", 12);

            XRect courseRect = new XRect(10, 10, page.Width.Point - 20, 50);
            gfx.DrawRectangle(XBrushes.Transparent, courseRect);
            gfx.DrawString(courseName, font, XBrushes.Black, courseRect, XStringFormats.Center);

            XRect groupRect = new XRect(10, 70, page.Width.Point - 20, 30);
            gfx.DrawRectangle(XBrushes.Transparent, groupRect);
            gfx.DrawString(groupName, font, XBrushes.Black, groupRect, XStringFormats.Center);

            XRect tableRect = new XRect(10, 110, page.Width.Point - 20, page.Height.Point - 120);
            DrawTable(gfx, font, tableRect, students);

            document.Save(filePath);
        }
    }

    private static void DrawTable(XGraphics gfx, XFont font, XRect rect, List<StudentRecord> students)
    {
        const int rows = 1 + 1; // Header row + data rows
        const int cols = 3;
        double rowHeight = rect.Height / rows;
        double colWidth = rect.Width / cols;

        XPen pen = new XPen(XColors.Black, 0.5);

        for (int i = 0; i <= rows; i++)
        {
            gfx.DrawLine(pen, rect.Left, rect.Top + i * rowHeight, rect.Right, rect.Top + i * rowHeight);
        }

        for (int i = 0; i <= cols; i++)
        {
            gfx.DrawLine(pen, rect.Left + i * colWidth, rect.Top, rect.Left + i * colWidth, rect.Bottom);
        }

        for (int i = 0; i < students.Count; i++)
        {
            var student = students[i];
            gfx.DrawString(student.Name, font, XBrushes.Black, new XRect(rect.Left, rect.Top + (i + 1) * rowHeight, colWidth, rowHeight), XStringFormats.Center);
            gfx.DrawString(student.Surname, font, XBrushes.Black, new XRect(rect.Left + colWidth, rect.Top + (i + 1) * rowHeight, colWidth, rowHeight), XStringFormats.Center);
            gfx.DrawString(student.Patronymic, font, XBrushes.Black, new XRect(rect.Left + 2 * colWidth, rect.Top + (i + 1) * rowHeight, colWidth, rowHeight), XStringFormats.Center);
        }
    }
}
}
