using SplitPDF.Interfaces;
using iTextSharp.text.pdf;


namespace SplitPDF.Models
{
    public class BaseDocument:IBaseDocument

    {
        //here define the functions


        public void SplitPDFs(int start, int end, string source, string output)
        {
            //read the uploaded pdf file
            var pdfReader = new PdfReader(source);
            try
            {
                pdfReader.SelectPages($"{start}-{end}");
                //using (var fs = new FileStream(output, FileMode.Create, FileAccess.Write))
                    using(var fs = new FileStream(output, FileMode.Create))
                {
                    PdfStamper stamper = null;
                    try
                    {
                        stamper = new PdfStamper(pdfReader, fs);
                    }
                    finally
                    {
                        stamper?.Close();
                    }

                }
            }
            finally
            {
                pdfReader.Close();
            }
            

        }
        public bool SearchPage(int page_num, string term, string path)
        {
            return false;
        }
     
    }
}
