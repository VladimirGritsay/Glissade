using Glissade.Infrastructure.Database;
using Glissade.Infrastructure.Net;
using Glissade.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;



namespace Glissade.Api.Controllers.Api {
    [RoutePrefix("api/us")]
    public class ScreenHandlerController : ApiController {


        [HttpPost]
        [Route("uploadimage")]
        public IScreen UploadImage(ContentDTO contentDTO) {
            string base64Array = Convert.ToBase64String(contentDTO.Content);
            LinkGenerator linkGenerator = new LinkGenerator();
            string link = linkGenerator.GenerateLink();

            using (Repository repo = new Repository()) {
                IScreen screenDAO = repo.AddScreen(link, base64Array);  
                                                                        
                ScreenDTO screenDTO = new ScreenDTO() {                
                    Id = screenDAO.Id,                                
                    Link = screenDAO.Link,
                    Content = screenDAO.Content
                };

                return screenDTO;
            }
        }



        [Route("viewimage")]
        [HttpGet]
        public IScreen TakesId(string id) {
            string halfLink = "http://localhost:4200/viewimage/";
            string returnedScreen = $"{halfLink}{id}";
            using (Repository repo = new Repository()) {
                IScreen screenDAO = repo.GetScreenById(id);

                ScreenDTO screenDTO = new ScreenDTO() {
                    Id = screenDAO.Id,
                    Link = screenDAO.Link,
                    Content = screenDAO.Content
                };

                return screenDTO;
            }
        }
    }
}