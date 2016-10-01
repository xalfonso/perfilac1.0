using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Perfilac.reportes;

namespace Perfilac.visual
{
    public partial class VisorDeInforme : Form
    {
        public VisorDeInforme(Object report,String selection)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.SelectionFormula = selection;

        }
    }
}