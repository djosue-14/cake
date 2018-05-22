using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Inmobiliaria.Reports
{
    public class CreateReport
    {
        public Stream StreamReport<T>(string path, T source)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(path);
            rd.SetDataSource(source);
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return stream;
        }
    }
}