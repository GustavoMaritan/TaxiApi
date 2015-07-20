using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;

namespace TaxiApi.Controllers
{
    public class UploadController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> UploadFile(string id)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return Request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, "The request doesn't contain valid content!");
            }
            try
            {
                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach (var file in provider.Contents)
                {
                    
                    var dataStream = await file.ReadAsStreamAsync();
                    var uploadPath = AppDomain.CurrentDomain.BaseDirectory + @"\Comum\content\perfil\";
                    var caminhoArquivo = Path.Combine(uploadPath, Path.GetFileName(file.Headers.ContentDisposition.FileName.Replace("\"", string.Empty)));

                    using (var streamReader = new MemoryStream())
                    {
                        dataStream.CopyTo(streamReader);
                        var byteBuff = streamReader.ToArray();
                        File.WriteAllBytes(caminhoArquivo, byteBuff);
                    }
                }
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent("Successful upload", Encoding.UTF8, "text/plain");
                response.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue(@"text/html");
                return response;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}//C:\Projetos GitHub\TaxiApi\TaxiApi