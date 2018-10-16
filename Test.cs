using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ProgramTest
    {
        static void Main(string[] args)
        {
            SpreadsheetGear.IWorkbook gear = SpreadsheetGear.Factory.GetWorkbook();
            SpreadsheetGear.IWorksheet worksheet = gear.Worksheets.Add();


            SpreadsheetGear.IWorksheetWindowInfo windowInfo = worksheet.WindowInfo;

            // Load some sample data.
            SpreadsheetGear.IRange dataRange = worksheet.Cells["A1:B6"];
            dataRange.Value = new string[,]
            {
                { "A", "$7,923"  },
                { "B", "$5,954"  },
                { "C", "$5,522"  },
                { "D", "$3,701"  },
                { "E", "$5,522"  },
                { "F", "$3,701"  }
            };


            SpreadsheetGear.Shapes.IShape shape = worksheet.Shapes.AddChart(0, 0, 100, 100);
            SpreadsheetGear.Charts.IChart chart = shape.Chart;

            chart.SetSourceData(dataRange, SpreadsheetGear.Charts.RowCol.Columns);

            chart.ChartType = SpreadsheetGear.Charts.ChartType.ColumnStacked;
            chart.ChartGroups[0].GapWidth = 50;
            chart.HasTitle = false;
            chart.HasLegend = false;
            chart.PlotVisibleOnly = true;
            chart.ChartArea.Font.Color = SpreadsheetGear.Color.FromArgb(178, 178, 178);

            chart.SeriesCollection[0].HasDataLabels = false;
            chart.SeriesCollection[0].HasLeaderLines = false;
             
            chart.SeriesCollection[0].MarkerStyle =SpreadsheetGear.Charts.MarkerStyle.Automatic;



             shape = worksheet.Shapes.AddChart(500, 500, 600, 600);
             chart = shape.Chart;


            chart.SetSourceData(dataRange, SpreadsheetGear.Charts.RowCol.Columns);

            chart.ChartType = SpreadsheetGear.Charts.ChartType.Pie;
            SpreadsheetGear.Charts.ISeries series = chart.SeriesCollection[0];


            series.XValues = dataRange;

            // Add series data labels and change to show percentage only.
            series.HasDataLabels = true;
            series.DataLabels.ShowPercentage = true;
            series.DataLabels.ShowValue = false;
            series.DataLabels.ShowCategoryName = false;


            worksheet.Cells["F3"].NumberFormat= @"_-* #,##0.00_-;-* #,##0.00_-;_-@_-";
            worksheet.Cells["F3"].Value = 3553654566.641;

            worksheet.Cells["F6"].Font.Color = SpreadsheetGear.Color.FromArgb(178,178,178);
            worksheet.Cells["F6"].Font.Name = "Webdings";
            worksheet.Cells["F6"].Value = "a";


            worksheet.Cells["F9"].Font.Color = SpreadsheetGear.Color.FromArgb(178, 178, 178);
            worksheet.Cells["F9"].Font.Name = "Webdings";
            worksheet.Cells["F9"].Value = "r";


            
            gear.SaveAs(@"D:\Excels.xls",SpreadsheetGear.FileFormat.OpenXMLWorkbook);

        }
    }
}
