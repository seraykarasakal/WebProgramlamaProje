using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
	internal interface IWriterService
	{
        void WriterAdd(Writer writer);
    }
}
