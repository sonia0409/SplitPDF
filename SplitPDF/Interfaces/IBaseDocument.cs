namespace SplitPDF.Interfaces
{
    interface IBaseDocument
    {
        //method to spplit the docment based on the page numbers
        void SplitPDFs(int start, int end, string filePath, string destPath);

        //method to split the document based on the search Name
        bool SearchPage(int page_num, string term, string path);
    }
}
