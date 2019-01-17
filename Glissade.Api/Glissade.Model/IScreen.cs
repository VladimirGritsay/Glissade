using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glissade.Model {
    public interface IScreen {
        int Id { get;  }
        string Link { get;  }
        string Content { get;  }
    }
}
