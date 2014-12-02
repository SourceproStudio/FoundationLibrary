using System;
using System.IO;
using System.Windows.Forms;

/*引用基础库资源处理命名空间。SourceProStudio.Practices.FoundationLibrary.Commons.dll*/
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources;

namespace SourcePro.Csharp.Examples
{
    public partial class ExampleForm : Form
    {
        public ExampleForm()
        {
            InitializeComponent();
        }

        #region Example Programs

        #region LoadLanguageResources
        /// <summary>
        /// 加载语言资源文件。
        /// </summary>
        /// <param name="culture">文化区域LCID。</param>
        private void LoadLanguageResources(int culture = 2052)
        {
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("{0}.resources", culture));
            ResourceReader<string> reader = new StringResourceReader(fileName);
            reader.Read();
            this.Text = reader.Resources["FormTitle"].Data;
            this.CtrlSimplifiedChineseButton.Text = reader.Resources["Button2052"].Data;
            this.CtrlEnglishButton.Text = reader.Resources["Button1033"].Data;
            this.CtrlExitApplicationButton.Text = reader.Resources["ButtonClose"].Data;
        }
        #endregion

        #region InitializeForm
        /// <summary>
        /// 初始化窗体。
        /// </summary>
        private void InitializeForm()
        {
            this.LoadLanguageResources(1033);
        }
        #endregion

        #region ResetForm
        /// <summary>
        /// 重置窗体。
        /// </summary>
        /// <param name="culture">文化区域标识。</param>
        private void ResetForm(int culture = 2052)
        {
            this.LoadLanguageResources(culture);
        }
        #endregion

        #endregion

        private void ExampleForm_Load(object sender, EventArgs e)
        {
            this.InitializeForm();
        }

        private void CtrlSimplifiedChineseButton_Click(object sender, EventArgs e)
        {
            this.ResetForm();
        }

        private void CtrlEnglishButton_Click(object sender, EventArgs e)
        {
            this.ResetForm(1033);
        }

        private void CtrlExitApplicationButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
