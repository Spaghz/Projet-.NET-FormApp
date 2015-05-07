using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormApp.Core.Shapes;
using System.Net;
using System.Windows.Forms;
using System.IO;

namespace FormApp.Core.DAO
{
    public class DAOFormMySQL : IDAOForm
    {
        private static DAOFormMySQL _instance;

        private string  _WEBSERVICE_Address;
        private string  _WEBSERVICE_SavePage;
        private string  _WEBSERVICE_LoadPage;
        private string  _WEBSERVICE_Method;

        /***********************************
         *  Constructor(s)
         ***********************************/
        private DAOFormMySQL(string webserviceAddress = @"http://127.0.0.1/formApp/", string webServiceLoadPage = "save.php",
            string webServiceSavePage = "load.php", string webServiceMethod = "POST")
        {
            _WEBSERVICE_Address     = webserviceAddress;
            _WEBSERVICE_SavePage    = webServiceLoadPage; 
            _WEBSERVICE_LoadPage    = webServiceSavePage;
            _WEBSERVICE_Method      = webServiceMethod;
        }

        /***********************************
         *  Method(s)
         ***********************************/
        public void Save(Shape f)
        {
            WebClient client = new WebClient();

            string response3 = client.UploadString(_WEBSERVICE_Address + @_WEBSERVICE_SavePage, "POST", "{"+f.ToJson()+"}");

            MessageBox.Show(response3);
        }

        public Shape Load(int id)
        {
            throw new NotImplementedException();
        }

        /***********************************
         *  Propertie(s)
         ***********************************/
        public static DAOFormMySQL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DAOFormMySQL();

                return _instance;
            }
        }

        public string WebServiceAddress
        {
            get { return _WEBSERVICE_Address; }
            set { _WEBSERVICE_Address = value; }
        }

        public string WebServiceSavePage
        {
            get { return _WEBSERVICE_SavePage; }
            set { _WEBSERVICE_SavePage = value; }
        }

        public string WebServiceLoadPage
        {
            get { return _WEBSERVICE_LoadPage; }
            set { _WEBSERVICE_LoadPage = value; }
        }

        public string WebServiceMethod
        {
            get { return _WEBSERVICE_Method; }
            set { _WEBSERVICE_Method = value; }
        }
    }
}
