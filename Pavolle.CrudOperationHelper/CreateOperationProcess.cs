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
        string manuelEklenecek = "";
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
                if(string.IsNullOrWhiteSpace(table.ProjectNameRoot))
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

                GenerateEntityClass(table);
                GenerateViewModels(table);


            }
            Thread.Sleep(2000);
            Output("Tamamlandı!");
        }

        private void GenerateViewModels(Table table)
        {
            //TODO List ve lookup yoksa aslında oluşturmamıza gerek yok.
            #region Criteria

            Output("*****************************");
            Output(table.TableClassName + "Criteria oluşturuluyor...");
            string criteria = "";
            criteria += "using "+ table.ProjectNameRoot + ".Common.Enums;" + Environment.NewLine;
            criteria += "using System;" + Environment.NewLine;
            criteria += "using System.Collections.Generic;" + Environment.NewLine;
            criteria += "using System.Linq;" + Environment.NewLine;
            criteria += "using System.Text;" + Environment.NewLine;
            criteria += "using System.Threading.Tasks;" + Environment.NewLine;
            criteria += "namespace "+table.ProjectNameRoot+".ViewModels.Criteria" + Environment.NewLine;
            criteria += "{" + Environment.NewLine;
            criteria += "    public class "+table.TableClassName+"Criteria : "+table.ProjectName+"CriteriaBase" + Environment.NewLine;
            criteria += "    {" + Environment.NewLine;
            foreach (var colum in table.Columns.Where(t=>t.AddToCriteria))
            {
                switch (colum.DataType)
                {
                    case EDataType.LONG:
                        criteria += "        public long? "+colum.Name+" { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.STRING:
                        criteria += "        public string " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.INT:
                        criteria += "        public int? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.FLOAT:
                        criteria += "        public float? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.DOUBLE:
                        criteria += "        public double? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.ENUM:
                        criteria += "        public "+colum.EnumClass+"? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.CLASS:
                        criteria += "        public long? " + colum.Name + "Oid { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.DATETIME:
                        criteria += "        public DateTime? StartOf" + colum.Name + " { get; set; }" + Environment.NewLine;
                        criteria += "" + Environment.NewLine;
                        criteria += "        public DateTime? EndOf" + colum.Name + "End { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.BOOL:
                        criteria += "        public bool? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    default:
                        break;
                }
                criteria += "" + Environment.NewLine;
            }
            criteria += "    }" + Environment.NewLine;
            criteria += "}" + Environment.NewLine;
            Output(criteria);
            Output("*****************************");
            Output("İlgili klasöre dosya yazılıyor...");
            #endregion

            //XCreateRequest
            string XCreateRequest = "";
            Output("*****************************");
            Output(table.TableClassName + "CreateRequest oluşturuluyor...");

            XCreateRequest += "using " + table.ProjectNameRoot + ".Common.Enums;" + Environment.NewLine;
            XCreateRequest += "using System;" + Environment.NewLine;
            XCreateRequest += "using System.Collections.Generic;" + Environment.NewLine;
            XCreateRequest += "using System.Linq;" + Environment.NewLine;
            XCreateRequest += "using System.Text;" + Environment.NewLine;
            XCreateRequest += "using System.Text;" + Environment.NewLine;
            XCreateRequest += "using System.Threading.Tasks;" + Environment.NewLine;
            XCreateRequest += "namespace " + table.ProjectNameRoot + ".ViewModels.Request" + Environment.NewLine;
            XCreateRequest += "{" + Environment.NewLine;
            XCreateRequest += "    public class "+table.TableClassName+"CreateRequest:"+table.ProjectName+"RequestBase" + Environment.NewLine;
            XCreateRequest += "    {" + Environment.NewLine;
            foreach (var colum in table.Columns.Where(t => t.Addable))
            {
                switch (colum.DataType)
                {
                    case EDataType.LONG:
                        XCreateRequest += "        public long? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.STRING:
                        XCreateRequest += "        public string " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.INT:
                        XCreateRequest += "        public int? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.FLOAT:
                        XCreateRequest += "        public float? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.DOUBLE:
                        XCreateRequest += "        public double? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.ENUM:
                        XCreateRequest += "        public " + colum.EnumClass + "? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.CLASS:
                        XCreateRequest += "        public long? " + colum.Name + "Oid { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.DATETIME:
                        XCreateRequest += "        public DateTime? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.BOOL:
                        XCreateRequest += "        public bool? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    default:
                        break;
                }
                XCreateRequest += "" + Environment.NewLine;
            }
            XCreateRequest += "    }" + Environment.NewLine;
            XCreateRequest += "}" + Environment.NewLine;

            Output(XCreateRequest);

            //XEditRequest
            string XEditRequest = "";
            Output("*****************************");
            Output(table.TableClassName + "EditRequest oluşturuluyor...");

            XEditRequest += "using " + table.ProjectNameRoot + ".Common.Enums;" + Environment.NewLine;
            XEditRequest += "using System;" + Environment.NewLine;
            XEditRequest += "using System.Collections.Generic;" + Environment.NewLine;
            XEditRequest += "using System.Linq;" + Environment.NewLine;
            XEditRequest += "using System.Text;" + Environment.NewLine;
            XEditRequest += "using System.Text;" + Environment.NewLine;
            XEditRequest += "using System.Threading.Tasks;" + Environment.NewLine;
            XEditRequest += "namespace " + table.ProjectNameRoot + ".ViewModels.Request" + Environment.NewLine;
            XEditRequest += "{" + Environment.NewLine;
            XEditRequest += "    public class " + table.TableClassName + "EditRequest:" + table.ProjectName + "RequestBase" + Environment.NewLine;
            XEditRequest += "    {" + Environment.NewLine;
            foreach (var colum in table.Columns.Where(t => t.Editable))
            {
                switch (colum.DataType)
                {
                    case EDataType.LONG:
                        XEditRequest += "        public long? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.STRING:
                        XEditRequest += "        public string " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.INT:
                        XEditRequest += "        public int? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.FLOAT:
                        XEditRequest += "        public float? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.DOUBLE:
                        XEditRequest += "        public double? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.ENUM:
                        XEditRequest += "        public " + colum.EnumClass + "? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.CLASS:
                        XEditRequest += "        public long? " + colum.Name + "Oid { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.DATETIME:
                        XEditRequest += "        public DateTime? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.BOOL:
                        XEditRequest += "        public bool? " + colum.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    default:
                        break;
                }
                XEditRequest += "" + Environment.NewLine;
            }
            XEditRequest += "    }" + Environment.NewLine;
            XEditRequest += "}" + Environment.NewLine;
            Output(XEditRequest);

            //XListResponse
            string XListResponse = "";
            Output("*****************************");
            Output(table.TableClassName + "ListResponse oluşturuluyor...");

            XListResponse += "using " + table.ProjectNameRoot + ".Common.Enums;" + Environment.NewLine;
            XListResponse += "using System;" + Environment.NewLine;
            XListResponse += "using System.Collections.Generic;" + Environment.NewLine;
            XListResponse += "using System.Linq;" + Environment.NewLine;
            XListResponse += "using System.Text;" + Environment.NewLine;
            XListResponse += "using System.Text;" + Environment.NewLine;
            XListResponse += "using System.Threading.Tasks;" + Environment.NewLine;
            XListResponse += "namespace " + table.ProjectNameRoot + ".ViewModels.Rsponse" + Environment.NewLine;
            XListResponse += "{" + Environment.NewLine;
            XListResponse += "    public class " + table.TableClassName + "ListResponse:" + table.ProjectName + "ResponseBase" + Environment.NewLine;
            XListResponse += "    {" + Environment.NewLine;
            XListResponse += "        public List<" + table.TableClassName + "ViewData> DataList { get; set; }" + Environment.NewLine;
            XListResponse += "    }" + Environment.NewLine;
            XListResponse += "}" + Environment.NewLine;
            Output("");
            Output(XListResponse);
            //XViewData
            string XViewData = "";

            //XDetailResponse
            string XDetailResponse = "";
            //XDetailViewData
            string XDetailViewData = "";
        }

        void GenerateEntityClass(Table table)
        {
            Output("*****************************");
            Output("Entity class oluşturuluyor...");
            string classSinifi = "";
            classSinifi += "using DevExpress.Xpo;" + Environment.NewLine;
            classSinifi += "using " + table.ProjectNameRoot + ".Common.Enums;" + Environment.NewLine;
            classSinifi += "using System;" + Environment.NewLine;
            classSinifi += "using System.Collections.Generic;" + Environment.NewLine;
            classSinifi += "using System.Linq;" + Environment.NewLine;
            classSinifi += "using System.Text;" + Environment.NewLine;
            classSinifi += "using System.Threading.Tasks;" + Environment.NewLine;
            classSinifi += "" + Environment.NewLine;//Boşluk
            classSinifi += "namespace " + table.ProjectNameRoot + ".DbModels.Entities" + Environment.NewLine;
            classSinifi += "{" + Environment.NewLine; ;
            classSinifi += "    [Persistent(\"" + table.TableDbName + "\")]" + Environment.NewLine;
            classSinifi += "    public class " + table.TableClassName + " : BaseObject" + Environment.NewLine;
            classSinifi += "    {" + Environment.NewLine;
            classSinifi += "        public " + table.TableClassName + "(Session session) : base(session){}" + Environment.NewLine;

            classSinifi += "" + Environment.NewLine;
            foreach (var column in table.Columns)
            {
                //TODO Bu kısım yazılacak.
                classSinifi += "        [Persistent(\"" + column.DbName + "\")]" + Environment.NewLine;
                if (column.DataType == EDataType.STRING)
                {
                    classSinifi += "        [Size(" + column.Size + ")]" + Environment.NewLine;
                }
                if (column.Index)
                {
                    classSinifi += "        [Indexed(Unique = " + (column.UniqueIndex ? "true" : "false") + ", Name = \"index_" + table.TableDbName + "_" + column.DbName + "\")]" + Environment.NewLine;
                }
                switch (column.DataType)
                {
                    case EDataType.LONG:
                        classSinifi += "        public long" + (column.Nullable ? "?" : "").ToString() + " " + column.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.STRING:
                        classSinifi += "        public string " + column.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.INT:
                        classSinifi += "        public int" + (column.Nullable ? "?" : "").ToString() + " " + column.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.FLOAT:
                        classSinifi += "        public float" + (column.Nullable ? "?" : "").ToString() + " " + column.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.DOUBLE:
                        classSinifi += "        public double" + (column.Nullable ? "?" : "").ToString() + " " + column.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.BOOL:
                        classSinifi += "        public bool" + (column.Nullable ? "?" : "").ToString() + " " + column.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.DATETIME:
                        classSinifi += "        public DateTime" + (column.Nullable ? "?" : "").ToString() + " " + column.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.ENUM:
                        classSinifi += "        public " + column.EnumClass + (column.Nullable ? "?" : "").ToString() + " " + column.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.CLASS:
                        classSinifi += "        public " + column.TableClass + " " + column.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    default:
                        break;
                }

                classSinifi += "" + Environment.NewLine;


            }

            classSinifi += "    }" + Environment.NewLine;
            classSinifi += "}" + Environment.NewLine;

            Output("Entity class oluşturuldu!");
            Output("*****************************");
            Output("");
            Output(classSinifi);
            Output("");

            Output("Class ilgili klasore yazılıyor...");
            Output("Class ilgili klasore yazıldı.");


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
