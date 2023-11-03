using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SplitPDF.Models;
using System.Web;
namespace SplitPDF.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHostEnvironment _environment;
        [BindProperty]
        public IFormFile UploadedFile { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }
        public void OnGet()
        {

        }
        public void Post()
        {
            var file = Request.Form["File"];
            string filePath = "";
            string destPath = "";
            string fileName = "";
            Splitter doc = new Splitter(filePath,fileName, destPath);

            var fileUpload = Request.Form["fileUpload"];
            Console.WriteLine(fileUpload);
        }
        public async Task OnPostAsync()
        {
            if (UploadedFile == null || UploadedFile.Length == 0)
            {
                return;
            }
            var fileName = UploadedFile.FileName;
            Console.WriteLine(fileName);

            string filePath = $@"{_environment.ContentRootPath}\temp\{UploadedFile.FileName}";
            string destPath = "";

            //string localfolder = ApplicationData.Current.LocalFolder.Path;
            string localfolder = System.Security.Principal.WindowsIdentity.GetCurrent().Name ;
            var array = localfolder.Split('\\');
            var username = array[1];
            destPath = @"C:\Users\" + username + @"\Downloads\";

            //add feature where user can select the start and last page of the document start_page-end_page
            int start_page = 0;
            int end_page= 0;    

            _logger.LogInformation($"Uploading {UploadedFile.FileName}.");
            string targetFileName = $"{_environment.ContentRootPath}/temp/{UploadedFile.FileName}";

            using (var stream = new FileStream(targetFileName, FileMode.Create))
            {

                await UploadedFile.CopyToAsync(stream);
            }
            Splitter doc = new Splitter(targetFileName, fileName, destPath);

        }



    }
}
