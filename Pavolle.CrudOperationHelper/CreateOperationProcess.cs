using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pavolle.CrudOperationHelper
{
    public partial class CreateOperationProcess : Form
    {
        Thread thread;
        Thread writeThread;
        public CreateOperationProcess()
        {
            InitializeComponent();
            thread = new Thread(new ThreadStart(StartGenerating));
            thread.Start();
        }

        private void StartGenerating()
        {
            Output("Tablo verileri analiz ediliyor...");

            var table = TableManager.Instance.GetTable();

            if (table.Columns.Count == 0)
            {
                Output("Kolon eklenmediği için işleme devam edilemiyor!!!");
                return;
            }
            else
            {
                if(string.IsNullOrWhiteSpace(table.ProjectName))
                {
                    Output("Proje ismi girilmediği için işleme devam edilemiyor...");
                    return;
                }
                if (string.IsNullOrWhiteSpace(table.TableClassName))
                {
                    Output("Class ismi girilmediği için işleme devam edilemiyor...");
                    return;
                }
                if (string.IsNullOrWhiteSpace(table.TableDbName))
                {
                    Output("Tablo ismi girilmediği için işleme devam edilemiyor...");
                    return;
                }
                Output("Tablo sınıfı oluşturuluyor...");

                string classSinifi = "";
                classSinifi += "using DevExpress.Xpo;"+Environment.NewLine;
                classSinifi += "using " + table.ProjectName + ".Common.Enums;" + Environment.NewLine;
                classSinifi += "using System;" + Environment.NewLine;
                classSinifi += "using System.Collections.Generic;" + Environment.NewLine;
                classSinifi += "using System.Linq;" + Environment.NewLine;
                classSinifi += "using System.Text;" + Environment.NewLine;
                classSinifi += "using System.Threading.Tasks;" + Environment.NewLine;
                classSinifi += "" + Environment.NewLine;//Boşluk
                classSinifi += "namespace "+table.ProjectName+".DbModels.Entities" + Environment.NewLine;
                classSinifi += "{" + Environment.NewLine; ;
                classSinifi += "    [Persistent(\""+table.TableDbName+"\")]" + Environment.NewLine;
                classSinifi += "    public class "+table.TableClassName+" : BaseObject" + Environment.NewLine;
                classSinifi += "    {" + Environment.NewLine;
                classSinifi += "        public "+table.TableClassName+"(Session session) : base(session){}" + Environment.NewLine;

                classSinifi += "" + Environment.NewLine;
                foreach (var column in table.Columns)
                {
                    //TODO Bu kısım yazılacak.
                    classSinifi += "        [Persistent(\""+column.DbName+"\")]" + Environment.NewLine;
                    if (column.DataType == EDataType.STRING)
                    {
                        classSinifi += "        [Size("+column.Size+")]" + Environment.NewLine;
                    }
                    if (column.Index)
                    {
                        classSinifi += "        [Indexed(Unique = " + (column.UniqueIndex ? "true" : "false") + ", Name = \"index_" + table.TableDbName +"_"+ column.DbName + "\")]" + Environment.NewLine;
                    }
                    switch (column.DataType)
                    {
                        case EDataType.LONG:
                            classSinifi += "        public long"+ (column.Nullable?"?":"").ToString()+" " + column.Name + " { get; set; }" + Environment.NewLine;
                            break;
                        case EDataType.STRING:
                            classSinifi += "        public string "+column.Name+" { get; set; }" + Environment.NewLine;
                            break;
                        case EDataType.INT:
                            classSinifi += "        public int"+ (column.Nullable?"?":"").ToString()+" " + column.Name + " { get; set; }" + Environment.NewLine;
                            break;
                        case EDataType.FLOAT:
                            classSinifi += "        public float"+ (column.Nullable?"?":"").ToString()+" " + column.Name + " { get; set; }" + Environment.NewLine;
                            break;
                        case EDataType.DOUBLE:
                            classSinifi += "        public double"+ (column.Nullable?"?":"").ToString()+" " + column.Name + " { get; set; }" + Environment.NewLine;
                            break;
                        case EDataType.ENUM:
                            classSinifi += "        public "+column.EnumClass+ (column.Nullable ? "?" : "").ToString() + " " + column.Name + " { get; set; }" + Environment.NewLine;
                            break;
                        case EDataType.CLASS:
                            classSinifi += "        public "+column.TableClass+" " + column.Name + " { get; set; }" + Environment.NewLine;
                            break;
                        default:
                            break;
                    }

                    classSinifi += "" + Environment.NewLine;


                }

                classSinifi += "    }" + Environment.NewLine;
                classSinifi += "}" + Environment.NewLine;


            }
            Thread.Sleep(2000);
            Output("Tamamlandı!");
        }

        void Output(string message)
        {
            writeThread = new Thread(new ParameterizedThreadStart(WriteMessage));
            writeThread.Start(message);
        }

        private void WriteMessage(object state)
        {
            try
            {

                string message = (string)state;
                textBoxOutput.BeginInvoke((MethodInvoker)(() =>
                {
                    textBoxOutput.AppendText(message + Environment.NewLine);

                }));
            }
            catch (Exception)
            {

            }
        }

        private void CreateOperationProcess_Load(object sender, EventArgs e)
        {

        }
    }
}
