using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextEditor
{
    public partial class frmmain : Form
    {
        public frmmain()
        {
            InitializeComponent();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            //Показываем диалог выбора файла
            openFileDialog1.ShowDialog();
            // Переменной fileName присваиваем имя открываемого файла
            string fileName = openFileDialog1.FileName;
            //Создаем поток fs и открываем файл для чтения.
            FileStream filestream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            //Проверяем,  открыт ли поток,  и если открыт, выполняем условие
            if (filestream != null)
            {
                //Создаем объект streamreader и связываем его с потоком filestream
                StreamReader streamreader = new StreamReader(filestream);
                //Считываем весь файл и записываем его в TextBox
                txtBox.Text = streamreader.ReadToEnd();
                //Закрываем поток.
                filestream.Close();
            }

        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            //Показываем диалог выбора файла
            saveFileDialog1.ShowDialog();
            // В качестве имени сохраняемого файла устанавливаем переменную fileName
            string fileName = saveFileDialog1.FileName;
            //Создаем поток fs и открываем файл для записи.
            FileStream filestream = File.Open(fileName, FileMode.Create, FileAccess.Write);
            //Проверяем,  открыт ли поток,  и если открыт, выполняем условие
            if (filestream != null)
            {
                //Создаем объект streamwriter и связываем его с потоком filestream
                StreamWriter streamwriter = new StreamWriter(filestream);
                //Записываем данные из TextBox в файл
                streamwriter.Write(txtBox.Text);
                //Переносим данные из потока в файл
                streamwriter.Flush();
                //Закрываем поток
                filestream.Close();
            }

        }
    }
}
