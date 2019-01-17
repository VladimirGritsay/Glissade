using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Glissade.Model {
    public class LinkGenerator {
        private readonly string halfLink = "http://localhost:4200/";

        public string GenerateLink() {
            string link = $"{halfLink}viewimage/{Guid.NewGuid()}";
            return link;
        }
    }
}
