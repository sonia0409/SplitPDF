using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;
using SplitPDF.Models;

namespace SplitPDF.Models
{
    public class Splitter :BaseDocument
    {
        //constructor
        public Splitter(string filePath, string filename, string destpath){

        
            //List<int> start_pages = new List<int>();
            int number_of_pages = 0;
            //check if filePath is not null
            if (filePath != null)
            {
                using(PdfReader reader = new PdfReader(filePath))
                {
                    number_of_pages = reader.NumberOfPages;
                    for(int page = 1 ; page <= number_of_pages; page++)
                    {
                        string text = " ";
                        text = PdfTextExtractor.GetTextFromPage(reader, page);
                        Console.WriteLine(text);
                        
                        SplitPDFs(page,page,filePath,destpath+ filename.Split(".")[0] + $"({ page})" + ".pdf" );
                    }
                }
                //delete file after splitting
                File.Delete(filePath);


            }


        }
    }
}
