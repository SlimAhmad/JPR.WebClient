using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.IO;
namespace JPR.WebClient
{
    public class FileUpload
    {


        public Stream Picture { get; set; }

        public string Base64Sdata { get; set; }

        [Required]
        [FileValidation(new[] { ".png", ".jpg" })]
        public IBrowserFile FileInfo { get; set; }
    }
}
