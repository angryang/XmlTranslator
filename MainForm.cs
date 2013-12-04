using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace XmlTranslate
{
    public partial class MainForm : Form
    {
        private Dictionary<string, string> langDic = new Dictionary<string, string>();

        private object xmlObj = null;

        public MainForm()
        {
            InitializeComponent();

            langDic.Add("英文", "en");
            langDic.Add("简体中文", "zh-CN");
            langDic.Add("繁体中文", "zh-TW");

            foreach (string item in langDic.Keys)
            {
                cmb_SrcLang.Items.Add(item);
                cmb_TgtLang.Items.Add(item);
            }
        }

        private void btn_SrcFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txt_SrcFile.Text = dialog.FileName;
            }
        }

        private void chk_SameToSrc_CheckedChanged(object sender, EventArgs e)
        {
            this.panel2.Enabled = !(sender as CheckBox).Checked;
        }

        private void btn_TargetFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderSel = new FolderBrowserDialog();
            if (folderSel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txt_TargetFolder.Text = folderSel.SelectedPath;
            }
        }

        private void btn_Translate_Click(object sender, EventArgs e)
        {
            // 从文件读取要翻译的字符
            Hashtable nameTextDic = ReadXml();
            Hashtable backupDic = nameTextDic;

            string s = "text";
            // 翻译
            Translate(ref s);

            // 将翻译好的内容保存到新的文件
            SaveResult();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private string XmlToJson()
        {
            return "";
        }

        private Hashtable ReadXml()
        {
            Hashtable nameTextHash = null;

            string file = this.txt_SrcFile.Text;
            if (!File.Exists(file)) return nameTextHash;

            XmlDocument document = new XmlDocument();
            document.Load(file);

            nameTextHash = new Hashtable();

            foreach (XmlNode xmlNodeItem in document.ChildNodes)
            {
                ReadXmlNode(xmlNodeItem, out nameTextHash);
            }

            return nameTextHash;
        }

        private void Translate(ref string nameTextDic)
        {
            string srcLang = this.langDic[this.cmb_SrcLang.SelectedItem as string];
            string tgtLang = this.langDic[this.cmb_TgtLang.SelectedItem as string];

            MultiLanguageTranslate(nameTextDic, srcLang, tgtLang);
        }


        /// <summary> 
        /// 使用WebRequest获取Google翻译后的内容 
        /// </summary> 
        /// <param name="strTranslateString">需要翻译的内容</param> 
        /// <param name="strRequestLanguage">原文语种</param> 
        /// <param name="tgtLang">译文语种</param> 
        /// <returns></returns> 

        private string GetGoogleTrans(string transStr, string srcLang, string tgtLang)
        {
            Led.DataCenter.IniManage.SetIniFilePath("Config.ini", true);
            string timeStr = Led.DataCenter.IniManage.GetValueFromFile("BASIC", "TIME");

            int time = 0;
            if (!string.IsNullOrEmpty(timeStr))
                time = int.Parse(timeStr);

            if (time >= 950)
                return string.Empty;
            string serverUrl = "";
            switch (this.comboBox1.SelectedItem as string)
            {
                case "bing":
                    serverUrl = @"";

                    break;
                case "youdao":
                    serverUrl = @"http://fanyi.youdao.com/openapi.do?keyfrom=Angryang666&key=1543796253&type=data&doctype=json&version=1.1&q=" + HttpUtility.UrlEncode(transStr);
                    break;

                default:
                    break;
            }
            WebRequest request = HttpWebRequest.Create(serverUrl);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            time++;
            Led.DataCenter.IniManage.SaveValueToFile("BASIC", "TIME", time.ToString());
            return responseFromServer;
        }

        public string MultiLanguageTranslate(string strTranslateString, string strRequestLanguage, string strResultLanguage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strTranslateString))
                {
                    string result = GetGoogleTrans(strTranslateString, strRequestLanguage, strResultLanguage);

                    TranslationData transtring = (TranslationData)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(TranslationData));
                    if (transtring.errorCode == 0)
                        return "";
                    //return transtring.responseData.translatedText;
                    else
                        return "There was an error.";
                }
                else
                {
                    return strTranslateString;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        private void SaveResult()
        {
            //throw new NotImplementedException();
        }

        private static void ReadXmlNode(XmlNode xmlNode, out Hashtable result)
        {
            result = new Hashtable();

            ReadSubXmlNode(xmlNode, ref result);
        }

        private static void ReadSubXmlNode(XmlNode xmlNode, ref Hashtable result)
        {
            if (xmlNode is XmlElement)
            {
                MakeHashTable(xmlNode as XmlElement, ref result);
            }

            if (xmlNode.HasChildNodes)
            {
                foreach (XmlNode xmlNodeItem in xmlNode.ChildNodes)
                {
                    ReadSubXmlNode(xmlNodeItem, ref result);
                }
            }
        }

        private static void MakeHashTable(XmlElement xmlElement, ref Hashtable result)
        {
            if (xmlElement.HasAttribute("Text"))
            {
                if (xmlElement.HasAttribute("Name"))
                {
                    result.Add(xmlElement.Attributes["Name"].Value, xmlElement.Attributes["Text"].Value);
                }
                else
                {
                    result.Add(xmlElement.Name, xmlElement.Attributes["Text"].Value);
                }
            }
        }
    }

    public class TranslationData
    {
        public int errorCode { get; set; }
        public string query { get; set; }
        public List<string> translation { get; set; }
        public TranslationBasic basic { get; set; }
        public List<TranslationWeb> web { get; set; }
    }
    public class TranslationBasic
    {
        public string phonetic { get; set; }
        public List<string> explains { get; set; }
    }
    public class TranslationWeb
    {
        public List<string> value { get; set; }
        public string key { get; set; }
    }
}
