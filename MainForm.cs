using Led.I18n;
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
        private const string EN = "英文";
        private const string ZHCHS = "简体中文";
        private const string ZHCHT = "繁体中文";

        private List<string> langList = new List<string>();

        private string _FolderName = string.Empty;
        private string _FileName = string.Empty;
        private object xmlObj = null;

        public MainForm()
        {
            InitializeComponent();

            langList.Add(EN);
            langList.Add(ZHCHS);
            langList.Add(ZHCHT);

            foreach (string item in langList)
            {
                cmb_SrcLang.Items.Add(item);
                cmb_TgtLang.Items.Add(item);
            }

            this.cmb_SrcLang.SelectedIndex = 0;
            this.cmb_TgtLang.SelectedIndex = 1;
            this.cmb_Translator.SelectedIndex = 1;
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
            if (nameTextDic == null) return;

            // 翻译
            //Translate(ref nameTextDic);

            // 将翻译好的内容保存到新的文件
            SaveResultToXml(nameTextDic);
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

            string[] results = file.Split('\\');
            this._FileName = results[results.Length - 1];
            this._FolderName = file.Replace(this._FileName, "");

            XmlDocument document = new XmlDocument();
            document.Load(file);

            nameTextHash = new Hashtable();

            foreach (XmlNode xmlNodeItem in document.ChildNodes)
            {
                ReadXmlNode(xmlNodeItem, out nameTextHash);
            }

            return nameTextHash;
        }

        private void Translate(ref Hashtable nameTextDic)
        {
            LanguageType fromLang = GetLanguageType(this.cmb_SrcLang.SelectedItem as string);
            LanguageType toLang = GetLanguageType(this.cmb_TgtLang.SelectedItem as string);


            string s = "text";
            Transalte(s, fromLang, toLang);
        }


        private LanguageType GetLanguageType(string languageName)
        {
            switch (languageName)
            {
                case EN:
                    return LanguageType.English;
                case ZHCHS:
                    return LanguageType.ChineseSimplified;
                case ZHCHT:
                    return LanguageType.ChineseTraditional;
                default:
                    return LanguageType.Empty;
            }
        }


        /// <summary> 
        /// 使用WebRequest获取Google翻译后的内容 
        /// </summary> 
        /// <param name="strTranslateString">需要翻译的内容</param> 
        /// <param name="strRequestLanguage">原文语种</param> 
        /// <param name="tgtLang">译文语种</param> 
        /// <returns></returns> 
        private string Transalte(string transStr, LanguageType srcLang, LanguageType tgtLang)
        {
            Led.DataCenter.IniManage.SetIniFilePath("Config.ini", true);
            string timeStr = Led.DataCenter.IniManage.GetValueFromFile("BASIC", "TIME");

            int time = 0;
            if (!string.IsNullOrEmpty(timeStr))
                time = int.Parse(timeStr);

            if (time >= 950)
                return string.Empty;
            //string serverUrl = "";
            string result = "";
            switch (this.cmb_Translator.SelectedItem as string)
            {
                case "bing":

                    result = BingTranslator.GetInstance().Translate(transStr, srcLang, tgtLang);

                    break;
                case "youdao":
                    break;

                case "baidu":
                    break;

                default:
                    break;
            }
            //WebRequest request = HttpWebRequest.Create(serverUrl);
            //request.Credentials = CredentialCache.DefaultCredentials;
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Stream dataStream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(dataStream);
            //string responseFromServer = reader.ReadToEnd();
            //reader.Close();
            //dataStream.Close();
            //response.Close();
            //time++;
            //Led.DataCenter.IniManage.SaveValueToFile("BASIC", "TIME", time.ToString());
            //return responseFromServer;

            return result;
        }

        public string MultiLanguageTranslate(string strTranslateString, string strRequestLanguage, string strResultLanguage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strTranslateString))
                {
                    //string result = GetGoogleTrans(strTranslateString, strRequestLanguage, strResultLanguage);

                    //TranslationData transtring = (TranslationData)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(TranslationData));
                    //if (transtring.errorCode == 0)
                    //    return "";
                    ////return transtring.responseData.translatedText;
                    //else
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

        private void SaveResultToXml(Hashtable resultText)
        {
            if (!this.chk_SameToSrc.Checked)
            {
                this._FolderName = this.txt_TargetFolder.Text;
            }

            string file = Path.Combine(this._FolderName, this._FileName);
            int index = 0;
            while (File.Exists(file))
            {
                string preFileName = string.Format("{0}{1}", this._FileName.Replace(".xml", ""), (index == 0 ? "" : index.ToString()));
                string nxtFileName = string.Format("{0}{1}", this._FileName.Replace(".xml", ""), index + 1);

                file = file.Replace(preFileName, nxtFileName);
                index++;
            }

            FileStream fileStream = File.Create(file);

            byte[] bytes = File.ReadAllBytes(this.txt_SrcFile.Text);

            fileStream.Write(bytes, 0, bytes.Length);

            fileStream.Close();
            fileStream.Dispose();


        }


        private void ReadAndSaveXml(string fileName, ref Hashtable resultText)
        {
            XmlDocument document = new XmlDocument();
            document.Load(fileName);

            foreach (XmlNode xmlNodeItem in document.ChildNodes)
            {
                UpdateXmlNode(xmlNodeItem, ref resultText);
            }
        }

        private void UpdateXmlNode(XmlNode xmlNode, ref Hashtable resultText)
        {

        }

        private void UpdateXmlText(XmlElement xmlElement, string value)
        {
            if (xmlElement == null) return;

            if (xmlElement.HasAttribute("Text"))
            {
                xmlElement.Attributes["Text"].Value = value;
            }
        }

        private void ReadXmlNode(XmlNode xmlNode, out Hashtable result)
        {
            result = new Hashtable();

            ReadSubXmlNode(xmlNode, ref result);
        }

        private void ReadSubXmlNode(XmlNode xmlNode, ref Hashtable result)
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

        private void MakeHashTable(XmlElement xmlElement, ref Hashtable result)
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

        private void btn_SwapChange_Click(object sender, EventArgs e)
        {
            int backupIndex = this.cmb_SrcLang.SelectedIndex;

            this.cmb_SrcLang.SelectedIndex = this.cmb_TgtLang.SelectedIndex;
            this.cmb_TgtLang.SelectedIndex = backupIndex;
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
