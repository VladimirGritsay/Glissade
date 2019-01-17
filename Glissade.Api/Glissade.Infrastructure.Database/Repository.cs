using Glissade.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glissade.Infrastructure.Database {
    public class Repository : IDisposable {
        private readonly Context db = new Context();

        public IScreen AddScreen(string link, string image) {
            ScreenDAO screen = new ScreenDAO();
            screen.Link = link;
            screen.Content = image;
            IScreen result = db.Screens.Add(screen);
            db.SaveChanges();

            return result;
        }

        public IScreen GetScreenById(string id) {
            ScreenDAO screenDao = new ScreenDAO();
            var allId = db.Screens;
            string link = "http://localhost:4200/viewimage/" + id;
            foreach (IScreen screen in allId) {
                if (screen.Link == link) {
                    screenDao.Id = screen.Id;
                    screenDao.Link = screen.Link;
                    screenDao.Content = screen.Content;
                }
            }
            return screenDao;
        }

        public void Dispose() {
            db.Dispose();
        }
    }
}
